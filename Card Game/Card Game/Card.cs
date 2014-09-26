using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Card_Game
{
    public class Card
    {
        private Codes.Symbols symbol;
        private Codes.Vals val;
        private int worth;
        private int x1,x2;
        private int y1,y2;
        private Texture2D image;
        String name = null;
        private int cardNo;

       // public Card(Codes.Symbols symbol,Codes.Vals val)
        public Card(int no)
        {
            this.cardNo = no;
            String name = XMLReader.getCardName(no);
            this.symbol = (Codes.Symbols)Enum.Parse(typeof(Codes.Symbols), name.Substring(0, 1));
            this.val = (Codes.Vals)Enum.Parse(typeof(Codes.Vals), name.Substring(1, 2));
            this.worth = XMLReader.getWorth(val);
            this.image = Game1.getCardImage(no);
            this.name = this.symbol.ToString() + this.val + "";

        }
        //public Card( )
        //{ 
        //}
        public int getNo()
        {
            return cardNo;
        }

        public Texture2D getImage()
        {
            return image;
        }
        //public Card(int x1, int x2, int y1, int y2, Codes.Symbols symbol, Codes.Vals val)
        //{
        //    this.x1 = x1;
        //    this.x2 = x2;
        //    this.y1 = y1;
        //    this.y2 = y2;

        //    this.symbol = symbol;
        //    this.val = val;
        //    this.worth = XMLReader.getWorth(val);
        //}
        public void setPos(int x1, int x2, int y1, int y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }

        public Boolean isMe(int x, int y)
        {
            if (x1 <= x && x <= x2 && y1 <= y && y <= y2) return true;
            else return false;
        }

        private int getWorth()
        {
            return worth;
        }

        public Codes.Symbols getSymbol()
        {
            return symbol;
        }

        public String getImageName()
        {
            return symbol.ToString() + val+".png";
        }

        public String getName()
        {
            return name;
        }


        public Boolean isWorthThan(Card card,Codes.Symbols thurumpu){
            if (this.getSymbol() == thurumpu && card.getSymbol() == thurumpu)
            {
                if (this.getWorth() >= card.getWorth()) return true;
                else return false;
            }
            else if (this.getSymbol() == thurumpu) return true;
            else if (card.getSymbol() == thurumpu) return false;
            else
            {
                if (this.getWorth() >= card.getWorth()) return true;
                else return false;
            }
        }

    }
}
