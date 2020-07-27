using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        private const int beginnerPlayerBounsHealth = 40;
        private const int beginnerPlayerCardsBonus = 30;


        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            if (attackPlayer.GetType() == typeof(Beginner))
            {
                attackPlayer.Health += beginnerPlayerBounsHealth;

                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += beginnerPlayerCardsBonus;
                }
            }

            if (enemyPlayer.GetType() == typeof(Beginner))
            {
                enemyPlayer.Health += beginnerPlayerBounsHealth;

                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += beginnerPlayerCardsBonus;
                }
            }

            attackPlayer.Health += attackPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);

            while (true)
            {
                var attackPlayerDamagePoints = attackPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);
                enemyPlayer.TakeDamage(attackPlayerDamagePoints);

                if (enemyPlayer.Health == 0)
                {
                    break;
                }

                var enemyPlayerDamagePoints = enemyPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);
                attackPlayer.TakeDamage(enemyPlayerDamagePoints);

                if (attackPlayer.Health == 0)
                {
                    break;
                }

            }
        }
         
    }
}
