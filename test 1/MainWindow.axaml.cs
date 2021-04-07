using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace test_1
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        
        public void onButtonClick(object sender, RoutedEventArgs e)
        {
            var cont = this.DataContext as MainViewModel;

            List<TableRow> temp = parser.Parse(cont.Url);
            if (temp != null) {
                foreach (var elem in temp) 
                {
                    cont.MyList.Add(new string(
                        string.Concat(
                        elem.artistName,
                        elem.songName,
                        elem.songLength
                        )
                    )) ;
                }

                cont.Result = "DONE!";
            }
                
           
        }
        
       
    }
}
