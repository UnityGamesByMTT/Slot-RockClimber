#if !BESTHTTP_DISABLE_ALTERNATE_SSL && (!UNITY_WEBGL || UNITY_EDITOR)
#pragma warning disable
using Best.HTTP.SecureProtocol.Org.BouncyCastle.Security;

namespace Best.HTTP.SecureProtocol.Org.BouncyCastle.Crypto
{
    public static class CryptoServicesRegistrar
    {
        public static SecureRandom GetSecureRandom()
        {
            return new SecureRandom();
        }

        public static SecureRandom GetSecureRandom(SecureRandom secureRandom)
        {
            return secureRandom ?? new SecureRandom();
        }
    }
}
#pragma warning restore
#endif
