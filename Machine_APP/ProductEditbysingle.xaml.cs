using Machine_APP.dal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Machine_APP.model;
// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Machine_APP
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ProductEditbysingle : Page
    {
        private bool isnew = false;
        public ObservableCollection<PRODUCT> PRODUCTs { get; } = new ObservableCollection<PRODUCT>();
        //List<PAY_DETAILS> listbuy = new List<PAY_DETAILS>();
        public string CCode = "";
        public string MCode = "";
        public ProductEditbysingle()
        {
            this.InitializeComponent();

        }

        //利用反射获取
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                var parameter = e.Parameter;
                var type = e.Parameter?.GetType();
                if (type == null)
                {
                    return;
                }

                var id1 = type.GetProperty("ChannelCode").GetValue(parameter);
                var name1 = type.GetProperty("MachineCode").GetValue(parameter);
                CCode = id1.ToString();
                MCode = name1.ToString();
                if (CCode == "" && MCode == "")
                {
                    isnew = true;
                    channelcode.IsReadOnly = false;
                    MachineCode.IsReadOnly = false;
                    return;
                }
                string sql = " and ChannelCode ='{0}' and MachineCode='{1}'";

                APP_PRODUCT_DAL pdal = new APP_PRODUCT_DAL();
                List<PRODUCT> plist = pdal.getlistbysingle(string.Format(sql, CCode, MCode));
                foreach (var item in plist)
                {
                    PRODUCTs.Add(item);
                }
                CapacityNum.Text = PRODUCTs[0].CapacityNum1.ToString();
                channelcode.Text = PRODUCTs[0].ChannelCode1.ToString();
                ChannelLength.Text = PRODUCTs[0].ChannelLength1.ToString();
                ChannelStatus.Text = PRODUCTs[0].ChannelStatus1.ToString();
                ChannelType.Text = PRODUCTs[0].ChannelType1.ToString();
                ChannelWidth.Text = PRODUCTs[0].ChannelWidth1.ToString();
                DiscountDate.Text = PRODUCTs[0].DiscountDate1.ToString();
                DiscountPrice.Text = PRODUCTs[0].DiscountPrice1.ToString();
                IsDisable.IsChecked = PRODUCTs[0].IsDisable1.ToString() == "1" ? true : false;
                MachineCode.Text = PRODUCTs[0].MachineCode1.ToString();
                MachineType.Text = PRODUCTs[0].MachineType1.ToString();
                PictureUrl.Text = PRODUCTs[0].PictureUrl1.ToString();
                Price.Text = PRODUCTs[0].Price1.ToString();
                ProductName.Text = PRODUCTs[0].ProductName1.ToString();
                ProductNum.Text = PRODUCTs[0].ProductNum1.ToString();
                XFlag.Text = PRODUCTs[0].XFlag1.ToString();
                YFlag.Text = PRODUCTs[0].YFlag1.ToString();
            }
            catch (Exception ex)
            {
                Log_dal ld = new Log_dal();
                ld.addLog(0, "PostHttpstringrequest_alipay  Error:" + ex.Message, DateTime.Now.ToString(), "");

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

        private void but_save_Click_1(object sender, RoutedEventArgs e)
        {
            APP_PRODUCT_DAL pdal = new APP_PRODUCT_DAL();
            PRODUCT p1 = new PRODUCT();
            try
            {
                #region 实体类赋值
                double outnum = 0;
                double.TryParse(CapacityNum.Text, out outnum);
                p1.CapacityNum1 = outnum;


                p1.ChannelCode1 = channelcode.Text;


                outnum = 0;
                double.TryParse(ChannelLength.Text, out outnum);
                p1.ChannelLength1 = outnum;


                int intout = -1;
                int.TryParse(ChannelStatus.Text, out intout);
                p1.ChannelStatus1 = intout;

                intout = -1;
                int.TryParse(ChannelType.Text, out intout);
                p1.ChannelType1 = intout;


                outnum = 0;
                double.TryParse(ChannelWidth.Text, out outnum);
                p1.ChannelWidth1 = outnum;


                p1.DiscountDate1 = DiscountDate.Text;

                outnum = 0;
                double.TryParse(DiscountPrice.Text, out outnum);
                p1.DiscountPrice1 = outnum;

                p1.IsDisable1 = IsDisable.IsChecked == true ? true : false;
                p1.MachineCode1 = MachineCode.Text;

                intout = -1;
                int.TryParse(MachineType.Text, out intout);
                p1.MachineType1 = intout;

                p1.PictureUrl1 = PictureUrl.Text;

                outnum = 0;
                double.TryParse(Price.Text, out outnum);
                p1.Price1 = outnum;

                p1.ProductName1 = ProductName.Text;

                double.TryParse(ProductNum.Text, out outnum);
                p1.ProductNum1 = outnum;


                double.TryParse(XFlag.Text, out outnum);
                p1.XFlag1 = outnum;

                double.TryParse(YFlag.Text, out outnum);
                p1.YFlag1 = outnum;
                #endregion
                #region 新增或者更新商品
                if (isnew)
                    pdal.insertproduct(p1);
                else
                    pdal.updateproduct(p1);

                var dialog = new ContentDialog()
                {
                    Title = "操作提示",
                    Content = "操作成功",
                    PrimaryButtonText = "确定",
                    //SecondaryButtonText = "取消",
                    FullSizeDesired = false,
                };
                dialog.PrimaryButtonClick += (_s, _e) => { };
                dialog.ShowAsync();
                this.Frame.Navigate(typeof(ProductEdit));
                #endregion
            }
            catch (Exception ex)
            {
                Log_dal ld = new Log_dal();
                ld.addLog(0, "but_save_Click_1  Error:" + ex.Message, DateTime.Now.ToString(), "");

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
            this.Frame.Navigate(typeof(ProductEdit));
        }
    }
}
