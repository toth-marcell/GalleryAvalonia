using System;

namespace GalleryAvalonia.Model
{
    public class GalleryEventArgs : EventArgs
    {
        public GalleryPainting GalleryPainting { get; private set; }
        public int PaintingNumber { get; private set; }
        public GalleryEventArgs(GalleryPainting galleryPainting, int paintingNumber)
        {
            GalleryPainting = galleryPainting;
            PaintingNumber = paintingNumber;
        }
    }
}
