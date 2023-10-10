using box_company_back.api.TransferModels;
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
        [Route("/api/boxes")]
        public IEnumerable<Box> GetBoxes()
        {
            return _service.GetAllBoxes();
        }
        
        [HttpDelete]
        [Route("/api/boxes/delete/{boxId}")]
        public bool Delete([FromRoute] int boxId)
        {
            return _service.DeleteBox(boxId);
        }
        
        [HttpPost]
        [Route("/api/boxes/create")]
        public Box Create([FromBody] BoxDto dto)
        {
            return _service.CreateBox(dto.Height, dto.Width, dto.Length, dto.Type, dto.Amount);
        }
        
        [HttpPut]
        [Route("/api/boxes/update/{boxId}")]
        public Box Put(
            [FromRoute] int boxId,
            [FromBody] BoxDto dto)
        {
            return _service.UpdateBox(boxId, dto.Height, dto.Width, dto.Length, dto.Type, dto.Amount);
        }
}