using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Machine_APP
{
    public class SYS_SETTING : INotifyPropertyChanged
    {

        string MachineCode;
        int ChannelCount;
        int LayerRowCount;
        int LayerColumnCount;
        string RequeryUrl;
        string ICardPassword;
        string MachineAddress;
        double Longitude;
        string Latitude;
        double AdvertisementDirectory;
        int IsDisplayPic;
        int IsCheckBox;
        int RunMode;
        string Creator;
        DateTime CreateTime;
        string Modifier;
        DateTime ModifyDate;
        string AlertMobile;
        string AlertEmail;
        string AppVersionID;

        public string MachineCode1 { get => MachineCode;  set
            {
                MachineCode = value; this.OnPropertyChanged();
            }
        }

        public int ChannelCount1 { get => ChannelCount; set { ChannelCount = value; this.OnPropertyChanged(); } }
        public int LayerRowCount1 { get => LayerRowCount; set { LayerRowCount = value; this.OnPropertyChanged(); } }
        public int LayerColumnCount1 { get => LayerColumnCount; set { LayerColumnCount = value; this.OnPropertyChanged(); } }
        public string RequeryUrl1 { get => RequeryUrl; set { RequeryUrl = value; this.OnPropertyChanged(); } }
        public string ICardPassword1 { get => ICardPassword; set { ICardPassword = value; this.OnPropertyChanged(); } }
        public string MachineAddress1 { get => MachineAddress; set { MachineAddress = value; this.OnPropertyChanged(); } }
        public double Longitude1 { get => Longitude; set { Longitude = value; this.OnPropertyChanged(); } }
        public string Latitude1 { get => Latitude; set { Latitude = value; this.OnPropertyChanged(); } }
        public double AdvertisementDirectory1 { get => AdvertisementDirectory; set { AdvertisementDirectory = value; this.OnPropertyChanged(); } }
        public int IsDisplayPic1 { get => IsDisplayPic; set { IsDisplayPic = value; this.OnPropertyChanged(); } }
        public int IsCheckBox1 { get => IsCheckBox; set { IsCheckBox = value; this.OnPropertyChanged(); } }
        public int RunMode1 { get => RunMode; set { RunMode = value; this.OnPropertyChanged(); } }
        public string Creator1 { get => Creator; set { Creator = value; this.OnPropertyChanged(); } }
        public DateTime CreateTime1 { get => CreateTime; set { CreateTime = value; this.OnPropertyChanged(); } }
        public string Modifier1 { get => Modifier; set { Modifier = value; this.OnPropertyChanged(); } }
        public DateTime ModifyDate1 { get => ModifyDate; set { ModifyDate = value; this.OnPropertyChanged(); } }
        public string AlertMobile1 { get => AlertMobile; set { AlertMobile = value; this.OnPropertyChanged(); } }
        public string AlertEmail1 { get => AlertEmail; set { AlertEmail = value; this.OnPropertyChanged(); } }
        public string AppVersionID1 { get => AppVersionID; set { AppVersionID = value; this.OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    
}
