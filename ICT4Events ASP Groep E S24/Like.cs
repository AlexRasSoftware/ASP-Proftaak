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
        private Account liker;
        private int id;

        //Property
        public Account Liker
        {
            get { return liker; }
        }

        public int Id
        {
            get { return id; }
        }

        //Constructor
        public Like(Account liker)
        {
            this.liker = liker;
        }

        

        public Like(Account liker, int id)
        {
            this.liker = liker;
            this.id = id;
            if (id > Administratie.hoogsteIdLike)
            {
                Administratie.hoogsteIdLike = id;
            }
        }
    }
}
