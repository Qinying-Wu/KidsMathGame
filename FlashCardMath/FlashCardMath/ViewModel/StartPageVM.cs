using FlashCardMath.Logistics;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCardMath.ViewModel
{
    public class StartPageVM:NotifyPropertyChanged
    {
        /// <summary>
        /// flag to indicate whether the user is reading the instructions or not
        /// </summary>
        public bool IsReadingInstructions
        {
            get { return _isReadingInstructions; }
            set
            {
                _isReadingInstructions = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// constructor
        /// </summary>
        public StartPageVM() { }
        private bool _isReadingInstructions;
    }
}
