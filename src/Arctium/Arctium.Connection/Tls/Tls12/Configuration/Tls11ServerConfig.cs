﻿using Arctium.Connection.Tls.Tls12.CryptoFunctions;
using Arctium.Connection.Tls.Protocol.HandshakeProtocol;
using System.Security.Cryptography.X509Certificates;

namespace Arctium.Connection.Tls.Tls12.Configuration
{
    public class Tls11ServerConfig
    {
        public delegate bool ClientAuthenticationDelegate(X509Certificate2[] certChain);

        public X509Certificate2[] Certificates;

        public bool AuthenticateClient;
        public ClientAuthenticationDelegate ClientAuthenticationHandler;

        public CipherSuite[] EnableCipherSuites;
    }
}
