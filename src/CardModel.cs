using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nancy.Simple
{
    public class CardModel
    {
        public string rank { get; set; }
        public string suit { get; set; }

        public int rankValue
        {
            get
            {
                switch (rank[0])
                {
                    case 'A':
                        return 14;
                    case 'K':
                        return 13;
                    case 'Q':
                        return 12;
                    case 'J':
                        return 11;
                    default:
                        return int.Parse(rank);
                }
            }
        }

    }
}
