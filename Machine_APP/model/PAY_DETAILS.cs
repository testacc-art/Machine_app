using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Machine_APP.model
{
   public class PAY_DETAILS : INotifyPropertyChanged
    {
        string PayDetailNo;
        string PayNo;
        string MachineCode;
        string ChannelCode;
        string ProductCode;
        string ProductName;
        string PictureUrl;
        int IsPayComplated;
        double PayAmount;
        double Amount;
        int IsOutStatus;
        double UnitPrice;
        int OutNum;
        int FinishOutNum;
        double ReturnAmount;
        int OutDetailNum;
        DateTime OutDetailDate;
        string OutDetailAuditor;
        DateTime AuditRefundAmount;
        string Creator;
        DateTime CreateDate;
        string Modifier;
        DateTime ModifyDate;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
           this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public string PayDetailNo1
        {
            get
            {
                return PayDetailNo;
            }

            set
            {
                PayDetailNo = value; this.OnPropertyChanged();
            }
        }

        public string PayNo1
        {
            get
            {
                return PayNo;
            }

            set
            {
                PayNo = value; this.OnPropertyChanged();
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
                MachineCode = value; this.OnPropertyChanged();
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
                ChannelCode = value; this.OnPropertyChanged();
            }
        }

        public string ProductCode1
        {
            get
            {
                return ProductCode;
            }

            set
            {
                ProductCode = value; this.OnPropertyChanged();
            }
        }

        public string ProductName1
        {
            get
            {
                return ProductName;
            }

            set
            {
                ProductName = value; this.OnPropertyChanged();
            }
        }

        public string PictureUrl1
        {
            get
            {
                return PictureUrl;
            }

            set
            {
                PictureUrl = value; this.OnPropertyChanged();
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
                IsPayComplated = value; this.OnPropertyChanged();
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
                PayAmount = value; this.OnPropertyChanged();
            }
        }

        public double Amount1
        {
            get
            {
                return Amount;
            }

            set
            {
                Amount = value; this.OnPropertyChanged();
            }
        }

        public int IsOutStatus1
        {
            get
            {
                return IsOutStatus;
            }

            set
            {
                IsOutStatus = value; this.OnPropertyChanged();
            }
        }

        public double UnitPrice1
        {
            get
            {
                return UnitPrice;
            }

            set
            {
                UnitPrice = value; this.OnPropertyChanged();
            }
        }

        public int OutNum1
        {
            get
            {
                return OutNum;
            }

            set
            {
                OutNum = value; this.OnPropertyChanged();
            }
        }

        public int FinishOutNum1
        {
            get
            {
                return FinishOutNum;
            }

            set
            {
                FinishOutNum = value; this.OnPropertyChanged();
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
                ReturnAmount = value; this.OnPropertyChanged();
            }
        }

        public int OutDetailNum1
        {
            get
            {
                return OutDetailNum;
            }

            set
            {
                OutDetailNum = value; this.OnPropertyChanged();
            }
        }

        public DateTime OUtDetailDate
        {
            get
            {
                return OutDetailDate;
            }

            set
            {
                OutDetailDate = value; this.OnPropertyChanged();
            }
        }

        public string OutDetailAuditor1
        {
            get
            {
                return OutDetailAuditor;
            }

            set
            {
                OutDetailAuditor = value; this.OnPropertyChanged();
            }
        }

        public DateTime AuditRefundAmount1
        {
            get
            {
                return AuditRefundAmount;
            }

            set
            {
                AuditRefundAmount = value; this.OnPropertyChanged();
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
                Creator = value; this.OnPropertyChanged();
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
                CreateDate = value; this.OnPropertyChanged();
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
                Modifier = value; this.OnPropertyChanged();
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
                ModifyDate = value; this.OnPropertyChanged();
            }
        }

        public PAY_DETAILS(string payDetailNo, string payNo, string machineCode, string channelCode, string productCode, string productName, string pictureUrl, int isPayComplated, double payAmount, double amount, int isOutStatus, double unitPrice, int outNum, int finishOutNum, double returnAmount, int outDetailNum, DateTime utDetailDate, string outDetailAuditor, DateTime auditRefundAmount, string creator, DateTime createDate, string modifier, DateTime modifyDate)
        {
            PayDetailNo1 = payDetailNo;
            PayNo1 = payNo;
            MachineCode1 = machineCode;
            ChannelCode1 = channelCode;
            ProductCode1 = productCode;
            ProductName1 = productName;
            PictureUrl1 = pictureUrl;
            IsPayComplated1 = isPayComplated;
            PayAmount1 = payAmount;
            Amount1 = amount;
            IsOutStatus1 = isOutStatus;
            UnitPrice1 = unitPrice;
            OutNum1 = outNum;
            FinishOutNum1 = finishOutNum;
            ReturnAmount1 = returnAmount;
            OutDetailNum1 = outDetailNum;
            OUtDetailDate = utDetailDate;
            OutDetailAuditor1 = outDetailAuditor;
            AuditRefundAmount1 = auditRefundAmount;
            Creator1 = creator;
            CreateDate1 = createDate;
            Modifier1 = modifier;
            ModifyDate1 = modifyDate;
        }
    }
}
