using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace ThreadWindow
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        #region Binding
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Fields
        private string _buttonText;
        private int _num;
        SubWindow subwindow;
        #endregion

        #region Properties
        public string ButtonText { get { return _buttonText; } set { _buttonText = value; OnPropertyChanged(nameof(ButtonText)); } }
        public int Num { get { return _num; } set { _num = value; OnPropertyChanged(nameof(Num)); } }
        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            ButtonText = "새 창";
            Btn_Click = new Command(Execute_func1, CanExecute_func);
        }
        #endregion

        #region Command
        public Command Btn_Click { get; set; }

        private bool CanExecute_func(object obj)
        {
            return true;
        }
        private void Execute_func1(object obj)
        {
            Thread testThread = new Thread(new ThreadStart(Live));
            testThread.Start();

            Thread thread = new Thread(new ThreadStart(NewWindow));
            //thread.SetApartmentState(ApartmentState.STA);
            thread.Start();


            // NewWindow();
        }


        #endregion

        #region Method
        private void NewWindow()
        {
            // Invoke
            /*
            App.Current.Dispatcher.Invoke(() =>
            {
                subwindow = new SubWindow();
                subwindow.ShowDialog();

            });
            */

            /*
            App.Current.Dispatcher.BeginInvoke(new Action(() =>
            {

            }));
            */
            while (true)
            {
                if(Num >= 30)
                {
                    Num = 0;

                    
                        App.Current.Dispatcher.Invoke(() =>
                        {
                            subwindow = new SubWindow();

                            if (!subwindow.IsVisible)
                            {
                                subwindow.Show();
                            }

                        });
                    // BeginInvoke

                }

                Thread.Sleep(100);
            }
            
           
        }

        private void Live()
        {
            try
            {
                while (true)
                {
                    Num++;
                    Thread.Sleep(100);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }
        #endregion
    }
}
