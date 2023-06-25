using System.Globalization;

namespace SimpraFinal.Business.OtherExtensions;

public class AppException : Exception
{
    public AppException(string message, params object[] args) 
        : base(String.Format(CultureInfo.CurrentCulture, message, args))
    {
    }
}