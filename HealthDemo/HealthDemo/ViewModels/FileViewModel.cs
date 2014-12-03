using HealthDemo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Labs;
using Xamarin.Forms.Labs.Services.Media;
using XLabs.Ioc;

namespace HealthDemo.ViewModels
{
    public class FileViewModel : ViewModelBase
    {
        public FileModel NewFile { get; set; }
        public MediaFile ImgFile { get; set; }

        public void SendFile(Action<bool> oncompleted)
        {
            IsLoading = true;
            Task.Run(() => SendMail(oncompleted));
        }

        private void SendMail(Action<bool> oncompleted)
        {
            if (ImgFile != null)
            {
                byte[] buffer = new byte[ImgFile.Source.Length];
                ImgFile.Source.Read(buffer, 0, (int)ImgFile.Source.Length);
                NewFile.ImageAsString = this.WrapImageData(buffer, NewFile.ImageExtension);
                //NewFile.ImageBytes = buffer;
                ImgFile = null;
            }

            WebService.CreateFile(NewFile, result =>
            {
                IsLoading = false;

                if (!result.Success)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        ShowError(result.ErrorMessage);
                    });
                }
                else NewFile = null;
                oncompleted(result.Success);
            });
        }

        public async Task ShowMediaPicker()
        {
            try
            {
                var device = Resolver.Resolve<IDevice>();
                var mediaPicker = device.MediaPicker;
                ImgFile = null;
                ImgFile = await mediaPicker.SelectPhotoAsync(new CameraMediaStorageOptions
                {
                    DefaultCamera = CameraDevice.Front,
                    MaxPixelDimension = 400
                });

                NewFile.Path = Path.GetFileName(ImgFile.Path);
                NewFile.RaisePropertyChanged("Path");
                NewFile.ImageExtension = Path.GetExtension(ImgFile.Path);
            }
            catch(TaskCanceledException)
            {

            }
        }

        public bool CheckValidation()
        {
            return (!string.IsNullOrEmpty(NewFile.Name) ||
                !string.IsNullOrEmpty(NewFile.EmirateID) ||
                !string.IsNullOrEmpty(NewFile.Thiqa));
        }

        private string WrapImageData(byte[] imageBytes, string extenssion)
        {
            var mimeTypeString = extenssion == ".jpg" ? "image/jpeg" : "image/png";
            var byteString = Convert.ToBase64String(imageBytes);
            var data = string.Format("name:{0};name,{1}", mimeTypeString, byteString);
            return data;
        }

    }
}
