using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseHelper.ContentGenerators
{
    class RandomNameGenerator : IGenerateNameStrategy
    {
        private Random _random;


        public RandomNameGenerator()
        {
            _random = new Random();
        }


        public string Generate()
        {
            int nameLength = _random.Next() % 8 + 3;

            var sb = new StringBuilder();

            while (nameLength-- > 0)
            {
                sb.Append(GetRandomLetter());
            }

            string name = sb.ToString();

            return name.First().ToString().ToUpper() + name.Substring(1);
        }


        private char GetRandomLetter()
        {
            string chars = "abcdefghijklmnopqrstuvwxyz";

            int num = _random.Next() % chars.Length;
            return chars[num];
        }
    }
}
