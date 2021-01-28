using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine_APP.model
{
    public class Json_restun
    {
        string count;
        string hasMore;
        string data;
        string code;
        string name;
        string msg;

        public Json_restun(string count, string hasMore, string data, string code, string name, string msg)
        {
            this.count = count;
            this.hasMore = hasMore;
            this.data = data;
            this.code = code;
            this.name = name;
            this.msg = msg;
        }

        public string Count { get => count; set => count = value; }
        public string HasMore { get => hasMore; set => hasMore = value; }
        public string Data { get => data; set => data = value; }
        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Msg { get => msg; set => msg = value; }

    }
}
