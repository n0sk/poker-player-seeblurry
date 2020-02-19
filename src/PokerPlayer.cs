using System;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public static class PokerPlayer
    {
        public static readonly string VERSION = "Default C# folding player";

        public static int BetRequest(JObject gameState, GameStateModel state)
        {
            int retVal = 50;

            try
            {
                //BettingClass.smallRaise(gameState)
                //var dGameState = (dynamic)gameState;
                //TODO: Use this method to return the value You want to bet
                //return (int)gameState["current_buy_in"] - (int)gameState["players"][gameState["in_action"]]["bet"] + (int)gameState["minimum_raise"];
                retVal = (int)(gameState)["small_blind"];
            }
            catch
            {
                retVal = 50;
            }

            if (retVal < 0)
                retVal = 50;

            return retVal;

		
        }

        public static void ShowDown(JObject gameState)
        {
            //TODO: Use this method to showdown
        }

		private static int JakobsAlgorithm(JObject gameState)
		{
			int minimum_raise = (int)gameState["minimum_raise"];
			int current_buy_in = (int)gameState["current_buy_in"];
			foreach (var player in gameState["players"]) {

			} 
			return minimum_raise;
		}
    }
}