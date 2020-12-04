using Machine_APP.dal;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;
//using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace Machine_APP
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MyPay : Page
    {
        public MyPay()
        {
            this.InitializeComponent();
            GetQRCode("https://qr.alipay.com/bax05495yze5bw2eicub50f0");
            //QRCodeHelper qh = new QRCodeHelper();

            //var bit =qh.GenerateQrCode("https://qr.alipay.com/bax05495yze5bw2eicub50f0");
            //BitmapImage bitmap = bit.Result;
            //Bitmap bitmapImage = qh.CreateQRimg("https://qr.alipay.com/bax05495yze5bw2eicub50f0");
            //BitmapImage bitmap = qh.BitmapToBitmapImage(bitmapImage);
            //pccode.Source = bitmap;
        }
        public async void GetQRCode(string  date)
        {
            string level = "L";
            QRCodeGenerator.ECCLevel eccLevel = (QRCodeGenerator.ECCLevel)(level == "L" ? 0 : level == "M" ? 1 : level == "Q" ? 2 : 3);
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(date, eccLevel);
            BitmapByteQRCode qrCodeBmp = new BitmapByteQRCode(qrCodeData);
            byte[] qrCodeImageBmp = qrCodeBmp.GetGraphic(20);//, new byte[] { 118, 126, 152 }, new byte[] { 144, 201, 111 }
            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes(qrCodeImageBmp);
                    await writer.StoreAsync();
                }

                var image = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                await image.SetSourceAsync(stream);
                pccode.Source = image;
            }
        }
        private void but_wx_Click(object sender, RoutedEventArgs e)
        {

            //ImageSource ImageSource = new BitmapImage(new Uri("ms-appx:///PIC/wx_2wm.png"));
            //pccode.Source = ImageSource;
            //ImageSource a = pccode.Source;
        }

        private void but_car_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MyCar), null);
        }

        private void but_zfb_Click(object sender, RoutedEventArgs e)
        {
            //ImageSource ImageSource = new BitmapImage(new Uri("ms-appx:///PIC/zfb_2wm.png"));
            //pccode.Source = ImageSource;
        }
    }
}
