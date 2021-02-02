using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TFTScoutWinForms
{
    public partial class FormScout : Form
    {
        private Button[] players;
        private Queue<int> playersFought;
        private int buttonMe;
        private List<int> playersKilled;

        public FormScout()
        {
            InitializeComponent();
            resetScout();
        }

        private void resetScout()
        {
            players = new Button[]
            {
                btnPosition1, btnPosition2, btnPosition3, btnPosition4, btnPosition5, btnPosition6, btnPosition7, btnPosition8
            };
            playersFought = new Queue<int>();
            buttonMe = -1;
            playersKilled = new List<int>();
            applyDisable(true);
        }


        private void cbAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = cbAlwaysOnTop.Checked;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var form = new FormPlayersNames();
            DialogResult dResult = form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                resetScout();
                applyDisable(false);
                btnPosition1.Text = FormPlayersNames.strPlayer1;
                btnPosition2.Text = FormPlayersNames.strPlayer2;
                btnPosition3.Text = FormPlayersNames.strPlayer3;
                btnPosition4.Text = FormPlayersNames.strPlayer4;
                btnPosition5.Text = FormPlayersNames.strPlayer5;
                btnPosition6.Text = FormPlayersNames.strPlayer6;
                btnPosition7.Text = FormPlayersNames.strPlayer7;
                btnPosition8.Text = FormPlayersNames.strPlayer8;
                defineButtonMe();
                applyInitColor();
            }            
        }

        private void applyDisable(bool apply)
        {
            for (int i = 0; i < players.Length; i++)
            {
                players[i].Enabled = !apply;
            }
            btnRestart.Enabled = !apply;
        }

        private void defineButtonMe()
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(players[i].Text))
                {
                    buttonMe = i;
                    players[i].Text = "ME";
                    break;
                }
            }
        }

        private void applyInitColor()
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (i == buttonMe || playersKilled.Contains(i))
                {
                    players[i].BackColor = Color.Red;
                }
                else
                {
                    players[i].BackColor = Color.Green;
                }
            }
        }

        private void applyClickColor(Button bClicked)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (i != buttonMe && !playersKilled.Contains(i) && playersKilled.Count < 4)
                {
                    if (players[i].Name.Equals(bClicked.Name))
                    {
                        bClicked.BackColor = Color.Red;
                        playersFought.Enqueue(i);
                    }
                }
            }
        }

        private void resetPossibleOponent()
        {
            if ((7 - playersKilled.Count) - playersFought.Count == 2)
            {
                int resetPlayer = playersFought.Dequeue();
                players[resetPlayer].BackColor = Color.Green;
            }
        }

        private void applyPlayerKilled(Button bClicked, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && !bClicked.Name.Equals(players[buttonMe].Name))
            {
                for (int i = 0; i < playersKilled.Count; i++)
                {
                    if (bClicked.Name.Equals(players[playersKilled[i]].Name))
                    {
                        return;
                    }
                }

                var confirmResult = MessageBox.Show("Eliminate player?",
                                     "Eliminate",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    for (int i = 0; i < players.Length; i++)
                    {
                        if (players[i].Name.Equals(bClicked.Name))
                        {
                            playersKilled.Add(i);
                            playersFought.Clear();
                            break;
                        }
                    }
                    applyInitColor();
                }
            }
        }

        private bool validClick(Button bClicked)
        {
            return !playersFought.Any(c => players[c].Name.Equals(bClicked.Name));
        }

        private void btnPosition1_Click(object sender, EventArgs e)
        {
            if (!validClick(btnPosition1)) return;
            applyClickColor(btnPosition1);
            resetPossibleOponent();
        }

        private void btnPosition2_Click(object sender, EventArgs e)
        {
            if (!validClick(btnPosition2)) return;
            applyClickColor(btnPosition2);
            resetPossibleOponent();
        }

        private void btnPosition3_Click(object sender, EventArgs e)
        {
            if (!validClick(btnPosition3)) return;
            applyClickColor(btnPosition3);
            resetPossibleOponent();
        }

        private void btnPosition4_Click(object sender, EventArgs e)
        {
            if (!validClick(btnPosition4)) return;
            applyClickColor(btnPosition4);
            resetPossibleOponent();
        }

        private void btnPosition5_Click(object sender, EventArgs e)
        {
            if (!validClick(btnPosition5)) return;
            applyClickColor(btnPosition5);
            resetPossibleOponent();
        }

        private void btnPosition6_Click(object sender, EventArgs e)
        {
            if (!validClick(btnPosition6)) return;
            applyClickColor(btnPosition6);
            resetPossibleOponent();
        }

        private void btnPosition7_Click(object sender, EventArgs e)
        {
            if (!validClick(btnPosition7)) return;
            applyClickColor(btnPosition7);
            resetPossibleOponent();
        }

        private void btnPosition8_Click(object sender, EventArgs e)
        {
            if (!validClick(btnPosition8)) return;
            applyClickColor(btnPosition8);
            resetPossibleOponent();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            playersFought = new Queue<int>();
            playersKilled = new List<int>();
            applyInitColor();
        }


        private void btnPosition1_MouseDown(object sender, MouseEventArgs e)
        {
            applyPlayerKilled(btnPosition1, e);
        }

        private void btnPosition2_MouseDown(object sender, MouseEventArgs e)
        {
            applyPlayerKilled(btnPosition2, e);
        }

        private void btnPosition3_MouseDown(object sender, MouseEventArgs e)
        {
            applyPlayerKilled(btnPosition3, e);
        }

        private void btnPosition4_MouseDown(object sender, MouseEventArgs e)
        {
            applyPlayerKilled(btnPosition4, e);
        }

        private void btnPosition5_MouseDown(object sender, MouseEventArgs e)
        {
            applyPlayerKilled(btnPosition5, e);
        }

        private void btnPosition6_MouseDown(object sender, MouseEventArgs e)
        {
            applyPlayerKilled(btnPosition6, e);
        }

        private void btnPosition7_MouseDown(object sender, MouseEventArgs e)
        {
            applyPlayerKilled(btnPosition7, e);
        }

        private void btnPosition8_MouseDown(object sender, MouseEventArgs e)
        {
            applyPlayerKilled(btnPosition8, e);
        }
    }
}
