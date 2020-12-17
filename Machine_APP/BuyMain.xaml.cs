using Machine_APP.dal;
using Newtonsoft.Json;
using QRCoder;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
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
    public sealed partial class BuyMain : Page
    {
        public ObservableCollection<ProductView> PRODUCTs { get; } = new ObservableCollection<ProductView>();
        public List<PRODUCT> plist { get; } = new List<PRODUCT>();
        List<PAY_DETAILS> listbuy = new List<PAY_DETAILS>();
        string MCode = "";
        public BuyMain()
        {
            this.InitializeComponent();
            MCode = (Application.Current as App).syscofig.MachineCode;
            #region   调用支付宝生成二维码网址接口
            //pay_infor_detail d1 = new pay_infor_detail("西芹", "3", "2019-10-27 09:35:51.212", "CJXM17060001", "genjin_1", "XM2222300012345678951234", "XM2222300000000000000001", "CJXM17060001", 1, 1, 0, 0, 0, 2, 0, 1);
            //pay_infor_detail d2 = new pay_infor_detail("黄瓜", "3", "2019-10-27 09:35:51.212", "CJXM17060001", "genjin_1", "XM2222300012345678951234", "XM2222300000000000000002", "CJXM17060001", 1, 1, 0, 0, 0, 2, 0, 1);
            //List<pay_infor_detail> dlist = new List<pay_infor_detail>();
            //dlist.Add(d1); dlist.Add(d2);
            //pay_info info = new pay_info("2", "XM2222300012345678951234", "2019-10-27 09:35:51.195", "CJXM17060001", dlist, "CJXM17060001", 0, 2, 0, 2, 0, 0, 0, 0, 0);

            //string jsona = JsonConvert.SerializeObject(info);

            //Task<string> addd = app_Interface.PostHttpstringrequest("", jsona);
            //var abc = addd;
            #endregion

            #region 微信支付
            //pay_infor_detail d1 = new pay_infor_detail("西芹", "3", "2019-10-27 09:35:51.212", "CJXM17060001", "genjin_1", "XM5555300012345678951234", "XM2222300000000000000001", "CJXM17060001", 1, 1, 0, 0, 0, 2, 0, 1);
            //pay_infor_detail d2 = new pay_infor_detail("黄瓜", "3", "2019-10-27 09:35:51.212", "CJXM17060001", "genjin_1", "XM5555300012345678951234", "XM2222300000000000000002", "CJXM17060001", 1, 1, 0, 0, 0, 2, 0, 1);
            //List<pay_infor_detail> dlist = new List<pay_infor_detail>();
            //dlist.Add(d1); dlist.Add(d2);
            //pay_info info = new pay_info("2", "XM5555300012345678951234", "2019-12-09 09:35:51.195", "CJXM17060001", dlist, "CJXM17060001", 0, 2, 0, 2, 0, 0, 0, 0, 0);

            //string jsona = JsonConvert.SerializeObject(info);

            //Task<string> addd = app_Interface.PostHttpstringrequest_alipay("", jsona);
            //var abc = addd;
            #endregion


            #region 绑定产品
            APP_PRODUCT_DAL pdal = new APP_PRODUCT_DAL();
            List<PRODUCT> plist = pdal.getlist();
            (Application.Current as App).plist = plist;

            //for (int i = 0; i < plist.Count; i++)
            //{
            //    plist.Add(plist[i]);
            //}
            //foreach (var item in plist)
            //{
            //    plist.Add(item);
            //}
            PRODUCTs = pdal.serpveiw(plist);
            foreach (ProductView item in PRODUCTs)
            {
                List<PAY_DETAILS> dtelist = (Application.Current as App).pdlist.Where(a => a.ChannelCode1 == item.ChannelCode1).ToList();
                if (dtelist.Count > 0)
                {
                    item.choosenum1 = dtelist[0].OutNum1;
                }
            }
            #endregion


        }

        private void add_1_1_Click(object sender, RoutedEventArgs e)
        {
            string CCode = "";
            Button but = sender as Button;
            Windows.UI.Xaml.Controls.StackPanel stackp = but.Parent as StackPanel;
            int outnum = 0;
            foreach (var item in stackp.Children)
            {
                TextBlock tb = item as TextBlock;
                if (tb == null)
                    continue;
                string abc = tb.Text;
                int.TryParse(abc, out outnum);
                outnum++;
                tb.Text = outnum.ToString();
                //if (tb.Tag == null)
                //{
                //    string abc = tb.Text;

                //    int.TryParse(abc, out outnum);
                //    outnum++;
                //    tb.Text = outnum.ToString();

                //}
                //else
                //{
                //    CCode = tb.Text; continue;
                //}
                ProductView p = tb.DataContext as ProductView;
                List<PAY_DETAILS> list = (Application.Current as App).pdlist.Where(a => a.ChannelCode1 == p.ChannelCode1).ToList();

                if (list.Count > 0)
                {
                    PAY_DETAILS listbak = list[0];
                    (Application.Current as App).pdlist.Remove(list[0]);
                    listbak.OutNum1 = int.Parse(tb.Text);
                    listbak.PayAmount1 = outnum * listbak.UnitPrice1;
                    (Application.Current as App).pdlist.Add(listbak);
                }
                else
                {
                    setPAY_RECORD();
                    double price = 0;
                    string vw = DateTime.Now.ToString("yyyyMMddHHmmssms");
                    DateTime dtime = DateTime.Now;

                    if (string.IsNullOrEmpty(p.DiscountDate1))
                        price = p.Price1;
                    else
                    {
                        DateTime.TryParse(p.DiscountDate1, out dtime);
                        if (DateTime.Now < dtime)
                            price = p.DiscountPrice1;
                        else
                            price = p.Price1;
                    }


                    PAY_DETAILS pd = new PAY_DETAILS(p.ChannelCode1 + vw, (Application.Current as App).pr.PayNo1, MCode, p.ChannelCode1, p.ChannelCode1
                        , p.ProductName1, p.PictureUrl1, 0, price * outnum, 0, 0, price, outnum, 0, 0, 0, DateTime.Now, "", DateTime.Now, "creator", DateTime.Now, "modifier", DateTime.Now);
                    (Application.Current as App).pdlist.Add(pd);

                }
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;
            Windows.UI.Xaml.Controls.StackPanel stackp = but.Parent as StackPanel;
            foreach (var item in stackp.Children)
            {
                TextBlock tb = item as TextBlock;
                if (tb == null)
                    continue;
                string abc = tb.Text;
                int outnum = -1;
                int.TryParse(abc, out outnum);
                outnum--;
                if (outnum < 0)
                    outnum = 0;
                tb.Text = outnum.ToString();
                ProductView p = tb.DataContext as ProductView;
                List<PAY_DETAILS> list = (Application.Current as App).pdlist.Where(a => a.ChannelCode1 == p.ChannelCode1).ToList();
                if (tb.Text == "0")
                {
                    if (list.Count > 0)
                        (Application.Current as App).pdlist.Remove(list[0]);
                    if (list.Count == 0)
                    {
                        (Application.Current as App).pr = null;
                    }
                }
                else
                {
                    PAY_DETAILS listbak = list[0];
                    (Application.Current as App).pdlist.Remove(list[0]);
                    listbak.OutNum1 = int.Parse(tb.Text);
                    listbak.PayAmount1 = outnum * listbak.UnitPrice1;
                    (Application.Current as App).pdlist.Add(listbak);

                }

            }
        }

        /// <summary>
        /// 新增主表
        /// </summary>
        public void setPAY_RECORD()
        {
            //判断是否已经存在
            if ((Application.Current as App).pr != null)
                return;
            //不存在就全局变量中新增
            string vw = DateTime.Now.ToString("yyyyMMddHHmmssms");
            (Application.Current as App).pr = new PAY_RECORD(MCode + vw, "", "", MCode, 0, "", "", 0, 0, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0, " ", "", DateTime.Now, "0", DateTime.Now);
        }

        private void but_car_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CarMain), null);
        }

        private void but_next_Click(object sender, RoutedEventArgs e)
        {

            //主表
            string payNo = "payNo" + DateTime.Now.ToString();
            double amount = 0;
            int num = 0;
            for (int i = 0; i < (Application.Current as App).pdlist.Count(); i++)
            {
                amount += (Application.Current as App).pdlist[i].PayAmount1;
                num += (Application.Current as App).pdlist[i].OutDetailNum1;
            }

            (Application.Current as App).pr.PayUserID1 = "payUserID";
            (Application.Current as App).pr.ChannelCode1 = "ChannelCode1";
            (Application.Current as App).pr.MachineCode1 = MCode;
            (Application.Current as App).pr.IsPayComplated1 = 0;
            (Application.Current as App).pr.PayType1 = "";
            (Application.Current as App).pr.PayAccount1 = "";
            (Application.Current as App).pr.PayAmount1 = amount;
            (Application.Current as App).pr.IsFinishSale1 = 0;
            (Application.Current as App).pr.OutSaleNum1 = num;
            (Application.Current as App).pr.ReturnAmount1 = 0;
            (Application.Current as App).pr.FinishReturnAmount1 = 0;
            (Application.Current as App).pr.ReturnNum1 = 0;
            (Application.Current as App).pr.CashAmount1 = 0;
            (Application.Current as App).pr.ChangeAmount1 = 0;
            (Application.Current as App).pr.CashGenerateStatus1 = 0;
            (Application.Current as App).pr.CashCode1 = "";
            (Application.Current as App).pr.Creator1 = "UserID";
            (Application.Current as App).pr.CreateDate1 = DateTime.Now;
            (Application.Current as App).pr.Modifier1 = "";
            (Application.Current as App).pr.ModifyDate1 = DateTime.Now;
            #region  insert 交易主表,子表
            //dal.PAY_RECORD_DAL prd = new dal.PAY_RECORD_DAL((Application.Current as App).pr);
            //prd.insertData();
            ////循环设置子表外键，并insert子表
            //dal.PAY_DETAILS_DAL pdd = new dal.PAY_DETAILS_DAL();
            //foreach (PAY_DETAILS item in (Application.Current as App).pdlist)
            //{
            //    pdd.detail = item;
            //    pdd.detail.PayNo1 = prd.record.PayNo1;
            //    pdd.insertData();
            //}
            #endregion 
            Frame.Navigate(typeof(MyPay), null);
        }
    }
}
