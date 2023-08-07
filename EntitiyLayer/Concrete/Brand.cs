using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class Brand
    {
        [Key]
        public int BrandID { get; set; }

        public string BrandName { get; set; }

        public bool BrandStatus { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public List<Series> Series { get; set; }

    }
}
