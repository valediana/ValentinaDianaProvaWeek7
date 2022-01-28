using GalaSoft.MvvmLight.Messaging;
using GiftCard.Desktop.WPF.Messaging;
using GiftCard.Desktop.WPF.Messaging.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GiftCard.Desktop.WPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class HomeView: Window
    {
        public HomeView()
        {
            InitializeComponent();
            Messenger.Default.Register<ShowCardMessage>(this, OnShowCardMessageReceived);
        }

        private void OnShowCardMessageReceived(ShowCardMessage obj)
        {
            //Inizializza le view e i view model
            CardEditorView view = new CardEditorView();
            CardEditorViewModel vm = new CardEditorViewModel();
            view.DataContext = vm;
            view.Show();
        }
    }
}
