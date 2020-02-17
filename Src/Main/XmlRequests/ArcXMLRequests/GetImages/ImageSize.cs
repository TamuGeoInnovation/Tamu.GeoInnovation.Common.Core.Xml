namespace USC.GISResearchLab.Common.XMLRequests.ArcXMLRequests
{
    public class ImageSize
    {

        #region Properties

        public int Height { get; set; }
        public int Width { get; set; }

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
