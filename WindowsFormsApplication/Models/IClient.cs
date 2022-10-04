using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication.Models
{
    internal interface IClient
    {
        public string Name { get; set; }
        public string IpAddress { get; set; }
    }
}
