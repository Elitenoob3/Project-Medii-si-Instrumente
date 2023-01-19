namespace MonopolyData
{
    public class Property : Tile
    {
        public PropertyData Data;
        //Tile neighbours and/or copies
        public List<int> Set;
        public int Owner = -1;

        public List<PlayerData> players;

        public Property(int _PurchasePrice, string _Name, List<PlayerData> players)
        {
            this.players = players;

            Data = new PropertyData()
            {
                PurchasePrice = _PurchasePrice,
                Level = 0,
                Name = _Name
            };

            Data.Prices = new List<int>();
            Set = new List<int>();
        }

        public override void TileInteraction(PlayerData player)
        {
            if (Owner != player.Id && Owner!= -1)
            {
                player.pay(Data.Prices[Data.Level], players[Owner]);
            }

        }

        
    }
}
