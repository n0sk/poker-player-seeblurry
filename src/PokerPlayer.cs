﻿using System;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
	public static class PokerPlayer
	{
		public static readonly string VERSION = "Default C# folding player";

		public static int BetRequest(JObject gameState)
        {
            int returnVal = 0;
            try
            {

                var dGameState = (dynamic)gameState;
                //TODO: Use this method to return the value You want to bet
                //return (int)dGameState.current_buy_in - (int)dGameState.player.in_action.bet + (int)dGameState.minimum_raise;
                int small_blind = (int)(gameState)["small_blind"];
                returnVal = 3 * small_blind;
			}
            catch (Exception e)
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
	}
}

