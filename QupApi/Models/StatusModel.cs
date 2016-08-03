using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QupApi.Models
{
    public class StatusModel
    {
        [Key]
        public int StatusId { get; set; }

        public string Status { get; set; }
    }
}