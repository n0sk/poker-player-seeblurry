using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public static class BettingClass
    {

        public static int fold(JObject gameState)
        {
            return 0;
        }
        public static int call(JObject gameState)
        {
            return smallRaise(gameState);
        }

        public static int smallRaise(JObject gameState) 
        {
            return minimumRaise(gameState);
        }

        public static int bigRaise(JObject gameState)
        {
            int myStack = (int)myself["stack"];
            return myStack * 0.3;
        }

        public static int allIn(JObject gameState)
        {
            return (int)myself["stack"];
        }
        
        private static int minimumRaise(JObject gameState)
        {
            int current_buy_in = (int)gameState["current_buy_in"];
            int minimum_raise = (int)gameState["minimum_raise"];
            int activePlayerBetSum = 0;
            foreach (var player in gameState["players"]) {
                if(player["status"] == "active") 
                {
                    activePlayerBetSum += (int)player["bet"];
                }
			}

            return current_buy_in - activePlayerBetSum + minimum_raise;
        }
        private static JObject myself(JObject gameState)
        {
            int myId = (int)gameState["in_action"];
            return gameState["players"][myId];
        }
    }
}