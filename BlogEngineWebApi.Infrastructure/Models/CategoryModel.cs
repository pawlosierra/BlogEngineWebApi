using System;
using System.Collections.Generic;

#nullable disable

namespace BlogEngineWebApi.Infrastructure.Models
{
    public partial class CategoryModel
    {
        public CategoryModel()
        {
            PostModels = new HashSet<PostModel>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<PostModel> PostModels { get; set; }
    }
}
