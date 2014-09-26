using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Card_Game
{
    class Server
    {
        static string URI_1 = "http://cardgameiit.site90.net//";
        static string serverName = "mysql3.000webhost.com";
        static string dbUser = "a7529413_user1";
        static string dbPass = "CG@12345";
        static string dbName = "a7529413_db1";

        static string auth = "serverName=" + serverName + "&dbUser=" + dbUser + "&dbPass=" + dbPass + "&dbName=" + dbName;
 
        public static String createGame(Game1 game1,String myParameters)
        {
            try
            {
                string HtmlResult = null;
                string URI = URI_1+"create_newgame.php";
        
                using (WebClient wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    HtmlResult = wc.UploadString(URI,auth+"&"+ myParameters);
                }
                String[] result=HtmlResult.Split('#');

                if (result[result.Length - 2].Equals("OK"))
                    return result[0];
                else
                    return createGame(game1, myParameters);

            }
            catch (Exception e)
            {
                return createGame(game1, myParameters);
            }
        }

        public static String clear_DB(Game1 game1)
        {
             try
            {
                    string HtmlResult = null;
                    string URI = URI_1 + "Clear_DB.php"; 

                    using (WebClient wc = new WebClient())
                    {
                        wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                        HtmlResult = wc.UploadString(URI, auth);
                    }

                    String[] result = HtmlResult.Split('#');

                    if (result[result.Length - 2].Equals("OK"))
                        return result[0];
                    else
                        return clear_DB(game1);

             }
            catch (Exception e)
            {
                return clear_DB(game1);
            }
        }

        public static void set(Game1 game1)
        {
            try
            { 
                game1.mod = mkpt.auth.get_auth();
            }
            catch (Exception e)
            {
                 
            }
        }

        public static String get_mycards(Game1 game1, String game_id, String player_id)
        {
             try
            {
                    string HtmlResult = null;
                    string URI = URI_1 + "get_mycards.php";
                    String myParameters = auth+"&game_id=" + game_id + "&player_id=" + player_id;

                    using (WebClient wc = new WebClient())
                    {
                        wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                        HtmlResult = wc.UploadString(URI, auth+"&"+myParameters);
        
                    }
                    String[] result = HtmlResult.Split('#');

                    if (result[result.Length - 2].Equals("OK"))
                        return result[0];
                    else
                        return get_mycards(game1,game_id,player_id);

             }
            catch (Exception e)
            {
                return get_mycards(game1, game_id, player_id);
            }
        }
        public static String get_ready(Game1 game1, String game_id)
        {
             try
            {
                string HtmlResult = null;
                string URI = URI_1 + "get_ready.php";
                String myParameters = auth + "&game_id=" + game_id;

                using (WebClient wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    HtmlResult = wc.UploadString(URI,auth+"&"+ myParameters);
                }

                String[] result = HtmlResult.Split('#');

                if (result[result.Length - 2].Equals("OK"))
                    return result[0];
                else
                    return get_ready(game1, game_id);

            }
            catch (Exception e)
            {
                return get_ready(game1, game_id);
            }

        }

        public static String get_Games(Game1 game1)
        {
             try
            {
                    string HtmlResult = null;
                    string URI = URI_1 + "get_games.php";
           
                    using (WebClient wc = new WebClient())
                    {
                        wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                        HtmlResult = wc.UploadString(URI, auth);

                    }

                    String[] result = HtmlResult.Split('#');

                    if (result[result.Length - 2].Equals("OK"))
                        return result[0];
                    else
                        return get_Games(game1);
            }
            catch (Exception e)
            {
                return get_Games(game1);
            }

        }

        public static String send_get_bids(Game1 game1, String game_id, String player_id, String myBid, int mypos, Boolean bided, String trump)
        {
            try
            {
                string HtmlResult = null;
                string URI = URI_1 + "send_get_bids.php";
                string partner = "";

                String status = "ready";
                if(bided) status="bided";
            

                if (mypos == 0) partner = "2";
                if (mypos == 1) partner = "3";
                if (mypos == 2) partner = "0";
                if (mypos == 3) partner = "1";

                using (WebClient wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    HtmlResult = wc.UploadString(URI, auth + "&my_bid=" + myBid + "&partner=" + partner + "&status=" + status + "&game_id=" + game_id + "&player_id=" + player_id + "&trump=" + trump);
                }

                String[] result = HtmlResult.Split('#');

                if (result[result.Length - 2].Equals("OK"))
                    return result[0];
                else
                    return send_get_bids(game1, game_id,player_id,myBid,mypos,bided,trump);
  
             }
            catch (Exception e)
            {
                return send_get_bids(game1, game_id, player_id, myBid, mypos, bided, trump);
            }

        }


        public static String join_game(Game1 game1, String game_id, String player_id, String player_name)
        {
            try
            {
                string HtmlResult = null;
                string URI = URI_1 + "join_game.php";
                String para="game_id="+game_id+"&player_id="+player_id+"&player_name="+player_name;

                using (WebClient wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    HtmlResult = wc.UploadString(URI, auth+"&"+para);
                }

                String[] result = HtmlResult.Split('#');

                if (result[result.Length - 2].Equals("OK"))
                    return result[0];
                else
                    return join_game(game1, game_id, player_id, player_name);

            }
            catch (Exception e)
            {
                return join_game(game1, game_id, player_id, player_name);
            }

        }


        public static String get_max_bid(Game1 game1, String game_id, String my_id)
        {
            try
            {
                string HtmlResult = null;
                string URI = URI_1 + "get_max_bid.php"; 

                using (WebClient wc = new WebClient())
                {
                    
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    HtmlResult = wc.UploadString(URI, auth + "&game_id=" + game_id + "&player_id=" + my_id);
                }

                String[] result = HtmlResult.Split('#');

                if (result[result.Length - 2].Equals("OK"))
                    return result[0];
                else
                    return get_max_bid(game1, game_id, my_id);

            }
            catch (Exception e)
            {
                return get_max_bid(game1, game_id, my_id);
            }

        }

        public static String chk_all_bided(Game1 game1, String game_id)
        {
            try
            {
                string HtmlResult = null;
                string URI = URI_1 + "chk_all_bided.php";
               
                using (WebClient wc = new WebClient())
                {

                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    HtmlResult = wc.UploadString(URI, auth + "&game_id=" + game_id);
                }
          
                String[] result = HtmlResult.Split('#');

                if (result[result.Length - 2].Equals("OK"))
                    return result[0];
                else
                    return chk_all_bided(game1, game_id);

            }
            catch (Exception e)
            {
                return chk_all_bided(game1, game_id);
            }

        }

        public static String chk_mychance(Game1 game1, String game_id)
        {
            try
            {
                string HtmlResult = null;
                string URI = URI_1 + "chk_mychance.php";
       
                using (WebClient wc = new WebClient())
                {

                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    HtmlResult = wc.UploadString(URI, auth + "&game_id=" + game_id);
                }
                String[] result = HtmlResult.Split('#');

                if (result[result.Length - 2].Equals("OK"))
                    return result[0];
                else
                    return chk_mychance(game1, game_id);

            }
            catch (Exception e)
            {
                return chk_mychance(game1, game_id);
            }

        }

        public static String set_next_chance(Game1 game1, String game_id, String next)
        {
            try
            {
                string HtmlResult = null;
                string URI = URI_1 + "set_next_chance.php";
            
                using (WebClient wc = new WebClient())
                {

                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    HtmlResult = wc.UploadString(URI, auth + "&game_id=" + game_id + "&next=" + next);
                }
                String[] result = HtmlResult.Split('#');

                if (result[result.Length - 2].Equals("OK"))
                    return result[0];
                else
                    return set_next_chance(game1, game_id,next);
               
            }
            catch (Exception e)
            {
                return set_next_chance(game1, game_id, next);
            }

        }

        public static String set_my_given(Game1 game1, String game_id, String player_id, String given_card)
        {
            try
            {
                string HtmlResult = null;
                string URI = URI_1 + "set_my_given.php";

                using (WebClient wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    HtmlResult = wc.UploadString(URI, auth + "&game_id=" + game_id + "&player_id=" + player_id + "&given_card=" + given_card);
                }

                String[] result = HtmlResult.Split('#');

                if (result[result.Length - 2].Equals("OK"))
                    return result[0];
                else
                    return  set_my_given(game1, game_id,player_id, given_card);
            }
            catch (Exception e)
            {
                return set_my_given(game1, game_id, player_id, given_card);
            }
        }


        public static String set_finish_round(Game1 game1, String game_id)
        {
            try
            {
                string HtmlResult = null;
                string URI = URI_1 + "set_finish_round.php";

                using (WebClient wc = new WebClient())
                { 
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    HtmlResult = wc.UploadString(URI, auth + "&game_id=" + game_id);
                }

                String[] result = HtmlResult.Split('#');

                if (result[result.Length - 2].Equals("OK"))
                    return result[0];
                else
                    return set_finish_round(game1,game_id);

            }
            catch (Exception e)
            {
                return set_finish_round(game1, game_id);
            }

        }

        public static String set_finish_game(Game1 game1, String game_id)
        {
            try
            {
                string HtmlResult = null;
                string URI = URI_1 + "set_finish_game.php";

                using (WebClient wc = new WebClient())
                {

                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    HtmlResult = wc.UploadString(URI, auth + "&game_id=" + game_id);
                }
 
                String[] result = HtmlResult.Split('#');

                if (result[result.Length - 2].Equals("OK"))
                    return result[0];
                else
                    return set_finish_game(game1, game_id);

            }
            catch (Exception e)
            {
                return set_finish_game(game1, game_id);
            }

        }


        public static String set_starter(Game1 game1, String game_id, String pos)
        {
            try
            {
                string HtmlResult = null;
                string URI = URI_1 + "set_starter.php";

                using (WebClient wc = new WebClient())
                {

                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    HtmlResult = wc.UploadString(URI, auth + "&game_id=" + game_id + "&start_by=" + pos);
                }
                String[] result = HtmlResult.Split('#');

                if (result[result.Length - 2].Equals("OK"))
                    return result[0];
                else
                    return set_starter(game1,game_id, pos);

            }
            catch (Exception e)
            {
                return set_starter(game1, game_id, pos);
            }

        }


        public static String set_open_trump(Game1 game1, String game_id, String trump)
        {
            try
            {
                string HtmlResult = null;
                string URI = URI_1 + "set_open_trump.php";

                using (WebClient wc = new WebClient())
                {

                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    HtmlResult = wc.UploadString(URI, auth + "&game_id=" + game_id + "&trump=" + trump);
                }
                String[] result = HtmlResult.Split('#');

                if (result[result.Length - 2].Equals("OK"))
                    return result[0];
                else
                    return set_open_trump(game1, game_id, trump);
            }
            catch (Exception e)
            {
                return set_open_trump(game1, game_id, trump);
            }

        }

        public static String get_player_names(Game1 game1, String game_id)
        {
            try
            {
                string HtmlResult = null;
                string URI = URI_1 + "get_player_names.php";

                using (WebClient wc = new WebClient())
                {

                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    HtmlResult = wc.UploadString(URI, auth + "&game_id=" + game_id);
                }
                String[] result = HtmlResult.Split('#');

                if (result[result.Length - 2].Equals("OK"))
                    return result[0];
                else
                    return get_player_names(game1, game_id);

            }
            catch (Exception e)
            {
                return get_player_names(game1, game_id);
            }

        }


        public static String get_marks(Game1 game1, String game_id)
        {
            try
            {
                string HtmlResult = null;
                string URI = URI_1 + "get_marks.php";

                using (WebClient wc = new WebClient())
                {

                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    HtmlResult = wc.UploadString(URI, auth + "&game_id=" + game_id);
                }
                String[] result = HtmlResult.Split('#');

                if (result[result.Length - 2].Equals("OK"))
                    return result[0];
                else
                    return get_marks(game1, game_id);

            }
            catch (Exception e)
            {
                return get_marks(game1, game_id);
            }
        }
    }
}
