using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nancy.Simple
{
    public class PlayerModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string version { get; set; }
        public int stack { get; set; }
        public int bet { get; set; }
        public CardModel[] hole_cards { get; set; }

        public int EvaluateHand()
        {
            var retVal = 0;

            if (GotPair())
                retVal += 2;
            if (GotStraightStart())
                retVal += 2;
            if (GotSameSuit())
                retVal += 1;
            if (GotSomething())
                retVal += 1;

            return retVal;
        }

        private bool GotPair()
        {
            return hole_cards[0].rank == hole_cards[1].rank;
        }


        private bool GotStraightStart()
        {
            return Math.Abs(hole_cards[0].rankValue - hole_cards[1].rankValue) == 1;
        }

        private bool GotSameSuit()
        {
            return hole_cards[0].suit == hole_cards[1].suit;
        }

        private bool GotSomething()
        {
            return hole_cards[0].rankValue > 10 || hole_cards[1].rankValue > 10;
        }
    }
}
