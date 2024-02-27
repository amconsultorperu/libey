using AutoMapper;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class LibeyUserAggregate : ILibeyUserAggregate
    {
        private readonly ILibeyUserRepository _repository;
        private readonly IMapper _mapper;
        public LibeyUserAggregate(ILibeyUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void Create(UserUpdateorCreateCommand command)
        {
            var libeyUser = _mapper.Map<LibeyUser>(command);
            _repository.Create(libeyUser);
        }
        public LibeyUserResponse FindResponse(string documentNumber)
        {
            var row = _repository.FindResponse(documentNumber);
            return row;
        }

        public List<LibeyUserDocumentTypeResponse> ListTypeDocument()
        {
            return _repository.ListTypeDocument();
        }

        public List<RegionResponse> ListRegion()
        {
            return _repository.ListRegion();
        }

        public List<ProvinceResponse> ListProvince(string codeRegion)
        {
            return _repository.ListProvince(codeRegion);
        }

        public List<UbigeoResponse> ListUbigeo(string codeRegion, string codeProvince)
        {
            return _repository.ListUbigeo(codeRegion, codeProvince);
        }

        public List<LibeyUserResponse> ListLibeyUser()
        {
            return _repository.ListLibeyUser();
        }
    }
}