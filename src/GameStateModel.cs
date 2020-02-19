using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nancy.Simple
{

    public enum GAME_STAGE
    {
        PRE_FLOP = 0,
        FLOP,
        TURN,
        RIVER

    }
    public class GameStateModel
    {
        public string tournament_id { get; set; }
        public string game_id { get; set; }
        public int round { get; set; }
        public int bet_index { get; set; }
        public int small_blind { get; set; }
        public int current_buy_in { get; set; }
        public int pot { get; set; }
        public int minimum_raise { get; set; }
        public int dealer { get; set; }
        public int orbits { get; set; }
        public int in_action { get; set; }
        public PlayerModel[] players { get; set; }
        public CardModel[] community_cards { get; set; }

        public PlayerModel ActivePlayer => players[in_action];

        public GAME_STAGE GameStage
        {
            get
            {
                switch (community_cards.Length)
                {
                    case 0:
                        return GAME_STAGE.PRE_FLOP;
                    case 1:
                    case 2:
                    case 3:
                        return GAME_STAGE.FLOP;
                    case 4:
                        return GAME_STAGE.TURN;
                    default:
                        return GAME_STAGE.RIVER;
                }
            }
        }

        public int EvaluateHand()
        {
            if (HasPair())
                return 5;


            var hand = ActivePlayer.EvaluateHand();
            switch (hand)
            {
                case 0:
                    return 0;
                case 1:
                case 2:
                    return 5;
                default:
                    return 7;
            }

        }

        public bool HasPair()
        {
            return community_cards.Any(x => ActivePlayer.hole_cards.Any(y => y.rank == x.rank));
        }
    }
}
