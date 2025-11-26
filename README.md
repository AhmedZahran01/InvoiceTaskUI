# InvoiceTaskUI

**InvoiceTaskUI**  
مشروع واجهة ونواة API لإنشاء وإدارة فواتير (Invoice) — مبني بـ **ASP.NET Core (.NET 8)** مع Web API وASP.NET Core MVC (Razor).  
المشروع عبارة عن واجهة بسيطة لإنشاء فواتير، وAPI يعالج الحفظ في قاعدة البيانات باستخدام **Entity Framework Core**، ويدعم مصادقة JWT للاختبارات.

---

## 🔧 التقنيات المستخدمة
- .NET 8 (ASP.NET Core Web API + MVC)
- Entity Framework Core (SQL Server)
- JWT للتصديق (Authentication)
- HTML / JavaScript للواجهة (Razor Views)
- Clean Architecture / طبقات بسيطة (Domain, Application, Infrastructure, Api, Web)

---

## ⚙️ مميزات المشروع (المطبق الآن)
- صفحة إنشاء فاتورة (Create Invoice) تحتوي على:
  - إضافة صفوف الأصناف (Item, Unit, Price, Qty, Discount, Net)
  - صف علوي يحتوي على: Invoice No, Invoice Date, Store (DropDown)
  - عداد وقت وتاريخ حي فوق الصفحة
  - حفظ الفاتورة عبر استدعاء API: `POST /api/Invoices/create`
- Backend:
  - `InvoicesController` مع endpoints `POST /api/Invoices/create` و `GET /api/Invoices/{id}`
  - Service (`IInvoiceService` / `InvoiceService`) يحسب ويخزن الفاتورة
  - `ApplicationDbContext` مع Entities: Item, Unit, Invoice, InvoiceItem
- CORS مفعل لتجربة الواجهة المحلية مع الـ API
- مثال بيانات مبدئية (Seeding) للأصناف والوحدات

---

## 🔁 بنية المشروع (موجز)
