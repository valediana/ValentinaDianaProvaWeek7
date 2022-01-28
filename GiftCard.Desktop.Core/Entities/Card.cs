using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCard.Desktop.Core.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public string Mittente { get; set; }
        public string Destinatario { get; set; }
        public string Messaggio { get; set; }
        public double Importo { get; set; }
        public DateTime DataScadenza { get; set; }

        public override string ToString()
        {
            return $"Mittente: {Mittente} Destinatario: {Destinatario} Messaggio: {Messaggio} DataScadenza: {DataScadenza}";
        }
    }
}
