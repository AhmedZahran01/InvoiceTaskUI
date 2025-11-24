using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationInvoiceTask.DTOs
{
    public class CreateInvoiceItemDto
    {
        public int ItemId { get; set; }
        public int UnitId { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal Discount { get; set; }
    }
}
