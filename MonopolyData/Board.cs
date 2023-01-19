using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MonopolyData
{
    public class Board
    {
        public List<Tile> Set = new List<Tile>();
        public List<PlayerData> players = new List<PlayerData>();

        public void LoadBoard(List<int> owners, List<int> levels, List<PlayerData> players)
        {
            for (int i = 0; i < Set.Count; i++)
            {
                if (owners[i] != -2)
                {
                    Property p = (Property) Set[i];
                    p.Owner = owners[i];
                    p.Data.Level = levels[i];
                }
            }

            this.players = players;
        }

        public Board(int playercount)
        {
            for (int i = 0; i < playercount; i++)
            {
                players.Add(new PlayerData(i));
            }

            Property NewProperty;
            CardDraw Card = new CardDraw(Set);
            IncomeTile incomeTile = new IncomeTile();
            SkipTile skipTile = new SkipTile();

            

            // Start
            incomeTile.money = 200;
            Set.Add(incomeTile);

            NewProperty = new Property(80, "BrownAV1", players);
            NewProperty.Data.Prices.Add(20); NewProperty.Data.Prices.Add(40); NewProperty.Data.Prices.Add(60); NewProperty.Data.Prices.Add(100);

            NewProperty.Set.Add(1); NewProperty.Set.Add(3);
            Set.Add(NewProperty);
                

            Set.Add(Card);

            NewProperty = new Property(120, "BrownAV2", players);
            NewProperty.Data.Prices.Add(30); NewProperty.Data.Prices.Add(60); NewProperty.Data.Prices.Add(100); NewProperty.Data.Prices.Add(150);

            NewProperty.Set.Add(1); NewProperty.Set.Add(3);
            Set.Add(NewProperty);
            

            //Tax
            incomeTile = new IncomeTile();
            incomeTile.money = -150;
            Set.Add(incomeTile);

            NewProperty = new Property(100, "TrainStation1", players);
            NewProperty.Data.Prices.Add(50); NewProperty.Data.Prices.Add(100); NewProperty.Data.Prices.Add(250); NewProperty.Data.Prices.Add(500);

            NewProperty.Set.Add(5); NewProperty.Set.Add(15); NewProperty.Set.Add(25); NewProperty.Set.Add(35);
            Set.Add(NewProperty);
            

            NewProperty = new Property(140, "LightBlueAV1", players);
            NewProperty.Data.Prices.Add(60); NewProperty.Data.Prices.Add(80); NewProperty.Data.Prices.Add(120); NewProperty.Data.Prices.Add(160);

            NewProperty.Set.Add(6); NewProperty.Set.Add(8); NewProperty.Set.Add(9);
            Set.Add(NewProperty);
            

            Set.Add(Card);

            NewProperty = new Property(160, "LightBlueAV2", players);
            NewProperty.Data.Prices.Add(70); NewProperty.Data.Prices.Add(90); NewProperty.Data.Prices.Add(140); NewProperty.Data.Prices.Add(180);

            NewProperty.Set.Add(6); NewProperty.Set.Add(8); NewProperty.Set.Add(9);
            Set.Add(NewProperty);
            

            NewProperty = new Property(180, "LightBlueAV3", players);
            NewProperty.Data.Prices.Add(90); NewProperty.Data.Prices.Add(120); NewProperty.Data.Prices.Add(160); NewProperty.Data.Prices.Add(200);

            NewProperty.Set.Add(6); NewProperty.Set.Add(8); NewProperty.Set.Add(9);
            Set.Add(NewProperty);
            

            //Jail
            skipTile.turncount = 0;
            Set.Add(skipTile);

            NewProperty = new Property(200, "PinkAV1", players);
            NewProperty.Data.Prices.Add(110); NewProperty.Data.Prices.Add(150); NewProperty.Data.Prices.Add(180); NewProperty.Data.Prices.Add(220);

            NewProperty.Set.Add(11); NewProperty.Set.Add(13); NewProperty.Set.Add(14);
            Set.Add(NewProperty);
            

            NewProperty = new Property(200, "Power", players);
            NewProperty.Data.Prices.Add(150); NewProperty.Data.Prices.Add(300);

            NewProperty.Set.Add(12); NewProperty.Set.Add(28);
            Set.Add(NewProperty);
            

            NewProperty = new Property(220, "PinkAV2", players);
            NewProperty.Data.Prices.Add(130); NewProperty.Data.Prices.Add(160); NewProperty.Data.Prices.Add(200); NewProperty.Data.Prices.Add(240);

            NewProperty.Set.Add(11); NewProperty.Set.Add(13); NewProperty.Set.Add(14);
            Set.Add(NewProperty);
            

            NewProperty = new Property(240, "PinkAV3", players);
            NewProperty.Data.Prices.Add(150); NewProperty.Data.Prices.Add(180); NewProperty.Data.Prices.Add(220); NewProperty.Data.Prices.Add(270);

            NewProperty.Set.Add(11); NewProperty.Set.Add(13); NewProperty.Set.Add(14);
            Set.Add(NewProperty);
            

            NewProperty = new Property(100, "TrainStation2", players);
            NewProperty.Data.Prices.Add(50); NewProperty.Data.Prices.Add(100); NewProperty.Data.Prices.Add(250); NewProperty.Data.Prices.Add(500);

            NewProperty.Set.Add(5); NewProperty.Set.Add(15); NewProperty.Set.Add(25); NewProperty.Set.Add(35);
            Set.Add(NewProperty);
            

            NewProperty = new Property(250, "OrangeAV1", players);
            NewProperty.Data.Prices.Add(180); NewProperty.Data.Prices.Add(200); NewProperty.Data.Prices.Add(240); NewProperty.Data.Prices.Add(300);

            NewProperty.Set.Add(16); NewProperty.Set.Add(18); NewProperty.Set.Add(19);
            Set.Add(NewProperty);
            

            Set.Add(Card);

            NewProperty = new Property(270, "OrangeAV2", players);
            NewProperty.Data.Prices.Add(200); NewProperty.Data.Prices.Add(240); NewProperty.Data.Prices.Add(280); NewProperty.Data.Prices.Add(320);

            NewProperty.Set.Add(16); NewProperty.Set.Add(18); NewProperty.Set.Add(19);
            Set.Add(NewProperty);
            

            NewProperty = new Property(290, "OrangeAV3", players);
            NewProperty.Data.Prices.Add(220); NewProperty.Data.Prices.Add(270); NewProperty.Data.Prices.Add(300); NewProperty.Data.Prices.Add(350);

            NewProperty.Set.Add(16); NewProperty.Set.Add(18); NewProperty.Set.Add(19);
            Set.Add(NewProperty);
            

            // Car Park
            skipTile = new SkipTile();
            skipTile.turncount = 1;
            Set.Add(skipTile);

            NewProperty = new Property(300, "RedAV1", players);
            NewProperty.Data.Prices.Add(240); NewProperty.Data.Prices.Add(290); NewProperty.Data.Prices.Add(320); NewProperty.Data.Prices.Add(370);

            NewProperty.Set.Add(21); NewProperty.Set.Add(23); NewProperty.Set.Add(24);
            Set.Add(NewProperty);
            

            Set.Add(Card);

            NewProperty = new Property(320, "RedAV2", players);
            NewProperty.Data.Prices.Add(260); NewProperty.Data.Prices.Add(310); NewProperty.Data.Prices.Add(340); NewProperty.Data.Prices.Add(400);

            NewProperty.Set.Add(21); NewProperty.Set.Add(23); NewProperty.Set.Add(24);
            Set.Add(NewProperty);
            

            NewProperty = new Property(340, "RedAV3", players);
            NewProperty.Data.Prices.Add(280); NewProperty.Data.Prices.Add(320); NewProperty.Data.Prices.Add(360); NewProperty.Data.Prices.Add(430);

            NewProperty.Set.Add(21); NewProperty.Set.Add(23); NewProperty.Set.Add(24);
            Set.Add(NewProperty);
            

            NewProperty = new Property(100, "TrainStation3", players);
            NewProperty.Data.Prices.Add(50); NewProperty.Data.Prices.Add(100); NewProperty.Data.Prices.Add(250); NewProperty.Data.Prices.Add(500);

            NewProperty.Set.Add(5); NewProperty.Set.Add(15); NewProperty.Set.Add(25); NewProperty.Set.Add(35);
            Set.Add(NewProperty);
            

            NewProperty = new Property(350, "YellowAV1", players);
            NewProperty.Data.Prices.Add(280); NewProperty.Data.Prices.Add(330); NewProperty.Data.Prices.Add(380); NewProperty.Data.Prices.Add(450);

            NewProperty.Set.Add(26); NewProperty.Set.Add(27); NewProperty.Set.Add(29);
            Set.Add(NewProperty);
            

            NewProperty = new Property(360, "YellowAV2", players);
            NewProperty.Data.Prices.Add(290); NewProperty.Data.Prices.Add(340); NewProperty.Data.Prices.Add(400); NewProperty.Data.Prices.Add(470);

            NewProperty.Set.Add(26); NewProperty.Set.Add(27); NewProperty.Set.Add(29);
            Set.Add(NewProperty);
            

            NewProperty = new Property(200, "Water", players);
            NewProperty.Data.Prices.Add(150); NewProperty.Data.Prices.Add(300);

            NewProperty.Set.Add(12); NewProperty.Set.Add(28);
            Set.Add(NewProperty);
            

            NewProperty = new Property(380, "YellowAV3", players);
            NewProperty.Data.Prices.Add(310); NewProperty.Data.Prices.Add(370); NewProperty.Data.Prices.Add(420); NewProperty.Data.Prices.Add(500);

            NewProperty.Set.Add(26); NewProperty.Set.Add(27); NewProperty.Set.Add(29);
            Set.Add(NewProperty);
            

            // Go to jail
            GoToJailTile goToJailTile = new GoToJailTile(Set);
            Set.Add(goToJailTile);

            NewProperty = new Property(400, "GreenAV1", players);
            NewProperty.Data.Prices.Add(310); NewProperty.Data.Prices.Add(370); NewProperty.Data.Prices.Add(440); NewProperty.Data.Prices.Add(550);

            NewProperty.Set.Add(31); NewProperty.Set.Add(32); NewProperty.Set.Add(34);
            Set.Add(NewProperty);
            

            NewProperty = new Property(420, "GreenAV2", players);
            NewProperty.Data.Prices.Add(350); NewProperty.Data.Prices.Add(450); NewProperty.Data.Prices.Add(500); NewProperty.Data.Prices.Add(580);

            NewProperty.Set.Add(31); NewProperty.Set.Add(32); NewProperty.Set.Add(34);
            Set.Add(NewProperty);
            

            Set.Add(Card);

            NewProperty = new Property(450, "GreenAV3", players);
            NewProperty.Data.Prices.Add(370); NewProperty.Data.Prices.Add(480); NewProperty.Data.Prices.Add(550); NewProperty.Data.Prices.Add(650);

            NewProperty.Set.Add(31); NewProperty.Set.Add(32); NewProperty.Set.Add(34);
            Set.Add(NewProperty);
            

            NewProperty = new Property(100, "TrainStation4", players);
            NewProperty.Data.Prices.Add(50); NewProperty.Data.Prices.Add(100); NewProperty.Data.Prices.Add(250); NewProperty.Data.Prices.Add(500);

            NewProperty.Set.Add(5); NewProperty.Set.Add(15); NewProperty.Set.Add(25); NewProperty.Set.Add(35);
            Set.Add(NewProperty);
            

            Set.Add(Card);

            NewProperty = new Property(480, "NavyAV1", players);
            NewProperty.Data.Prices.Add(400); NewProperty.Data.Prices.Add(500); NewProperty.Data.Prices.Add(630); NewProperty.Data.Prices.Add(720);

            NewProperty.Set.Add(37); NewProperty.Set.Add(39);
            Set.Add(NewProperty);
            

            // Tax
            incomeTile = new IncomeTile();
            incomeTile.money = -500;
            Set.Add(incomeTile);

            NewProperty = new Property(500, "NavyAV2", players);
            NewProperty.Data.Prices.Add(420); NewProperty.Data.Prices.Add(550); NewProperty.Data.Prices.Add(650); NewProperty.Data.Prices.Add(800);

            NewProperty.Set.Add(37); NewProperty.Set.Add(39);
            Set.Add(NewProperty);
            
        }
    }
}
