using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_2: Blue
    {
        private string _output;
        private string _todel;
        public string Output => _output;

        public Blue_2(string input, string todel): base(input)
        {
            _output = "";
            _todel = todel;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(_todel) || string.IsNullOrEmpty(Input))
            {
                _output = "";
                return;
            }

            string[] w = Input.Split(' ');
            string result = "";
            bool firstWord = true;

            foreach (string word in w)
            {
                if (!word.Contains(_todel))
                {
                    if (!firstWord)
                        result += " ";
                    result += word;
                    firstWord = false;
                }
                else
                {
                    int startIndex = 0;
                    while (startIndex < word.Length && char.IsPunctuation(word[startIndex]))
                    {
                        if (!firstWord && (startIndex == 0 || result[result.Length - 1] == ' '))
                            result += " ";
                        result += word[startIndex];
                        startIndex++;
                        firstWord = false;
                    }

                    int endIndex = word.Length - 1;
                    while (endIndex >= startIndex && char.IsPunctuation(word[endIndex]))
                    {
                        endIndex--;

                        for (int i = endIndex + 1; i < word.Length; i++)
                        {
                            result += word[i];
                        }
                    }
                }

                _output = result.Trim();
            }
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(_output))
                return "";

            return _output;
        }
    }
}
