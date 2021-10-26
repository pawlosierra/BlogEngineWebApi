using System;
using System.Collections.Generic;

namespace BlogEngineWebApi.Domain.Models
{
  public class Post
  {
    public Guid Id { get; set; }
    public Guid IdCategory { get; set; }
    public string Title { get; set; }
    public DateTime PublicationDate { get; set; }
    public string Content { get; set; }
    public string Category { get; set; }
  }
}
