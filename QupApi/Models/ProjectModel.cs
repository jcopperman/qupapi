using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QupApi.Models
{
    public class ProjectModel
    {
        [Key]
        public int ProjectId { get; set; }

        public string Name { get; set; }

        public DateTime ProjectStartDate { get; set; }

        public DateTime ProjectEndDate { get; set; }

        public ICollection<SprintModel> Sprints { get; set; }
    }
}