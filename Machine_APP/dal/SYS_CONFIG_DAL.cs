using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine_APP.dal
{
    public class SYS_CONFIG_DAL
    {
        public SYS_CONFIG config = null;
        DBhelp db = new DBhelp();
        public List<SYS_CONFIG> getlist()
        {
            try
            {
                List<SYS_CONFIG> configs = new List<SYS_CONFIG>();
                string sqlbing = @"SELECT * FROM APP_SYS_CONFIG";
                SYS_CONFIG p = db.getsinglesysconfig(sqlbing);
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
