using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_ASP_Groep_E_S24
{
    public class Reservering
    {
        //Fields
        private string status;
        private List<Plaats> plaatsen;
        private Hoofdboeker hoofdboeker;

        //Properties
        public string Status
        {
            get { return status; }
        }

        public List<Plaats> Plaatsen
        {
            get { return plaatsen; }
        }

        //Constructor
        public Reservering(Hoofdboeker hoofdboeker, List<Plaats> plaatsen)
        {
            this.hoofdboeker = hoofdboeker;
            this.plaatsen = plaatsen;
        }

        public bool HuurMateriaal(Huuritem huuritem)
        {
            // Als het huuritem nog niet gehuurd is, moet deze bij een persoon aan de lijst gehuurd toegevoegd worden.
            // bool isgehuurd wordt true.
            return false;
        }
    }
}
