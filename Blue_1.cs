using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_1: Blue
    {
        private string[] _output;
        public string[] Output => _output == null ? null : (string[])_output.Clone();

        public Blue_1(string input): base(input) {
            _output = null;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = null;
                return;
            }

            string[] words = Input.Split(' ');

            if (words.Length == 0)
            {
                _output = null;
                return;
            }

            int lineCount = 1;
            int currentLength = words[0].Length;

            for (int i = 1; i < words.Length; i++)
            {
                if (currentLength + 1 + words[i].Length > 50)
                {
                    lineCount++;
                    currentLength = words[i].Length;
                }
                else
                {
                    currentLength += 1 + words[i].Length;
                }
            }

            _output = new string[lineCount];
            int index = 0;
            _output[index] = words[0];

            for (int i = 1; i < words.Length; i++)
            {
                if (_output[index].Length + 1 + words[i].Length <= 50)
                {
                    _output[index] += " " + words[i];
                }
                else
                {
                    index++;
                    _output[index] = words[i];
                }
            }
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0) return string.Empty;
            return string.Join(Environment.NewLine, _output);
        }
    }
}
