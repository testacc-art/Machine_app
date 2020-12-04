using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Machine_APP
{
    public class SYS_CONFIG : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string configNo;
        string configName;
        string configType;
        string machineCode;
        public SYS_CONFIG()
        { }
        public SYS_CONFIG(string configNo1, string configName1, string configType1, string machineCode1)
        {
            configNo = configNo1;
            configName = configName1;
            configType = configType1;
            machineCode = machineCode1;
        }

        public string ConfigNo
        {
            get
            {
                return configNo;
            }

            set
            {
                configNo = value;
                this.OnPropertyChanged();
            }
        }


        public string ConfigName
        {
            get
            {
                return configName;
            }

            set
            {
                configName = value;
                this.OnPropertyChanged();
            }
        }

        public string ConfigType
        {
            get
            {
                return configType;
            }

            set
            {
                configType = value;
                this.OnPropertyChanged();
            }
        }

        public string MachineCode
        {
            get
            {
                return machineCode;
            }

            set
            {
                machineCode = value;
                this.OnPropertyChanged();
            }
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
           this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
