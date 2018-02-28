using Foundation;
using UIKit;

namespace WoodgroveBankApp.Common
{
    public class ImageConverter
    {
        public ImageConverter()
        {
        }

        public static UIImage GetImageFromBase64String(string Data)
        {
            byte[] bytes = System.Convert.FromBase64String(Data);
            NSData imageData = NSData.FromArray(bytes);
            return UIImage.LoadFromData(imageData);
        }
    }
}
