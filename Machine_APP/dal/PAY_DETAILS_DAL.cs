using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine_APP.dal
{
    public class PAY_DETAILS_DAL
    {
        public PAY_DETAILS detail = null;
        DBhelp db = new DBhelp();
        public PAY_DETAILS_DAL()
        { }
        public PAY_DETAILS_DAL(PAY_DETAILS ds)
        {
            detail = ds;
        }
        public int insertData()
        {
            string sql = string.Format(@"INSERT INTO  APP_PAY_DETAILS  (PayDetailNo, PayNo, MachineCode, ChannelCode, ProductCode, ProductName, PictureUrl, IsPayComplated, 
PayAmount, Amount, IsOutStatus, UnitPrice, OutNum, FinishOutNum, ReturnAmount, OutDetailNum, OutDetailDate, OutDetailAuditor, AuditRefundAmount, 
Creator, CreateDate, Modifier, ModifyDate) 
VALUES ( '{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},{8},{9},{10},{11},{12},{13},{14},{15},'{16}','{17}',{18},'{19}','{20}','{21}','{22}');", detail.PayDetailNo1,detail.PayNo1,
detail.MachineCode1, detail.ChannelCode1, detail.ProductCode1, detail.ProductName1, detail.PictureUrl1, detail.IsPayComplated1, detail.PayAmount1, detail.Amount1, detail.IsOutStatus1,
detail.UnitPrice1, detail.OutNum1, detail.FinishOutNum1, detail.ReturnAmount1, detail.OutDetailNum1, detail.OUtDetailDate, detail.OutNum1, detail.FinishOutNum1, detail.ReturnAmount1
, detail.OutDetailNum1, detail.OUtDetailDate, detail.OutDetailAuditor1, detail.AuditRefundAmount1, detail.Creator1, detail.CreateDate1, detail.Modifier1, detail.ModifyDate1);
            SQLitePCL.SQLiteResult sr = db.InsertRow(sql);
            if (sr == SQLitePCL.SQLiteResult.DONE)
                return 1;
            else
                return 0;
        }

        public int updateData()
        {
            string sql = string.Format(@"update  APP_PAY_DETAILS  set  PayNo='{1}', MachineCode='{2}', ChannelCode='{3}', ProductCode={4}, ProductName='{5}', PictureUrl='{6}', IsPayComplated={7}, 
PayAmount={8}, Amount={9}, IsOutStatus={10}, OunitPrice{11}=, OutNum={12}, FinishOutNum={13}, ReturnAmount={14}, OutDetailNum={15}, OutDetailDate='{16}', OutDetailAuditor='{17}', AuditRefundAmount={18}, 
Creator='{19}', CreateDate='{20}', Modifier='{21}', ModifyDate='{22}'
where PayDetailNo='{0}'
", detail.PayDetailNo1, detail.PayNo1,
detail.MachineCode1, detail.ChannelCode1, detail.ProductCode1, detail.ProductName1, detail.PictureUrl1, detail.IsPayComplated1, detail.PayAmount1, detail.Amount1, detail.IsOutStatus1,
detail.UnitPrice1, detail.OutNum1, detail.FinishOutNum1, detail.ReturnAmount1, detail.OutDetailNum1, detail.OUtDetailDate, detail.OutNum1, detail.FinishOutNum1, detail.ReturnAmount1
, detail.OutDetailNum1, detail.OUtDetailDate, detail.OutDetailAuditor1, detail.AuditRefundAmount1, detail.Creator1, detail.CreateDate1, detail.Modifier1, detail.ModifyDate1);

            SQLitePCL.SQLiteResult sr = db.UpdateRow(sql);

            if (sr == SQLitePCL.SQLiteResult.DONE)
                return 1;
            else
                return 0;
        }

    }
}