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
            return current_buy_in - (int)myself["bet"];
        }

        public static int smallRaise(JObject gameState) 
        {
            return minimumRaise(gameState);
        }

        public static int bigRaise(JObject gameState)
        {
            int difference = current_buy_in - (int)myself["bet"];
            int myStack = (int)myself["stack"];
            return (myStack * 0.3) + difference;
        }

        public static int allIn(JObject gameState)
        {
            return (int)myself["stack"];
        }
        
        private static int minimumRaise(JObject gameState)
        {
            int current_buy_in = (int)gameState["current_buy_in"];
            int minimum_raise = (int)gameState["minimum_raise"];
            return current_buy_in - (int)myself["bet"] + minimum_raise;
        }
        private static JObject myself(JObject gameState)
        {
            return gameState["players"][(int)gameState["in_action"]];
        }
    }
}