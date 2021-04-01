using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseHelper.EntityBuilders;
using WarehouseHelper.Reports;

namespace WarehouseHelper
{
    public class Client : IVisitable
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [MaxLength(128)]
        public string Email { get; set; }

        public List<Shipment> Shipments { get; set; }


        public void Accept(IVisitor visitor)
        {
            visitor.VisitClient(this);
        }
    }


    public class Supplier : IVisitable
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        public List<Loading> Loadings { get; set; }


        public void Accept(IVisitor visitor)
        {
            visitor.VisitSupplier(this);
        }
    }


    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        public int Count { get; set; }

        public int MaxCount { get; set; }

        public string Description { get; set; }

        public List<Shipment> Shipments { get; set; }


        public static ProductBuilder CreateBuilder()
        {
            return new ProductBuilder();
        }
    }
    

    public class Shipment
    {
        public int Id { get; set; }

        public DateTime Datetime { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Count { get; set; }
    }


    public class Loading
    {
        public int Id { get; set; }

        public DateTime Datetime { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Count { get; set; }
    }
}
