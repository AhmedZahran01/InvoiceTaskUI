using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationInvoiceTask.DTOs
{
    public class CreateInvoiceDto
    {
        public List<CreateInvoiceItemDto> Items { get; set; } = new();
        public decimal Discount { get; set; }
    }
}
