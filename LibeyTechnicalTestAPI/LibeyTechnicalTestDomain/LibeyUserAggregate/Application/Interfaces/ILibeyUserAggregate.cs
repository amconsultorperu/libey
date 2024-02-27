using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserAggregate
    {
        LibeyUserResponse FindResponse(string documentNumber);
        void Create(UserUpdateorCreateCommand command);
        List<LibeyUserDocumentTypeResponse> ListTypeDocument();
        List<RegionResponse> ListRegion();
        List<ProvinceResponse> ListProvince(string codeRegion);
        List<UbigeoResponse> ListUbigeo(string codeRegion, string codeUbigeo);
        List<LibeyUserResponse> ListLibeyUser();
    }
}