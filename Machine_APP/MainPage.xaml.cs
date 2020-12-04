using SQLitePCL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace Machine_APP
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary> 
    public sealed partial class MainPage : Page // , INotifyPropertyChanged
    {
        //List<PRODUCT> plist = new List<PRODUCT>();
        //PAY_RECORD prlist = new PAY_RECORD();
        //List<PAY_DETAILS> pdlist = new List<PAY_DETAILS>();
        public MainPage()
        {
            this.InitializeComponent();
           


        }


        private void min_Click(object sender, RoutedEventArgs e)
        {
            string basename = ((Windows.UI.Xaml.FrameworkElement)sender).Name;
            Grid gd = this.Content as Grid;
            Grid grid_1 = null;
            Windows.UI.Xaml.Controls.StackPanel sp = null;
            foreach (var item in gd.Children)
            {
                if (((Windows.UI.Xaml.FrameworkElement)item).Name == "grid_1")
                {
                    grid_1 = item as Grid;
                    break;
                }
            }
            foreach (var item1 in grid_1.Children)
            {
                string name1 = basename.Replace("min", "sp");
                if (((Windows.UI.Xaml.FrameworkElement)item1).Name == name1)
                {
                    sp = item1 as StackPanel;
                    break;
                }
            }
            foreach (var item2 in sp.Children)
            {
                string txtname = basename.Replace("min", "txt");
                if (((Windows.UI.Xaml.FrameworkElement)item2).Name == txtname)
                {
                    TextBox tx = item2 as TextBox;
                    int num = int.Parse(tx.Text);
                    if (num <= 0)
                        tx.Text = "0";
                    else
                        tx.Text = (num - 1).ToString();
                    //划重点
                    string name = basename.Replace("min", "mame");
                    List<PAY_DETAILS> list = (Application.Current as App).pdlist.Where(a => a.ProductName1 == basename.Replace("min_1_", "ProductName00")).ToList();
                    if (tx.Text == "0")
                    {
                        list.Remove(list[0]);
                    }
                    else
                    {
                        PAY_DETAILS listbak = list[0];
                        (Application.Current as App).pdlist.Remove(list[0]);
                        listbak.OutNum1 = int.Parse(tx.Text);
                        listbak.PayAmount1 = int.Parse(tx.Text) * listbak.UnitPrice1;
                        (Application.Current as App).pdlist.Add(listbak);

                    }



                    break;
                }
            }
        }
        private void add_Click(object sender, RoutedEventArgs e)
        {
            string basename = ((Windows.UI.Xaml.FrameworkElement)sender).Name;
            Grid gd = this.Content as Grid;
            Grid grid_1 = null;
            Windows.UI.Xaml.Controls.StackPanel sp = null;
            foreach (var item in gd.Children)
            {
                if (((Windows.UI.Xaml.FrameworkElement)item).Name == "grid_1")
                {
                    grid_1 = item as Grid;
                    break;
                }
            }
            foreach (var item1 in grid_1.Children)
            {
                string name1 = basename.Replace("add", "sp");
                if (((Windows.UI.Xaml.FrameworkElement)item1).Name == name1)
                {
                    sp = item1 as StackPanel;
                    break;
                }
            }
            foreach (var item2 in sp.Children)
            {
                string txtname = basename.Replace("add", "txt");
                if (((Windows.UI.Xaml.FrameworkElement)item2).Name == txtname)
                {
                    TextBox tx = item2 as TextBox;
                    int num = int.Parse(tx.Text);
                    num++;
                    tx.Text = num.ToString();
                    string name = basename.Replace("add", "mame");
                    if (tx.Text != "0")
                    {
                        List<PAY_DETAILS> list = (Application.Current as App).pdlist.Where(a => a.ProductName1 == basename.Replace("add_1_", "ProductName00")).ToList();
                        if (list.Count > 0)
                        {
                            PAY_DETAILS listbak = list[0];
                            (Application.Current as App).pdlist.Remove(list[0]);
                            listbak.OutNum1 = int.Parse(tx.Text);
                            listbak.PayAmount1 = int.Parse(tx.Text) * listbak.UnitPrice1;
                            (Application.Current as App).pdlist.Add(listbak);

                        }
                        else
                        {
                            string vw = DateTime.Now.ToString();
                            PAY_DETAILS pd = new PAY_DETAILS("paydetailno" + vw, "", "MachineCode001", "ChannelCode001", basename.Replace("add_1_", "Productcode00")
                                , basename.Replace("add_1_", "ProductName00"), "", 0, 0, 1.11 * num, 0, 1.11, num, 0, 0, 0, DateTime.Now, "", DateTime.Now, "creator", DateTime.Now, "modifier", DateTime.Now);
                            (Application.Current as App).pdlist.Add(pd);
                        }



                    }


                    break;
                }
            }

        }

        private void but_car_Click(object sender, RoutedEventArgs e)
        {


            Frame.Navigate(typeof(MyCar), null);


            //CoreApplicationView newView = CoreApplication.CreateNewView();

            //int newViewId = 0;
            //Frame frame = new Frame();

            //frame.Navigate(typeof(MyCar), null);

            //Window.Current.Content = frame;
            //Window.Current.Activate();
            //newViewId = ApplicationView.GetForCurrentView().Id;
            //ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
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


        //#region Fields
        ////数据库名
        //private string _dbName;
        ////表名
        //private string _tableName;
        ////name字段的数据集合
        //private string[] _names = { "IoT-1", "IoT-2", "IoT-3" };

        //#endregion

        //#region Events

        //public event PropertyChangedEventHandler PropertyChanged;

        //#endregion

        //#region Properties

        //private string _result;
        ////操作结果
        //public string Result
        //{
        //    get
        //    {
        //        return _result;
        //    }

        //    set
        //    {
        //        _result = value;
        //        OnPropertyChanged("Result");
        //    }
        //}

        //#endregion

        //#region Constructor



        //#endregion

        //#region Methods

        //private SQLiteConnection CreateDbConnection()
        //{
        //    //创建连接
        //    SQLiteConnection connection = new SQLiteConnection(_dbName);
        //    if (null == connection)
        //    {
        //        throw new Exception("create db connection failed");
        //    }
        //    return connection;
        //}

        //private void CreateTable(SQLiteConnection connection)
        //{
        //    //创建表
        //    string sql = string.Format("create table if not exists {0} (id integer primary key autoincrement,name text)", _tableName);
        //    using (ISQLiteStatement sqliteStatement = connection.Prepare(sql))
        //    {
        //        //执行语句
        //        sqliteStatement.Step();
        //    }
        //}

        //private void InsertRow(SQLiteConnection connection, string name)
        //{
        //    //插入数据
        //    string sql = string.Format("insert into {0} (name) values (?)", _tableName);
        //    using (ISQLiteStatement sqliteStatement = connection.Prepare(sql))
        //    {
        //        //绑定参数
        //        sqliteStatement.Bind(1, name);
        //        //执行语句
        //        sqliteStatement.Step();
        //    }
        //}

        //private void UpdateRow(SQLiteConnection connection, string newName, string oldName)
        //{
        //    string sql = string.Format("update {0} set name = ? where name = ?", _tableName);
        //    using (ISQLiteStatement sqliteStatement = connection.Prepare(sql))
        //    {
        //        //绑定参数
        //        sqliteStatement.Bind(1, newName);
        //        sqliteStatement.Bind(2, oldName);
        //        //执行语句
        //        sqliteStatement.Step();
        //    }
        //}

        //private void DeleteRow(SQLiteConnection connection, string name)
        //{
        //    string sql = string.Format("delete from {0} where name = ?", _tableName);
        //    using (ISQLiteStatement sqliteStatement = connection.Prepare(sql))
        //    {
        //        //绑定参数
        //        sqliteStatement.Bind(1, name);
        //        //执行语句
        //        sqliteStatement.Step();
        //    }



        //}

        //public void OnPropertyChanged(string propertyName)
        //{
        //    //MVVM依赖属性事件
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        //#endregion


        ///// <summary>
        ///// 读取数据库数据
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public SQLiteResult ReadData()
        //{
        //    SQLiteConnection connection = CreateDbConnection();

        //    SQLiteResult result;
        //    using (var statment = connection.Prepare("select * from users where name ='leon';"))
        //    {

        //        result = statment.Step();
        //        if (SQLiteResult.ROW == result)
        //        {


        //            var s = statment[1];
        //            var r = statment["name"];
        //        }

        //    }
        //    return result;
        //}

        //private void button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    //SQLiteConnection connection = CreateDbConnection();
        //    //string sql = sqltext.Text;
        //    //SQLiteException exc = new SQLiteException(sql);
        //    SQLiteConnection connection = CreateDbConnection();
        //    connection = CreateDbConnection();
        //    InsertRow(connection, "leon");
        //    User u = new User();
        //    u.Name = "leon";
        //    ReadData();
        //}
    }
}
