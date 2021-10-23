using System;

namespace HomeTask_8_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Text text = new(@"D:\Users\vital\source\repos\HomeTask_8_3\input.txt");

            foreach (var item in text.Sentences)
            {
                Console.WriteLine(item);
            }

            text.SortSentences();

            Console.WriteLine("\n\nAfter sort:\n");

            foreach (var item in text.Sentences)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nSentences where the depth of the brackets is the largest:\n"+text.GetSentenceWihtMaxDepthOfBrackets());
        }
    }
}
