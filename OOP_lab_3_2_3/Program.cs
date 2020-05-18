using System;
using System.IO;

namespace OOP_lab_3_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader input = new StreamReader("input.txt");

            string sentence = input.ReadLine();

            string[] words = sentence.Split(new char[] { '\n', '\r', ' ', ':', ';', '.', ',', '?', '!', '(', ')', '{', '}', '[', ']', '@', '#', '№', '$', '^', '%', '&', '*', '/', '|' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; ++i)
            {
                if (!String.IsNullOrWhiteSpace(words[i]))
                {
                    int k = 0;

                    for (int j = 0; j < words[i].Length; ++j)
                    {
                        if (words[i][j] == words[i][words[i].Length - j - 1])
                        {
                            ++k;
                        }
                    }
                    if (k - words[i].Length == 0)
                    {
                        words[i] = words[i].Remove(0);
                    }
                }
            }

            StreamWriter output = File.CreateText("output.txt");

            for (int i = 0; i < words.Length; ++i)
            {
                if (!String.IsNullOrWhiteSpace(words[i]))
                {
                    output.Write("{0} ", words[i]);
                }
            }

            output.Close();
        }
    }
}
