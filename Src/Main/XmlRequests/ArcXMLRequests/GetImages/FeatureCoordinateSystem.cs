namespace USC.GISResearchLab.Common.XMLRequests.ArcXMLRequests
{
    public class FeatureCoordinateSystem
    {
        #region Properties
        public int CoordinateSystemCode { get; set; }
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
