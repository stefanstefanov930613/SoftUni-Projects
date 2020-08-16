namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Models.Machines;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private IList<IPilot> pilots;
        private IList<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            if (this.pilots.Any(p => p.Name == name))
            {
                return $"Pilot {name} is hired already";
            }

            IPilot pilot = new Pilot(name);

            this.pilots.Add(pilot);

            return $"Pilot {name} hired";
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
             

            if (this.machines.Any(t => t.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }

            ITank tank = new Tank(name, attackPoints, defensePoints);

            this.machines.Add(tank);

            return $"Tank {name} manufactured - attack: {tank.AttackPoints}; defense: {tank.DefensePoints}";
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {

            if (this.machines.Any(f => f.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }

            IFighter fighter = new Fighter(name, attackPoints, defensePoints);

            this.machines.Add(fighter);

            return $"Fighter {name} manufactured - attack: {fighter.AttackPoints}; defense: {fighter.DefensePoints}; aggressive: ON";

        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var pilot = this.pilots.FirstOrDefault(p => p.Name == selectedPilotName);

            if (pilot == null)
            {
                return $"Pilot {selectedPilotName} could not be found";
            }

            var machine = this.machines.FirstOrDefault(m => m.Name == selectedMachineName);

            if (machine == null)
            {
                return $"Machine {selectedMachineName} could not be found";
            }

            if (machine.Pilot != null)
            {
                return $"Machine {selectedMachineName} is already occupied";
            }

            machine.Pilot = pilot;

            pilot.AddMachine(machine);

            return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";

        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attackingMachine = this.machines.FirstOrDefault(a => a.Name == attackingMachineName);

            if (attackingMachine == null)
            {
                return $"Machine {attackingMachineName} could not be found";
            }

            var defendingMachine = this.machines.FirstOrDefault(d => d.Name == defendingMachineName);

            if (defendingMachine == null)
            {
                return $"Machine {defendingMachineName} could not be found";
            }

            if (attackingMachine.HealthPoints <= 0)
            {
                return $"Dead machine {attackingMachineName} cannot attack or be attacked";
            }

            if (defendingMachine.HealthPoints <= 0)
            {
                return $"Dead machine {defendingMachineName} cannot attack or be attacked";
            }

            attackingMachine.Attack(defendingMachine);

            return $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {defendingMachine.HealthPoints}";


        }

        public string PilotReport(string pilotReporting)
        {
            var pilot = this.pilots.FirstOrDefault(p => p.Name == pilotReporting);

            if (pilot == null)
            {
                return $"Pilot {pilotReporting} could not be found";
            }

            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {

            var machine = this.machines.FirstOrDefault(m => m.Name == machineName);

            if (machine == null)
            {
                return $"Machine with {machineName} could not be found";
            }

            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var fighter = this.machines.FirstOrDefault(f => f.Name == fighterName);

            if (fighter == null)
            {
                return $"Machine {fighterName} could not be found";
            }


            IFighter fighter1 = (IFighter)fighter;

            fighter1.ToggleAggressiveMode();

            return $"Fighter {fighterName} toggled aggressive mode";


        }

        public string ToggleTankDefenseMode(string tankName)
        {
            var tank = this.machines.FirstOrDefault(t => t.Name == tankName);

            if (tank == null)
            {
                return $"Machine {tankName} could not be found";
            }

            ITank tank1 = (ITank)tank;

            tank1.ToggleDefenseMode();

            return $"Tank {tankName} toggled defense mode";
        }
    }
}