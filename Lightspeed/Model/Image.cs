
namespace Lightspeed.Model
{
    public class Image
    {
        public int imageID { get; set; }
        public string description { get; set; }
        public string filename { get; set; }
        public int ordering { get; set; }
        public string publicID { get; set; }
        public int itemID { get; set; }
        public int itemMatrixID { get; set; }

        public string imageUrl
        {
            get
            {
                return string.Format("https://res.cloudinary.com/lightspeed-retail/image/upload/{0}.jpg", publicID);
            }
        }
    }
}
