using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
 
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Threading;
 

namespace Card_Game
{
    public partial class GAmeController : Form
    {
         
        Game1 game1;
        String gameID;
       // Card[] myCards;
        Card[] cardsPack;
        Table table;
        string my_ID;

        public GAmeController(Game1 g)
        {
            
            InitializeComponent();
            this.game1 = g;
            table = new Table();
            this.Show();
        }

        private void GAmeController_Load(object sender, EventArgs e)
        {
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtPlayerName.Text != "" && txtGameName.Text != "" && txtEmail.Text != "")
            {
                this.Hide();
                createGame();
                Updater update = new Updater(game1, gameID, my_ID);
                Thread updater = new Thread(new ThreadStart(update.start));
                updater.Start();
            }
            else
            {
                MessageBox.Show("Fill essential data", "Invalied inputs", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void createGame()
        {
          
            cardsPack = table.getCardPAck();   
         
            this.gameID = DateTime.Now.ToString();
            game1.game_id = gameID;

            String password = "";// txtPassword.Text; 
            String player_Name = txtPlayerName.Text;
            String gameName = txtGameName.Text;

            my_ID = txtEmail.Text;
            game1.player_id = my_ID;


            /////////////////////////////////////////////////////////////////////////////////////////////////
            string myParameters0 = "game_id=" + gameID + "&game_name="+gameName+"&password=" + password + "&thurumpu=" + "" + "&player_id_0=" +
                txtEmail.Text + "&player_name_0=" + player_Name + "&card_0=" + cardsPack[0].getName() + "&card_1=" + cardsPack[1].getName() + "&card_2=" + cardsPack[2].getName() + "&card_3=" + cardsPack[3].getName()
                + "&card_4=" + cardsPack[4].getName() + "&card_5=" + cardsPack[5].getName();
            /////////////////////////////////////////////////////////////////////////////////////////////////

            string myParameters1 = "game_id=" + gameID + "&password=" + password + "&thurumpu=" + "" + "&player_id_1=" +
               "" + "&player_name=" + player_Name + "&card_6=" + cardsPack[6].getName() + "&card_7=" + cardsPack[7].getName() + "&card_8=" + cardsPack[8].getName() + "&card_9=" + cardsPack[9].getName()
                + "&card_10=" + cardsPack[10].getName() + "&card_11=" + cardsPack[11].getName();
             
            /////////////////////////////////////////////////////////////////////////////////////////////////
            string myParameters2 = "game_id=" + gameID + "&password=" + password + "&thurumpu=" + "" + "&player_id_2=" +
                "" + "&player_name=" + player_Name + "&card_12=" + cardsPack[12].getName() + "&card_13=" + cardsPack[13].getName() + "&card_14=" + cardsPack[14].getName() + "&card_15=" + cardsPack[15].getName()
                + "&card_16=" + cardsPack[16].getName() + "&card_17=" + cardsPack[17].getName();
 
            /////////////////////////////////////////////////////////////////////////////////////////////////
            string myParameters3 = "game_id=" + gameID + "&password=" + password + "&thurumpu=" + "" + "&player_id_3=" +
              "" + "&player_name=" + player_Name + "&card_18=" + cardsPack[18].getName() + "&card_19=" + cardsPack[19].getName() + "&card_20=" + cardsPack[20].getName() + "&card_21=" + cardsPack[21].getName()
              + "&card_22=" + cardsPack[22].getName() + "&card_23=" + cardsPack[23].getName();

            /////////////////////////////////////////////////////////////////////////////////////////////////
            Server.createGame(game1, myParameters0 + "&" + myParameters1 + "&" + myParameters2 + "&" + myParameters3);
            Console.WriteLine("Game created");
 
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Server.clear_DB(game1);
            Console.WriteLine("DB Cleared");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            string ss=(Server.get_Games(game1));
          
            while(ss==null)
                ss = (Server.get_Games(game1));

            Console.WriteLine(ss);
            JoinGame jg = new JoinGame(game1,ss);
          
        }

    }
}
 