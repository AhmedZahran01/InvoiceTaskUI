using ApplicationInvoiceTask.DTOs;
using ApplicationInvoiceTask.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_InvoiceTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _service;

        public InvoicesController(IInvoiceService service)
        {
            _service = service;
        }

        //// POST: api/invoices
        //[HttpPost("create")]
        //[Authorize]
        //public async Task<IActionResult> Create( )
        //{
        //    //var result = await _service.CreateInvoiceAsync(dto);
        //    return CreatedAtAction(nameof(Get), new { id =1 }, 1);
        //}

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateInvoiceDto dto)
        {
            var result = await _service.CreateInvoiceAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }


        // GET: api/invoices/{id}
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var invoice = await _service.GetInvoiceAsync(id);

            if (invoice == null)
                return NotFound();

            return Ok(invoice);
        }
    } 
     
}
