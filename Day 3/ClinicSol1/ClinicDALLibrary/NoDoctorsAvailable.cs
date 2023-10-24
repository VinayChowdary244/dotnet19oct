using System.Runtime.Serialization;

namespace ClinicBLLibrary
{
    [Serializable]
    public class NoDoctorsAvailable : Exception
    {
        public NoDoctorsAvailable()
        {
        }

        
    }
}