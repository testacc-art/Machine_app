using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Machine_APP.dal
{
    public class app_Interface
    {
        public app_Interface() { }

        public static async Task<string> PostHttpstringrequest(string requesturl, string jsonstr)
        {
            try
            {
                //jsonstr = "{\"PayType\":\"2\",\"PayNo\":\"XM2222200012345678951234\",\"CreateDate\":\"2019-10-27 09:35:51.195\",\"Creator\":\"CJXM17060001\",\"MPayDetailList\":[{\"ProductName\":\"西芹\",\"ChannelCode\":\"3\",\"CreateDate\":\"2019-10-27 09:35:51.212\",\"Creator\":\"CJXM17060001\",\"PictureUrl\":\"genjin_1\",\"PayNo\":\"XM2222200012345678951234\",\"PayDetailNo\":\"XM2222200000000000000001\",\"MachineCode\":\"CJXM17060001\",\"PayAmount\":1,\"OutNum\":1,\"IsPayComplated\":0,\"IsOutStatus\":0,\"FinishOutNum\":0,\"Amount\":2.0,\"ReturnAmount\":0.0,\"UnitPrice\":1.0},{\"ProductName\":\"黄瓜\",\"ChannelCode\":\"3\",\"CreateDate\":\"2019-10-27 09:35:51.212\",\"Creator\":\"CJXM17060001\",\"PictureUrl\":\"genjin_1\",\"PayNo\":\"XM2222200012345678951234\",\"PayDetailNo\":\"XM2222200000000000000002\",\"MachineCode\":\"CJXM17060001\",\"PayAmount\":1,\"OutNum\":1,\"IsPayComplated\":0,\"IsOutStatus\":0,\"FinishOutNum\":0,\"Amount\":2.0,\"ReturnAmount\":0.0,\"UnitPrice\":1.0}],\"MachineCode\":\"CJXM17060001\",\"IsPayComplated\":0,\"OutSaleNum\":2,\"IsFinishSale\":0,\"PayAmount\":2,\"ChangeAmount\":0.0,\"CashGenerateStatus\":0,\"CashAmount\":0.0,\"ReturnAmount\":0.0,\"ReturnNum\":0.0}";
                requesturl = "http://www.yiwuwangtu.com/AlipayQrCodeMoreToApp";
                #region
                var myClient = new HttpClient();
                var myRequest = new HttpRequestMessage(HttpMethod.Post, requesturl);
                HttpContent content = new StringContent(jsonstr, Encoding.UTF8, "application/json");
                myRequest.Content = content;



                var response = await myClient.SendAsync(myRequest);
                string resp_body = await response.Content.ReadAsStringAsync();
                return resp_body;
                //return response;
                //{ "count":0,"hasMore":null,"data":"https://qr.alipay.com/bax01376i5nmxij19mot002a","code":0,"name":"Success","msg":"操作成功"}
                #endregion

            }
            catch (Exception ex)
            {
                return null;

            }
        }
    }

}

