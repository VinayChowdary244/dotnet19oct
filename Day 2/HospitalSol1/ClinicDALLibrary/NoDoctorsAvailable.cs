using System.Runtime.Serialization;

namespace ClinicBLLibrary
{
    [Serializable]
    public class NoDoctorsAvailable : Exception
    {
        string message;
        public NoDoctorsAvailable()
        {
            message = "No doctors are available";
        }
        public override string Message => message;
        
    }
}