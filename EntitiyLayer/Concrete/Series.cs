using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class Series
    {
        [Key]
        public int SeriesID { get; set; }

        public string SeriesName { get; set; }

        public bool SeriesStatus { get; set; }

        public int BrandID { get; set; }
        public Brand Brand{ get; set; }

        public List<Model> Models { get; set; }

    }
}
