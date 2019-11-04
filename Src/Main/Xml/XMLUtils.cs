using System;
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace USC.GISResearchLab.Common.Utils.XML
{
    /// <summary>
    /// Summary description for XMLUtils.
    /// </summary>
    public class XMLUtils
    {
        public XMLUtils()
        {
        }

        public static string XmlDocumentAsString(XmlDocument doc)
        {
            string ret = null;
            try
            {
                StringWriter sw = new StringWriter();
                XmlTextWriter xw = new XmlTextWriter(sw);
                doc.WriteTo(xw);
                ret = sw.ToString();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred converting XmlDocument toString: " + e.Message, e);
            }
            return ret;
        }

        public static string XmlNodeAsString(XmlNode node)
        {
            string ret = null;
            try
            {
                StringWriter sw = new StringWriter();
                XmlTextWriter xw = new XmlTextWriter(sw);
                node.WriteTo(xw);
                ret = sw.ToString();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred converting XmlNodeAsString: " + e.Message, e);
            }
            return ret;
        }

        public static XmlDocument CreateXmlDocumentFromXmlString(string nodeXml)
        {
            XmlDocument ret = new XmlDocument();
            ret.LoadXml(nodeXml);
            return ret;
        }

        public static XmlDocument CreateXmlDocumentFromNode(XmlNode node)
        {
            XmlDocument ret = new XmlDocument();
            XmlNode newNode = ret.ImportNode(node, true);
            ret.DocumentElement.AppendChild(newNode);
            return ret;
        }

        public static XmlDocument appendChild(XmlDocument doc1, XmlDocument doc2)
        {
            XmlNode rootDest = doc1.DocumentElement;
            XmlNode nodeOrig = doc2.DocumentElement;

            XmlNode nodeDest = doc1.ImportNode(nodeOrig, true);

            rootDest.AppendChild(nodeDest);
            return doc1;
        }

        public static void appendChild(XmlNode root, XmlDocument doc2)
        {
            XmlNode nodeOrig = doc2.DocumentElement;
            XmlNode nodeDest = root.OwnerDocument.ImportNode(nodeOrig, true);

            root.AppendChild(nodeDest);
        }

        public static ArrayList getValues(XmlDocument doc, string xPath)
        {
            return getValues(doc, xPath, false);
        }

        public static ArrayList getValues(XmlDocument doc, string xPath, bool shouldThrowWarning)
        {
            ArrayList ret = new ArrayList();
            XmlNodeList nodeList = doc.SelectNodes(xPath);
            if (nodeList != null)
            {
                for (int i = 0; i < nodeList.Count; i++)
                {
                    XmlNode node = nodeList[i];
                    ret.Add(node.InnerXml);
                }
            }
            else
            {
                if (shouldThrowWarning)
                {
                    throw new Exception("Node Not Found in XML Document: " + xPath);
                }
            }
            return ret;
        }

        public static DateTime getValueAsDateTime(XmlDocument doc, string xPath)
        {
            DateTime ret = new DateTime();
            string value = getValueAsString(doc, xPath);
            if (value != null)
            {
                ret = DateTime.Parse(value);
            }
            return ret;
        }

        public static double getValueAsDouble(XmlDocument doc, string xPath)
        {
            double ret = 0.0;
            object value = getValue(doc, xPath, false);
            if (value != null)
            {
                ret = Convert.ToDouble(value);
            }
            return ret;
        }

        public static bool getValueAsBoolean(XmlDocument doc, string xPath)
        {
            bool ret = false;
            object value = getValue(doc, xPath, false);
            if (value != null)
            {
                ret = Convert.ToBoolean(value);
            }
            return ret;
        }

        public static string getValueAsString(XmlDocument doc, string xPath)
        {
            return getValueAsString(doc, xPath, false);
        }

        public static string getValueAsString(XmlDocument doc, string xPath, bool unescapeXML)
        {
            string ret = "";
            object value = getValue(doc, xPath, false, unescapeXML);
            if (value != null)
            {
                ret = Convert.ToString(value);
            }

            if (ret.IndexOf("&amp;") != -1)
            {
                ret = ret.Replace("&amp;", "&");
            }

            if (ret.IndexOf("&lt;") != -1)
            {
                ret = ret.Replace("&lt;", "<");
            }

            return ret;
        }

        public static int getValueAsInt(XmlDocument doc, string xPath)
        {
            int ret = 0;
            object value = getValue(doc, xPath, false);
            if (value != null)
            {
                ret = Convert.ToInt32(value);
            }
            return ret;
        }

        public static object getValue(XmlDocument doc, string xPath)
        {
            return getValue(doc, xPath, false, false);
        }

        public static object getValue(XmlDocument doc, string xPath, bool shouldDecode)
        {
            return getValue(doc, xPath, false, shouldDecode);
        }

        public static object getValue(XmlDocument doc, string xPath, bool shouldThrowWarning, bool shouldDecode)
        {
            object ret = null;
            XmlNode node = doc.SelectSingleNode(xPath);
            if (node != null)
            {
                if (!shouldDecode)
                {
                    ret = node.InnerXml;
                }
                else
                {
                    ret = node.InnerText;
                }
            }
            else
            {
                if (shouldThrowWarning)
                {
                    throw new Exception("Node Not Found in XML Document: " + xPath);
                }
            }
            return ret;
        }

        public static XmlDocument getDocumentFromNode(XmlNode selection)
        {
            XmlDocument ret = null;

            ret = new XmlDocument();
            XmlNode copiedSelection = ret.ImportNode(selection, true);
            ret.AppendChild(copiedSelection);

            return ret;
        }

        public static XmlDocument getDocumentFromNode(XmlDocument doc, string xPath)
        {
            XmlDocument ret = null;
            XmlNode selection = doc.SelectSingleNode(xPath);
            if (selection != null)
            {
                ret = new XmlDocument();
                XmlNode copiedSelection = ret.ImportNode(selection, true);
                ret.AppendChild(copiedSelection);

            }
            else
            {
                throw new Exception("Node Not Found in XML Document: " + xPath);
            }
            return ret;
        }

        public static ArrayList getValuesAsList(XmlDocument doc, string xPath)
        {
            ArrayList ret = new ArrayList();
            XmlNodeList nodes = doc.SelectNodes(xPath);
            if (nodes != null)
            {
                for (int i = 0; i < nodes.Count; i++)
                {
                    XmlNode node = nodes[i];
                    string val = node.InnerXml;
                    ret.Add(val);
                }
            }
            else
            {
                throw new Exception("NodeList Not Found in XML Document: " + xPath);
            }
            return ret;
        }

        public static double getAttributeDoubleValue(XmlNode node, string attributeName)
        {
            string val = node.Attributes.GetNamedItem(attributeName).Value;
            return Convert.ToDouble(val);
        }

        public static string getAttributeValue(XmlNode node, string attributeName)
        {
            String ret = node.Attributes.GetNamedItem(attributeName).Value;
            return ret;
        }

        public static XmlNodeList getNodeList(XmlDocument doc, string xPath)
        {
            XmlNodeList ret = doc.SelectNodes(xPath);
            return ret;
        }

        public static void createAndAppendElementWithValue(XmlElement root, string nodeName, int nodeValue)
        {
            createAndAppendElementWithValue(root, nodeName, Convert.ToString(nodeValue));
        }

        public static void createAndAppendElementWithValue(XmlElement root, string nodeName, bool nodeValue)
        {
            createAndAppendElementWithValue(root, nodeName, Convert.ToString(nodeValue));
        }

        public static void createAndAppendElementWithValue(XmlElement root, string nodeName, double nodeValue)
        {
            createAndAppendElementWithValue(root, nodeName, Convert.ToString(nodeValue));
        }

        public static void createAndAppendElementWithValue(XmlElement root, string nodeName, string nodeValue)
        {
            XmlElement newNode = root.OwnerDocument.CreateElement("", nodeName, "");
            if (nodeValue != null)
            {
                if (nodeValue.IndexOf("&") != -1)
                {
                    nodeValue = nodeValue.Replace("&", "&amp;");
                }

                if (nodeValue.IndexOf("<") != -1)
                {
                    nodeValue = nodeValue.Replace("<", "&lt;");
                }

                newNode.InnerXml = nodeValue;
            }
            else
            {
                newNode.InnerXml = "";
            }
            root.AppendChild(newNode);
        }

        public static string getGrandchildValue(XPathNavigator node, string childName, string grandchildName)
        {
            string ret = null;

            string childNodeName = null;
            string grandchildNodeName = null;
            string nodeName = node.LocalName;

            // check the first child
            node.MoveToFirstChild();
            childNodeName = node.LocalName;
            if (childNodeName.Equals(childName))
            {
                // check the first grandchild
                node.MoveToFirstChild();
                grandchildNodeName = node.LocalName;
                if (grandchildNodeName.Equals(grandchildName))
                {
                    ret = node.Value;
                    node.MoveToParent();
                }
                // go through all other grandchildren
                else
                {
                    while (node.MoveToNext())
                    {
                        grandchildNodeName = node.LocalName;
                        if (grandchildNodeName.Equals(grandchildName))
                        {
                            ret = node.Value;
                            node.MoveToParent();
                        }
                    }
                }
            }

            // go through all other children
            else
            {

                while (node.MoveToNext())
                {
                    childNodeName = node.LocalName;
                    if (childNodeName.Equals(childName))
                    {
                        // check the first grandchild
                        node.MoveToFirstChild();
                        grandchildNodeName = node.LocalName;
                        if (grandchildNodeName.Equals(grandchildName))
                        {
                            ret = node.Value;
                            node.MoveToParent();
                        }
                        // go through all other grandchildren
                        else
                        {
                            while (node.MoveToNext())
                            {
                                grandchildNodeName = node.LocalName;
                                if (grandchildNodeName.Equals(grandchildName))
                                {
                                    ret = node.Value;
                                    node.MoveToParent();
                                }
                            }
                        }
                    }
                }
            }

            node.MoveToParent();
            return ret;
        }
    }
}
