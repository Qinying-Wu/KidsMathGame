using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCardMath.ViewModel
{
    public class StartPageVM
    {
        
        /// <summary>
        /// flag to indicate whether the user is reading the instructions how to play the game or not
        /// </summary>
        public bool ReadInstruction { get; set; }
        public bool IsChallengerMode { get; set; }
        /// <summary>
        /// constructor
        /// </summary>
        public StartPageVM() { }
    }
}
