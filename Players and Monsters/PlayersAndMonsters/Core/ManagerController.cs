namespace PlayersAndMonsters.Core
{
    using System;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private readonly ICardRepository cardRepository;
        private readonly IPlayerRepository playerRepository;
        private readonly IBattleField battleField;


        public ManagerController()
        {
            this.cardRepository = new CardRepository();
            this.playerRepository = new PlayerRepository();
            this.battleField = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {

            if (type == "Beginner")
            {

                IPlayer player = new Beginner(new CardRepository(), username);
                this.playerRepository.Add(player);

            }

            if (type == "Advanced")
            {
                IPlayer player = new Advanced(new CardRepository(), username);
                playerRepository.Add(player);
            }

            var result = $"Successfully added player of type {type} with username: {username}";
            return result;
        }

        public string AddCard(string type, string name)
        {
             
            if (type == "Magic")
            {
                ICard card = new MagicCard(name);
                cardRepository.Add(card);
            }

            if (type == "Trap")
            {
                ICard card = new TrapCard(name);
                cardRepository.Add(card);
            }

            var result = string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);

            return result;
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = this.playerRepository.Find(username);
            var card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            string result = string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, card.Name, player.Username);

            return result;
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attack = this.playerRepository.Find(attackUser);
            var enemy = this.playerRepository.Find(enemyUser);

            battleField.Fight(attack, enemy);

            var result = string.Format(ConstantMessages.FightInfo, attack.Health, enemy.Health);

            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            var players = this.playerRepository.Players;


            foreach (var player in players)
            {
                sb.AppendLine($"Username: {player.Username} - Health: {player.Health} - Cards {player.CardRepository.Count}");

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                }

                sb.AppendLine(ConstantMessages.DefaultReportSeparator);
            }

            return sb.ToString().TrimEnd();

        }
    }
}
