namespace USC.GISResearchLab.Common.XMLRequests.ArcXMLRequests
{
    public class ImageSize
    {

        #region Properties
        private int _Width;
        private int _Height;

        public int Height
        {
            get { return _Height; }
            set { _Height = value; }
        }

        public int Width
        {
            get { return _Width; }
            set { _Width = value; }
        }

        #endregion

        public ImageSize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            string ret = "";
            ret += "<IMAGESIZE width=\"" + Width + "\" height=\"" + Height + "\" />";
            return ret;
        }
    }
}
