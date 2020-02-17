namespace USC.GISResearchLab.Common.XMLRequests.ArcXMLRequests
{
    public class FilterCoordinateSystem
    {
        #region Properties
        public int CoordinateSystemCode { get; set; }
        #endregion


        public FilterCoordinateSystem(int coordinateSystemCode)
        {
            CoordinateSystemCode = coordinateSystemCode;
        }

        public override string ToString()
        {

            string ret = "";
            if (CoordinateSystemCode > 0)
            {
                ret += "<FILTERCOORDSYS id=\"" + CoordinateSystemCode + "\" />";
            }
            return ret;
        }
    }
}
