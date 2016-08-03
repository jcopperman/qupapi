using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QupApi.Models
{
    public class FeatureStoryModel
    {
        [Key]
        public int FeatureStoryId { get; set; }

        public string FeatureStory { get; set; }

        public ICollection<UserStoryModel> UserStories { get; set; }

    }
}