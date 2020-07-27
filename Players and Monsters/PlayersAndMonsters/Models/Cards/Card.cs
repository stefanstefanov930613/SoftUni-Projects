﻿using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public abstract class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoints;


        public Card(string name, int damagePoints, int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                _ = String.IsNullOrWhiteSpace(value)
                    ? throw new ArgumentException("Card's name cannot be null or an empty string.")
                    : this.name = value;
            }
        }

        public int DamagePoints
        {
            get => this.damagePoints;
            set
            {
                _ = value < 0 ? throw new ArgumentException("Card's damage points cannot be less than zero.")
                    : this.damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get => this.healthPoints;
            private set
            {
                _ = value < 0 ? throw new ArgumentException("Card's HP cannot be less than zero.")
                    : this.healthPoints=value;
            }
        }
    }
}
