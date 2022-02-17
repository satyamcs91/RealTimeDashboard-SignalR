using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mysql.Helper
{
    public class Products
    {
        public int Id { get; set; }
        public int ModelNo { get; set; }
        public string AssetName { get; set; }
        public string Location { get; set; }
        public decimal Cost { get; set; }
    }
}
