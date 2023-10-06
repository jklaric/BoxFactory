using box_company_back.models;
using box_company_back.service;
using Microsoft.AspNetCore.Mvc;

namespace box_company_back.Controllers;

[ApiController]
public class CrudController : ControllerBase
{
    private readonly Service _service;

    public CrudController(Service service)
    {
        _service = service;
    }
        
        [HttpGet]
        [Route("/testdb")]
        public IEnumerable<Box> GetBoxes()
        {
            return _service.GetAllBoxes();
        }

		[HttpDelete]
		[Route("/api/boxes{boxId}")]
		public object Delete([FromRoute] int boxId)
		{
			return _service.DeleteBox(boxId);
		}
}