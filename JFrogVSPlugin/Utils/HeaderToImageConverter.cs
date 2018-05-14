using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Imaging.Interop;
using System.Collections.Generic;
using EnvDTE;
using System.Drawing;
using GelUtilities = Microsoft.Internal.VisualStudio.PlatformUI.Utilities;


namespace JFrogVSPlugin.Utils
{
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();
        private static readonly Guid JFrogManifestGuid = new Guid("86a2727e-a627-4c99-a8cc-c5622bc3479c");
        //public IVsImageService2 ImageService { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ImageMoniker imageMoniker = new ImageMoniker { Guid = JFrogManifestGuid, Id = 10 };
            IVsImageService2 imageService = (IVsImageService2)Package.GetGlobalService(typeof(SVsImageService));
            ImageAttributes attributes = new ImageAttributes
            {
                StructSize = Marshal.SizeOf(typeof(ImageAttributes)),
                // IT_Bitmap for Bitmap, IT_Icon for Icon  
                ImageType = (uint)_UIImageType.IT_Bitmap,
                Format = (uint)_UIDataFormat.DF_WinForms,
                LogicalWidth = 16,
                LogicalHeight = 16,
                // Desired RGBA color, if you don't use this, don't set IAF_Background below  
                Background = 0xFFFFFFFF,
                Flags = (uint)_ImageAttributesFlags.IAF_RequiredFlags,
            };
            IVsUIObject uIObj = imageService.GetImage(imageMoniker, attributes);
            return (BitmapImage)GelUtilities.GetObjectData(uIObj);
//            return new ImageMoniker { Guid = JFrogManifestGuid, Id = 20 };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
