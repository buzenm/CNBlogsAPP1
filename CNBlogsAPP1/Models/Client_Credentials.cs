using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPAPP.Models
{
    public class Client_Credentials
    {
        public string client_id { get; set; }

        public string client_secret { get; set; }

        public string grant_type { get; set; }

    }
}
