using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseHelper.ContentGenerators
{
    public class DBContentGenerator : IDBContentGenerator
    {
        private string[] _names =
        {
            "John", "Mike", "Michael", "Jason", "Eugene",
            "Alex", "Leo", "Mark", "Matt", "Bill", "Simon"
        };

        private Random _random;

        
        public DBContentGenerator()
        {
            _random = new Random();
        }


        public IEnumerable<Client> GenerateClients(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var client = new Client
                {
                    Name = GenerateName(),
                    Email = GenerateEmail(),
                };

                yield return client;
            }
        }


        private string GenerateName()
        {
            return _names[_random.Next() % _names.Length];
        }


        private string GenerateEmail()
        {
            string[] ends = { "yandex.ru", "ya.ru", "mail.ru", "gmail.com" };

            int count = _random.Next(5, 20);

            var sb = new StringBuilder();

            while (count-- > 0)
            {
                sb.Append(GetRandomLetter());
            }

            sb.Append('@');

            return sb.Append(ends[_random.Next() % ends.Length]).ToString();
        }


        private char GetRandomLetter()
        {
            string chars = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int num = _random.Next() % chars.Length;
            return chars[num];
        }
    }
}
