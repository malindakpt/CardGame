using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Card_Game
{
    class Player
    {
        Codes.Teams team;
        Card[] cards;
        private int cardCount;

        public Player(Codes.Teams team)
        {
            this.team = team;
            cards = new Card[Codes.CARDS_PER_PLAYER];
            cardCount=Codes.CARDS_PER_PLAYER;
        }
    }
}
