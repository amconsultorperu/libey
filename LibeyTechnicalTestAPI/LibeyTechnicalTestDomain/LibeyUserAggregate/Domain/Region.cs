using System.ComponentModel.DataAnnotations;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Domain
{
    public class Region
    {
        public string RegionCode { get; private set; }
        public string RegionDescription { get; private set; }

        public Region(string regionCode, string regionDescription)
        {
            RegionCode = regionCode;
            RegionDescription = regionDescription;

        }
    }
}