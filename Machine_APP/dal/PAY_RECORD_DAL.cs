using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine_APP;
namespace Machine_APP.dal
{
    public class PAY_RECORD_DAL
    {
        public PAY_RECORD record = null;
        DBhelp db = new DBhelp();
        public PAY_RECORD_DAL(PAY_RECORD pre)
        {
            record = pre;

        }

        public int insertData()
        {
            string sql = string.Format(@"insert into APP_PAY_RECORD (
   PayNo                ,
   PayUserID            ,
   ChannelCode          ,
   MachineCode          ,
   IsPayComplated       ,
   PayType              ,
   PayAccount           ,
   PayAmount            ,
   IsFinishSale         ,
   OutSaleNum           ,
   ReturnAmount         ,
   FinishReturnAmount   ,
   ReturnNum            ,
   CashAmount           ,
   ChangeAmount         ,
   CashGenerateStatus   ,
   CashCode             ,
   Creator              ,
   CreateDate           ,
   Modifier             ,
   ModifyDate           )
  values(
  '{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}',{8},{9},'{10}','{11}','{12}','{13}','{14}',{15},'{16}','{17}','{18}','{19}','{20}'
  )", record.PayNo1, record.PayUserID1, record.ChannelCode1, record.MachineCode1, record.IsPayComplated1, record.PayType1, record.PayAccount1,
  record.PayAmount1, record.IsFinishSale1, record.OutSaleNum1, record.ReturnAmount1, record.FinishReturnAmount1, record.ReturnNum1, record.CashAmount1, record.ChangeAmount1,
  record.CashGenerateStatus1, record.CashCode1, record.Creator1, DateTime.Now.ToString(), record.Modifier1, DateTime.Now.ToString()
  );


            SQLitePCL.SQLiteResult sr = db.InsertRow(sql);

            if (sr == SQLitePCL.SQLiteResult.DONE)
                return 1;
            else
                return 0;
        }

        public int updateData()
        {
            string sql = string.Format(@"update  APP_PAY_RECORD set
              
   PayUserID  =   '{1}'       ,
   ChannelCode  =  '{2}'      ,
   MachineCode  =  '{3}'      ,
   IsPayComplated = {4}     ,
   PayType       =   '{5}'    ,
   PayAccount    =  '{6}'     ,
   PayAmount       =  '{7}'   ,
   IsFinishSale    =  {8}   ,
   OutSaleNum      =  {9}   ,
   ReturnAmount     =  '{10}'  ,
   FinishReturnAmount = '{11}' ,
   ReturnNum         = '{12}'  ,
   CashAmount        ='{13}'   ,
   ChangeAmount      = '{14}'  ,
   CashGenerateStatus={15} ,
   Modifier   =   '{16}'       ,  ,
   CashCode =    '{17}'        ,
   Creator  =    '{18}'        ,
   CreateDate  =  '{19}'       
   ModifyDate = '{20}' where  PayNo =   '{0}'
  ", record.PayNo1, record.PayUserID1, record.ChannelCode1, record.MachineCode1, record.IsPayComplated1, record.PayType1, record.PayAccount1,
  record.PayAmount1, record.IsFinishSale1, record.OutSaleNum1, record.ReturnAmount1, record.FinishReturnAmount1, record.ReturnNum1, record.CashAmount1, record.ChangeAmount1,
  record.CashGenerateStatus1, record.CashCode1, record.Creator1, DateTime.Now.ToString(), record.Modifier1, DateTime.Now.ToString()
  );

            SQLitePCL.SQLiteResult sr = db.UpdateRow(sql);

            if (sr == SQLitePCL.SQLiteResult.DONE)
                return 1;
            else
                return 0;
        }

        public string selectSingleDate(string where)
        {
            string sql = "select * from APP_PAY_RECORD where 1=1 ";
            sql = sql + where;
            return sql;
        }

    }

}
