namespace USC.GISResearchLab.Common.XMLRequests.ArcXMLRequests
{
    public class FilterCoordinateSystem
    {
        #region Properties
        private int _CoordinateSystemCode;
        public int CoordinateSystemCode
        {
            get { return _CoordinateSystemCode; }
            set { _CoordinateSystemCode = value; }
        }
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
