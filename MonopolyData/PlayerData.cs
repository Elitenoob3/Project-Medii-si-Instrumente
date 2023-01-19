namespace MonopolyData
{
    public class PlayerData
    {
        public int Id { get; set; }

        public int money = 2000;
        public int position = 0;
        public int turnCombo = 0;
        public int skiptime = 0;

        public bool jailCard;
        public bool halfPrice;
        public bool extraTurn;

        public PlayerData(int id)
        { 
        Id = id;
        }

        //Basic Operations

        public int roll()
        {
            Random rng = new Random();
            int d1, d2;
            d1 = rng.Next(1, 6);
            d2 = rng.Next(1, 6);

            if (d1 == d2) extraTurn = true;

            return d1 + d2;
        }

        public void pay(int value, PlayerData player)
        {
            money -= value;
            player.money += value;
            if (money <= 0) Console.WriteLine("GameOver");
        }

        public void move(int destination, List<Tile> map)
        {
            if (destination > 39) destination -= 39; 
            if (position > destination)
            {
                money += 200;
            }
            position = destination;
            
            map[position].TileInteraction(this);
        }
    }
}