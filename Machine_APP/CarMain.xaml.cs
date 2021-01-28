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
    public sealed partial class CarMain : Page
    {
        public ObservableCollection<PAY_DETAILS> DETAILS { get; } = new ObservableCollection<PAY_DETAILS>();
        public CarMain()
        {
            this.InitializeComponent();
            foreach (var item in (Application.Current as App).pdlist)
            {
                DETAILS.Add(item);
            }
            orderamount.Text = (Application.Current as App).pr.PayAmount1.ToString();
            ordernum.Text = (Application.Current as App).pr.OutSaleNum1.ToString();
        }

        //跳转付款画面
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            ////主表
            //string payNo = "payNo" + DateTime.Now.ToString();
            //double amount = 0;
            //int num = 0;
            //for (int i = 0; i < (Application.Current as App).pdlist.Count(); i++)
            //{
            //    amount += (Application.Current as App).pdlist[i].PayAmount1;
            //    num += (Application.Current as App).pdlist[i].OutNum1;
            //}
            //            (Application.Current as App).pr = new PAY_RECORD(payNo, "payUserID",
            // "channelCode", "machineCode", 0, "payType", "payAccount", amount, 0, num, 0.00, 0.00, 0.00,
            //0.00, 0.00, 0, " cashCode", "reator", DateTime.Now, "modifier", DateTime.Now);


            //dal.PAY_RECORD_DAL prd = new dal.PAY_RECORD_DAL((Application.Current as App).pr);
            ////主表主键
            ////prd.record.PayNo1 = "PayNo" + DateTime.Now.ToString();
            ////insert
            //prd.insertData();

            ////循环设置子表外键，并insert子表
            //dal.PAY_DETAILS_DAL pdd = new dal.PAY_DETAILS_DAL();
            //foreach (PAY_DETAILS item in (Application.Current as App).pdlist)
            //{
            //    pdd.detail = item;
            //    pdd.detail.PayNo1 = prd.record.PayNo1;
            //    pdd.insertData();
            //}

            Frame.Navigate(typeof(MyPay), null);
        }

        private void but_back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BuyMain), null);
        }

        private void but_min_Click(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;
            Windows.UI.Xaml.Controls.StackPanel stackp = but.Parent as StackPanel;
            PAY_DETAILS pds = null;
            int num = 0;
            foreach (var item in stackp.Children)
            {
                TextBlock tb = item as TextBlock;
                if (tb == null)
                    continue;
                else
                {
                    pds = tb.DataContext as PAY_DETAILS;
                    string abc = tb.Text;
                    int.TryParse(abc, out num);
                    num--;
                    if (num < 0)
                        num = 0;


                    tb.Text = num.ToString();
                    break;
                }
            }
            if (pds != null)
            {

                if (num == 0)
                    pds.PayAmount1 = 0;
                else
                {
                    double bakamount = pds.PayAmount1;
                    double am = 0;
                    double.TryParse(orderamount.Text, out am);
                    pds.PayAmount1 = num * pds.UnitPrice1;
                    orderamount.Text = (am - bakamount + pds.PayAmount1).ToString();
                }
                pds.OutNum1 = num;
            }
        }

        private void but_add_Click(object sender, RoutedEventArgs e)
        {
            Button but = sender as Button;
            Windows.UI.Xaml.Controls.StackPanel stackp = but.Parent as StackPanel;
            PAY_DETAILS pds = null;
            int num = 0;
            foreach (var item in stackp.Children)
            {
                TextBlock tb = item as TextBlock;
                if (tb == null)
                    continue;
                else
                {
                    pds = tb.DataContext as PAY_DETAILS;
                    string abc = tb.Text;
                    int.TryParse(abc, out num);
                    num++;

                    if (pds != null)
                    {
                        List<PRODUCT> pt = (Application.Current as App).plist.Where(a => a.ChannelCode1 == pds.ChannelCode1).ToList();
                        if (pt.Count > 0)
                        {
                            if (double.Parse(num.ToString()) > pt[0].CapacityNum)
                            {
                                num--;
                            }
                        }
                        pds.OutNum1 = num;
                        if (pds.OutNum1 == 0)
                            pds.PayAmount1 = 0;
                        else
                        {
                            double bakamount = pds.PayAmount1;
                            double am = 0;
                            double.TryParse(orderamount.Text, out am);
                            pds.PayAmount1 = pds.OutNum1 * pds.UnitPrice1;
                            orderamount.Text = (am - bakamount + pds.PayAmount1).ToString();
                        }
                    }
                    tb.Text = num.ToString();
                    break;
                }
            }

        }
    }
}

