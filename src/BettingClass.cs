using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public static class BettingClass
    {

        public static int fold(GameStateModel gameState)
        {
            return 0;
        }
        public static int call(GameStateModel gameState)
        {
            return gameState.current_buy_in - myself(gameState).bet;
        }

        public static int smallRaise(GameStateModel gameState) 
        {
            return minimumRaise(gameState);
        }

        public static int bigRaise(GameStateModel gameState)
        {
            int difference = gameState.current_buy_in - myself(gameState).bet;
            int myStack = myself(gameState).stack;
            return (myStack * 0.3) + difference;
        }

        public static int allIn(GameStateModel gameState)
        {
            return myself(gameState).stack;
        }
        
        private static int minimumRaise(GameStateModel gameState)
        {
            int current_buy_in = gameState.current_buy_in;
            int minimum_raise = gameState.minimum_raise;
            return current_buy_in - myself(gameState).bet + minimum_raise;
        }
        private static PlayerModel myself(GameStateModel gameState)
        {
            return gameState.players[gameState.in_action];
        }
    }
}