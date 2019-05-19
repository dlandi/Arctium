﻿namespace Arctium.Connection.Tls.CryptoConfiguration
{
    class Tls12Secrets
    {
        public byte[] MasterSecret;

        public byte[] ClientWriteMacKey;
        public byte[] ServerWriteMacKey;
        public byte[] ClientWriteKey;
        public byte[] ServerWriteKey;
        public byte[] ClientIV;
        public byte[] ServerIV;
    }
}
