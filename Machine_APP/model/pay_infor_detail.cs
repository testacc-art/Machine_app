using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine_APP
{
    [JsonObject(MemberSerialization.OptOut)]
    public class pay_infor_detail
    {
        public pay_infor_detail() { }
        public pay_infor_detail(string productName, string channelCode, string createDate, string creator, string pictureUrl, string payNo, string payDetailNo, string machineCode, int payAmount, int outNum, int isPayComplated, int isOutStatus, int finishOutNum, float amount, float returnAmount, float unitPrice)
        {
            ProductName = productName;
            ChannelCode = channelCode;
            CreateDate = createDate;
            Creator = creator;
            PictureUrl = pictureUrl;
            PayNo = payNo;
            PayDetailNo = payDetailNo;
            MachineCode = machineCode;
            PayAmount = payAmount;
            OutNum = outNum;
            IsPayComplated = isPayComplated;
            IsOutStatus = isOutStatus;
            FinishOutNum = finishOutNum;
            Amount = amount;
            ReturnAmount = returnAmount;
            UnitPrice = unitPrice;
        }

        public string ProductName { get; set; }
        public string ChannelCode { get; set; }
        public string CreateDate { get; set; }
        public string Creator { get; set; }
        public string PictureUrl { get; set; }
        public string PayNo { get; set; }
        public string PayDetailNo { get; set; }
        public string MachineCode { get; set; }
        public int PayAmount { get; set; }
        public int OutNum { get; set; }
        public int IsPayComplated { get; set; }
        public int IsOutStatus { get; set; }
        public int FinishOutNum { get; set; }
        public float Amount { get; set; }
        public float ReturnAmount { get; set; }
        public float UnitPrice { get; set; }
    }
}
