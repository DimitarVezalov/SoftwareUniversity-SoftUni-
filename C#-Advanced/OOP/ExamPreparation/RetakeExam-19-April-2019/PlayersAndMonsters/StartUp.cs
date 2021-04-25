namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using Core.Factories.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using IO;
    using IO.Contracts;
    using Models.BattleFields;
    using Models.BattleFields.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IPlayerRepository playerRepository = new PlayerRepository();
            ICardRepository cardRepository = new CardRepository();
            IPlayerFactory playerFactory = new PlayerFactory();
            ICardFactory cardFactory = new CardFactory();
            IBattleField battleField = new BattleField();

            IManagerController managerController = new ManagerController(
                playerRepository, cardRepository, playerFactory, cardFactory, battleField);

            IEngine engine = new Engine(managerController, reader,writer);
            engine.Run();
        }
    }
}