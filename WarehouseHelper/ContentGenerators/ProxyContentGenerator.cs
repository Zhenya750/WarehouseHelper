using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseHelper.ContentGenerators
{
    class ProxyGeneratorLogger : IDBContentGenerator
    {
        private IDBContentGenerator _generator { get; set; }


        public ProxyGeneratorLogger(IDBContentGenerator generator)
        {
            _generator = generator;
        }


        public IEnumerable<Client> GenerateClients(int count)
        {
            foreach (var client in _generator.GenerateClients(count))
            {
                Console.WriteLine($"Generated client name = {client.Name}, email = {client.Email} at {DateTime.Now}");
                yield return client;
            }
        }
    }
}
