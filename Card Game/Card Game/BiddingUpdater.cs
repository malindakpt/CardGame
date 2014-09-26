using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Card_Game
{
    public class BiddingUpdater
    { 
        int mypos;
        string game_id;
        string player_id; 
        Game1 game1;
  
        public BiddingUpdater( Game1 game1,string game_id,string player_id,int mypos)
        {         
            this.game1 = game1;
            this.mypos = mypos;
            this.game_id = game_id;
            this.player_id = player_id;   
        }


        public void start()
        {        
            Console.WriteLine("BIDDER STARTED"); 
            while (true)
            {
                try
                {
                    String bids = Server.send_get_bids(game1, game_id, player_id, game1.myBid, mypos, game1.MeBided, game1.myTrump.getName().ToString());

                    if (bids != null && !game1.AllBided)
                    {
                   
                        String biddingCompleted = bids.Split('*')[1];
                        String[] players = bids.Split('*')[0].Split('&');

                        Game1.p0bid = players[0].Split(':')[1];
                        Game1.p1bid = players[1].Split(':')[1];
                        Game1.p2bid = players[2].Split(':')[1];
                        Game1.p3bid = players[3].Split(':')[1];

                        if (biddingCompleted.Equals("0"))
                        {
                            game1.giveAllCards = true;
                            game1.trumpChooser = false;

                            String Snames = Server.get_player_names(game1, game1.game_id);
                            String[] names =Snames.Split(':');
                            Console.WriteLine(Snames);

                            game1.p0Name = names[0];
                            game1.p1Name = names[1];
                            game1.p2Name = names[2];
                            game1.p3Name = names[3];

                            break;
                        }

                    }
                }
                catch (Exception e)
                { }
                Thread.Sleep(2000);
            }
            game1.stop_song = true;
            Console.WriteLine("\nBIDDER CLOSED");
        }
    }
}
