using System;

namespace NetCoreRazorEFCoreSchool
{
  public static class Utility
  {
    public static string GetLastChars(Guid token)
    {
      return token.ToString().Substring(token.ToString().Length - 3);
    }
  }
}