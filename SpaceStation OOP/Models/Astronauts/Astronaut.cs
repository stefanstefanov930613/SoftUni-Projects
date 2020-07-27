using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        public static int deadAstronauts = 0;
        private string name;
        private double oxygen;

        public Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                _ = String.IsNullOrWhiteSpace(value) ? throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName)
                    : this.name = value;
            }
        }

        public double Oxygen
        {
            get => this.oxygen;

            protected set
            {
                _ = value < 0 ? throw new ArgumentException(ExceptionMessages.InvalidOxygen)
                    : this.oxygen = value;
            }
        }

        public bool CanBreath { get; set; }

        public IBag Bag { get; private set; }

        public virtual void Breath()
        {
             
            if (this.Oxygen > 0)
            {
                this.Oxygen -= 10;
            }
            else
            {
                deadAstronauts++;
            }

        }
    }
}
