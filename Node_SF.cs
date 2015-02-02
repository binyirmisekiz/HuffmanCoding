using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huffmanCoding
{
    class Node_SF
    {
        private string symbol;
        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        public string code="";

        public int frequence;
        public Node_SF  next;
        Node_SF left, right;
        internal Node_SF Right
        {
            get { return right; }
            set { right = value; }
        }

        internal Node_SF Left
        {
            get { return left; }
            set { left = value; }
        }
        public Node_SF(string value)
        {
            this.symbol = value;
            frequence = 1;   // karakter varsa node yaratılmıştır, o yuzden ilk deger 1
         
        }

        public Node_SF(string symbol, int freq)
        {
            this.symbol = symbol;
            frequence = freq;
           

        }


        public string getString()
        {
            if (code=="")
                return "        " + symbol.ToString() + "         " + frequence.ToString() + "          ";
            else
                return "        " + symbol.ToString() + "         " + frequence.ToString() + "        " + code.ToString();
        }

    }
}
