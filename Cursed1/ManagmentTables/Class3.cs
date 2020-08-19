using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursed1.ManagmentTables
{
    public class ComboboxModel : INotifyPropertyChanged
    {
        public ComboboxModel()
        {

        }

        private string _comboitem = "";
        public string Comboitem
        {
            get { return _comboitem; }
            set
            {
                if (_comboitem != value)
                {
                    _comboitem = value;
                    NotifyPropertyChanged("ComboItem");
                }
            }
        }

        #region INotifyPropertyChanged Members

        /// Need to implement this interface in order to get data binding
        /// to work properly.
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }

}
