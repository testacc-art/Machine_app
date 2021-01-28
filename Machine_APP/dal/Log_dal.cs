using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine_APP.dal
{
    public class Log_dal
    {
        public void addLog(int type, string mess, string createDT, string user)
        {
            try
            {
                DBhelp db = new DBhelp();
                string sqlcouint = @"select max(id) from app_log ";
                int countnum = db.MAXData(sqlcouint);
                countnum++;
                string insertsql = string.Format(@"insert into app_log values({0},{1},'{2}','{3}', '{4}')", countnum.ToString(), type, mess, createDT, user);
                db.InsertRow(insertsql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
