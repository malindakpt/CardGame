using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Card_Game
{
    class Updater
    {
        private Game1 game1;
        Card[] mycards;
        string[] Smycards;
        string gameID;
        string myID;
        int status = 0;
        String given_card;
        String drawnText = "";
        String round_starter = "";
        Boolean enable_incre = false;
        String nowC = "";
       
        
     
        public Updater(Game1 game1,String gameID,String myID)
        {
            this.game1 = game1;
            this.gameID = gameID;
            this.myID = myID;
           
        }
     
        public  void start()
        {
            Console.WriteLine("pos " + game1.myPos + ", Updater started succesfully");
            game1.drawMiddle = true;
            
            int t = 0;
            ////////////////////////////////////////////////////////////
            while(true)
            {
                String temp = Server.get_ready(game1, gameID);

                if (temp != null)
                { 
                    if (temp.Equals("0"))
                        break;
                    if (++t == 1) break;
                }
                Thread.Sleep(Codes.UPDATE_TIME);            
            }
            Console.WriteLine("pos " + game1.myPos + ", Waiting for other players to join OK");
            ///////////////////////////////////////////////////////////////////////////////
            do
            {
                String mc = Server.get_mycards(game1, gameID, myID);
                if(mc!=null)
                    Smycards = mc.Split(':');

            } while (Smycards.Length < Codes.CARDS_PER_PLAYER);


            mycards = new Card[Codes.CARDS_PER_PLAYER];

            for (int i = 0; i < Codes.CARDS_PER_PLAYER; i++)
            {
                mycards[i] = new Card(XMLReader.getCardNO(Smycards[i]));
            }

            game1.myCards = mycards;
            game1.giveFirstCards = true;

            for (int i = 0; i < Codes.CARDS_PER_PLAYER / 2; i++)
            {
                game1.giveCardtoEast();
                Thread.Sleep(Codes.SLEEP_TIME);

                game1.giveCardtoNorth();
                Thread.Sleep(Codes.SLEEP_TIME);

                game1.giveCardtoWest();
                Thread.Sleep(Codes.SLEEP_TIME);

                game1.giveCardtoMe();
                Thread.Sleep(Codes.SLEEP_TIME);
            }

           game1.trumpChooser = true;
 
           while (!game1.giveAllCards) {  }
           Console.WriteLine("pos " + game1.myPos + ", Waiting for Bidder to give all cards OK");
            
            
            ////////////////////////////////////////////////////////////////
           for (int i = Codes.CARDS_PER_PLAYER / 2; i < Codes.CARDS_PER_PLAYER; i++)
           {
               game1.giveCardtoEast();
               Thread.Sleep(Codes.SLEEP_TIME);

               game1.giveCardtoNorth();
               Thread.Sleep(Codes.SLEEP_TIME);

               game1.giveCardtoWest();
               Thread.Sleep(Codes.SLEEP_TIME);

               game1.giveCardtoMe();
               Thread.Sleep(Codes.SLEEP_TIME);
           }
           ////////////////////////////////////////////////////////////    
      
           while (!game1.MeBided) {  }
           Console.WriteLine("pos " + game1.myPos + ", Waiting for My bid OK");

           ////////////////////////////////////////////////////////////            
           Console.WriteLine("pos " + game1.myPos + ", Checking all bided ..");
           String trump_player = "";
          
           while (true)
           {

               String ss = Server.chk_all_bided(game1, game1.game_id);
               
               if (ss!=null && !ss.Equals(""))
               {
                    trump_player = ss.Split(':')[0];
            
                   game1.game_bid = Convert.ToInt32(ss.Split(':')[1]);
                   game1.AllBided = true;

                   String trump = ss.Split(':')[2];

                   game1.gameTrump = new Trump(trump.ToUpper());
                   game1.game_trump = trump.ToUpper();

                   Console.WriteLine("ALL BIDED, bid=" + game1.game_bid+"pos="+trump_player+"sym="+trump);

                   if (trump_player.Equals(game1.myPos)) game1.trump_my = true;

                   break;
               }
              Thread.Sleep(Codes.UPDATE_TIME);
           }
           Console.WriteLine("pos " + game1.myPos + ", Checking all bided OK");
           /////////////////////////////////////////////////////////
           if (game1.myPos == 0)
           {
               Console.WriteLine("----trump_player=" + trump_player);
               Server.set_starter(game1, game1.game_id, trump_player);
               while (!Server.set_next_chance(game1, game1.game_id, trump_player).Equals("ok")) { Thread.Sleep(Codes.UPDATE_TIME * 2); }
           }
            //////////////////////////////////////////////////////
           Console.WriteLine("pos "+game1.myPos+",Waiting for my chance to play ..");


           while (true && game1.isRunning)
           {
               try
               {
                   game1.widthX = game1.widthXMAX;
                   if (!game1.my_chance)
                   {
                       Console.WriteLine("-------------------- " + game1.updateNo + " -------------------- ");
                       getUpdate();
                   }
                   else if (game1.ready_send_myChoice)
                   {
                       
                       Server.set_my_given(game1,game1.game_id, game1.player_id, game1.my_given_card.getName());

                       if (drawnText.Length < 45)
                       {
                           Server.set_next_chance(game1, game1.game_id, getNextPos());
                       }
                       else if (drawnText.Length ==45)
                       {
                           Server.set_next_chance(game1, game1.game_id, "-1");
                       }
                      
                       ///////////////////////////////////////////////////
                       game1.my_chance = false;
                       game1.me_given = false;
                       game1.ready_send_myChoice = false;
                   }

                   chk_round(status);
               }
               catch (Exception e) { }
               Thread.Sleep(Codes.UPDATE_TIME);
           }
 
        }

        private void getMarks()
        {
            try
            {
                String[] marks = Server.get_marks(game1, game1.game_id).Split(':');

                game1.m0 = marks[0];
                game1.m1 = marks[1];
                game1.m2 = marks[2];
                game1.m3 = marks[3];

            }
            catch (Exception e)
            { }


        }

        private void finishCards()
        {
            game1.EastCardCount = 0;
            game1.NorthCardCount = 0;
            game1.WestCardCount = 0;
            game1.myCardCount = 0;
        }
 
        private void getUpdate( ){
            String text = Server.chk_mychance(game1, game1.game_id);
            drawnText = text;
            String[] plys = text.Split(','); 
            status = 0;
            int pos = 0;

           round_starter=plys[0].Split(':')[3];

           if (plys[0].Split(':')[2].Equals("") && plys[1].Split(':')[2].Equals("") && plys[2].Split(':')[2].Equals("") && plys[3].Split(':')[2].Equals("") && !game1.is_starter)
           {
               game1.new_round();
               if (enable_incre)
               {
                   game1.round++;
                   enable_incre = false;
               }
           }
           else
           {
               enable_incre = true;
           }

            if (drawnText.Length > 47 && game1.is_starter)
            {
                Console.WriteLine("ROUND OVER=" + drawnText);
                finish_round();
            }

            if (Convert.ToInt32(plys[0].Split(':')[3]) == game1.myPos)
            {
                game1.is_starter = true;
            }
            else
            {
                game1.is_starter = false;
            }

            if (!(plys[0].Split(':')[4]).Equals("0"))
            {
                    String s= plys[0].Split(':')[4];
                    game1.gameTrump = new Trump(s);
                    game1.trump_discovered = true;
            }
            else
            {
                game1.trump_discovered = false;
            }

            for (int i = 0; i < 4; i++)
            {
                String temp = plys[i];
                pos = Convert.ToInt32(temp.Split(':')[1]);
                given_card = temp.Split(':')[2];

                try
                {
                    status = Convert.ToInt32(temp.Split(':')[0]);

                    if (i == 0)
                    {
                        game1.game_trump_player = pos;
                    }
                }
                catch (Exception e)
                {
                    if (temp.Split(':')[0].Equals("won") && pos==game1.myPos)
                    {
                        game1.game_result = "WON";
                        Console.WriteLine("-------YOU WON----------------GAME OVER--------------------------");
                        getMarks();
                        game1.isRunning = false;
                        finishCards();
                        break;
                    }
                    else if (temp.Split(':')[0].Equals("notwon1") && pos == game1.myPos)
                    {
                        
                        game1.game_result = "FAILED";
                        Console.WriteLine("-------YOU FAILED--------------GAME OVER-------------------------");
                        getMarks();
                        game1.isRunning = false;
                        finishCards();
                        break;
                    }
                }


              if (!given_card.Equals("") && !round_starter.Equals(""))
                {
                    if (round_starter.Equals(pos.ToString()))
                    {
                        game1.trump_player = temp.Split(':')[0];
                        if (!given_card.Equals(""))
                        {
                            game1.nowCard = given_card;
                            nowC = game1.nowCard.Substring(0, 1);
                        }
                        else
                            game1.nowCard = null;
                    }

                    if (status != game1.myPos || true)
                    {
                        if (game1.myPos == 0)
                        {
                            if (pos == 0) { game1.my_given_card = new Card(XMLReader.getCardNO(given_card)); }
                            else if (pos == 1) { game1.p1_given_card = new Card(XMLReader.getCardNO(given_card)); }
                            else if (pos == 2) { game1.p2_given_card = new Card(XMLReader.getCardNO(given_card)); }
                            else if (pos == 3) { game1.p3_given_card = new Card(XMLReader.getCardNO(given_card)); }
                        }
                        else if (game1.myPos == 1)
                        {
                            if (pos == 0) { game1.p3_given_card = new Card(XMLReader.getCardNO(given_card)); }
                            else if (pos == 1) { game1.my_given_card = new Card(XMLReader.getCardNO(given_card)); }
                            else if (pos == 2) { game1.p1_given_card = new Card(XMLReader.getCardNO(given_card)); }
                            else if (pos == 3) { game1.p2_given_card = new Card(XMLReader.getCardNO(given_card)); }
                        }
                        else if (game1.myPos == 2)
                        {
                            if (pos == 0) { game1.p2_given_card = new Card(XMLReader.getCardNO(given_card)); }
                            else if (pos == 1) { game1.p3_given_card = new Card(XMLReader.getCardNO(given_card)); }
                            else if (pos == 2) { game1.my_given_card = new Card(XMLReader.getCardNO(given_card)); }
                            else if (pos == 3) { game1.p1_given_card = new Card(XMLReader.getCardNO(given_card)); }
                        }
                        else if (game1.myPos == 3)
                        {
                            if (pos == 0) { game1.p1_given_card = new Card(XMLReader.getCardNO(given_card)); }
                            else if (pos == 1) { game1.p2_given_card = new Card(XMLReader.getCardNO(given_card)); }
                            else if (pos == 2) { game1.p3_given_card = new Card(XMLReader.getCardNO(given_card)); }
                            else if (pos == 3) { game1.my_given_card = new Card(XMLReader.getCardNO(given_card)); }
                        }
                    }
                }
            }
            game1.updateNo++;
            Console.WriteLine(game1.updateNo + " Drawn " + text);

            if (game1.updateNo == 1)
            {
                game1.allow_draw = true;
            }
            else
            {
                game1.allow_draw = false;
            }

            if (status == game1.myPos && game1.isRunning)
            {
                Console.WriteLine("pos " + game1.myPos + ", my chance to play-  UPDATE NO= " + game1.updateNo);
                game1.my_chance = true;
                game1.curernt =game1.myPos;
            }
            else
            {
                game1.curernt = status;
            }
        }

        private void finish_round()
        { 
                Console.WriteLine((game1.round++) + "  ROUND OVER ! ! !-" + nowC);
                String result = Server.set_finish_round(game1, game1.game_id);

                if (game1.cards_over())
                {
                    Console.WriteLine("  FINISH GAME ");
                    String s = Server.set_finish_game(game1, game1.game_id);
                    
                }
                game1.new_round();
                 
        }

        private void chk_round(int status)
        {
            if (game1.my_given_card != null && game1.p1_given_card != null && game1.p2_given_card != null && game1.p3_given_card != null
                && status != game1.myPos)
            {
                Thread.Sleep(1500);
                game1.new_round();
            }

        }

        private String getNextPos()
        {
            if (game1.myPos == 0) return "1";
            else if (game1.myPos == 1) return "2";
            else if (game1.myPos == 2) return "3";
            else return "0";
        }
   }
}
