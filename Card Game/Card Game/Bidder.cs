using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Card_Game
{
    public partial class Bidder : Form
    {

        Game1 game1;
        int lastVal;

        public Bidder(Game1 game1)
        {
            InitializeComponent();
            this.game1 = game1;
        }

        private void Bidder_Load(object sender, EventArgs e)
        {
            Console.WriteLine("L1");
            if (game1.myPos == 0)
            {
                Console.WriteLine("L2");
                trackBar1.Value = 160;
                label1.Text = trackBar1.Value.ToString();
                game1.myBid = trackBar1.Value.ToString();
            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (lastVal < trackBar1.Value)
            {
                label1.Text = trackBar1.Value.ToString();
                progressBar1.Value = trackBar1.Value;
                game1.myBid = trackBar1.Value.ToString();

                lastVal = trackBar1.Value;
            }
            else
            {
                trackBar1.Value = lastVal;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String bidString = Server.get_max_bid(game1, game1.game_id, game1.player_id);
            String maxPlayer = bidString.Split(':')[0];
            String maxbid = bidString.Split(':')[1];

            //if(maxbid==game1.myBid && ){

            //}

            if (maxbid.Equals(game1.myBid.ToString()) && !maxPlayer.Equals(game1.myPos.ToString()))
            {
                MessageBox.Show("Conflicting bid. try a gain");
            }
            else
            {

                game1.MeBided = true;
                trackBar1.Enabled = false;
                button1.Text = "WAIT...";
                button1.Enabled = false;
            }

        }
     
    }
}
