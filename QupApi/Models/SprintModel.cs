using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QupApi.Models
{
    public class SprintModel
    {
        [Key]
        public int SprintId { get; set; }

        public string SprintName { get; set; }

        public ICollection<FeatureModel> Features { get; set; }

        public DateTime SprintStartDate { get; set; }

        public DateTime SprintEndDate { get; set; }
    }
}