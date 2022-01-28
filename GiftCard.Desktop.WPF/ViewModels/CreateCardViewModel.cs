using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GiftCard.Desktop.Core.BusinessLayer;
using GiftCard.Desktop.Core.Entities;
using GiftCard.Desktop.Core.Mock.Repositories;
using GiftCard.Desktop.WPF.Messaging.Card;
using GiftCard.Desktop.WPF.Messaging.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GiftCard.Desktop.WPF.ViewModels
{
    public class CreateCardViewModel: ViewModelBase
    {
        public ICommand CreateCommand { get; set; }

        private string _Destinatario;
        public string Destinatario
        {
            get { return _Destinatario; }
            set
            {
                _Destinatario = value; RaisePropertyChanged();
            }
        }

        private string _Mittente;
        public string Mittente
        {
            get { return _Mittente; }
            set
            {
                _Mittente = value; RaisePropertyChanged();
            }
        }

        private string _Messaggio;
        public string Messaggio
        {
            get { return _Messaggio; }
            set
            {
                _Messaggio = value; RaisePropertyChanged();
            }
        }

        private double _Importo;
        public double Importo
        {
            get { return _Importo; }
            set
            {
                _Importo = value; RaisePropertyChanged();
            }
        }

        private DateTime _DataScadenza;
        public DateTime DataScadenza
        {
            get { return _DataScadenza; }
            set
            {
                _DataScadenza = value; RaisePropertyChanged();
            }
        }

        public CreateCardViewModel()
        {
            CreateCommand = new RelayCommand(() => ExecuteCreate(), () => CanExecuteCreate());

            if (!IsInDesignMode)
            {
                PropertyChanged += (s, e) =>
                {
                    (CreateCommand as RelayCommand).RaiseCanExecuteChanged();
                };
            }
        }

        private bool CanExecuteCreate()
        {
            //Il pulsante create è abilitato soltanto se tutti i campi sono valorizzati
            return !string.IsNullOrEmpty(Destinatario) &&
                !string.IsNullOrEmpty(Mittente) &&
                !string.IsNullOrEmpty(Messaggio) &&
                !string.IsNullOrEmpty(Importo.ToString()) &&
                !string.IsNullOrEmpty(DataScadenza.ToString());
        }

        private void ExecuteCreate()
        {
            //Recupero i dati dalle proprietà del view
            //model e creo una nuova entità
            var entity = new Card
            {
                Destinatario= Destinatario,
                Mittente= Mittente,
                Messaggio= Messaggio,
                Importo=Importo,
                DataScadenza= DataScadenza,
            };

            //Inizializzo il business layer
            var layer = new MainBusinessLayer(new CardRepositoryMock());
            //Richiamo l'operazione del layer
            var response = layer.CreateCard(entity);

            if (!response.Success)
            {
                Messenger.Default.Send(new DialogMessage
                {
                    Title = "Something wrong",
                    Content = response.Message,
                    Icon = System.Windows.MessageBoxImage.Warning
                });
                return;
            }
            else
            {
                Messenger.Default.Send(new DialogMessage
                {
                    Title = "Creazione completata",
                    Content = response.Message,
                    Icon = System.Windows.MessageBoxImage.Information
                });
            }
            Messenger.Default.Send(new CloseCreateCardMessage());
        }
    }
}
