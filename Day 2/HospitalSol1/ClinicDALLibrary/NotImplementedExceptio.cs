using System.Runtime.Serialization;

namespace ClinicBLLibrary
{
    [Serializable]
    public class NotAddedException : Exception
    {
        string message;
        public NotAddedException()
        {
            message = "Doctor not added ";
        }

        public override string Message => message;
    }
}