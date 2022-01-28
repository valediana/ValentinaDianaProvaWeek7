
using GiftCard.Desktop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCard.Desktop.Core.Mock
{
    public static class AllocationMockStorage
    {
        public static IList<Card> Cards { get; set; }
       

        public static void Initialize()
        {
            
            //creazione della lista vuota
            Cards = new List<Card>();

            //Aggiunta di card
            Cards.Add(new Card
            {
                Id = 1,
                Destinatario ="Valentina D",
                Mittente ="Mario Rossi",
                Importo =50.0 ,
                DataScadenza = new DateTime(2022, 12, 31),
                Messaggio="Congratulazioni"

            });
            Cards.Add(new Card
            {
                Id = 2,
                Destinatario = "Anna Bianchi",
                Mittente = "Marco Verdi",
                Importo = 100.0,
                DataScadenza = new DateTime(2022, 12, 31),
                Messaggio ="Tanti auguri"
            });
            Cards.Add(new Card
            {
                Id = 3,
                Destinatario = "Luca Verdi",
                Mittente = "Marco Verdi",
                Importo = 200.0,
                DataScadenza = new DateTime(2022, 12, 31),
                Messaggio="Buon compleanno"
            });



        }
    }
}
