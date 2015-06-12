namespace USC.GISResearchLab.Common.XMLRequests.ArcXMLRequests
{
    public class FeatureCoordinateSystem
    {
        #region Properties
        private int _CoordinateSystemCode;
        public int CoordinateSystemCode
        {
            get { return _CoordinateSystemCode; }
            set { _CoordinateSystemCode = value; }
        }
        #endregion


        public FeatureCoordinateSystem(int coordinateSystemCode)
        {
            CoordinateSystemCode = coordinateSystemCode;
        }

        public override string ToString()
        {
            string ret = "";
            if (CoordinateSystemCode > 0)
            {
                ret += "<FEATURECOORDSYS id=\"" + CoordinateSystemCode + "\" />";
            }
            return ret;
        }
    }
}
