using System;
using System.Text;
using System.Collections.Generic;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities.Models.Machines
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private double attackPoints;
        private double defensePoints;
        private double healthPoints;
        private IList<string> targets;
        private IPilot pilot;


        private BaseMachine()
        {
            this.targets = new List<string>();
        }


        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints) :
            this()

        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;

        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }

                this.pilot = value;
            }

        }
        public double HealthPoints
        {
            get => this.healthPoints;
            set
            {
                this.healthPoints = value;
            }
        }

        public double AttackPoints
        {
            get => this.attackPoints;
            protected set
            {
                this.attackPoints = value;
            }
        }

        public double DefensePoints
        {
            get => this.defensePoints;
            protected set
            {
                this.defensePoints = value;
            }

        }

        public IList<string> Targets => this.targets;

        public void Attack(IMachine target)
        {
            if (target == null)
                throw new NullReferenceException("Target cannot be null");

            double hpDecreasment = this.AttackPoints - this.DefensePoints;

            target.HealthPoints -= hpDecreasment;

            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;


            }

            this.targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string targetOutput = this.targets.Count > 0 ? string.Join(",", this.targets) : "None";

            sb.AppendLine($"- {this.Name}")
            .AppendLine($" *Type: {this.GetType().Name}")
            .AppendLine($" *Health: {this.HealthPoints:f2}")
            .AppendLine($" *Attack: {this.AttackPoints:f2}")
            .AppendLine($" *Defense: {this.DefensePoints:f2}")
            .AppendLine($" *Targets: {targetOutput}");

            return sb.ToString().TrimEnd();
        }
    }
}
