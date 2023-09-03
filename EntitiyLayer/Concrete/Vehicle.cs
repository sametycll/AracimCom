using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class Vehicle
    {
        [Key]
        public int VehicleID { get; set; }
        public string VehicleTitle { get; set; }
        public string VehicleDescription { get; set; }
        public decimal VehiclePrice { get; set; }
        public int VehicleYear { get; set; }
        public int VehicleKm { get; set; }
        public string VehicleFuel { get; set; }
        public string VehicleGear { get; set; }
        public string VehicleBodyType { get; set; }
        public int VehicleEnginePower { get; set; }
        public int VehicleEngineCapacity { get; set; }
        public string VehicleWheelDrive { get; set; }
        public string VehicleColor { get; set; }
        public string VehicleWarranty { get; set; }
        public string VehicleFrom { get; set; }
        public string VehicleExcangeable { get; set; }
        public string VehicleCity { get; set; }
        public string VehicleDistrict { get; set; }
        public string VehicleAd { get; set; }
        public DateTime VehicleAdDate { get; set; }
        public string VehicleThumbnailImage { get; set; }
        public string VehicleImage { get; set; }
        public bool VehicleStatus { get; set; }

        public int ModelID { get; set; }
        public Model Model { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

    }
}
