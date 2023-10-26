using System.Runtime.Serialization;

namespace ShoppingBLLibrary
{
    [Serializable]
    public class UnableToRegisterCustomerException : Exception
    {
        string message;
        public UnableToRegisterCustomerException()
        {
            message = "Unable to register the customer";
        }

        public override string Message => message;
    }
}