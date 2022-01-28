using GiftCard.Desktop.Core.Entities;
using GiftCard.Desktop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCard.Desktop.Core.Mock.Repositories
{
    public class CardRepositoryMock : ICardRepository
    {
        public void Create(Card card)
        {
            var newId = AllocationMockStorage.Cards.Max(e => e.Id) + 1;
            card.Id = newId;
            AllocationMockStorage.Cards.Add(card);
        }

        public void Delete(Card card)
        {
            var existingCard = AllocationMockStorage.Cards.FirstOrDefault(c => c.Id == card.Id);
            AllocationMockStorage.Cards.Remove(existingCard);
        }

        public IList<Card> FetchAll()
        {
            return AllocationMockStorage
               .Cards
               .OrderBy(x => x.Id)
               .ToList();
        }

        public void Update(Card oldCard, Card newCard)
        {
            throw new NotImplementedException();
        }
    }
}
