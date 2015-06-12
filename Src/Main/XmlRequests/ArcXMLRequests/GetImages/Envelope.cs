namespace USC.GISResearchLab.Common.XMLRequests.ArcXMLRequests
{
    public class Envelope
    {
        #region Properties
        private double _MinX;
        private double _MaxX;
        private double _MinY;
        private double _MaxY;

        public double MinX
        {
            get { return _MinX; }
            set { _MinX = value; }
        }

        public double MaxX
        {
            get { return _MaxX; }
            set { _MaxX = value; }
        }

        public double MinY
        {
            get { return _MinY; }
            set { _MinY = value; }
        }

        public double MaxY
        {
            get { return _MaxY; }
            set { _MaxY = value; }
        }
        #endregion


        public Envelope(double minX, double minY, double maxX, double maxY)
        {
            MinX = minX;
            MaxX = maxX;
            MinY = minY;
            MaxY = maxY;
        }

        public override string ToString()
        {
            string ret = "";
            if (MinX != 0 || MaxX != 0 || MinY != 0 || MaxY != 0)
            {
                ret += "<ENVELOPE ";
                ret += " minx= \"" + MinX + "\"";
                ret += " miny=\"" + MinY + "\"";
                ret += " maxx= \"" + MaxX + "\"";
                ret += " maxy=\"" + MaxY + "\" ";
                ret += " />";
            }
            return ret;
        }
    }
}
