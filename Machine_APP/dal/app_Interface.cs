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
using Windows.UI.Xaml.Controls;

namespace Machine_APP.dal
{
    public class app_Interface
    {

        public app_Interface() { }

        public static async Task<string> PostHttpstringrequest_alipay(string requesturl, string jsonstr)
        {
            try
            {
                if (requesturl == "wechat")
                    //jsonstr = "{\"PayType\":\"2\",\"PayNo\":\"XM2222200012345678951234\",\"CreateDate\":\"2019-10-27 09:35:51.195\",\"Creator\":\"CJXM17060001\",\"MPayDetailList\":[{\"ProductName\":\"西芹\",\"ChannelCode\":\"3\",\"CreateDate\":\"2019-10-27 09:35:51.212\",\"Creator\":\"CJXM17060001\",\"PictureUrl\":\"genjin_1\",\"PayNo\":\"XM2222200012345678951234\",\"PayDetailNo\":\"XM2222200000000000000001\",\"MachineCode\":\"CJXM17060001\",\"PayAmount\":1,\"OutNum\":1,\"IsPayComplated\":0,\"IsOutStatus\":0,\"FinishOutNum\":0,\"Amount\":2.0,\"ReturnAmount\":0.0,\"UnitPrice\":1.0},{\"ProductName\":\"黄瓜\",\"ChannelCode\":\"3\",\"CreateDate\":\"2019-10-27 09:35:51.212\",\"Creator\":\"CJXM17060001\",\"PictureUrl\":\"genjin_1\",\"PayNo\":\"XM2222200012345678951234\",\"PayDetailNo\":\"XM2222200000000000000002\",\"MachineCode\":\"CJXM17060001\",\"PayAmount\":1,\"OutNum\":1,\"IsPayComplated\":0,\"IsOutStatus\":0,\"FinishOutNum\":0,\"Amount\":2.0,\"ReturnAmount\":0.0,\"UnitPrice\":1.0}],\"MachineCode\":\"CJXM17060001\",\"IsPayComplated\":0,\"OutSaleNum\":2,\"IsFinishSale\":0,\"PayAmount\":2,\"ChangeAmount\":0.0,\"CashGenerateStatus\":0,\"CashAmount\":0.0,\"ReturnAmount\":0.0,\"ReturnNum\":0.0}";
                    requesturl = "http://www.yiwuwangtu.com/WxPayCodeForMultiToApp";//微信支付
                else if (requesturl == "alipay")
                    requesturl = "http://www.yiwuwangtu.com/AlipayQrCodeMoreToApp"; // 支付宝
                #region
                var myClient = new HttpClient();
                var myRequest = new HttpRequestMessage(HttpMethod.Post, requesturl);
                HttpContent content = new StringContent(jsonstr, Encoding.UTF8, "application/json");
                myRequest.Content = content;
                var response = await myClient.SendAsync(myRequest);
                string resp_body = await response.Content.ReadAsStringAsync();

                //Task.WaitAll();

                return resp_body;
                //return response;
                //{ "count":0,"hasMore":null,"data":"https://qr.alipay.com/bax01376i5nmxij19mot002a","code":0,"name":"Success","msg":"操作成功"}
                #endregion

            }
            catch (Exception ex)
            {
                Log_dal ld = new Log_dal();
                ld.addLog(0, "PostHttpstringrequest_alipay  Error:" + ex.Message, DateTime.Now.ToString(), "");
                return null;

            }
        }


        /// <summary>
        /// 支付接口
        /// </summary>
        /// <param name="requesturl"></param>
        /// <param name="jsonstr"></param>
        /// <returns></returns>
        public static string postdata(string requesturl, string jsonstr)
        {
            try
            {
                if (requesturl == "wechat")
                    requesturl = "http://www.yiwuwangtu.com/WxPayCodeForMultiToApp";//微信支付
                else if (requesturl == "alipay")
                    requesturl = "http://www.yiwuwangtu.com/AlipayQrCodeMoreToApp"; // 支付宝
                string url = requesturl;
                string param = jsonstr;
                string result = string.Empty;
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                Encoding encoding = Encoding.UTF8;
                byte[] bs = Encoding.UTF8.GetBytes(param);
                string responseData = String.Empty;
                req.Method = "Post";
                req.Accept = "application/json, text/javascript, */*; q=0.01";
                req.ContentType = "application/json; charset=UTF-8";
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(bs, 0, bs.Length);
                    reqStream.Close();
                }
                using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), encoding))
                    {
                        responseData = reader.ReadToEnd().ToString();
                    }
                    result = responseData;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static string Post(string Url, string Data, string Referer)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.yiwuwangtu.com/api/App/Machine/AppProductRestore?machineCode=CJXM17060001");
            request.Proxy = null;
            request.KeepAlive = false;
            request.Method = "GET";
            request.ContentType = "application/json; charset=UTF-8";
            request.AutomaticDecompression = DecompressionMethods.GZip;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();

            myStreamReader.Close();
            myResponseStream.Close();

            if (response != null)
            {
                response.Close();
            }
            if (request != null)
            {
                request.Abort();
            }

            return retString;
        }


    public static string GetProducts(string machinecode, string url)
        {
            string posturl = "";
            if (string.IsNullOrEmpty(url))
             
                posturl = "http://www.yiwuwangtu.com/api/Machine/AppProductRestore";
            else
                posturl = url;

            string result = "";

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(posturl);
            Encoding encoding = Encoding.UTF8;
            byte[] bs = Encoding.UTF8.GetBytes(machinecode);
            string responseData = String.Empty;
            req.Referer = "machineCode";
            req.Method = "Post";
            req.Accept = "application/json, text/javascript, */*; q=0.01";
            req.ContentType = "application/json; charset=UTF-8";
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(bs, 0, bs.Length);
                reqStream.Close();
            }
            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), encoding))
                {
                    responseData = reader.ReadToEnd().ToString();
                }
                result = responseData;
            }

            return result;

        }
    }

}

