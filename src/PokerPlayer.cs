using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public static class PokerPlayer
    {
        public static readonly string VERSION = "Default C# folding player";

        public static int BetRequest(JObject gameState)
        {
			//BettingClass.smallRaise(gameState)
            //var dGameState = (dynamic)gameState;
            //TODO: Use this method to return the value You want to bet
            //return (int)gameState["current_buy_in"] - (int)gameState["players"][gameState["in_action"]]["bet"] + (int)gameState["minimum_raise"];
            int small_blind = (int)(gameState)["small_blind"];
            return 50;
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