using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass1_opt1
{
    
    class DeckCard
    {
        private Card[] _allCards; // list all card
        internal Card[] AllCards
        {
            get { return _allCards; }
            set { _allCards = value; }
        }

        private int _currentCards; // sum all current card in deck

        public DeckCard()
        {
            _allCards = new Card[52]; // a full deck card have 52 main card  
            _currentCards = 0;
        }

        /* Create new full deck card
         * Input: 
         * Output: DeckCard - full deck card
         */
        public static DeckCard CreateNewDeckCard()
        {
            try
            {
                DeckCard result = new DeckCard();
                int cardIndex = 0;
                for (int i = 0; i < 13; i++) // a full deck card have 13 rank
                {
                    for (int j = 0; j < 4; j++) // a full deck card have 4 suit correspond to each rank
                    {
                        // create new a card
                        Card newCard = new Card((RANK)i, (SUIT)j);
                        result._allCards[cardIndex++] = newCard;
                        result._currentCards++;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /* Check current deck card is full
         * Input: 
         * Output: bool - true: if current deck card is full, false: if current deck card is not full
         */
        public bool IsFullCard()
        {
            if (_currentCards > _allCards.Length)  // check sum card in current full deck card is max value (52)
                return false;
            return true;
        }

        /* Get random a card from current full deck card and remove it from current full deck card
         * Input: 
         * Output: Card - if current full deck card have least 1 card, else return null and throw an exception
         */
        public Card GetCardRandom()
        {
            try
            {
                // check current full deck card is null
                if (_currentCards < 1)
                    throw new Exception("Full deck card haven't any card, now!");

                Card result = null;

                // create random index selecting card from list card in current full deck card
                Random rd = new Random();
                int index = rd.Next(0, _currentCards);
                int removeIndex = 0;

                // select card and remove it from full deck card
                for (int i = 0; i < _allCards.Length; i++)
                {
                    if (removeIndex == index && _allCards[i] != null) // check index appropriate 
                    {
                        result = _allCards[i]; // select card
                        _allCards[i] = null; // remove it from current full deck card
                        _currentCards--; // update sum card in deck
                        break;
                    }
                    else if (_allCards[i] != null)
                    {
                        removeIndex++;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /* Check current deck card is null
         * Input: 
         * Output: bool - true: if current deck card is null, false: if current deck card is not null
         */
        public bool IsNull()
        {
            if (_currentCards > 0) // check current full deck card have any card
                return false;
            return true;
        }

        /* Get string show all card from current full deck card
         * Input: 
         * Output: string - information string
         */
        public string GetShowAllCard()
        {
            // create header
            string result = "Full deck card have "+_currentCards;
            result += (_currentCards < 2) ? " card, now." : " cards, now.";
            if (_currentCards < 1)
                return result;
            result += "\r\nInclude:";

            // add infomation about each card in current full deck card
            for (int i = 0; i < _allCards.Length; i++)
            {
                if (i % 4 == 0)
                    result += "\r\n";
                if (_allCards[i] != null)
                    result += "\t" + _allCards[i].GetCard();
            }
            return result;
        }
    }

}
