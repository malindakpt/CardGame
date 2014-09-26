using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Card_Game
{
    
    class Table
    {
        private Codes.Symbols thurumpu;
        public Card[] cardsPack;

        
        private Player[] player;
        private Hashtable hashtable ;


        public Table()
        {
            hashtable = new Hashtable();
            this.cardsPack = new Card[Codes.NO_OF_CARDS];
            player = new Player[Codes.NO_OF_PLAYERS];
            createCardPack();
                        
        }

        public Card[] getCardPAck()
        { 
            return cardsPack;
        }

        public Card[] createCardPack()
        {
         
            int[] xx = assignCards();

            for (int i = 0; i < Codes.NO_OF_CARDS; i++)
            {
                cardsPack[i] = new Card(xx[i]);
               
            }

            return cardsPack;
        }

        public int[] assignCards()
        {
            int[] set = new int[Codes.NO_OF_CARDS]; 
            Random r = new Random();
            int i=0;
            while (i < Codes.NO_OF_CARDS)
            {
                int x = 52 - Codes.NO_OF_CARDS + r.Next(Codes.NO_OF_CARDS);

                if (!hashtable.ContainsKey(x))
                { 
                    set[i] = x;
                    hashtable.Add(x, true);
                    i++;
                }
            }

            return set;
        }

        
    }
}
