using System;
using System.Collections.Generic;

namespace Ants
{

    class MyBot : Bot
    {
        private int turnCounter = 1;

        // DoTurn is run once per turn
        public override void DoTurn(IGameState state)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine(string.Format("{0}: Starting turn {1}", DateTime.Now.ToLongTimeString(), turnCounter), "TURN");
#endif

            // loop through all my ants and try to give them orders
            foreach (Ant ant in state.MyAnts)
            {

                // try all the directions
                foreach (Direction direction in Ants.Aim.Keys)
                {

                    // GetDestination will wrap around the map properly
                    // and give us a new location
                    Location newLoc = state.GetDestination(ant, direction);

                    // GetIsPassable returns true if the location is land
                    if (state.GetIsPassable(newLoc))
                    {
                        IssueOrder(ant, direction);
                        // stop now, don't give 1 and multiple orders
                        break;
                    }
                }

                // check if we have time left to calculate more orders
                if (state.TimeRemaining < 10) break;
            }

#if DEBUG
            System.Diagnostics.Debug.WriteLine(string.Format("{0}: Ending turn {1}", DateTime.Now.ToLongTimeString(), turnCounter++), "TURN");
            if (true) { } // silly line just to set a breakpoint
#endif
        }


        public static void Main(string[] args)
        {
#if DEBUG
            int argsLength = args.Length;
            for (int i = 0; i < argsLength; i++)
            {
                if (args[i].Equals("rundebuggame", StringComparison.InvariantCultureIgnoreCase))
                {
                    // Bot is called by visual studio. Fire up the game and reference the bot again.
                    System.Diagnostics.Process.Start("debug_game.cmd");
                    return;
                }
            }

            System.Diagnostics.Debugger.Launch();
            while (!System.Diagnostics.Debugger.IsAttached)
            {
                // Wait for debugger to attach
            }
            System.Diagnostics.Debug.WriteLine(string.Format("{0}:A Bot started", DateTime.Now.ToLongTimeString()), "INFO");
#endif

            new Ants().PlayGame(new MyBot());

#if DEBUG
            System.Diagnostics.Debug.WriteLine(string.Format("{0}: Game ended", DateTime.Now.ToLongTimeString()), "INFO");
#endif
        }

    }

}