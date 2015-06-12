namespace USC.GISResearchLab.Common.XMLRequests.ArcXMLRequests
{
    public class ArcXMLGetImageRequest : ArcXMLRequest
    {
        #region Properties
        private GetImageProperties _GetImageProperties;
        public GetImageProperties GetImageProperties
        {
            get { return _GetImageProperties; }
            set { _GetImageProperties = value; }
        }
        #endregion

        public ArcXMLGetImageRequest(double minX, double minY, double maxX, double maxY, int filterCoordinateSystemId, string filterCoordinateSystemString, int featureCoordinateSystemId, string featureCoordinateSystemString, int width, int height)
        {
            GetImageProperties = new GetImageProperties(minX, minY, maxX, maxY, filterCoordinateSystemId, filterCoordinateSystemString, featureCoordinateSystemId, featureCoordinateSystemString, width, height);
        }

        public override string ToString()
        {
            string ret = "";
            ret += base.ToString();
            ret += "<ARCXML version= \"1.1\">";
            ret += "<REQUEST>";
            ret += "<GET_IMAGE>";
            ret += GetImageProperties.ToString();
            ret += "</GET_IMAGE>";
            ret += "</REQUEST>";
            ret += "</ARCXML>";
            return ret;
        }
    }
}
