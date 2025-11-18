using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryAvalonia.Model
{
    public class GalleryEventArgs : EventArgs
    {
        public GalleryPainting GalleryPainting { get; private set; }
        public GalleryEventArgs(GalleryPainting galleryPainting)
        {
            GalleryPainting = galleryPainting;
        }
    }
}
