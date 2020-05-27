namespace FlashCardMath.Model
{
    /// <summary>
    /// list of possible operators for the flash card problems
    /// </summary>
    public enum OperatorList
    {
        add=0,
        subtract=1,
        multiply=2,
        divide=3
    }
    public class FlashCard
    {
        /// <summary>
        /// the first number
        /// </summary>
        public int FirstOperand { get; set; }
        /// <summary>
        /// the second number
        /// </summary>
        public int SecondOperand { get; set; }
        /// <summary>
        /// the answer of this problem
        /// </summary>
        public int Answer { get; set; }
        /// <summary>
        /// the type of operation (+-*/)
        /// </summary>
        public int Operator { get; set; }
        public string OperatorSymbol { get; set; }
        /// <summary>
        /// constructor for the Flash Card object
        /// </summary>
        /// <param name="first">the first operand</param>
        /// <param name="second">the second operand</param>
        /// <param name="ans">the answer</param>
        /// <param name="op">the operator</param>
        public FlashCard(int first, int second, int op)
        {
            FirstOperand = first;
            SecondOperand = second;
            Answer = CalculateAnswer();
            Operator = op;
        }
        /// <summary>
        /// function to calculate the answer after the arithmetic operation
        /// </summary>
        /// <returns>the answer of the arithmetic operator</returns>
        public int CalculateAnswer()
        {
            int ans = 0;
            switch (Operator)
            {
                case (int)OperatorList.add: //add
                    OperatorSymbol = "+";
                    ans = FirstOperand + SecondOperand;
                    break;
                case (int)OperatorList.subtract: //subtract
                    OperatorSymbol = "-";
                    ans = FirstOperand - SecondOperand;
                    break;
                case (int)OperatorList.multiply: //multiply
                    OperatorSymbol = "X";
                    ans = FirstOperand * SecondOperand;
                    break;
                case (int)OperatorList.divide://divide
                    OperatorSymbol = "/";
                    ans = FirstOperand / SecondOperand;
                    break;
            }
            return ans;
        }
    }

}
