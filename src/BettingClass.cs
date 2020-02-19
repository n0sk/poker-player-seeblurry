using System;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public static class BettingClass
    {

        public static int bet(GameStateModel gameState, int betWeight)
        {
            if (betWeight < 3) {
                return foldOrCheck(gameState);
            }
            else if (betWeight >= 3 && betWeight < 10) {
                if (gameState.current_buy_in - myself(gameState).bet > 500) {
                    return 250 > myself(gameState).stack ? myself(gameState).stack : 250;
                } else {
                    return call(gameState);
                }
            }
            else if (betWeight == 10) {
                return allIn(gameState);
            }
            else {
                return foldOrCheck(gameState);
            }
            
        }
        public static int foldOrCheck(GameStateModel gameState)
        {
            return 0;
        }
        public static int call(GameStateModel gameState)
        {
            var retVal = gameState.current_buy_in - myself(gameState).bet;
            return retVal > myself(gameState).stack ? myself(gameState).stack : retVal;
        }

        public static int smallRaise(GameStateModel gameState) 
        {
            return minimumRaise(gameState);
        }

        public static int bigRaise(GameStateModel gameState)
        {
            int difference = gameState.current_buy_in - myself(gameState).bet;
            int myStack = myself(gameState).stack;
            var retVal = (int)Math.Ceiling((myStack * 0.3) + difference);
            return retVal > myStack ? myStack : retVal;
        }

        public static int allIn(GameStateModel gameState)
        {
            return myself(gameState).stack;
        }
        
        private static int minimumRaise(GameStateModel gameState)
        {
            int current_buy_in = gameState.current_buy_in;
            int minimum_raise = gameState.minimum_raise;
            var retVal = current_buy_in - myself(gameState).bet + minimum_raise;
            return retVal > myself(gameState).stack ? myself(gameState).stack : retVal;
        }
        private static PlayerModel myself(GameStateModel gameState)
        {
            return gameState.players[gameState.in_action];
        }
    }
}