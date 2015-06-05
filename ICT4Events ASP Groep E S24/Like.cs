using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events_ASP_Groep_E_S24
{
    public class Like
    {
        //Field
        private Persoon liker;
        private int id;

        //Property
        public Persoon Liker
        {
            get { return liker; }
        }

        //Constructor
        public Like(Persoon liker)
        {
            this.liker = liker;
        }

        public Like(Persoon liker, int id)
        {
            this.liker = liker;
            this.id = id;
        }
    }
}
