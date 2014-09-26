using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Card_Game
{
    public class Trump
    {
        int x1,x2,y1,y2;
        String sym;
        private Texture2D image=null;

        public Trump(String sym)
        {
            this.sym = sym;
            if(sym.Equals(Codes.Symbols.C.ToString()))    this.image=Game1.getThurumpuImage(0);
            if (sym.Equals(Codes.Symbols.D.ToString())) this.image = Game1.getThurumpuImage(1);
            if (sym.Equals(Codes.Symbols.H.ToString())) this.image = Game1.getThurumpuImage(2);
            if (sym.Equals(Codes.Symbols.S.ToString())) this.image = Game1.getThurumpuImage(3);
        }

        public String getSym()
        {
            return this.sym.ToString();
        }


        public Texture2D getImage()
        {
            return image;
        }

        public Boolean isMe(int x, int y)
        {

           // Console.WriteLine("x=" + x + " y=" + y + " x1=" + x1 + " y1=" + y1 + " x2=" + x2 + " y2=" + y2);

            if (x1 <= x && x <= x2 && y1 <= y && y <= y2) return true;
            else return false;
        }

        public void setPos(int x1, int x2, int y1, int y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }

        
    }
}
