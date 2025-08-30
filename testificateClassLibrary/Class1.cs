using System;
using System.Timers;
using Timer = System.Timers.Timer;
namespace libCow
{
    public class CowState
    {
        public int Hunger { get; set; }
        public int Thirst { get; set; }
        public int Stamina { get; set; }
        public string LastAction { get; set; } = "";
    }
    public class cowStuff
    {
        public event Action<CowState> OnStateChanged;
        private CowState state;
        int hunger = 100;
        int thirst = 100;
        int stamina = 100;
        private Timer decayTimer;

        public cowStuff()
        {
            // create the CowState object pointing to the current stats
            state = new CowState() { Hunger = hunger, Thirst = thirst, Stamina = stamina };
        }


        public int[] cow()
        {
            decayTimer = new Timer(2000); // every 2 seconds
            decayTimer.Elapsed += decayStats;
            decayTimer.AutoReset = true;
            decayTimer.Start();
            return [hunger, thirst, stamina];
        }

        private void decayStats(object? sender, ElapsedEventArgs e)
        {
            hunger = Math.Max(0, hunger - 1);
            thirst = Math.Max(0, thirst - 2);
            stamina = Math.Max(0, stamina - 1);

            // update the state object
            state.Hunger = hunger;
            state.Thirst = thirst;
            state.Stamina = stamina;
            state.LastAction = "Tick";

            // fire the event so listeners get notified
            OnStateChanged?.Invoke(state);
        }

        public string moo(int mooVolume)
        {
            if (mooVolume >= 10)
            {
                hunger -= 3;
                thirst--;
                stamina -= (thirst - hunger);
                return "MOOOOOOO!!!";
            }
            else
            {
                hunger--;
                stamina--;
                return "Moooo.";
            }
        }

        public int eatGrass()
        {
            if (hunger >= 100) return 0;
            hunger += 5;
            return hunger <= 50 ? 1 : -1;
        }

        public int drinkWater()
        {
            if (thirst >= 100) return 0;
            thirst += 5;
            return thirst <= 50 ? 1 : -1;
        }

        public int sleep()
        {
            if (stamina >= 100) return 0;
            stamina += 5;
            return stamina <= 50 ? 1 : -1;
        }

        public int[] getCowData()
        {
            return [hunger, thirst, stamina];
        }
    }
}
