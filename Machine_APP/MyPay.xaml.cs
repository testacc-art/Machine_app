using Machine_APP.dal;
using Machine_APP.model;
using Newtonsoft.Json;
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
            //GetQRCode("https://qr.alipay.com/bax05495yze5bw2eicub50f0");

        }
        public async void GetQRCode(string date)
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
            try
            {
                #region 微信支付
                List<pay_infor_detail> dlist = new List<pay_infor_detail>();
                foreach (PAY_DETAILS item in (Application.Current as App).pdlist)
                {
                    pay_infor_detail payinford = new pay_infor_detail(item.ProductName1, item.ChannelCode1, item.CreateDate1.ToString(), item.Creator1, item.PictureUrl1, item.PayNo1, item.PayDetailNo1, item.MachineCode1, (int)item.PayAmount1, item.OutNum1, item.IsPayComplated1, item.IsOutStatus1, item.FinishOutNum1, (float)item.Amount1, (float)item.ReturnAmount1, (float)item.UnitPrice1);
                    dlist.Add(payinford);


                }
                pay_info info = new pay_info("wechat", (Application.Current as App).pr.PayNo1, (Application.Current as App).pr.CreateDate1.ToString(), (Application.Current as App).pr.Creator1, dlist, (Application.Current as App).pr.MachineCode1, (Application.Current as App).pr.IsPayComplated1, (Application.Current as App).pr.OutSaleNum1, (Application.Current as App).pr.IsFinishSale1, float.Parse((Application.Current as App).pr.PayAmount1.ToString()), (float)(Application.Current as App).pr.ChangeAmount1, (Application.Current as App).pr.CashGenerateStatus1, (float)(Application.Current as App).pr.CashAmount1, (float)(Application.Current as App).pr.ReturnAmount1, (float)(Application.Current as App).pr.ReturnNum1);
                //pay_info info = new pay_info("2", "XM5555300012345678951234", "2019-12-09 09:35:51.195", "CJXM17060001", dlist, "CJXM17060001", 0, 2, 0, 2, 0, 0, 0, 0, 0);
                string jsona = JsonConvert.SerializeObject(info);

                string abc = app_Interface.postdata("wechat", jsona);

                Json_restun jr = Newtonsoft.Json.JsonConvert.DeserializeObject<Json_restun>(abc);
                // Task<string> addd =  app_Interface.PostHttpstringrequest_alipay("wechat", jsona);
                GetQRCode(jr.Data);
                #endregion
            }
            catch (Exception ex)
            {
                Log_dal ld = new Log_dal();
                ld.addLog(0, "but_wx_Click  Error:" + ex.Message, DateTime.Now.ToString(), "");
                var dialog = new ContentDialog()
                {
                    Title = "报错提示",
                    Content = ex.Message,
                    PrimaryButtonText = "确定",
                    //SecondaryButtonText = "取消",
                    FullSizeDesired = false,
                };
                dialog.PrimaryButtonClick += (_s, _e) => { };
                dialog.ShowAsync();
            }
        }

        private void but_zfb_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                #region   调用支付宝生成二维码网址接口

                List<pay_infor_detail> dlist = new List<pay_infor_detail>();
                foreach (PAY_DETAILS item in (Application.Current as App).pdlist)
                {
                    pay_infor_detail payinford = new pay_infor_detail(item.ProductName1, item.ChannelCode1, item.CreateDate1.ToString(), item.Creator1, item.PictureUrl1, item.PayNo1, item.PayDetailNo1, item.MachineCode1, (int)item.PayAmount1, item.OutNum1, item.IsPayComplated1, item.IsOutStatus1, item.FinishOutNum1, (float)item.Amount1, (float)item.ReturnAmount1, (float)item.UnitPrice1);
                    dlist.Add(payinford);


                }
                pay_info info = new pay_info("alipay", (Application.Current as App).pr.PayNo1, (Application.Current as App).pr.CreateDate1.ToString(), (Application.Current as App).pr.Creator1, dlist, (Application.Current as App).pr.MachineCode1, (Application.Current as App).pr.IsPayComplated1, (Application.Current as App).pr.OutSaleNum1, (Application.Current as App).pr.IsFinishSale1, float.Parse((Application.Current as App).pr.PayAmount1.ToString()), (float)(Application.Current as App).pr.ChangeAmount1, (Application.Current as App).pr.CashGenerateStatus1, (float)(Application.Current as App).pr.CashAmount1, (float)(Application.Current as App).pr.ReturnAmount1, (float)(Application.Current as App).pr.ReturnNum1);
                //pay_info info = new pay_info("2", "XM5555300012345678951234", "2019-12-09 09:35:51.195", "CJXM17060001", dlist, "CJXM17060001", 0, 2, 0, 2, 0, 0, 0, 0, 0);
                string jsona = JsonConvert.SerializeObject(info);

                string abc = app_Interface.postdata("alipay", jsona);

                Json_restun jr = Newtonsoft.Json.JsonConvert.DeserializeObject<Json_restun>(abc);
                // Task<string> addd =  app_Interface.PostHttpstringrequest_alipay("wechat", jsona);
                GetQRCode(jr.Data);
            }
            catch (Exception ex)
            {
                Log_dal ld = new Log_dal();
                ld.addLog(0, "but_zfb_Click  Error:" + ex.Message, DateTime.Now.ToString(), "");
                var dialog = new ContentDialog()
                {
                    Title = "报错提示",
                    Content = ex.Message,
                    PrimaryButtonText = "确定",
                    //SecondaryButtonText = "取消",
                    FullSizeDesired = false,
                };
                dialog.PrimaryButtonClick += (_s, _e) => { };
                dialog.ShowAsync();
            }

            //pay_infor_detail d1 = new pay_infor_detail("西芹", "3", "2019-10-27 09:35:51.212", "CJXM17060001", "genjin_1", "XM2222300012345678951234", "XM2222300000000000000001", "CJXM17060001", 1, 1, 0, 0, 0, 2, 0, 1);
            //pay_infor_detail d2 = new pay_infor_detail("黄瓜", "3", "2019-10-27 09:35:51.212", "CJXM17060001", "genjin_1", "XM2222300012345678951234", "XM2222300000000000000002", "CJXM17060001", 1, 1, 0, 0, 0, 2, 0, 1);
            //List<pay_infor_detail> dlist = new List<pay_infor_detail>();
            //dlist.Add(d1); dlist.Add(d2);
            //pay_info info = new pay_info("2", "XM2222300012345678951234", "2019-10-27 09:35:51.195", "CJXM17060001", dlist, "CJXM17060001", 0, 2, 0, 2, 0, 0, 0, 0, 0);

            //string jsona = JsonConvert.SerializeObject(info);

            //Task<string> addd = app_Interface.PostHttpstringrequest("", jsona);
            //var abc = addd;
            #endregion
        }

        private void but_car_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int sumnum = 0;
                double sumamount = 0;
                foreach (PAY_DETAILS item in (Application.Current as App).pdlist)
                {
                    sumnum = sumnum + item.OutNum1;
                    sumamount = sumamount + item.PayAmount1;
                }
                (Application.Current as App).pr.PayAmount1 = sumamount;
                (Application.Current as App).pr.OutSaleNum1 = sumnum;
                Frame.Navigate(typeof(CarMain), null);
            }
            catch (Exception ex)
            {
                Log_dal ld = new Log_dal();
                ld.addLog(0, "but_car_Click  Error:" + ex.Message, DateTime.Now.ToString(), "");
                var dialog = new ContentDialog()
                {
                    Title = "报错提示",
                    Content = ex.Message,
                    PrimaryButtonText = "确定",
                    //SecondaryButtonText = "取消",
                    FullSizeDesired = false,
                };
                dialog.PrimaryButtonClick += (_s, _e) => { };
                dialog.ShowAsync();
            }

        }

        private void but_cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                (Application.Current as App).pdlist.Clear();
                (Application.Current as App).plist.Clear();
                (Application.Current as App).pr = null;
                Frame.Navigate(typeof(BuyMain), null);
            }
            catch (Exception ex)
            {
                Log_dal ld = new Log_dal();
                ld.addLog(0, "but_cancel_Click  Error:" + ex.Message, DateTime.Now.ToString(), "");
                var dialog = new ContentDialog()
                {
                    Title = "报错提示",
                    Content = ex.Message,
                    PrimaryButtonText = "确定",
                    //SecondaryButtonText = "取消",
                    FullSizeDesired = false,
                };
                dialog.PrimaryButtonClick += (_s, _e) => { };
                dialog.ShowAsync();
            }
        }
    }
}
