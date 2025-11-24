using ApplicationInvoiceTask.DTOs;
using DomainInvoiceTask.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationInvoiceTask.Interfaces
{
    public interface IInvoiceService
    {
        Task<Invoice> CreateInvoiceAsync(CreateInvoiceDto dto);
        Task<Invoice?> GetInvoiceAsync(int id);
    }
}
