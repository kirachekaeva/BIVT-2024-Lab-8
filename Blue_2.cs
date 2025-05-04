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
            _output = null;
            _todel = todel;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(_todel) || string.IsNullOrEmpty(Input))
            {
                _output = null;
                return;
            }

            string[] words = Input.Split(' ');
            _output = Input;

            foreach (string word in words)
            {
                if (word.Contains(_todel))
                {
                    bool hasPunctuation = word.Contains(".") || word.Contains(",") || word.Contains(";");

                    if (hasPunctuation)
                    {
                        char lastChar = word[word.Length - 1];

                        if (word.Contains("\""))
                        {
                            _output = _output.Replace(word, "\"\"" + lastChar);
                        }
                        else
                        {
                            _output = _output.Replace(word, lastChar.ToString());
                        }
                    }
                    else
                    {
                        _output = _output.Replace(word + " ", "");
                    }
                }
            }

            while (_output.Contains("  "))
            {
                _output = _output.Replace("  ", " ");
            }

            _output = _output.Trim();
        }
    

        public override string ToString()
        {
            if (string.IsNullOrEmpty(_output))
                return string.Empty;

            return _output;
        }
    }
}
