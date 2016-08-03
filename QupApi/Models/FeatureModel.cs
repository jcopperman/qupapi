using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QupApi.Models
{
    public class FeatureModel
    {
        [Key]
        public int FeatureId { get; set; }

        public string FeatureDescription { get; set; }

        public ICollection<SprintModel> Sprints { get; set; }

        public ICollection<FeatureStoryModel> StoryModels {get;set;}

        public ICollection<UserInfoViewModel> UserStories { get; set; }

        public ICollection<FileResult> Attachments { get; set; }

    }
}