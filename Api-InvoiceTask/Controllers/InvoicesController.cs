using ApplicationInvoiceTask.DTOs;
using ApplicationInvoiceTask.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("create")]
        //[Authorize] // ممكن تعطلها لتجربة أولية
        public async Task<IActionResult> Create([FromBody] CreateInvoiceDto dto)
        {
            var result = await _service.CreateInvoiceAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var invoice = await _service.GetInvoiceAsync(id);
            if (invoice == null) return NotFound();
            return Ok(invoice);
        }
    }
}
