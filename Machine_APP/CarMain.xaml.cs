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
        }

        //跳转付款画面
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //主表
            string payNo = "payNo" + DateTime.Now.ToString();
            double amount = 0;
            int num = 0;
            for (int i = 0; i < (Application.Current as App).pdlist.Count(); i++)
            {
                amount += (Application.Current as App).pdlist[i].PayAmount1;
                num += (Application.Current as App).pdlist[i].OutNum1;
            }
                        (Application.Current as App).pr = new PAY_RECORD(payNo, "payUserID",
             "channelCode", "machineCode", 0, "payType", "payAccount", amount, 0, num, 0.00, 0.00, 0.00,
            0.00, 0.00, 0, " cashCode", "reator", DateTime.Now, "modifier", DateTime.Now);


            dal.PAY_RECORD_DAL prd = new dal.PAY_RECORD_DAL((Application.Current as App).pr);
            //主表主键
            //prd.record.PayNo1 = "PayNo" + DateTime.Now.ToString();
            //insert
            prd.insertData();

            //循环设置子表外键，并insert子表
            dal.PAY_DETAILS_DAL pdd = new dal.PAY_DETAILS_DAL();
            foreach (PAY_DETAILS item in (Application.Current as App).pdlist)
            {
                pdd.detail = item;
                pdd.detail.PayNo1 = prd.record.PayNo1;
                pdd.insertData();
            }

            Frame.Navigate(typeof(MyPay), null);
        }
    }
}
