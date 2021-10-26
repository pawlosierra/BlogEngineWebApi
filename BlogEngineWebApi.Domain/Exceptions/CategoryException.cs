using System;

namespace BlogEngineWebApi.Domain.Exceptions
{
  public class CategoryException : Exception
  {
    public CategoryException(string errorCode, string message) : base(message)
    {
      ErrorCode = errorCode;
    }

    public string ErrorCode { get; set; }
  }
}
