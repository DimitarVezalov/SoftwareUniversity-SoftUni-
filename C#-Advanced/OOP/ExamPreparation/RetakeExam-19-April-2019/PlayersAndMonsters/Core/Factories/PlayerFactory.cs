using PlayersAndMonsters.Repositories;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;


namespace PlayersAndMonsters.Core
{
    public class PlayerFactory : IPlayerFactory
    {

        public IPlayer CreatePlayer(string type, string username)
        {
            if (type == nameof(Beginner))
            {
                return new Beginner(new CardRepository(), username);
            }
            else
            {
                return new Advanced(new CardRepository(), username);
            }
        }
    }
}
