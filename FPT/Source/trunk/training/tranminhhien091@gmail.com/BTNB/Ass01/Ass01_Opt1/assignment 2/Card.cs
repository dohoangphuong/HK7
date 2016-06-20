using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_2
{
    public class Card
    {
        public Card()
        {

        }

        public Card(string rank, string suite)
        {
            this.rank = rank;
            this.suite = suite;
        }

        private string rank;

        public string Rank
        {
            get { return rank; }
            set { rank = value; }
        }
        private string suite;

        public string Suite
        {
            get { return suite; }
            set { suite = value; }
        }

        public string CardName()
        {
            return (rank + suite);
        }

    }
}
