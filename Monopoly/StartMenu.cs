using MonopolyData;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;


namespace Monopoly
{
    public partial class StartMenu : Form
    {
        GameMenu gameWindow;

        public StartMenu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gameWindow = new GameMenu((int)numericUpDown1.Value);
            gameWindow.Show();
            button1.Enabled = false;
            button3.Enabled = false;
            button3.BackColor = Color.Silver;
            button1.BackColor = Color.Silver;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveClass sc;

            button1.Enabled = false;
            button3.Enabled = false;
            button3.BackColor = Color.Silver;
            button1.BackColor = Color.Silver;

            try 
            {
                string jsonText = File.ReadAllText(@"C:\MonopolyDump.json");
                sc = JsonConvert.DeserializeObject<SaveClass>(jsonText);

                gameWindow = new GameMenu(sc);
                gameWindow.Show();
            }
            catch 
            {
                if (!File.Exists(@"C:\MonopolyDump.json")) 
                {
                    Console.WriteLine("No save file detected!");
                    button3.Enabled = true;
                    button3.BackColor = Color.SteelBlue;
                }
            }

            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}