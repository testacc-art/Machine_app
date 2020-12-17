using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Machine_APP.model
{
    public class ProductView : INotifyPropertyChanged
    {
        string ChannelCode;
        int MachineType;
        string MachineCode;
        string ProductName;
        double Price;
        double DiscountPrice;
        string DiscountDate;
        double XFlag;
        double YFlag;
        int ChannelStatus;
        string PictureUrl;
        double ChannelLength;
        double ChannelWidth;
        int ChannelType;
        double ProductNum;
        double CapacityNum;
        bool IsDisable;
        string Creator;
        DateTime CreateDate;
        string Modifier;
        DateTime ModifyDate;
        double choosenum;

        public ProductView() { }

        public double choosenum1
        {
            get
            {
                return choosenum;
            }

            set
            {
                choosenum = value; this.OnPropertyChanged();
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
                this.OnPropertyChanged();
            }
        }

        public int MachineType1
        {
            get
            {
                return MachineType;
            }

            set
            {
                MachineType = value; this.OnPropertyChanged();
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

        public double Price1
        {
            get
            {
                return Price;
            }

            set
            {
                Price = value; this.OnPropertyChanged();
            }
        }

        public double DiscountPrice1
        {
            get
            {
                return DiscountPrice;
            }

            set
            {
                DiscountPrice = value; this.OnPropertyChanged();
            }
        }

        public string DiscountDate1
        {
            get
            {
                return DiscountDate;
            }

            set
            {
                DiscountDate = value; this.OnPropertyChanged();
            }
        }

        public double XFlag1
        {
            get
            {
                return XFlag;
            }

            set
            {
                XFlag = value; this.OnPropertyChanged();
            }
        }

        public double YFlag1
        {
            get
            {
                return YFlag;
            }

            set
            {
                YFlag = value; this.OnPropertyChanged();
            }
        }

        public int ChannelStatus1
        {
            get
            {
                return ChannelStatus;
            }

            set
            {
                ChannelStatus = value; this.OnPropertyChanged();
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

        public double ChannelLength1
        {
            get
            {
                return ChannelLength;
            }

            set
            {
                ChannelLength = value; this.OnPropertyChanged();
            }
        }

        public double ChannelWidth1
        {
            get
            {
                return ChannelWidth;
            }

            set
            {
                ChannelWidth = value; this.OnPropertyChanged();
            }
        }

        public int ChannelType1
        {
            get
            {
                return ChannelType;
            }

            set
            {
                ChannelType = value; this.OnPropertyChanged();
            }
        }

        public double ProductNum1
        {
            get
            {
                return ProductNum;
            }

            set
            {
                ProductNum = value; this.OnPropertyChanged();
            }
        }

        public double CapacityNum1
        {
            get
            {
                return CapacityNum;
            }

            set
            {
                CapacityNum = value; this.OnPropertyChanged();
            }
        }

        public bool IsDisable1
        {
            get
            {
                return IsDisable;
            }

            set
            {
                IsDisable = value; this.OnPropertyChanged();
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

        public ProductView(string channelCode, int machineType, string machineCode, string productName, double price, double discountPrice, string discountDate, double xFlag, double yFlag, int channelStatus, string pictureUrl, double channelLength, double channelWidth, int channelType, double productNum, double capacityNum, bool isDisable, string creator, DateTime createDate, string modifier, DateTime modifyDate)
        {
            ChannelCode1 = channelCode;
            MachineType1 = machineType;
            MachineCode1 = machineCode;
            ProductName1 = productName;
            Price1 = price;
            DiscountPrice1 = discountPrice;
            DiscountDate1 = discountDate;
            XFlag1 = xFlag;
            YFlag1 = yFlag;
            ChannelStatus1 = channelStatus;
            PictureUrl1 = pictureUrl;
            ChannelLength1 = channelLength;
            ChannelWidth1 = channelWidth;
            ChannelType1 = channelType;
            ProductNum1 = productNum;
            CapacityNum1 = capacityNum;
            IsDisable1 = isDisable;
            Creator1 = creator;
            CreateDate1 = createDate;
            Modifier1 = modifier;
            ModifyDate1 = modifyDate;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}



