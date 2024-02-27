using System.ComponentModel.DataAnnotations;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Domain
{
    public class Ubigeo
    {
        public string UbigeoCode { get; private set; }
        public string ProvinceCode { get; private set; }
        public string RegionCode { get; private set; }
        public string UbigeoDescription { get; private set; }

        public Ubigeo(string ubigeoCode, string provinceCode, string regionCode, string ubigeoDescription)
        {
            UbigeoCode = ubigeoCode;
            ProvinceCode = provinceCode;
            RegionCode = regionCode;
            UbigeoDescription = ubigeoDescription;

        }
    }
}