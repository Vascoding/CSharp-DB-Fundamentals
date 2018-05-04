using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.Models;

namespace Sales
{
    public class InitializeAndSeed : DropCreateDatabaseAlways<SalesContext>
    {
        protected override void Seed(SalesContext context)
        {
        //    Product egg = new Product();
        //    egg.Name = "Eggs";
        //    egg.Quantity = 10;
        //    egg.Price = 0.50m;

        //    Product cheese = new Product();
        //    cheese.Name = "cheese";
        //    cheese.Quantity = 10;
        //    cheese.Price = 6.50m;

        //    Product milk = new Product();
        //    milk.Name = "milk";
        //    milk.Quantity = 10;
        //    milk.Price = 3.50m;


        //    Customer Gosho = new Customer();
        //    Gosho.Name = "Gosho";
        //    Gosho.CreditCardNumber = "VB2312532BG";
        //    Gosho.Email = "email@dir.bg";

        //    Customer Pesho = new Customer();
        //    Pesho.Name = "Pesho";
        //    Pesho.CreditCardNumber = "VB2323252BG";
        //    Pesho.Email = "email@dir.bg";

        //    Customer Stoyan = new Customer();
        //    Stoyan.Name = "Stoyan";
        //    Stoyan.CreditCardNumber = "VB5366732BG";
        //    Stoyan.Email = "email@dir.bg";


        //    StoreLocation Billa = new StoreLocation();
        //    Billa.LocationName = "Simitli";

        //    StoreLocation Liddl = new StoreLocation();
        //    Liddl.LocationName = "Svoge";

        //    StoreLocation TkMax = new StoreLocation();
        //    TkMax.LocationName = "Bania";


        //    Sale cheeseSale = new Sale();
        //    cheeseSale.Product = cheese;
        //    cheeseSale.Customer = Gosho;
        //    cheeseSale.StoreLocation = Billa;

        //    Sale eggSale = new Sale();
        //    eggSale.Product = egg;
        //    eggSale.Customer = Pesho;
        //    eggSale.StoreLocation = Liddl;

        //    Sale milkSale = new Sale();
        //    milkSale.Product = milk;
        //    milkSale.Customer = Stoyan;
        //    milkSale.StoreLocation = TkMax;

            
        //    context.Sales.Add(cheeseSale);
        //    context.Sales.Add(eggSale);
        //    context.Sales.Add(milkSale);
        //    context.SaveChanges();
        //    base.Seed(context);
        }
    }
}
