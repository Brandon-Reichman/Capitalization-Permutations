using System;
using System.Collections.Generic;
using System.Linq;

namespace Capitalization_Permutations
{
    public static class Program
    {
        static void Main()
        {
            while (true)
            {

                Console.WriteLine("Enter string");
                string value = Console.ReadLine();

                value = value.ToLower();

                if (value == ":q")
                    break;

                List<string> list = new List<string>();

                var results =
                    from e in Enumerable.Range(0, 1 << value.Length)
                    let p =
                    from b in Enumerable.Range(0, value.Length)
                    select (e & (1 << b)) == 0 ? (char?)null : value[b]
                    select string.Join(string.Empty, p);

                foreach (string s in results)
                {
                    string newValue = value;
                    s.ToLower();
                    foreach (char c in s)
                    {
                        var Old = c.ToString().ToLower();
                        var New = c.ToString().ToUpper();
                        newValue = ReplaceFirstOccurrence(newValue, Old, New);
                    }
                    list.Add(newValue);
                }

                int count = 0;
                var check = Math.Pow(2, value.Length);

                foreach (string s in list)
                {
                    count++;
                    Console.WriteLine(s);
                }

                Console.WriteLine("Count: " + count + "\nCheck: " + check);

                string msg = (count == check) ? "Success" : "Failure";

                Console.WriteLine(msg);
                Console.ReadKey();
            }
        }

        public static string ReplaceFirstOccurrence(string Source, string Find, string Replace)
        {
            int Place = Source.IndexOf(Find);
            string result = Source.Remove(Place, Find.Length).Insert(Place, Replace);
            return result;
        }
    }
}
