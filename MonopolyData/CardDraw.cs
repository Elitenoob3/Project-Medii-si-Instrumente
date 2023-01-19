namespace MonopolyData
{
    public class CardDraw : Tile
    {
        List<Tile> map;
        public CardDraw(List<Tile> map) { this.map = map; }

        public override void TileInteraction(PlayerData player)
        {
            Random rng = new Random();
            int playercard = rng.Next(1, 7);
            switch (playercard)
            {
                case 1:
                    //Lose cash
                    player.money -= 150;
                    break;
                case 2:
                    //Win cash
                    player.money += player.roll() * 50;
                    break;
                case 3:
                    //Free park
                    player.move(20, map);
                    break;
                case 4:
                    //Go to jail card
                    player.move(10, map);
                    player.skiptime = 3;
                    break;
                case 5:
                    //Get out of jail card
                    player.jailCard = true;
                    break;
                case 6:
                    //Half price property
                    player.halfPrice = true;
                    break;
                case 7:
                    player.move(25, map);
                    break;
            }
        }
    }
}
