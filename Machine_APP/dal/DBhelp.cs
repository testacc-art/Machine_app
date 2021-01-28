using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine_APP.model;
namespace Machine_APP.dal
{
    public class DBhelp
    {
        string dbname = "";
        public DBhelp()
        {
            //配置处
            dbname = "IoTDB.sdf";
        }
        private SQLiteConnection CreateDbConnection(string dbname)
        {
            //创建连接
            try
            {
                SQLiteConnection connection = new SQLiteConnection(dbname);
                if (null == connection)
                {
                    throw new Exception("create db connection failed");
                }
                return connection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private SQLiteConnection CreateDbConnection()
        {
            try
            {
                //创建连接
                SQLiteConnection connection = new SQLiteConnection(dbname);
                return connection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateBaseTable()
        {
            //创建表
            SQLiteConnection connection = new SQLiteConnection(dbname);
            string sql = string.Format(@"create table APP_SYS_CONFIG (
   ConfigNo             nvarchar(50)         not null, --配置编号
   ConfigName           nvarchar(50)         null, --参数名称
   ConfigType           nvarchar(50)         null, --参数类型
   MachineCode          nvarchar(50)         null, --机器编号
   constraint PK_APP_SYS_CONFIG primary key(ConfigNo)
)");
            using (ISQLiteStatement SQLiteConnection = connection.Prepare(sql))
            {
                //执行语句
                SQLiteConnection.Step();
            }

            sql = string.Format(@"create table APP_SYS_SETTING (
   MachineCode          nvarchar(50)         not null,
   ChannelCount         int                  null,
   LayerRowCount        int                  null,
   LayerColumnCount     int                  null,
   RequeryUrl           nvarchar(300)        null,
   ICardPassword        nvarchar(20)         null,
   MachineAddress       nvarchar(500)        null,
   Longitude            float                null,
   Latitude             float                null,
   AdvertisementDirectory nvarchar(300)        null,
   IsDisplayPic         int                  null,
   IsCheckBox           int                  null,
   RunMode              int                  null,
   Creator              nvarchar(50)         null,
   CreateTime           datetime             null,
   Modifier             nvarchar(50)         null,
   ModifyDate           datetime             null,
   AlertMobile          nvarchar(25)         null,
   AlertEmail           nvarchar(50)         null,
   AppVersionID         nvarchar(50)         null,
   constraint PK_APP_SYS_SETTING primary key (MachineCode)
)");
            using (ISQLiteStatement SQLiteConnection = connection.Prepare(sql))
            {
                //执行语句
                SQLiteConnection.Step();
            }

            sql = string.Format(@"create table APP_PAY_DETAILS (
   PayDetailNo          nvarchar(50)         not null,
   PayNo                nvarchar(50)         null,
   MachineCode          nvarchar(50)         null,
   ChannelCode          nvarchar(50)         null,
   ProductCode          nvarchar(50)         null,
   ProductName          nvarchar(50)         null,
   PictureUrl           nvarchar(250)        null,
   IsPayComplated       int                  null,
   PayAmount            decimal(18,2)        null,
   Amount               decimal(18,2)        null,
   IsOutStatus          int                  null,
   UnitPrice            decimal(18,2)        null,
   OutNum               int                  null,
   FinishOutNum         int                  null,
   ReturnAmount         decimal(18,2)        null,
   OutDetailNum         int                  null,
   OutDetailDate        datetime             null,
   OutDetailAuditor     nvarchar(50)         null,
   AuditRefundAmount    decimal(18,2)        null,
   Creator              varchar(50)          null,
   CreateDate           datetime             null,
   Modifier             nvarchar(50)         null,
   ModifyDate           datetime             null,
   constraint PK_APP_PAY_DETAILS primary key (PayDetailNo)
)");
            using (ISQLiteStatement SQLiteConnection = connection.Prepare(sql))
            {
                //执行语句
                SQLiteConnection.Step();
            }

            sql = string.Format(@"create table APP_PAY_RECORD (
   PayNo                nvarchar(50)          not null,
   PayUserID            nvarchar(50)         null,
   ChannelCode          nvarchar(50)         null,
   MachineCode          nvarchar(50)         null,
   IsPayComplated       int                  null,
   PayType              nvarchar(50)         null,
   PayAccount           nvarchar(100)        null,
   PayAmount            decimal(18,2)        null,
   IsFinishSale         int                  null,
   OutSaleNum           int                  null,
   ReturnAmount         decimal(18,2)        null,
   FinishReturnAmount   decimal(18,2)        null,
   ReturnNum            decimal(18,2)        null,
   CashAmount           decimal(18,2)        null,
   ChangeAmount         decimal(18,2)        null,
   CashGenerateStatus   int                  null,
   CashCode             nvarchar(50)         null,
   Creator              varchar(50)         null,
   CreateDate           datetime             null,
   Modifier             nvarchar(50)          null,
   ModifyDate           datetime             null,
   constraint PK_APP_PAY_RECORD primary key (PayNo)
)");
            using (ISQLiteStatement SQLiteConnection = connection.Prepare(sql))
            {
                //执行语句
                SQLiteConnection.Step();
            }

            sql = string.Format(@"create table APP_PRODUCT (
   ChannelCode          nvarchar(50)         not null,
   MachineType          int                  null,
   MachineCode          nvarchar(50)         not null,
   ProductName          nvarchar(50)         null,
   Price                float                null,
   DiscountPrice        float                null,
   DiscountDate         nvarchar(25)         null,
   XFlag                float                null,
   YFlag                float                null,
   ChannelStatus        int                  null,
   PictureUrl           nvarchar(300)        null,
   ChannelLength        float                null,
   ChannelWidth         float                null,
   ChannelType          int                  null,
   ProductNum           float                null,
   CapacityNum          float                null,
   IsDisable            int                  null,
   Creator              nvarchar(50)         null,
   CreateDate           datetime             null,
   Modifier             nvarchar(50)         null,
   ModifyDate           datetime             null,
   constraint PK_APP_PRODUCT primary key (ChannelCode, MachineCode)
)");
            using (ISQLiteStatement SQLiteConnection = connection.Prepare(sql))
            {
                //执行语句
                SQLiteConnection.Step();
            }
            sql = string.Format(@"create table APP_FINISHOUT_DETAILS (
   FinishOutID          nvarchar(50)         not null,
   PayNo                nvarchar(50)         null,
   PayDetailNo          nvarchar(50)         null,
   MachineCode          nvarchar(50)         null,
   ChannelCode          nvarchar(50)         null,
   ProductCode          nvarchar(50)         null,
   ProductName          nvarchar(50)         null,
   FinishOutNum         int                  null,
   UnitPrice            decimal(18,2)        null,
   Temperature          decimal(18,2)        null,
   FanTemperature       decimal(18,2)        null,
   Memo                 nvarchar(100)        null,
   Creator              varchar(50)          null,
   CreateDate           datetime             null,
   Modifier             nvarchar(50)         null,
   ModifyDate           datetime             null,
   constraint PK_APP_FINISHOUT_DETAILS primary key (FinishOutID)
)");
            using (ISQLiteStatement SQLiteConnection = connection.Prepare(sql))
            {
                //执行语句
                SQLiteConnection.Step();
            }
            sql = string.Format(@"create table APP_LOG(
id int identity(1,1),
type int null,
message text not null,
createTime datetime  not null,
user nvarchar(50) null
)"); 
            using (ISQLiteStatement SQLiteConnection = connection.Prepare(sql))
            {
                //执行语句
                SQLiteConnection.Step();
            }

        }


        public SQLiteResult InsertRow(string sql)
        {
            SQLiteResult sr = new SQLiteResult();
            //插入数据
            SQLiteConnection connection = new SQLiteConnection(dbname);
            using (ISQLiteStatement sqliteStatement = connection.Prepare(sql))
            {
                //执行语句
                sr = sqliteStatement.Step();
            }
            return sr;
        }

        public SQLiteResult UpdateRow(string sql)
        {
            SQLiteResult sr = new SQLiteResult();
            SQLiteConnection connection = new SQLiteConnection(dbname);
            using (ISQLiteStatement sqliteStatement = connection.Prepare(sql))
            {
                //执行语句
                sr = sqliteStatement.Step();
            }
            return sr;
        }

        public SQLiteResult DeleteRow(string sql)
        {
            SQLiteResult sr = new SQLiteResult();
            SQLiteConnection connection = new SQLiteConnection(dbname);
            using (ISQLiteStatement sqliteStatement = connection.Prepare(sql))
            {

                //执行语句
                sr = sqliteStatement.Step();
            }

            return sr;
        }


        public int MAXData(string sql)
        {
            SQLiteConnection connection = new SQLiteConnection(dbname);

            SQLiteResult result;
            int a = 0;
            using (var statment = connection.Prepare(sql))
            {

                result = statment.Step();
                //if (SQLiteResult.ROW == result)
                //{
                //    var s = statment[1];
                //    var r = statment[0];
                //}
                a = int.Parse(statment[0].ToString());
            }
            return a;
        }

        public SQLiteResult ReadData(string sql)
        {
            SQLiteConnection connection = new SQLiteConnection(dbname);

            SQLiteResult result;
            using (var statment = connection.Prepare(sql))
            {

                result = statment.Step();
                if (SQLiteResult.ROW == result)
                {
                    var s = statment[1];
                    var r = statment[0];
                }

            }
            return result;
        }


        public string getcount(string sql)
        {
            string countum = "";
            SQLiteConnection connection = new SQLiteConnection(dbname);

            SQLiteResult result;
            using (var statment = connection.Prepare(sql))
            {

                result = statment.Step();
                if (SQLiteResult.ROW == result)
                {
                    var s = statment[1];
                    countum = statment[0].ToString();
                }

            }
            return countum;
        }

        public PRODUCT getsinglePRODUCT(string sql)
        {
            SQLiteConnection connection = new SQLiteConnection(dbname);
            SQLiteResult result;
            using (var statment = connection.Prepare(sql))
            {
                result = statment.Step();
                if (SQLiteResult.ROW == result)
                {
                    PRODUCT p = new PRODUCT();
                    p.ChannelCode1 = statment[1].ToString();
                    int inttype = 0;
                    double doubletype = 0;
                    int.TryParse(statment[2].ToString(), out inttype);
                    p.MachineType1 = inttype;
                    p.MachineCode1 = statment[3].ToString();
                    p.ProductName1 = statment[4].ToString();
                    double.TryParse(statment[5].ToString(), out doubletype);
                    p.Price1 = doubletype;
                    doubletype = 0;
                    double.TryParse(statment[6].ToString(), out doubletype);
                    p.DiscountPrice1 = doubletype;
                    p.DiscountDate1 = statment[7].ToString();
                    doubletype = 0;
                    double.TryParse(statment[8].ToString(), out doubletype);
                    p.XFlag1 = doubletype;
                    doubletype = 0;
                    double.TryParse(statment[9].ToString(), out doubletype);
                    p.YFlag1 = doubletype;
                    inttype = 0;
                    int.TryParse(statment[10].ToString(), out inttype);
                    p.ChannelStatus1 = inttype;
                    p.PictureUrl1 = statment[11].ToString();
                    doubletype = 0;
                    double.TryParse(statment[12].ToString(), out doubletype);
                    p.ChannelLength1 = doubletype;
                    doubletype = 0;
                    double.TryParse(statment[13].ToString(), out doubletype);
                    p.ChannelWidth1 = doubletype;
                    inttype = 0;
                    int.TryParse(statment[14].ToString(), out inttype);
                    p.ChannelType1 = inttype;
                    doubletype = 0;
                    double.TryParse(statment[15].ToString(), out doubletype);
                    p.ProductNum1 = doubletype;
                    doubletype = 0;
                    double.TryParse(statment[16].ToString(), out doubletype);
                    p.CapacityNum1 = doubletype;
                    inttype = 0;
                    int.TryParse(statment[17].ToString(), out inttype);
                    if (inttype == 1)
                        p.IsDisable1 = true;
                    else
                        p.IsDisable1 = false;
                    p.Creator1 = statment[18].ToString();
                    DateTime dtime = DateTime.Now;
                    DateTime.TryParse(statment[19].ToString(), out dtime);
                    p.CreateDate1 = dtime;
                    p.Modifier1 = statment[20].ToString();
                    dtime = DateTime.Now;
                    DateTime.TryParse(statment[21].ToString(), out dtime);
                    p.ModifyDate1 = dtime;
                    return p;
                }
                else return null;

            }

        }

        public SYS_CONFIG getsinglesysconfig(string sql)
        {
            SQLiteConnection connection = new SQLiteConnection(dbname);
            SQLiteResult result;
            using (var statment = connection.Prepare(sql))
            {
                result = statment.Step();
                if (SQLiteResult.ROW == result)
                {
                    SYS_CONFIG p = new SYS_CONFIG();
                    p.ConfigNo = statment[0].ToString();
                   p.ConfigName = statment[1].ToString();
                    p.ConfigType = statment[2].ToString();
                    p.MachineCode = statment[3].ToString();
                    return p;
                }
                else return null;

            }
        }


        public SYS_SETTING getsinglesysset(string sql)
        {
            SQLiteConnection connection = new SQLiteConnection(dbname);
            SQLiteResult result;
            using (var statment = connection.Prepare(sql))
            {
                result = statment.Step();
                if (SQLiteResult.ROW == result)
                {
                    SYS_SETTING p = new SYS_SETTING();
                   
                    return p;
                }
                else return null;

            }
        }



        #region 暂时不用
        private void InsertRow(SQLiteConnection connection, string name)
        {
            //插入数据
            string sql = string.Format("insert into {0} (name) values (?)", "tablename");
            using (ISQLiteStatement sqliteStatement = connection.Prepare(sql))
            {
                //绑定参数
                sqliteStatement.Bind(1, name);
                //执行语句
                sqliteStatement.Step();
            }
        }


        private void UpdateRow(SQLiteConnection connection, string newName, string oldName)
        {
            string sql = string.Format("update {0} set name = ? where name = ?", "tablename");
            using (ISQLiteStatement sqliteStatement = connection.Prepare(sql))
            {
                //绑定参数
                sqliteStatement.Bind(1, newName);
                sqliteStatement.Bind(2, oldName);
                //执行语句
                sqliteStatement.Step();
            }
        }

        private void DeleteRow(SQLiteConnection connection, string name)
        {
            string sql = string.Format("delete from {0} where name = ?", name);
            using (ISQLiteStatement sqliteStatement = connection.Prepare(sql))
            {
                //绑定参数
                sqliteStatement.Bind(1, name);
                //执行语句
                sqliteStatement.Step();
            }



        }
        #endregion
    }
}
