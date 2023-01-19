namespace MonopolyData
{
    public class IncomeTile : Tile
    {
        public int money { get; set; }

        public override void TileInteraction(PlayerData player)
        {
            player.money += this.money;
        }
    }
}
