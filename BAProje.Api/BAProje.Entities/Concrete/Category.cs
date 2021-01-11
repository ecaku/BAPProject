using BAProje.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace BAProje.Entities.Concrete
{
    public class Category:ITable
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
    }
}
