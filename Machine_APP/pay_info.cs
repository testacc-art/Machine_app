using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine_APP
{
    [JsonObject(MemberSerialization.OptOut)]
    public class pay_info
    {
        public pay_info(string payType, string payNo, string createDate, string creator, List<pay_infor_detail> mPayDetailList, string machineCode, int isPayComplated, int outSaleNum, int isFinishSale, int payAmount, float changeAmount, int cashGenerateStatus, float cashAmount, float returnAmount, float returnNum)
        {
            PayType = payType;
            PayNo = payNo;
            CreateDate = createDate;
            Creator = creator;
            MPayDetailList = mPayDetailList;
            MachineCode = machineCode;
            IsPayComplated = isPayComplated;
            OutSaleNum = outSaleNum;
            IsFinishSale = isFinishSale;
            PayAmount = payAmount;
            ChangeAmount = changeAmount;
            CashGenerateStatus = cashGenerateStatus;
            CashAmount = cashAmount;
            ReturnAmount = returnAmount;
            ReturnNum = returnNum;
        }

        public string PayType { get; set; }
        public string PayNo { get; set; }
        public string CreateDate { get; set; }
        public string Creator { get; set; }
        public List<pay_infor_detail> MPayDetailList { get; set; }
        public string MachineCode { get; set; }
        public int IsPayComplated { get; set; }
        public int OutSaleNum { get; set; }
        public int IsFinishSale { get; set; }
        public int PayAmount { get; set; }
        public float ChangeAmount { get; set; }
        public int CashGenerateStatus { get; set; }
        public float CashAmount { get; set; }
        public float ReturnAmount { get; set; }
        public float ReturnNum { get; set; }

  
    }
}
