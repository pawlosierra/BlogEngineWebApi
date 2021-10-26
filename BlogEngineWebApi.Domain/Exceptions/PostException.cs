using System;
using System.Collections.Generic;
using System.Text;

namespace BlogEngineWebApi.Domain.Exceptions
{
  public class PostException : Exception
  {
    public PostException(string errorCode, string message) : base(message)
    {
      ErrorCode = errorCode;
    }

    public string ErrorCode { get; set; }
  }
}
