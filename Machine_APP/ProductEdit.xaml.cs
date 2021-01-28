using Machine_APP.dal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
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
using System.Data;
// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Machine_APP
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ProductEdit : Page
    {

        string ChannelCode1 = "";
        string MachineCode1 = "";
        string ProductName1 = "";
        string Price1 = "";
        string ProductNum1 = "";
        public ObservableCollection<PRODUCT> PRODUCTs { get; } = new ObservableCollection<PRODUCT>();
        public ProductEdit()
        {
            this.InitializeComponent();
            APP_PRODUCT_DAL pdal = new APP_PRODUCT_DAL();
            List<PRODUCT> plist = pdal.getlist();
            foreach (var item in plist)
            {
                PRODUCTs.Add(item);
            }
        }

        private void but_clear_Click(object sender, RoutedEventArgs e)
        {
            //Button but = sender as Button;
            //string a = but.Content.ToString();
            //string b = but.Command.ToString();
        }

        private void but_sub_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string updatesql = "update APP_PRODUCT set  productname='{0}',price={1},discountprice={1},ProductNum={2} where ChannelCode='{3}' and MachineCode='{4}'";

                Button but = sender as Button;
                string aa = but.Name;
                StackPanel sp = but.Parent as StackPanel;

                for (int i = 0; i < sp.Children.Count; i++)
                {
                    if (i == 0)
                    {
                        TextBlock tb = sp.Children[0] as TextBlock;
                        ChannelCode1 = tb.Text;
                    }
                    if (i == 1)
                    {
                        TextBlock tb = sp.Children[1] as TextBlock;
                        MachineCode1 = tb.Text;
                    }
                    if (i == 2)
                    {
                        TextBox tb = sp.Children[2] as TextBox;
                        ProductName1 = tb.Text;
                    }
                    if (i == 3)
                    {
                        TextBox tb = sp.Children[3] as TextBox;
                        Price1 = tb.Text;
                        double a = 0;
                        if (!double.TryParse(Price1, out a))
                        {

                            var dialog = new ContentDialog()
                            {
                                Title = "消息提示",
                                Content = "当前输入值错误",
                                PrimaryButtonText = "确定",
                                //SecondaryButtonText = "取消",
                                FullSizeDesired = false,
                            };
                            dialog.PrimaryButtonClick += (_s, _e) => { };
                            dialog.ShowAsync();
                        }
                    }
                    if (i == 4)
                    {
                        TextBox tb = sp.Children[4] as TextBox;
                        ProductNum1 = tb.Text;
                        double a = 0;
                        if (!double.TryParse(Price1, out a))
                        {

                            var dialog = new ContentDialog()
                            {
                                Title = "消息提示",
                                Content = "当前输入值错误",
                                PrimaryButtonText = "确定",
                                //SecondaryButtonText = "取消",
                                FullSizeDesired = false,
                            };
                            dialog.PrimaryButtonClick += (_s, _e) => { };
                            dialog.ShowAsync();
                        }
                    }
                }

                APP_PRODUCT_DAL dal = new APP_PRODUCT_DAL();
                dal.updateforsql(string.Format(updatesql, ProductName1, double.Parse(Price1), double.Parse(ProductNum1), ChannelCode1, MachineCode1));
                var dialogOK = new ContentDialog()
                {
                    Title = "消息提示",
                    Content = "保存成功",
                    PrimaryButtonText = "确定",
                    //SecondaryButtonText = "取消",
                    FullSizeDesired = false,
                };
                dialogOK.PrimaryButtonClick += (_s, _e) => { };
                dialogOK.ShowAsync();
                ChannelCode1 = "";
                MachineCode1 = "";
                ProductName1 = "";
                Price1 = "";
                ProductNum1 = "";
            }
            catch (Exception ex)
            {
                Log_dal ld = new Log_dal();
                ld.addLog(0, "but_clear_Click  Error:" + ex.Message, DateTime.Now.ToString(), "");
            }
        }

        private void but_edit_Click(object sender, RoutedEventArgs e)
        {
            ChannelCode1 = "";
            MachineCode1 = "";
            ProductName1 = "";
            Price1 = "";
            ProductNum1 = "";
            Button but = sender as Button;
            string aa = but.Name;
            StackPanel sp = but.Parent as StackPanel;

            for (int i = 0; i < sp.Children.Count; i++)
            {
                if (i == 0)
                {
                    TextBlock tb = sp.Children[0] as TextBlock;
                    ChannelCode1 = tb.Text;
                }
                if (i == 1)
                {
                    TextBlock tb = sp.Children[1] as TextBlock;
                    MachineCode1 = tb.Text;
                }
                if (i == 2)
                {
                    TextBox tb = sp.Children[2] as TextBox;
                    ProductName1 = tb.Text;
                }
            }
            this.Frame.Navigate(typeof(ProductEditbysingle), new { ChannelCode = ChannelCode1, MachineCode = MachineCode1 });
        }

        private void but_new_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ProductEditbysingle), new { ChannelCode = "", MachineCode = "" });
        }

        private void but_backup_Click(object sender, RoutedEventArgs e)
        {
            Log_dal dlog = new Log_dal();
            dlog.addLog(0, "but_backup_Click  Error:", DateTime.Now.ToString(), "");
            try
            {
                string mcode = (Application.Current as App).syscofig.MachineCode;
                string res = app_Interface.Post(mcode, mcode, "");
                DataTable dt = jsonHelp.jsonTOdatatable(res);
                APP_PRODUCT_DAL dal = new APP_PRODUCT_DAL();
                dal.deleteAllproduct();
                foreach (DataRow item in dt.Rows)
                {
                    int outint = 4;
                    double outdoubel = 0;
                    bool outbool = false;
                    DateTime outdt;
                    PRODUCT p = new PRODUCT();
                    p.ChannelCode1 = item["ChannelCode"].ToString();
                    p.MachineType1 = int.TryParse(item["MachineType"].ToString(), out outint) ? outint : outint;
                    p.MachineCode1 = item["MachineCode"].ToString();
                    p.ProductName1 = item["ProductName"].ToString();
                    p.Price1 = double.TryParse(item["Price"].ToString(), out outdoubel) ? outdoubel : outdoubel;
                    outdoubel = 0;
                    p.DiscountPrice1 = double.TryParse(item["DiscountPrice"].ToString(), out outdoubel) ? outdoubel : outdoubel;
                    outdoubel = 0;
                    p.DiscountDate1 = item["DiscountDate"].ToString();
                    p.XFlag1 = double.TryParse(item["XFlag"].ToString(), out outdoubel) ? outdoubel : outdoubel;
                    outdoubel = 0;
                    p.YFlag1 = double.TryParse(item["YFlag"].ToString(), out outdoubel) ? outdoubel : outdoubel;
                    outint = 4;
                    p.ChannelStatus1 = int.TryParse(item["ChannelStatus"].ToString(), out outint) ? outint : outint;

                    p.PictureUrl1 = item["PictureUrl"].ToString();
                    outdoubel = 0;
                    p.ChannelLength1 = double.TryParse(item["ChannelLength"].ToString(), out outdoubel) ? outdoubel : outdoubel;
                    outdoubel = 0;
                    p.ChannelWidth1 = double.TryParse(item["ChannelWidth"].ToString(), out outdoubel) ? outdoubel : outdoubel;
                    outint = 4;
                    p.ChannelType1 = int.TryParse(item["ChannelType"].ToString(), out outint) ? outint : outint;
                    outdoubel = 0;
                    p.ProductNum1 = double.TryParse(item["ProductNum"].ToString(), out outdoubel) ? outdoubel : outdoubel;
                    outdoubel = 0;
                    p.CapacityNum1 = double.TryParse(item["CapacityNum"].ToString(), out outdoubel) ? outdoubel : outdoubel;
                    p.IsDisable1 = bool.TryParse(item["IsDisable"].ToString(), out outbool) ? outbool : outbool;
                    p.Creator1 = item["Creator"].ToString();
                    p.CreateDate1 = DateTime.TryParse(item["CreateDate"].ToString(), out outdt) ? outdt : outdt;
                    p.Modifier1 = item["Modifier"].ToString();
                    p.ModifyDate1 = DateTime.TryParse(item["ModifyDate"].ToString(), out outdt) ? outdt : outdt;
                    dal.insertproduct(p);

                }
            }
            catch (Exception ex)
            {
                Log_dal ld = new Log_dal();
                ld.addLog(0, "but_backup_Click  Error:" + ex.Message, DateTime.Now.ToString(), "");
            }
        }


        private void but_back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AppConfig), null);
        }

        //private void but_new_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof(ProductEditbysingle), new { ChannelCode = "", MachineCode = "" });
        //}
    }
}
