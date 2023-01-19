namespace MonopolyData
{
    public class GoToJailTile : Tile
    {
        List<Tile> map;
        public GoToJailTile(List<Tile> map) { this.map = map; }

        public override void TileInteraction(PlayerData player)
        {
            player.move(10, map);
            player.skiptime = 3;
        }
    }
}
