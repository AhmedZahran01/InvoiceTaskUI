using ApplicationInvoiceTask.DTOs;
using ApplicationInvoiceTask.Interfaces;
using DomainInvoiceTask.Entities;
using InfrastructureInvoiceTask.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureInvoiceTask.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ApplicationDbContext _db;
        public InvoiceService(ApplicationDbContext db) { _db = db; }

        public async Task<Invoice> CreateInvoiceAsync(CreateInvoiceDto dto)
        {
            var invoice = new Invoice();

            foreach (var it in dto.Items)
            {
                var item = await _db.Items.FindAsync(it.ItemId);
                var unit = await _db.Units.FindAsync(it.UnitId);

                var invItem = new InvoiceItem
                {
                    ItemId = it.ItemId,
                    UnitId = it.UnitId,
                    Price = it.Price,
                    Quantity = it.Quantity,
                    Discount = it.Discount
                };
                invoice.Items.Add(invItem);
            }

            invoice.SubTotal = invoice.Items.Sum(i => i.Total);
            invoice.Discount = dto.Discount;
            invoice.TotalNet = invoice.SubTotal - invoice.Discount;

            _db.Invoices.Add(invoice);
            await _db.SaveChangesAsync();
            return invoice;
        }

        public async Task<Invoice?> GetInvoiceAsync(int id)
        {
            return await _db.Invoices
                .Include(i => i.Items)
                .ThenInclude(ii => ii.Item)
                .Include(i => i.Items)
                .ThenInclude(ii => ii.Unit)
                .FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
