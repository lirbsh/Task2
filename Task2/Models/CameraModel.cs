using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Models
{
    public abstract class CameraModel
    {
        protected const string ImagesDirectory = "Images";
        protected string imagesPath = string.Empty;
        protected abstract void InitImagesDirectory();

        public EventHandler? PictureTaken;
        public string? FilePath { get; set; }
        public ImageSource? Source { get; set; }
        public abstract void TakePicture();
    }
}
