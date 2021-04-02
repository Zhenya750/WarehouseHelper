using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseHelper.ContentGenerators
{
    public class DBContentGenerator : IDBContentGenerator
    {
        private IGenerateNameStrategy _strategy;

        private Random _random;

        
        public DBContentGenerator(IGenerateNameStrategy strategy)
        {
            _strategy = strategy;
            _random = new Random();
        }


        public IEnumerable<Client> GenerateClients(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var client = new Client
                {
                    Name = _strategy.Generate(),
                    Email = GenerateEmail(),
                };

                yield return client;
            }
        }


        private string GenerateEmail()
        {
            string[] ends = { "yandex.ru", "ya.ru", "mail.ru", "gmail.com" };

            int count = _random.Next(5, 20);

            var sb = new StringBuilder();
            sb.Append("email");
            sb.Append('@');

            return sb.Append(ends[_random.Next() % ends.Length]).ToString();
        }
    }
}
