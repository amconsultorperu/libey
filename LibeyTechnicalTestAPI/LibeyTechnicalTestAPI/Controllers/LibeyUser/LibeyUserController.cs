using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace LibeyTechnicalTestAPI.Controllers.LibeyUser
{
    [ApiController]
    [Route("[controller]")]
    public class LibeyUserController : Controller
    {
        private readonly ILibeyUserAggregate _aggregate;
        public LibeyUserController(ILibeyUserAggregate aggregate)
        {
            _aggregate = aggregate;
        }
        [HttpGet]
        [Route("{documentNumber}")]
        public IActionResult FindResponse(string documentNumber)
        {
            var row = _aggregate.FindResponse(documentNumber);
            return Ok(row);
        }

        [HttpGet("document-types")]
        public IActionResult ListTypeDocuments()
        {
            var row = _aggregate.ListTypeDocument();
            return Ok(row);
        }

        [HttpGet("list-region")]
        public IActionResult ListRegion()
        {
            var row = _aggregate.ListRegion();
            return Ok(row);
        }

        [HttpGet("region/{codeRegion}/list-province")]
        public IActionResult ListProvince(string codeRegion)
        {
            var row = _aggregate.ListProvince(codeRegion);
            return Ok(row);
        }

        [HttpGet("region/{codeRegion}/province/{codeProvince}/list-ubigeo")]
        public IActionResult ListUbigeo(string codeRegion, string codeProvince)
        {
            var row = _aggregate.ListUbigeo(codeRegion, codeProvince);
            return Ok(row);
        }

        [HttpGet("LibeyUser-list")]
        public IActionResult ListLibeyUser()
        {
            var row = _aggregate.ListLibeyUser();
            return Ok(row);
        }

        [HttpPost]
        public IActionResult Create(UserUpdateorCreateCommand command)
        {
            _aggregate.Create(command);
            return Ok(true);
        }
    }
}