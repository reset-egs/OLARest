using OLAClassLibrary;

namespace Assignment4.Managers
{
    public class FootballPlayersManager
    {
        private static int _nextId = 1;
        private static readonly List<FootballPlayer> Data = new List<FootballPlayer>
        {
            new FootballPlayer() { Id = _nextId++, Name = "Szymon Zwara", Age = 23, ShirtNumber = 69 },
            new FootballPlayer() { Id = _nextId++, Name = "Digna Bringule", Age = 14, ShirtNumber = 13},
            new FootballPlayer() { Id = _nextId++, Name = "Bartol Cagalj", Age = 19, ShirtNumber = 55},
            new FootballPlayer() { Id = _nextId++, Name = "Tea Koscina", Age = 27, ShirtNumber = 1}
        };

        public List<FootballPlayer> GetAll()
        {
            return Data;
        }

        public FootballPlayer? GetById(int id)
        {
            return Data.Find(x => x.Id == id);
        }

        public FootballPlayer Add(FootballPlayer player)
        {
            player.Id = _nextId++;
            Data.Add(player);
            return player;
        }

        public FootballPlayer? Update(int id, FootballPlayer newPlayer)
        {
            FootballPlayer? player = Data.Find(x => x.Id == id);
            if (player == null) return null;
            player.Name = newPlayer.Name;
            player.Age = newPlayer.Age;
            player.ShirtNumber = newPlayer.ShirtNumber;
            return player;
        }

        public FootballPlayer? Delete(int id)
        {
            FootballPlayer? player = Data.Find(x => x.Id == id);
            if (player == null) return null;
            Data.Remove(player);
            return player;
        }
    }
}
