using GalaSoft.MvvmLight.Messaging;
using GiftCard.Desktop.WPF.Messaging.Card;
using GiftCard.Desktop.WPF.ViewModels;
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
using System.Windows.Shapes;

namespace GiftCard.Desktop.WPF.Views
{
    /// <summary>
    /// Interaction logic for CardEditorView.xaml
    /// </summary>
    public partial class CardEditorView : Window
    {
        
        public CardEditorView()
        {
            InitializeComponent();
            Messenger.Default.Register<ShowCreateCardMessage>(this, OnShowCreateCardExecuted);
            //Messenger.Default.Register<ShowUpdateCardMessage>(this, OnShowUpdateCardMessageReceived);
        }

        //private void OnShowUpdateCardMessageReceived(ShowUpdateCardMessage message)
        //{
        //    //Creazione della view, del vm, marriage e show
        //    UpdateCardView view = new UpdateCardView();
        //    UpdateCardViewModel vm = new UpdateCardViewModel(message.Entity);
        //    view.DataContext = vm;
        //    view.ShowDialog();
        //}

        private void OnShowCreateCardExecuted(ShowCreateCardMessage obj)
        {
            CreateCardView view = new CreateCardView();
            CreateCardViewModel vm = new CreateCardViewModel();
            view.DataContext = vm;
            view.ShowDialog();
        }
    }
}
