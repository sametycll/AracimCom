namespace AracimCom.Areas.Owner.Models
{
    public class AddVehicleImage
    {
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
        public IFormFile VehicleThumbnailImage { get; set; }
        public IFormFile VehicleImage { get; set; }
        public bool VehicleStatus { get; set; }
        public int ModelID { get; set; }
        public int UserID { get; set; }

       
        public string ImageAdd(IFormFile image)
        {
            var extension = Path.GetExtension(image.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/VehicleImageFiles/",
                newImageName);
            var stream = new FileStream(location, FileMode.Create);
            image.CopyTo(stream);
            return newImageName;
        }

        public string ThumbNailImageAdd(IFormFile image)
        {
            var extension = Path.GetExtension(image.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/VehicleThumbnailImageFiles/",
                newImageName);
            var stream = new FileStream(location, FileMode.Create);
            image.CopyTo(stream);
            return newImageName;
        }
    }
}
