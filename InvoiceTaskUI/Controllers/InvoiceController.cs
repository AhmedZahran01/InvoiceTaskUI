using Microsoft.AspNetCore.Mvc;

namespace InvoiceTaskUI.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
