using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public static class PokerPlayer
    {
        public static readonly string VERSION = "Default C# folding player";

        public static int BetRequest(JObject gameState, string state)
        {
            int retVal = 50;

            try
            {
                var model = JsonConvert.DeserializeObject<GameStateModel>(state);
                retVal = PreFlop(model);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("C#: " + e.ToString());
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

        private static int PreFlop(GameStateModel model)
        {
            var hand = model.players[model.in_action].EvaluateHand();

            switch (hand)
            {
                case 0:
                    return BettingClass.foldOrCheck(model);
                case 1:
                case 2:
                    return BettingClass.call(model);
                default:
                    return BettingClass.smallRaise(model);
            }
        }
    }
}