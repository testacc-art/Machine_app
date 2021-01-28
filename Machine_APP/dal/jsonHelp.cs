using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Machine_APP.dal
{
    public class jsonHelp
    {

        public static DataTable jsonTOdatatable(string JsonStr)
        {
            try
            {
                //JsonStr为Json字符串
                JArray array = JsonConvert.DeserializeObject(JsonStr) as JArray;//反序列化为数组
                if (array.Count > 0)
                {
                    StringBuilder columns = new StringBuilder();
                    DataTable table = new DataTable();
                    JObject objColumns = array[0] as JObject;
                    //构造表头
                    foreach (JToken jkon in objColumns.AsEnumerable<JToken>())
                    {
                        string name = ((JProperty)(jkon)).Name;
                        columns.Append(name + ",");
                        table.Columns.Add(name);
                    }
                    //向表中添加数据
                    for (int i = 0; i < array.Count; i++)
                    {
                        DataRow row = table.NewRow();
                        JObject obj = array[i] as JObject;
                        foreach (JToken jkon in obj.AsEnumerable<JToken>())
                        {

                            string name = ((JProperty)(jkon)).Name;
                            string value = ((JProperty)(jkon)).Value.ToString();
                            row[name] = value;
                        }
                        table.Rows.Add(row);
                    }
                    return table;
                }
                else return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
