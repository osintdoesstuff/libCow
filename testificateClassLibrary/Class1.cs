using System;
using System.Runtime.CompilerServices;
using System.Timers;
using Timer = System.Timers.Timer;
namespace libCow
{
    public class CowState
    {
        public int foodLevel { get; set; }
        public int waterLevel { get; set; }
        public int Stamina { get; set; }
        public string LastAction { get; set; } = "";
    }
    public class cowStuff
    {
        public event Action<CowState> OnStateChanged;
        private CowState state;
        int foodLevel = 100;
        int waterLevel = 100;
        int stamina = 100;
        Random globalRand = new Random();
        private Timer decayTimer;

        public cowStuff()
        {
            // create the CowState object pointing to the current stats
            state = new CowState() { foodLevel = foodLevel, waterLevel = waterLevel, Stamina = stamina };
        }


        public int[] cow()
        {
            decayTimer = new Timer(2000); // every 2 seconds
            decayTimer.Elapsed += decayStats;
            decayTimer.AutoReset = true;
            decayTimer.Start();
            return [foodLevel, waterLevel, stamina];
        }

        private void decayStats(object? sender, ElapsedEventArgs e)
        {
            foodLevel = Math.Max(0, foodLevel - 1);
            waterLevel = Math.Max(0, waterLevel - 2);
            stamina = Math.Max(0, stamina - 1);

            // update the state object
            state.foodLevel = foodLevel;
            state.waterLevel = waterLevel;
            state.Stamina = stamina;
            state.LastAction = "Tick";

            // fire the event so listeners get notified
            OnStateChanged?.Invoke(state);
        }

        public string moo()
        {
            double cowHappiness = (foodLevel * waterLevel) + stamina + globalRand.Next(1,3);
            double cowSadness = (foodLevel - 5 / waterLevel) * stamina - globalRand.Next(1, 10);
            double cowCurrentEmotion = cowSadness + cowHappiness / 2;
            char[] mooChars = "Moo".ToCharArray();
            for (int i = 0; i < Math.Floor((cowCurrentEmotion/100)); i++)
            {
                if (globalRand.Next(0, 2) == 0)
                {
                    mooChars.Append('o');
                }
                if (globalRand.Next(0, 2) == 1)
                {
                    mooChars.Append('O');
                }
            }
            for (int i = 0; i < mooChars.Length; i++)
            {
                mooChars.Append('!');
            }
            return mooChars.ToString();
        }

        public int eatGrass()
        {
            if (foodLevel >= 100) return 0;
            foodLevel += 5;
            return foodLevel <= 50 ? 1 : -1;
        }

        public int drinkWater()
        {
            if (waterLevel >= 100) return 0;
            waterLevel += 5;
            return waterLevel <= 50 ? 1 : -1;
        }

        public int sleep()
        {
            int napTime = globalRand.Next(10000, 20000);
            if (stamina >= 100) return 0;
            stamina += napTime/1000;
            System.Threading.Thread.Sleep(napTime);
            if(stamina >= 100) { stamina = 100; }
            return stamina <= 50 ? 1 : -1;
        }

        public int[] getCowData()
        {
            return [foodLevel, waterLevel, stamina];
        }
    }
}
