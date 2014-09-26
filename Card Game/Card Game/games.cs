using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Card_Game
{
    class games
    {
        String game_id;
        String game_name;
        String password;

        public games(String game_id, String game_name, String password)
        {
            this.game_id = game_id;
            this.game_name = game_name;
            this.password = password;
        }

        public String getID()
        {
            return game_id;
        }
        public String getName()
        {
            return game_name;
        }
        public String getPwd()
        {
            return password;
        }
    }
}
