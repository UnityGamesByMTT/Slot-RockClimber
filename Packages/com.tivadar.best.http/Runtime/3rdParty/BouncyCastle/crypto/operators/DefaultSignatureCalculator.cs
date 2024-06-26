#if !BESTHTTP_DISABLE_ALTERNATE_SSL && (!UNITY_WEBGL || UNITY_EDITOR)
#pragma warning disable
using System;
using System.IO;

using Best.HTTP.SecureProtocol.Org.BouncyCastle.Crypto.IO;

namespace Best.HTTP.SecureProtocol.Org.BouncyCastle.Crypto.Operators
{
    public class DefaultSignatureCalculator
        : IStreamCalculator<IBlockResult>
    {
        private readonly SignerSink mSignerSink;

        public DefaultSignatureCalculator(ISigner signer)
        {
            this.mSignerSink = new SignerSink(signer);
        }

        public Stream Stream
        {
            get { return mSignerSink; }
        }

        public IBlockResult GetResult()
        {
            return new DefaultSignatureResult(mSignerSink.Signer);
        }
    }
}
#pragma warning restore
#endif
