namespace PlayersAndMonsters.Core
{
    using System;
    using System.Text;

    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ICardRepository _cardRepository;

        private IPlayerFactory _playerFactory;
        private ICardFactory _cardFactory;

        private IBattleField _battleField;

        public ManagerController(IPlayerRepository playerRepository, ICardRepository cardRepository,
            IPlayerFactory playerFactory, ICardFactory cardFactory, IBattleField battleField)
        {
            this._playerRepository = playerRepository;
            this._cardRepository = cardRepository;

            this._playerFactory = playerFactory;
            this._cardFactory = cardFactory;

            this._battleField = battleField;
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player = this._playerFactory.CreatePlayer(type, username);
            this._playerRepository.Add(player);

            return String.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            ICard card = this._cardFactory.CreateCard(type, name);
            this._cardRepository.Add(card);

            return String.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = this._playerRepository.Find(username);
            ICard card = this._cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            return String.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attacker = this._playerRepository.Find(attackUser);
            IPlayer enemy = this._playerRepository.Find(enemyUser);

            this._battleField.Fight(attacker, enemy);

            return String.Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in this._playerRepository.Players)
            {
                sb.AppendLine(String.Format(ConstantMessages.PlayerReportInfo,
                    player.Username, player.Health, player.CardRepository.Count));

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine(String.Format(ConstantMessages.CardReportInfo, card.Name,
                        card.DamagePoints));
                }

                sb.AppendLine("###");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
