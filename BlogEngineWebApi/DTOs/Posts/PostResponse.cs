using System;
using System.Collections.Generic;

namespace BlogEngineWebApi.DTOs.Posts
{
  public class PostResponse
  {
    public string Title { get; set; }
    public DateTime PublicationDate { get; set; }
    public string Content { get; set; }
    public string Category { get; set; }
  }
}
