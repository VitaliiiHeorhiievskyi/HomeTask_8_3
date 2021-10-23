using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_8_3
{
    class Text
    {
        public List<string> Sentences { get; private set; }

        public List<string> Lines { get; private set; }

        public Text(string filePath) : this()
        {
            ReadDataFromFile(filePath);
        }

        public Text()
        {
            Sentences = new List<string>();
            Lines = new List<string>();
        }

        public void ReadDataFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException();
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    Lines.Add(line);
                    line = reader.ReadLine();
                }
            }

            DoSentences();
        }

        public void SortSentences()
        {
            Sentences.Sort((fst, second) => fst.Length.CompareTo(second.Length));
        }

        public void DoSentences()
        {
            string sentence = "";

            List<string> tempSent;

            bool part = false;

            string partSentence = "";

            foreach (var line in Lines)
            {
                tempSent = line.Replace(". ", ".").Split(".", StringSplitOptions.RemoveEmptyEntries).ToList();

                if (part)
                {
                    sentence = partSentence + tempSent[0] + '.';

                    Sentences.Add(sentence);

                    part = false;

                    tempSent.RemoveAt(0);
                }

                if (line[line.Length - 1] != '.')
                {
                    partSentence = tempSent[tempSent.Count - 1] + " ";
                    part = true;
                    tempSent.RemoveAt(tempSent.Count - 1);
                }

                foreach (var value in tempSent)
                {
                    Sentences.Add(value + '.');
                }
            }

            if (part)
                throw new ArgumentException("The sentence is not over !!");


        }

        public string GetSentenceWihtMaxDepthOfBrackets()
        {
            List<string> temp = new List<string>(Sentences);
            temp.Sort((fst, second) => GetDepthOfBrackets(second).CompareTo(GetDepthOfBrackets(fst)));
            return temp[0];
        }

        public int GetDepthOfBrackets(string sentence)
        {
            int count = 0;
            int depth=0;
            int maxDepth = 0;

                foreach (var symbol in sentence)
                {
                    if (symbol == '(')
                    {
                        count++;
                        depth++;
                    }
                    
                    if (symbol == ')')
                        count--;

                    if (count < 0)
                        throw new ArgumentException("The brackets in the sentence are incorrect.");
                    if (count == 0 && depth > maxDepth)
                    {
                        maxDepth = depth;
                        depth = 0;
                    }
                }

                if(count!=0)
                throw new ArgumentException("The brackets in the sentence are incorrect.");


            return maxDepth;
        }

        
        
    }
}
