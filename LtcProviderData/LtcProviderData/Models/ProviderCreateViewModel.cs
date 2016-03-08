using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LtcProviderData.Models
{
    public class ProviderCreateViewModel
    {
        [Required]
        public int CCN { get; set; }

        public string Comment { get; set; }

    }
}