using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using FlashCardMath.Model;
using FlashCardMath.Logistics;
using Xamarin.Forms;
using GalaSoft.MvvmLight.Command;
using System.Diagnostics.Contracts;

namespace FlashCardMath.ViewModel
{
    public class GamePageVM:NotifyPropertyChanged
    {
        ///// <summary>
        ///// the capacity of the flash card queue
        ///// </summary>
        //public int CardsCount { get; set; } 

        /// <summary>
        /// flag to indicate whether the game is over or not
        /// </summary>
        public bool IsGameOver {
            get
            {
                return _isGameOver;
            }
            set
            {
                _isGameOver = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// flag to indicate whether the game is paused or not
        /// </summary>
        public bool IsGamePaused
        {
            get
            {
                return _isGamePaused;
            }
            set
            {
                _isGamePaused = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// the current arithmetic problem being evaluated
        /// </summary>
        public FlashCard CurrentFC
        {
            get
            {
                return _currentFC ;
            }
            set
            {
                _currentFC = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// the set of flash cards after the current one
        /// </summary>
        public Queue<FlashCard> Cards { get; set; }
      
        /// <summary>
        /// stores the player's input answer
        /// </summary>
        public int? InputAnswer
        {
            get
            {
                return _inputAnswer;
            }
            set
            {
                _inputAnswer = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The player's score
        /// </summary>
        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// function to enqueue more cards to the Cards card queue to keep the game going
        /// </summary>
        public void EnqueueCard()
        {
            Random random = new Random();
            FlashCard fc=new FlashCard(random.Next(0,100),random.Next(0,100), random.Next(0, 4));
            switch (fc.Operator)
            {
                case (0): //add
                    fc.OperatorSymbol = "+";
                    fc.Answer = fc.FirstOperand + fc.SecondOperand;
                    break;
                case (1): //subtract
                    fc.OperatorSymbol = "-";
                    if (fc.FirstOperand < fc.SecondOperand) //make sure the first operand is always greater than the second operand
                    {
                        int temp = fc.FirstOperand;
                        fc.FirstOperand = fc.SecondOperand;
                        fc.SecondOperand = temp;
                    }
                    fc.Answer = fc.FirstOperand - fc.SecondOperand;
                    break;
                case (2): //multiply
                    fc.OperatorSymbol = "X";
                    if(fc.FirstOperand>10 && fc.SecondOperand > 10) //make sure at least one of the operands is <=10 for calculation simplicity
                    {
                        int randomizer = random.Next(0, 2); ///randomize the position of the operand <10 in the arithmetic problem
                        switch (randomizer)
                        {
                            case (0):
                                fc.FirstOperand = random.Next(0, 11);
                                break;
                            case (1):
                                fc.SecondOperand = random.Next(0, 11);
                                break;
                        }
                    }
                    fc.Answer = fc.FirstOperand * fc.SecondOperand;
                    break;
                case (3): //divide
                    fc.OperatorSymbol = "/";
                    fc.SecondOperand = random.Next(1, 20);//regenerate the second operand to prevent it from being 0 or too large
                    if (fc.FirstOperand < fc.SecondOperand||fc.FirstOperand%fc.SecondOperand!=0) //make sure at least one of the operand or the answer of the problem is <=10 for calculation simplicity
                    {
                        fc.FirstOperand = fc.SecondOperand * random.Next(1, 11);
                    }
                    
                    fc.Answer = fc.FirstOperand / fc.SecondOperand;
                    break;
            }
            Cards.Enqueue(fc);
            InputAnswer = null;
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
        public void IsCorrect()
        {
            if (InputAnswer == CurrentFC.Answer)
            {
                CurrentFC = Cards.Dequeue();
                EnqueueCard();
                Score++;
            }
        }

        public RelayCommand EvaluateAnswer { get; private set; }
        public RelayCommand SkipCommand { get; private set; }
        /// <summary>
        /// constructor for the Flash Card View Model, there are 30 flash cards initially
        /// </summary>
        public GamePageVM()
        {
            Cards = new Queue<FlashCard>();
            EnqueueCard();
            EnqueueCard();
            Score = 0;
            CurrentFC = Cards.Dequeue();
            EvaluateAnswer = new RelayCommand(IsCorrect);
            SkipCommand = new RelayCommand(() =>
              {
                  CurrentFC = Cards.Dequeue();
                  EnqueueCard();
              });
        }
        private FlashCard _currentFC;
        
        private bool _isGameOver;
        private bool _isGamePaused;
        private int? _inputAnswer;
        private int _score;
    }
}
