using MonopolyData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace Monopoly
{
    public partial class GameMenu : Form
    {
        private int currentPlayer = 0;
        private int maxPlayers;
        GameMaster gameMaster;
        public List<PlayerData> players;

        List<Property> PlayerSet = new List<Property>();

        public GameMenu(int playerCount)
        {
            InitializeComponent();

            gameMaster = new GameMaster(playerCount);
            maxPlayers = playerCount;
            currentPlayer = 0;
            players = gameMaster.GetPlayers();

            listBox1.Items.Add("It is player " + (currentPlayer + 1).ToString() + "'s turn");
            label4.Text = players[currentPlayer].money.ToString() + " $";
            button3.Enabled = false;
            button3.BackColor = Color.Silver;
            button3.Enabled = false;
            button4.BackColor = Color.Silver;
            button4.Enabled = false;

            prepareProperties();
        }

        public GameMenu(SaveClass sc)
        {
            InitializeComponent();

            
            currentPlayer = sc.currentPlayer;
            maxPlayers= sc.maxPlayers;
            gameMaster = new GameMaster(maxPlayers);
            gameMaster.LoadGameMaster(sc.ownerList, sc.levelList, sc.players);

            players = gameMaster.GetPlayers();

            prepareProperties();

            listBox1.Items.Add("It is player " + (currentPlayer + 1).ToString() + "'s turn");

            button3.Enabled = false;
            button3.BackColor = Color.Silver;
            button3.Enabled = false;
            button4.BackColor = Color.Silver;
            button4.Enabled = false;

            label4.Text = players[currentPlayer].money.ToString() + " $";

        }



        private void button1_Click(object sender, EventArgs e)
        {
            
            int index = comboBox1.SelectedIndex;
            if(comboBox1.Items.Count > 0)
            if (players[currentPlayer].money > PlayerSet[index].Data.Prices[PlayerSet[index].Data.Level])
            {
                bool FullSet = true;
                for (int i = 0; i < PlayerSet[index].Set.Count; i++)
                {
                    Property p = (Property)gameMaster.gameBoard.Set[PlayerSet[index].Set[i]];
                    if (p.Owner != currentPlayer) FullSet = false;
                }


                if (FullSet)
                {
                    players[currentPlayer].money -= PlayerSet[index].Data.Prices[PlayerSet[index].Data.Level];
                    PlayerSet[index].Data.Level += 1;
                    listBox1.Items.Add("Upgrade Complete. The price is now " + PlayerSet[index].Data.Prices[PlayerSet[index].Data.Level].ToString());
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                }
                else
                {
                    listBox1.Items.Add("You don't own the set of properties to upgrade this one");
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                }
            }
            else
            {
                listBox1.Items.Add("Not enough money");
                listBox1.TopIndex = listBox1.Items.Count - 1;
            }
            label4.Text = players[currentPlayer].money.ToString() + " $";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //If needed
            getOutJail();

            if (players[currentPlayer].skiptime == 0)
            {
                int pos = players[currentPlayer].position;
                players[currentPlayer].move(pos + players[currentPlayer].roll(), gameMaster.gameBoard.Set);
                if (players[currentPlayer].extraTurn == false)
                {
                    button3.Enabled = true;
                    button3.BackColor = Color.Transparent;
                    button2.Enabled = false;
                    button2.BackColor = Color.Silver;
                    listBox1.Items.Add("You have moved from " + pos.ToString() + " to " + players[currentPlayer].position.ToString() + ". ");
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                }
                else
                {
                    listBox1.Items.Add("You have moved from " + pos.ToString() + " to " + players[currentPlayer].position.ToString() + ". ");
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                    listBox1.Items.Add("You have rolled a double. You get to move a second time");
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                    players[currentPlayer].extraTurn = false;
                }

                Property p = gameMaster.gameBoard.Set[players[currentPlayer].position] as Property;
                if (p != null)
                {
                    if (p.Owner == -1)
                    {
                        button4.Enabled = true;
                        button4.BackColor = Color.Transparent;
                    }
                    else
                    {
                        button4.Enabled = false;
                        button4.BackColor = Color.Silver;
                    }

                    listBox1.Items.Add("Welcome to " + p.Data.Name);
                    if (p.Owner == -1) listBox1.Items.Add("The purchase price is " + p.Data.PurchasePrice.ToString());
                    else if (p.Owner != currentPlayer) listBox1.Items.Add("You have to pay " + p.Data.Prices[p.Data.Level].ToString());
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                }

                CardDraw cd = gameMaster.gameBoard.Set[players[currentPlayer].position] as CardDraw;
                if (cd != null)
                {
                    listBox1.Items.Add("You have drawn a random card and suffered it's effect");
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                }
            }
            else
            {
                listBox1.Items.Add("You had to skip a turn");
                listBox1.TopIndex = listBox1.Items.Count - 1;
                players[currentPlayer].skiptime -= 1;
            }
            label4.Text = players[currentPlayer].money.ToString() + " $";

            prepareProperties();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!gameMaster.gameEnd())
            {
                button2.Enabled = true;
                button2.BackColor = Color.Transparent;
                button3.Enabled = false;
                button3.BackColor = Color.Silver;
                currentPlayer++;

                if (currentPlayer >= maxPlayers) currentPlayer = 0;

                listBox1.Items.Add("It is player " + (currentPlayer + 1).ToString() + "'s turn");
                listBox1.TopIndex = listBox1.Items.Count - 1;
                label4.Text = players[currentPlayer].money.ToString() + " $";

                prepareProperties();
            }
            else
            {
                listBox1.Items.Add("The game has ended beacuse player " + currentPlayer.ToString() + " has gone bankrupt");
                listBox1.TopIndex = listBox1.Items.Count - 1;
            }

            label4.Text = players[currentPlayer].money.ToString() + " $";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Property p = gameMaster.gameBoard.Set[players[currentPlayer].position] as Property;
            if (p != null && p.Owner == -1 && players[currentPlayer].money >= p.Data.PurchasePrice)
            {
                p.Owner = currentPlayer;
                players[currentPlayer].money -= p.Data.PurchasePrice;
                listBox1.Items.Add("You have purchased " + p.Data.Name + ".");
                listBox1.TopIndex = listBox1.Items.Count - 1;
                button4.Enabled = false;
                button4.BackColor= Color.Silver;
            }

            if (players[currentPlayer].money < p.Data.PurchasePrice)
            {
                listBox1.Items.Add("You don't have enough money for " + p.Data.Name + ".");
                listBox1.TopIndex = listBox1.Items.Count - 1;
                button4.Enabled = false;
                button4.BackColor = Color.Silver;
            }

            label4.Text = players[currentPlayer].money.ToString() + " $";
        }

        void prepareProperties()
        {
            PlayerSet = gameMaster.GetProperties(currentPlayer);
            comboBox1.Items.Clear();
            for (int i = 0; i < PlayerSet.Count; i++)
            {
                if (PlayerSet[i].Owner == currentPlayer)
                comboBox1.Items.Add(PlayerSet[i].Data.Name);
            }
            if (PlayerSet.Count > 0)
            {
                button1.Enabled = true;
                button1.BackColor = Color.Transparent;
            }
            else
            {
                button1.Enabled = false;
                button1.BackColor = Color.Silver;
            } 
        }

        public void getOutJail()
        {
            if (players[currentPlayer].jailCard && players[currentPlayer].skiptime > 1)
            {
                players[currentPlayer].jailCard = false;
                players[currentPlayer].skiptime = 0;
                listBox1.Items.Add("You have used the get out of jail card");
                listBox1.TopIndex = listBox1.Items.Count - 1;

            }
            else if (players[currentPlayer].skiptime > 1)
            {
                int x = players[currentPlayer].roll();
                if (players[currentPlayer].extraTurn)
                {
                    players[currentPlayer].extraTurn = false;
                    players[currentPlayer].skiptime = 0;
                    listBox1.Items.Add("You have rolled a double and got out of jail");
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                }
                else
                {
                    listBox1.Items.Add("You have failed to roll a double and get out of jail");
                    listBox1.TopIndex = listBox1.Items.Count - 1;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveClass sc = new SaveClass();

            sc.players = players;

            for (int i = 0;i < gameMaster.gameBoard.Set.Count;i++) 
            {
                if (gameMaster.gameBoard.Set[i] is Property)
                {
                    Property p = gameMaster.gameBoard.Set[i] as Property;
                    sc.ownerList.Add(p.Owner);
                    sc.levelList.Add(p.Data.Level);
                }
                else
                {
                    sc.ownerList.Add(-2);
                    sc.levelList.Add(-2);
                }
            }

            sc.currentPlayer = currentPlayer;
            sc.maxPlayers= maxPlayers;

            string jsonContent = JsonConvert.SerializeObject(sc);

            try
            {
                File.WriteAllText(@"C:\MonopolyDump.json", jsonContent);
            }
            catch
            {
                File.Delete(@"C:\MonopolyDump.json");
                File.WriteAllText(@"C:\MonopolyDump.json", jsonContent);
            }

        }
    }
}
