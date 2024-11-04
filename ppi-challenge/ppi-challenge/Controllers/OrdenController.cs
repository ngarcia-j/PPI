using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ppi_challenge.Models.DTOs;
using ppi_challenge.Models.Entities;
using ppi_challenge.Models.Requests;
using ppi_challenge.Services;

namespace ppi_challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdenController : Controller
    {
        private readonly IOrdenService _ordenService;
        private readonly IMapper _mapper;

        public OrdenController(IOrdenService ordenService
                                , IMapper mapper)
        {
            _ordenService = ordenService;
            _mapper = mapper;
        }


        [HttpGet("GetOrdenes")]
        public async Task<ActionResult<IEnumerable<OrdenDto>>> GetOrdenes()
        {
            var ordenes = await _ordenService.GetOrdenes();
            return Ok(ordenes);
        }

        [HttpGet("GetOrden/{id}")]
        public async Task<ActionResult<OrdenDto>> GetOrdenesById(int id)
        {
            var orden = await _ordenService.GetOrdenesById(id);
            if (orden == null)
            {
                return NotFound("Orden no encontrada.");
            }
            return Ok(orden);
        }

        [HttpPost("CreateOrden")]
        public async Task<ActionResult<OrdenDto>> CreateOrden(NewOrdenRequest ordenRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ordenDto = _mapper.Map<OrdenDto>(ordenRequest);
            var orden = await _ordenService.CreateOrden(ordenDto);
            return Ok(orden);
        }

        [HttpPut("UpdateOrden/{id}")]
        public async Task<ActionResult> UpdateOrden(int id, UpdateOrdenRequest updateOrden)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ordenDto = _mapper.Map<OrdenDto>(updateOrden);
            var orden = await _ordenService.UpdateOrden(id, ordenDto);
            return Ok();
        }

        [HttpDelete("DeleteOrden/{id}")]
        public async Task<ActionResult> DeleteOrden(int id)
        {
            await _ordenService.DeleteOrden(id);
            return Ok();
        }
    }
}
