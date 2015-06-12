namespace USC.GISResearchLab.Common.XMLRequests.ArcXMLRequests
{
    public class GetImageProperties
    {
        #region Properties
        private Envelope _Envelope;
        private FilterCoordinateSystem _FilterCoordinateSystem;
        private FeatureCoordinateSystem _FeatureCoordinateSystem;
        private ImageSize _ImageSize;

        public ImageSize ImageSize
        {
            get { return _ImageSize; }
            set { _ImageSize = value; }
        }


        public FeatureCoordinateSystem FeatureCoordinateSystem
        {
            get { return _FeatureCoordinateSystem; }
            set { _FeatureCoordinateSystem = value; }
        }


        public FilterCoordinateSystem FilterCoordinateSystem
        {
            get { return _FilterCoordinateSystem; }
            set { _FilterCoordinateSystem = value; }
        }



        public Envelope Envelope
        {
            get { return _Envelope; }
            set { _Envelope = value; }
        }
        #endregion

        public GetImageProperties(double minX, double minY, double maxX, double maxY, int filterCoordinateSystemId, string filterCoordinateSystemString, int featureCoordinateSystemId, string featureCoordinateSystemString, int width, int height)
        {
            Envelope = new Envelope(minX, minY, maxX, maxY);
            FilterCoordinateSystem = new FilterCoordinateSystem(filterCoordinateSystemId);
            FeatureCoordinateSystem = new FeatureCoordinateSystem(featureCoordinateSystemId);
            ImageSize = new ImageSize(width, height);
        }

        public override string ToString()
        {
            string ret = "";
            ret += "<PROPERTIES>";
            ret += Envelope;
            ret += FilterCoordinateSystem;
            ret += FeatureCoordinateSystem;
            ret += ImageSize;
            ret += "</PROPERTIES>";
            return ret;
        }
    }
}
