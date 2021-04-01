using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseHelper.EntityBuilders
{
    public class ProductBuilder
    {
        private Product _product { get; set; }


        public ProductBuilder()
        {
            _product = new Product();
        }


        public ProductBuilder SetName(string name)
        {
            _product.Name = name;
            return this;
        }


        public ProductBuilder SetDescription(string description)
        {
            _product.Description = description;
            return this;
        }


        public ProductBuilder SetCount(int count)
        {
            _product.Count = count;
            return this;
        }


        public ProductBuilder SetMaxCount(int maxcount)
        {
            _product.MaxCount = maxcount;
            return this;
        }


        public Product Build()
        {
            return _product;
        }
    }
}
