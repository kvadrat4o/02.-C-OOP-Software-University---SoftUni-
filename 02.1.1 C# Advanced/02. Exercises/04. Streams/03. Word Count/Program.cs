using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace _03.Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            Dictionary<string,int> wordsCount = new Dictionary<string, int>();
            using (StreamReader one = new StreamReader("..//..//words.txt"))
            {
                using (StreamReader two = new StreamReader("..//..//text.txt"))
                {
                    using (StreamWriter writer = new StreamWriter("..//..//results.txt"))
                    {

                        while ((line = one.ReadLine()) != null)
                        {
                            wordsCount[line.ToLower()] = 0;
                        }
                        while ((line = two.ReadLine()) != null)
                        {
                            var words = line.Split(new char[] { ' ', '.', ',', '!', '-', '?' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                            for (int i = 0; i < words.Length; i++)
                            {
                                words[i] = words[i].ToLower();
                            }
                            foreach (var word in words)
                            {
                                if (wordsCount.ContainsKey(word))
                                {
                                    wordsCount[word] ++;
                                }
                            }
                        }
                        //wordsCount.OrderByDescending(a => a.Value);
                        foreach (var wordsC in wordsCount.OrderByDescending(a => a.Value))
                        {
                            writer.WriteLine($"{wordsC.Key} - {wordsC.Value}");
                        }
                    }
                }
            }
        }
    }
}
