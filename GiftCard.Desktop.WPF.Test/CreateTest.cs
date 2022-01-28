using GiftCard.Desktop.Core.BusinessLayer;
using GiftCard.Desktop.Core.Entities;
using GiftCard.Desktop.Core.Mock;
using GiftCard.Desktop.Core.Mock.Repositories;
using GiftCard.Desktop.Core.Repositories;
using System;
using Xunit;

namespace GiftCard.Desktop.WPF.Test
{
    public class CreateTest
    {
        [Fact]
        public void ShouldCreateNewCard()
        {
            //ARRANGE
            //Recupero i dati che mi serviranno per gestire l'operazione
            AllocationMockStorage.Initialize();

            //Creazione del repository
            ICardRepository cardRepository = new CardRepositoryMock();

            //Creazione del business layer
            MainBusinessLayer layer = new MainBusinessLayer(cardRepository);

            Card newCard = new Card()
            {
                Id = 4,
                Destinatario="Luigi",
                Mittente="Chiara",
                Messaggio="ciao",
                Importo=100.0,
                DataScadenza=new DateTime(2022,12,20)
            };

            //ACT - Eseguo l'operazione da testare
            var result = layer.CreateCard(newCard);

            //ASSERT - Verifica del risultato ottenuto
            Assert.True(result.Success);
        }
    }
}
