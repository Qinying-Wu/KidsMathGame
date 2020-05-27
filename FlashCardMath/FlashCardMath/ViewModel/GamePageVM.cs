using System;
using System.Collections.Generic;
using System.Text;
using FlashCardMath.Model;
using Xamarin.Forms;

namespace FlashCardMath.ViewModel
{
    public class GamePageVM
    {
        ///// <summary>
        ///// the capacity of the flash card queue
        ///// </summary>
        //public int CardsCount { get; set; } 
        
        /// <summary>
        /// flag to indicate whether the game is over or not
        /// </summary>
        public bool IsGameOver { get; set; }
        /// <summary>
        /// flag to indicate whether the game is paused or not
        /// </summary>
        public bool IsGamePaused { get; set; }
        //The current flash card object
        /// <summary>
        /// game objective indication
        /// true: complete a certain count of cards within the shortest duration
        /// false: complete as many cards as possible within the given duration
        /// </summary>
        public bool ShortTimeMode { get; set; }
       
        /// <summary>
        /// indication for the game mode
        /// true: a maximum of three incorrect attempts is allowed, fail the game if violated
        /// false: unlimited allocation for incorrect answer
        /// </summary>
        public bool IsChallengerMode { get; set; }
        public string BGC { get; set; }
        /// <summary>
        /// the current arithmetic problem being evaluated
        /// </summary>
        public FlashCard CurrentFC { get; set; }
       
        /// <summary>
        /// the set of flash cards after the current one
        /// </summary>
        public Queue<FlashCard> Cards { get; set; }
      
        /// <summary>
        /// stores the player's input answer
        /// </summary>
        public int InputAnswer { get; set; }
        
        /// <summary>
        /// function to enqueue more cards to the Cards card queue to keep the game going
        /// </summary>
        public void EnqueueCard()
        {
            Random random = new Random();
            Cards.Enqueue(new FlashCard(random.Next(0,11), random.Next(0,11), random.Next(0,4)));
        }

        ///// <summary>
        ///// function to skip the current card and retrieve the next flash card in the Cards queue
        ///// </summary>
        //public void SkipCard()
        //{
        //    CurrentFC = Cards.Dequeue();
        //}
        /// <summary>
        /// function to determine whether the player's answer is correct or not by comparing with the already calculated result
        /// </summary>
        /// <returns>true if the player's input matches the pre-calculated result, false otherwise</returns>
        public bool IsCorrect()
        {
            if (InputAnswer == CurrentFC.Answer)
            {
                CurrentFC = Cards.Dequeue();
                EnqueueCard();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// constructor for the Flash Card View Model, there are 30 flash cards initially
        /// </summary>
        public GamePageVM()
        {
            Cards = new Queue<FlashCard>();
            EnqueueCard();
            EnqueueCard();
            CurrentFC = Cards.Dequeue();
        }

    }
}
