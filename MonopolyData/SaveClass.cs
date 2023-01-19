namespace MonopolyData
{

    public class SaveClass
    {
        public int currentPlayer = 0;
        public int maxPlayers;

        public List<PlayerData> players = new List<PlayerData>();
        public List<int> ownerList = new List<int>();
        public List<int> levelList = new List<int>();
    }
}