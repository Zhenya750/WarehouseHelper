using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseHelper.Reports
{
    class TextExportVisitor : IVisitor
    {
        public void VisitClient(Client client)
        {
            Console.WriteLine($"Client id = {client.Id}, name = {client.Name}, email = {client.Email}");
        }


        public void VisitSupplier(Supplier supplier)
        {
            Console.WriteLine($"Supplier id = {supplier.Id}, name = {supplier.Name}");
        }
    }
}
