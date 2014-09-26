using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Card_Game
{
    public static class Codes
    {
        public const int VID_PLAY_TIME = 23000;
        public const int MID_BACGROUND_TIME = 2000;

        public const int SLEEP_TIME = 100;
        public const int UPDATE_TIME = 3000;
        public enum Symbols { C, D, H, S,NULL};
        public enum Vals { AC, TW, TH, FO, FI, SI, SE, EI, NI, TE, JA, QU, KI };
        public enum Teams { A, B };
        public enum Pos { NORTH, WEST, SOUTH, EAST };
        public const int NO_OF_PLAYERS = 4;
        public const int NO_OF_CARDS = 24;
        public const int CARDS_PER_PLAYER = NO_OF_CARDS / NO_OF_PLAYERS;
        public const String PATH = "C:\\Program Files\\CARDS.xml";
    }
}
