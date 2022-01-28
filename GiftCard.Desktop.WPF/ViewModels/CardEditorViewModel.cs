using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GiftCard.Desktop.Core.BusinessLayer;
using GiftCard.Desktop.Core.Entities;
using GiftCard.Desktop.Core.Mock.Repositories;
using GiftCard.Desktop.Core.Repositories;
using GiftCard.Desktop.WPF.Messaging.Card;
using GiftCard.Desktop.WPF.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace GiftCard.Desktop.WPF.Views
{
    public class CardEditorViewModel: ViewModelBase
    {
        public ICommand CreateCard { get; set; }


        public ObservableCollection<CardRowViewModel> _CardsSource;
        private ICollectionView _Cards;
        public ICollectionView Cards
        {
            get { return _Cards; }
            set { _Cards = value; RaisePropertyChanged(); }
        }

        public ICommand LoadCardsCommand { get; set; }

        public CardEditorViewModel()
        {
            CreateCard = new RelayCommand(() => ExecuteShowCreateCard());
            LoadCardsCommand = new RelayCommand(() => ExecuteLoadCards());

            //inizializzazione delle liste
            _CardsSource = new ObservableCollection<CardRowViewModel>();
            _Cards = new CollectionView(_CardsSource);

            LoadCardsCommand.Execute(null);
        }

        private void ExecuteLoadCards()
        {
            //Inizializzo il business layer
            //Istanziare il repository
            ICardRepository repo = new CardRepositoryMock();
            MainBusinessLayer layer = new MainBusinessLayer(repo);

            
            var Cards = layer.FetchAllCards();

            //Pulizia della lista sorgente
            _CardsSource.Clear();

           
            foreach (Card item in Cards)
            {
                var vmCardRow = new CardRowViewModel(item);
                _CardsSource.Add(vmCardRow);
            }


        }

        private void ExecuteShowCreateCard()
        {
            Messenger.Default.Send(new ShowCreateCardMessage());
        }
    }
}