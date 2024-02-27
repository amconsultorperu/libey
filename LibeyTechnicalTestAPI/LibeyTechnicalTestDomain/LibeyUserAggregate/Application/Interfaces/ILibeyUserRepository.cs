using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserRepository
    {
        LibeyUserResponse FindResponse(string documentNumber);
        List<LibeyUserDocumentTypeResponse> ListTypeDocument();
        List<RegionResponse> ListRegion();
        List<ProvinceResponse> ListProvince(string codeRegion);
        List<UbigeoResponse> ListUbigeo(string codeRegion, string codeUbigeo);
        List<LibeyUserResponse> ListLibeyUser();
        void Create(LibeyUser libeyUser);
    }
}
