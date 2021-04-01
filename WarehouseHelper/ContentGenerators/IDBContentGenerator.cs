using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WarehouseHelper.ContentGenerators
{
    public interface IDBContentGenerator
    {
        IEnumerable<Client> GenerateClients(int count);
    }
}
