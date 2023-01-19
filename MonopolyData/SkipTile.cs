namespace MonopolyData
{
    public class SkipTile : Tile
    {
        public int turncount { get; set; }

        public override void TileInteraction(PlayerData player)
        {
            if (turncount > 0) player.skiptime = turncount;
        }
    }
}
