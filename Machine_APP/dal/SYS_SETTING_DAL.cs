using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine_APP.dal
{
   
    public class SYS_SETTING_DAL
    {
        public SYS_SETTING config = null;
        DBhelp db = new DBhelp();
        public List<SYS_SETTING> getlist()
        {
            try
            {
                List<SYS_SETTING> configs = new List<SYS_SETTING>();
                string sqlbing = @"SELECT * FROM SYS_CONFIG";
                SYS_SETTING p = db.getsinglesysset(sqlbing);
                configs.Add(p);

                return configs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 更新SYS_CONFIG
        /// </summary>
        /// <param name="sql"></param>
        public void updateforsql(string sql)
        {
            try
            {
                DBhelp db = new DBhelp();
                db.UpdateRow(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
