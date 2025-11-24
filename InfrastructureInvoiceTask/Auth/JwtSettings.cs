using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureInvoiceTask.Auth
{
    public class JwtSettings
    {
        public string Issuer { get; set; } = "InvoiceTaskIssuer";
        public string Audience { get; set; } = "InvoiceTaskAudience";
        public string Secret { get; set; } = "replace_this_with_a_long_secret_key_please";
        public int ExpMinutes { get; set; } = 60;
    }
}
