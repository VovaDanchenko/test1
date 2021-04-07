using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;


namespace test_1
{
    class MainViewModel : INotifyPropertyChanged

    {
        private string? _url;
        private string? _result;
        private ObservableCollection<String> myList = new ObservableCollection<string>(new string[] { });
        public ObservableCollection<String> MyList
        {
            get => myList;
            set
           {
               if (value != myList)
               {
                   myList = value;
                    OnPropertyChanged();
               }
            }
        }
      
        public string Url
        {
            get { return _url; }
            set
            {
                if (value != _url)
                {
                    _url = value;
                    OnPropertyChanged();
                }
            }

        }
        public string Result
        {
            get { return _result; }
            set
            {
                if (value != _result)
                {
                    _result = value;
                    OnPropertyChanged();
                }
            }

        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName= null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
