﻿using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;

        private List<string> items;

        public Planet(string name)
        {
            this.Name = name;
            this.items = new List<string>();
        }

        public ICollection<string> Items => this.items;

        public string Name
        {
            get => this.name;

            private set
            {
                _ = String.IsNullOrWhiteSpace(value) ? throw new ArgumentNullException(ExceptionMessages.InvalidPlanetName)
                    : this.name = value;
            }
        }
    }
}
