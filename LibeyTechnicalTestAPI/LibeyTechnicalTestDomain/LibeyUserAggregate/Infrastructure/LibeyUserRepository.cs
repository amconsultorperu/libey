using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class LibeyUserRepository : ILibeyUserRepository
    {
        private readonly Context _context;
        public LibeyUserRepository(Context context)
        {
            _context = context;
        }
        public void Create(LibeyUser libeyUser)
        {
            _context.LibeyUsers.Add(libeyUser);
            _context.SaveChanges();
        }
        public LibeyUserResponse FindResponse(string documentNumber)
        {

            var q = from libeyUser in _context.LibeyUsers.Where(x => x.DocumentNumber.Equals(documentNumber))
                    select new LibeyUserResponse()
                    {
                        DocumentNumber = libeyUser.DocumentNumber,
                        Active = libeyUser.Active,
                        Address = libeyUser.Address,
                        DocumentTypeId = libeyUser.DocumentTypeId,
                        Email = libeyUser.Email,
                        FathersLastName = libeyUser.FathersLastName,
                        MothersLastName = libeyUser.MothersLastName,
                        Name = libeyUser.Name,
                        Password = libeyUser.Password,
                        Phone = libeyUser.Phone
                    };
            var list = q.ToList();
            if (list.Any()) return list.First();
            else return new LibeyUserResponse();
        }

        public List<LibeyUserResponse> ListLibeyUser()
        {

            var q = from libeyUser in _context.LibeyUsers
                    join region in _context.Regions on libeyUser.UbigeoCode.Substring(0, 2) equals region.RegionCode
                    select new LibeyUserResponse()
                    {
                        DocumentNumber = libeyUser.DocumentNumber,
                        Active = libeyUser.Active,
                        Address = libeyUser.Address,
                        DocumentTypeId = libeyUser.DocumentTypeId,
                        Email = libeyUser.Email,
                        FathersLastName = libeyUser.FathersLastName,
                        MothersLastName = libeyUser.MothersLastName,
                        Name = libeyUser.Name,
                        Password = libeyUser.Password,
                        Phone = libeyUser.Phone,
                        RegionDescription = region.RegionDescription
                    };
            var list = q.ToList();
            if (list.Any()) return list.ToList();
            else return new List<LibeyUserResponse>();
        }

        public List<LibeyUserDocumentTypeResponse> ListTypeDocument()
        {
            var userDocuments = _context.DocumentTypes
                                  .Select(document => new LibeyUserDocumentTypeResponse
                                  {
                                      DocumentTypeId = document.DocumentTypeId,
                                      DocumentTypeDescription = document.DocumentTypeDescription
                                  })
                                  .ToList();
            return userDocuments;
        }

        public List<RegionResponse> ListRegion()
        {
            var regions = _context.Regions
                                  .Select(document => new RegionResponse
                                  {
                                      RegionCode = document.RegionCode,
                                      RegionDescription = document.RegionDescription
                                  })
                                  .ToList();
            return regions;
        }

        public List<ProvinceResponse> ListProvince(string codeRegion)
        {
            var provinces = _context.Provinces
                                .Where(p => p.RegionCode == codeRegion)
                                .Select(document => new ProvinceResponse
                                {
                                    ProvinceCode = document.ProvinceCode,
                                    ProvinceDescription = document.ProvinceDescription
                                })
                                .ToList();
            return provinces;
        }

        public List<UbigeoResponse> ListUbigeo(string codeRegion, string codeProvince)
        {
            var provinces = _context.Ubigeos
                                .Where(p => p.RegionCode == codeRegion && p.ProvinceCode == codeProvince)
                                .Select(document => new UbigeoResponse
                                {
                                    UbigeoCode = document.UbigeoCode,
                                    UbigeoDescription = document.UbigeoDescription
                                })
                                .ToList();
            return provinces;
        }
    }
}