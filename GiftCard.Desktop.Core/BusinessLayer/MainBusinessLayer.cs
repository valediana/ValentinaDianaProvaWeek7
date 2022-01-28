using GiftCard.Desktop.Core.Entities;
using GiftCard.Desktop.Core.Repositories;
using GiftCard.Desktop.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCard.Desktop.Core.BusinessLayer
{
    public class MainBusinessLayer
    {
        private ICardRepository _CardRepository;

        public MainBusinessLayer(ICardRepository repoCard)
        {
            _CardRepository = repoCard;
        }

        //Restituire la lista 
        public IList<Card> FetchAllCards()
        {
            //Semplice chiamata al repository per la restituzione delle card
            return _CardRepository.FetchAll();
        }

        public Response CreateCard(Card entity)
        {
            //validazione dell'argomento
            if (entity == null)
                return new Response { Success = false, Message = "Invalid entity" };

            if (entity.Importo < 0.0)
                return new Response { Success = false, Message = "L'importo deve essere maggiore di zero" };

            _CardRepository.Create(entity);
            //Emetto la risposta con esito positivo
            return new Response
            {
                Success = true,
                Message = $"Card: {entity.Destinatario} {entity.Importo} created"
            };
        }

        public Response DeleteCard(Card entity)
        {
            if (entity == null)
                return new Response { Success = false, Message = "Invalid entity" };
            if (entity.Id < 0)
                return new Response { Success = false, Message = "Invalid ID" };
            var CardToDelete = FetchAllCards().FirstOrDefault(x => x.Id == entity.Id);
            if (CardToDelete == null)
                return new Response
                {
                    Success = false,
                    Message = $"No Card with ID: {entity.Id}"
                };
            _CardRepository.Delete(CardToDelete);

            return new Response { Success = true, Message = $"Card deleted" };
        }

        public Response UpdateCard(Card entity)
        {
            //Validazione argomenti
            if (entity == null)
                return new Response() { Success = false, Message = "Incorrect entity" };

            
            var CardToUpdate = FetchAllCards().FirstOrDefault(x => x.Id == entity.Id);

            //Se invece la lista è vuota significa che è andato tutto bene
            _CardRepository.Update(CardToUpdate, entity);

            //Emetto comunque la lista (vuota) per segnalare che è andato tutto bene
            return new Response() { Success = true, Message = "Card updated" };
        }
    }
}
