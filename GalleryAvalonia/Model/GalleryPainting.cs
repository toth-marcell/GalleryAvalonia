using Avalonia.Media.Imaging;

namespace GalleryAvalonia.Model
{
    public class GalleryPainting
    {
        public string Name { get; private set; }
        public string Creator { get; private set; }
        public string Condition { get; private set; }
        public int Price { get; private set; }
        public Bitmap CardImage { get; private set; }
        public GalleryPainting(string name, string creator, string condition, int price, Bitmap cardImage)
        {
            Name = name;
            Creator = creator;
            Condition = condition;
            Price = price;
            CardImage = cardImage;
        }
    }
}
