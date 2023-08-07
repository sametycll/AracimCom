using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class Model
    {
        [Key]
        public int ModelID { get; set; }

        public string ModelName { get; set; }

        public bool ModelStatus { get; set; }

        public int SeriesID { get; set; }
        public Series Series{ get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}
