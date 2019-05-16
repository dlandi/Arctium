﻿using Arctium.Connection.Tls.Configuration;
using Arctium.Connection.Tls.Operator;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Arctium.Connection.Tls
{
    public class TlsServerConnection
    {
        TlsServerConfig config;

        public TlsServerConnection(X509Certificate2 cert)
        {
            this.config = new TlsServerConfig();
            config.Tls11ServerConfig = DefaultConfigurations.CreateDefaultTls11ServerConfig();
            config.Tls11ServerConfig.Certificates = new X509Certificate2[] { cert };
        }

        ///<summary>Accept new connection from specified stream</summary>
        public TlsStream Accept(Stream innerStream)
        {
            var protocolOperator = TlsProtocolOperatorSwitch.OpenServerSession(innerStream, config);

            return new TlsStream(protocolOperator);
        }
    }
}