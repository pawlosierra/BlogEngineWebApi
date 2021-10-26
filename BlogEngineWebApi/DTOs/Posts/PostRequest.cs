using System;

namespace BlogEngineWebApi.DTOs.Posts
{
  public class PostRequest
  {
    public string Title { get; set; }
    public DateTime PublicationDate { get; set; }
    public string Content { get; set; }
    public string Category { get; set; }
  }
}
