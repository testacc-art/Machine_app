using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Machine_APP
{
    public class PAY_RECORD
    {
        string PayNo;//	支付编号
        string PayUserID;//支付用户ID
        string ChannelCode;//	货道编号标明是哪个货道出货
        string MachineCode;//	"售货机编号标明是哪个售货机
        int IsPayComplated;//	是否支付完成
        string PayType;//	支付方式
        string PayAccount;//	支付宝账号
        double PayAmount;//	应支付金额
        int IsFinishSale;//	是否已经出货
        int OutSaleNum;//	出货数量
        double ReturnAmount;//	退款金额
        double FinishReturnAmount;//	
        double ReturnNum;//	退货数量
        double CashAmount;//	现金收款金额
        double ChangeAmount;//	找零金额
        int CashGenerateStatus;//	账单状态（0或null 为未生成账单，1 代表已经生成订单）
        string CashCode;//	账单编号
        string Creator;//	创建人
        DateTime CreateDate;//	创建时间
        string Modifier;//	最后编辑人员
        DateTime ModifyDate;//	最后编辑时间

        public string PayNo1
        {
            get
            {
                return PayNo;
            }

            set
            {
                PayNo = value;
            }
        }

        public string PayUserID1
        {
            get
            {
                return PayUserID;
            }

            set
            {
                PayUserID = value;
            }
        }

        public string ChannelCode1
        {
            get
            {
                return ChannelCode;
            }

            set
            {
                ChannelCode = value;
            }
        }

        public string MachineCode1
        {
            get
            {
                return MachineCode;
            }

            set
            {
                MachineCode = value;
            }
        }

        public int IsPayComplated1
        {
            get
            {
                return IsPayComplated;
            }

            set
            {
                IsPayComplated = value;
            }
        }

        public string PayType1
        {
            get
            {
                return PayType;
            }

            set
            {
                PayType = value;
            }
        }

        public string PayAccount1
        {
            get
            {
                return PayAccount;
            }

            set
            {
                PayAccount = value;
            }
        }

        public double PayAmount1
        {
            get
            {
                return PayAmount;
            }

            set
            {
                PayAmount = value;
            }
        }

        public int IsFinishSale1
        {
            get
            {
                return IsFinishSale;
            }

            set
            {
                IsFinishSale = value;
            }
        }

        public int OutSaleNum1
        {
            get
            {
                return OutSaleNum;
            }

            set
            {
                OutSaleNum = value;
            }
        }

        public double ReturnAmount1
        {
            get
            {
                return ReturnAmount;
            }

            set
            {
                ReturnAmount = value;
            }
        }

        public double FinishReturnAmount1
        {
            get
            {
                return FinishReturnAmount;
            }

            set
            {
                FinishReturnAmount = value;
            }
        }

        public double ReturnNum1
        {
            get
            {
                return ReturnNum;
            }

            set
            {
                ReturnNum = value;
            }
        }

        public double CashAmount1
        {
            get
            {
                return CashAmount;
            }

            set
            {
                CashAmount = value;
            }
        }

        public double ChangeAmount1
        {
            get
            {
                return ChangeAmount;
            }

            set
            {
                ChangeAmount = value;
            }
        }

        public int CashGenerateStatus1
        {
            get
            {
                return CashGenerateStatus;
            }

            set
            {
                CashGenerateStatus = value;
            }
        }

        public string CashCode1
        {
            get
            {
                return CashCode;
            }

            set
            {
                CashCode = value;
            }
        }

        public string Creator1
        {
            get
            {
                return Creator;
            }

            set
            {
                Creator = value;
            }
        }

        public DateTime CreateDate1
        {
            get
            {
                return CreateDate;
            }

            set
            {
                CreateDate = value;
            }
        }

        public string Modifier1
        {
            get
            {
                return Modifier;
            }

            set
            {
                Modifier = value;
            }
        }

        public DateTime ModifyDate1
        {
            get
            {
                return ModifyDate;
            }

            set
            {
                ModifyDate = value;
            }
        }

        public PAY_RECORD(string payNo, string payUserID, string channelCode, string machineCode, int isPayComplated, string payType, string payAccount, double payAmount, int isFinishSale, int outSaleNum,
            double returnAmount, double finishReturnAmount, double returnNum, double cashAmount, double changeAmount, int cashGenerateStatus, string cashCode, string creator, DateTime createDate, string modifier, DateTime modifyDate)
        {
            PayNo1 = payNo;
            PayUserID1 = payUserID;
            ChannelCode1 = channelCode;
            MachineCode1 = machineCode;
            IsPayComplated1 = isPayComplated;
            PayType1 = payType;
            PayAccount1 = payAccount;
            PayAmount1 = payAmount;
            IsFinishSale1 = isFinishSale;
            OutSaleNum1 = outSaleNum;
            ReturnAmount1 = returnAmount;
            FinishReturnAmount1 = finishReturnAmount;
            ReturnNum1 = returnNum;
            CashAmount1 = cashAmount;
            ChangeAmount1 = changeAmount;
            CashGenerateStatus1 = cashGenerateStatus;
            CashCode1 = cashCode;
            Creator1 = creator;
            CreateDate1 = createDate;
            Modifier1 = modifier;
            ModifyDate1 = modifyDate;
        }
    }
}
