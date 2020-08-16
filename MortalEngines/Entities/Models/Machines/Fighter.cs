using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MortalEngines.Entities.Models.Machines
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double HealthPoints = 200;

        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, HealthPoints)
        {
            this.ToggleAggressiveMode();
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode == false)
            {
                this.AggressiveMode = true;
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
            else
            {
                this.AggressiveMode = false;
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
        }

        public override string ToString()
        {

            string aggressiveOutput = this.AggressiveMode ? "ON" : "OFF";

            return base.ToString() + Environment.NewLine + $" *Aggressive: {aggressiveOutput}";
        }
    }
}
