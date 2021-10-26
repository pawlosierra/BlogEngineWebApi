using System;
using System.Collections.Generic;

#nullable disable

namespace BlogEngineWebApi.Infrastructure.Models
{
    public partial class PostModel
    {
        public Guid Id { get; set; }
        public Guid IdCategory { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }

        public virtual CategoryModel IdCategoryNavigation { get; set; }
    }
}
