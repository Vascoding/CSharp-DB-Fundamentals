using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalStore.Models;

namespace LocalStore
{
    class Startup
    {
        static void Main(string[] args)
        {
            
            Product newProduct = new Product("Milk", "DanTrans", "7%fat", 5.00m, 2.5, 1);
            var context = new LocalStoreContext();
            context.Products.Add(newProduct);
            context.SaveChanges();
            var productForRemove = context.Products.Find(1);
            context.Products.Remove(productForRemove);
        }
    }
}
