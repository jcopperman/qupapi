using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QupApi.Models
{
    public class UserStoryModel
    {
        [Key]
        public int UserStoryId { get; set; }

        public string UserStory { get; set; }

        public ICollection<StatusModel> Statuses { get; set; }
    }
}