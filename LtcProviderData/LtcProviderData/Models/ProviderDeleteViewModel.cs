using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LtcProviderData.Models
{
    public class ProviderDeleteViewModel
    {
        public int ID { get; set; }
        public int CCN { get; set; }
        public string Comment { get; set; }
    }
}