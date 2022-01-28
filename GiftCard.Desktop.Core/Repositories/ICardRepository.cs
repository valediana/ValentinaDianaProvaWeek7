using GiftCard.Desktop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCard.Desktop.Core.Repositories
{
    public interface ICardRepository
    {
        IList<Card> FetchAll();

        void Create(Card card);

        void Update(Card oldCard, Card newCard);

        void Delete(Card card);
    }
}
