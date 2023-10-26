using System.Runtime.Serialization;

namespace ClinicBLLibrary
{
    [Serializable]
    public class NotImplementedExceptio : Exception
    {
        string message;
        public NotImplementedExceptio()
        {
            message = "Not Implemented ";
        }

        public override string Message => message;
    }
}