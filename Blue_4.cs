using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_4: Blue
    {
        private int _output;

        public int Output => _output;

        public Blue_4(string input): base(input)
        {
            _output = 0;
        }

        public override void Review()
        { 
            if (string.IsNullOrEmpty(Input)) return;

            int currentNumber = 0;
            bool inNumber = false;

            for (int i = 0; i < Input.Length; i++)
            {
                char c = Input[i];

                if (c >= '0' && c <= '9')
                {
                    currentNumber = currentNumber * 10 + (c - '0');
                    inNumber = true;
                }
                else
                {
                    if (inNumber)
                    {
                        _output += currentNumber;
                        currentNumber = 0;
                        inNumber = false;
                    }
                }
            }

            if (inNumber)
            {
                _output += currentNumber;
            }
        }

        public override string ToString()
        {
            if (_output == 0) return "0";

            int number = _output;
            char[] chars = new char[10]; 
            int index = 0;

            if (number == 0)
            {
                return "0";
            }

            while (number > 0)
            {
                chars[index++] = (char)('0' + (number % 10));
                number /= 10;
            }

            for (int i = 0; i < index / 2; i++)
            {
                char temp = chars[i];
                chars[i] = chars[index - i - 1];
                chars[index - i - 1] = temp;
            }

            return new string(chars, 0, index);
        }
    }
}

