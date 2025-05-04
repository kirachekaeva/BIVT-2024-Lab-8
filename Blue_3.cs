using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_3: Blue
    {
        private (char, double)[] _output;

        public (char, double)[] Output => _output;

        public Blue_3(string input): base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input)) return;

            string[] words = Regex.Split(Input, @"[^\w'-]+")
                .Where(x => !string.IsNullOrEmpty(x))
                .ToArray();
            char[] firstLetters = new char[words.Length];
            int letterCount = 0;
            int totalWords = 0;

            foreach (string word in words)
            {
                if (word.Length == 0) continue;

                char firstLetter = char.ToLower(word[0]);
                if (char.IsLetter(firstLetter))
                {
                    firstLetters[letterCount++] = firstLetter;
                    totalWords++;
                }
            }

            if (totalWords == 0)
            {
                _output = null;
                return;
            }

            (char letter, int count)[] letters = new (char, int)[26];
            int uniqueCount = 0;

            for (int i = 0; i < letterCount; i++)
            {
                char current = firstLetters[i];
                bool found = false;

                for (int j = 0; j < uniqueCount; j++)
                {
                    if (letters[j].letter == current)
                    {
                        letters[j].count++;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    letters[uniqueCount++] = (current, 1);
                }
            }

            (char, double)[] result = new (char, double)[uniqueCount];
            for (int i = 0; i < uniqueCount; i++)
            {
                double percentage = Math.Round((double)letters[i].count / totalWords * 100, 4);
                result[i] = (letters[i].letter, percentage);
            }

            for (int i = 0; i < result.Length - 1; i++)
            {
                for (int j = 0; j < result.Length - i - 1; j++)
                {
                    bool needSwap = false;

                    if (result[j].Item2 < result[j + 1].Item2)
                    {
                        needSwap = true;
                    }

                    else if (Math.Abs(result[j].Item2 - result[j + 1].Item2) < 0.0001 &&
                             result[j].Item1 > result[j + 1].Item1)
                    {
                        needSwap = true;
                    }

                    if (needSwap)
                    {
                        var temp = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = temp;
                    }
                }
            }

            _output = result;
        }

        public override string ToString()
        {
            if (_output == null) return null;
            return string.Join(Environment.NewLine, _output.Select(p => $"{p.Item1} - {p.Item2:F4}"));
        }
    }
}
