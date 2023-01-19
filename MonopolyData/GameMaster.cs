
namespace MonopolyData
{
    public class GameMaster
    {
        int playercount;
        public Board gameBoard;

        // More advanced operations

        public GameMaster(int playercount)
        {
            gameBoard = new Board(playercount);
        }

        public void LoadGameMaster(List<int> owners, List<int> levels, List<PlayerData> players)
        {
            gameBoard.LoadBoard(owners, levels, players);
        }

        public bool gameEnd() 
        {
            for (int i = 0; i < gameBoard.players.Count; i++)
            {
                if (gameBoard.players[i].money <= 0) return true;
            }
            return false;
        }

        public List<Property> GetProperties(int PlayerIndex)
        {
            List<Property> PlayerSet = new List<Property>();

            for (int i = 0; i < gameBoard.Set.Count; i++)
            {
                if (gameBoard.Set[i] is Property)
                {
                    Property p = (Property)gameBoard.Set[i];
                    if(p.Owner == PlayerIndex) PlayerSet.Add((Property)gameBoard.Set[i]);
                }
            }

            return PlayerSet;
        }

        public List<PlayerData> GetPlayers()
        { 
        return gameBoard.players;
        }

    }
}