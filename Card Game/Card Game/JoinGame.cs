using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Card_Game
{
    public partial class JoinGame : Form
  
    {
         games[] gg;
         Game1 game1;
         Boolean won = false;
        
         Thread updater;

        public JoinGame(Game1 game1,String details)
        {
            InitializeComponent();
            this.game1 = game1;
            this.updater = game1.updater;

            String[] ss=details.Split('&');
           gg = new games[ss.Length-1];

            for (int i = 0; i < ss.Length-1; i++)
            {
                String[] temp = ss[i].Split('$');
                gg[i] = new games(temp[0], temp[1], temp[2]);

                cmbGames.Items.Add(gg[i].getName());
            }
            this.Show();
        }

        private void JoinGame_Load(object sender, EventArgs e)
        {
            cmbGames.SelectedIndex = 0;


            // cmbGames.SelectedIndex = 1;
            // txtName.Text=DateTime.Now.ToString()+" Name";
            // txtEmail.Text=DateTime.Now.ToString()+" Email";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbGames.SelectedIndex != 0 && txtEmail.Text!="" && txtName.Text!="")
            { 
                String name = txtName.Text;
                String email = txtEmail.Text;
                String game_id = gg[cmbGames.SelectedIndex - 1].getID();

                game1.game_id = game_id;
                game1.player_id = email;

                if (cmbGames.SelectedIndex == 0)
                    MessageBox.Show("Please select a game");
                else
                {
                    this.Hide();
                    String pos = Server.join_game(game1, game_id, email, name);

                    game1.myPos = Convert.ToInt32(pos);

                    if (pos.Equals(""))
                    {
                        MessageBox.Show("Game is Full");
                        this.Show();
                    }
                    else
                    {
                        Console.WriteLine(pos);
                       Updater update = new Updater(game1, game_id, email);
                        updater = new Thread(new ThreadStart(update.start));
                        updater.Start();
                    }

                }
            }
            else
            {
                MessageBox.Show("Error in your inputs", "Invalied inputs", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            int t = cmbGames.SelectedIndex;

            //if (gg[t].getPwd().Equals(""))
            //    txtPWD.Enabled = false;
            //else
            //    txtPWD.Enabled = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new GAmeController(game1);
        }
    }
}
