using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GiftCard.Desktop.WPF.Messaging.Card;
using GiftCard.Desktop.WPF.Messaging.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GiftCard.Desktop.WPF.ViewModels
{
    public class HomeViewModel: ViewModelBase
    {
        public ICommand ExitCommand { get; set; }
        public ICommand ShowCardsCommand { get; set; }

        public HomeViewModel()
        {
            //Inizializzazione dei command
            ShowCardsCommand = new RelayCommand(() => ExecuteShowCards());
            ExitCommand = new RelayCommand(() => ExecuteExit());
        }

        private void ExecuteExit()
        {
            Messenger.Default.Send(new DialogMessage
            {
                Title = "Confirm exit",
                Content = "Are you sure?",
                Icon = MessageBoxImage.Question,
                Buttons = MessageBoxButton.YesNo,
                Callback = (result) =>
                {
                    //Esco dall'applicazione solo se l'utente preme "YES"
                    if (result == MessageBoxResult.Yes)
                        Messenger.Default.Send(new ShutDownApplicationMessage());
                }
            });
        }

        private void ExecuteShowCards()
        {
            Messenger.Default.Send(new ShowCardMessage());
        }
    }
}
