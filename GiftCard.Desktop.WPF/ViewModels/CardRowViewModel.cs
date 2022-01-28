using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GiftCard.Desktop.Core.BusinessLayer;
using GiftCard.Desktop.Core.Entities;
using GiftCard.Desktop.Core.Mock.Repositories;
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
    public class CardRowViewModel: ViewModelBase
    {
        private Card item;

        private string _Destinatario;
        public string Destinatario
        {
            get { return _Destinatario; }
            set { _Destinatario = value; RaisePropertyChanged(); }
        }

        private double _Importo;
        public double Importo
        {
            get { return _Importo; }
            set { _Importo = value; RaisePropertyChanged(); }
        }

        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public CardRowViewModel()
        {
            //Inizializzazione dei comandi
            UpdateCommand = new RelayCommand(() => ExecuteUpdate());
            DeleteCommand = new RelayCommand(() => ExecuteDelete());

        }

        public CardRowViewModel(Card item) : this()
        {
            //Associo il dipendente trovato e popolo la mia view
            this.item = item;
            Destinatario = item.Destinatario;
            Importo = item.Importo;
        }


        private void ExecuteDelete()
        {
            Messenger.Default.Send(new DialogMessage
            {
                Title = "Confirm delete",
                Content = "Are you sure?",
                Icon = MessageBoxImage.Question,
                Buttons = MessageBoxButton.YesNo,
                Callback = OnMessageBoxResultReceived
            });
        }

        private void OnMessageBoxResultReceived(MessageBoxResult result)
        {
            //Solo se l'utente ha cliccato sì
            if (result == MessageBoxResult.Yes)
            {
                var layer = new MainBusinessLayer(new CardRepositoryMock());

                //Cancello l'elemento selezionato
                var response = layer.DeleteCard(item);

                //se la response è ok
                if (!response.Success)
                {
                    Messenger.Default.Send(new DialogMessage
                    {
                        Title = "Errore",
                        Content = response.Message,
                        Icon = MessageBoxImage.Error,
                        Buttons = MessageBoxButton.OK
                    });
                    return;
                }
                else
                {
                    Messenger.Default.Send(new DialogMessage
                    {
                        Title = "Deletion Confirmed",
                        Content = response.Message,
                        Icon = MessageBoxImage.Information
                    });
                }
            }
        }

        private void ExecuteUpdate()
        {
            Messenger.Default.Send(new ShowUpdateCardMessage { Entity = item });
        }
    }
}
