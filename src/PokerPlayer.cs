using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public static class PokerPlayer
    {
        public static readonly string VERSION = "Default C# folding player";

        public static int BetRequest(JObject gameState, string json = "")
        {
            int returnVal = 50;
            try
            {
                
                var dGameState = (dynamic)gameState;
                //TODO: Use this method to return the value You want to bet
                //return (int)dGameState.current_buy_in - (int)dGameState.player.in_action.bet + (int)dGameState.minimum_raise;
                int small_blind = (int)(gameState)["small_blind"];
                returnVal = 3 * small_blind;
			}
            catch
            {
                returnVal = 50;
            }

            if (returnVal < 0)
                returnVal = 50;

            return returnVal;

        }

        public static void ShowDown(JObject gameState)
        {
            //TODO: Use this method to showdown
        }

		private static int JakobsAlgorithm(JObject gameState)
		{
			int minimum_raise = (int)gameState["minimum_raise"];
			return minimum_raise;
		}
    }
}