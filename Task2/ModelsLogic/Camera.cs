using Task2.Models;

namespace Task2.ModelsLogic
{
    public class Camera : CameraModel
    {
        public Camera() 
        {
            InitImagesDirectory();
        }
        public override async void TakePicture()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            { 
                try
                {
                    FileResult? fr = await MediaPicker.Default.CapturePhotoAsync();
                    if (fr != null)
                    {
                        // save and read file
                        string path = Path.Combine(FileSystem.AppDataDirectory, ImagesDirectory);
                        path = Path.Combine(path, fr.FileName);
                        using Stream source = await fr.OpenReadAsync();
                        using FileStream dest = File.OpenWrite(path);
                        await source.CopyToAsync(dest);
                        source.Close();
                        dest.Close();
                        Source = ImageSource.FromFile(path);
                        FilePath = path;
                        PictureTaken?.Invoke(this, EventArgs.Empty);
                    }
                }
                catch (Exception e)
                {
                    await Shell.Current.DisplayAlert("Camera", e.Message, "Close");
                }
            }
            else
                await Shell.Current.DisplayAlert("Camera", "Not supported", "Close");
        }

        protected override void InitImagesDirectory()
        {
            imagesPath = Path.Combine(FileSystem.AppDataDirectory, ImagesDirectory);
            if (!Directory.Exists(imagesPath))
                Directory.CreateDirectory(imagesPath);
        }
    }
}
