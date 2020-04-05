using System;
using System.Collections.Generic;
using System.Text;

namespace MFFT.Tests.BusinessLayer.Infra
{
   public class Product
    {
        public int Id { get; set; }
        public String ProductName { get; set; }

        public  decimal Price { get; set; }
    }


   public class ProductCat
   {
       private List<Product> _products;

       public int Id { get; set; }
       public String ProductCatName { get; set; }

        public  Product SelectedProduct { get; set; }


       public List<Product> Products
       {
           get
           {
                if(_products==null)
                    _products=new List<Product>();

                return _products;

           }
           set { _products = value; }
       }
   }


}
