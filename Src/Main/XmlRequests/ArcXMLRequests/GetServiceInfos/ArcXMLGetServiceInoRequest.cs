namespace USC.GISResearchLab.Common.XMLRequests.ArcXMLRequests
{
    public class ArcXMLGetServiceInfoRequest : ArcXMLRequest
    {
        public override string ToString()
        {
            string ret = "";
            ret += base.ToString();
            ret += "<ARCXML version= \"1.1\">";
            ret += "<REQUEST>";
            ret += "<GET_SERVICE_INFO fields=\"false\" envelope=\"true\" renderer=\"false\" extensions=\"false\" />";
            ret += "</REQUEST>";
            ret += "</ARCXML>";
            return ret;
        }
    }
}
