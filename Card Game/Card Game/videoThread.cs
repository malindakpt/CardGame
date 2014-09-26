using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Card_Game
{
    class videoThread
    {
        Game1 game1; 

        public videoThread(Game1 game1)
        {
            this.game1 = game1;
        }
 
        public void start()
        {
            Thread.Sleep(Codes.VID_PLAY_TIME);
           
           
             
            if(!game1.skip){

                game1.vidPlay = false;
                game1.comeUp = true;

                for (int i = 0; i < 6 ; i++)
                {
                    game1.gap += 50;
                    Thread.Sleep(350);
                }
                game1.gap = game1.gap1;
                for (int i = 0; i < 6 ; i++)
                {
                    game1.gap += 50;
                    Thread.Sleep(350);
                }
                game1.comeUp = false;
                game1.gameOk = true;
            }
        }
    }
}
