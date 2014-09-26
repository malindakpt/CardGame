using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Card_Game
{
    
    class CardStore
    { 
        static HashSet<string> hs=new HashSet<string>();
        static HashSet<string> hsMycards = new HashSet<string>();

        public void addCard(String card)
        {
            if(!card.Equals(""))
            {
                hs.Add(card);
            }
        }

        public void clearCards()
        {
            hs.Clear();
        }


    }
}
