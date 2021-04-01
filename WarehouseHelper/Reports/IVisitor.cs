using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseHelper.Reports
{
    public interface IVisitor
    {
        void VisitClient(Client client);
        void VisitSupplier(Supplier supplier);
    }
}
