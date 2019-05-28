﻿using Arctium.Connection.Tls.Configuration;
using Arctium.Connection.Tls.Operator;
using Arctium.Connection.Tls.Operator.Tls12Operator;
using System.IO;

namespace Arctium.Connection.Tls
{
    public class TlsClientConnection
    {
        Tls12ClientConfig config;

        public TlsClientConnection() { }

        public TlsConnectionResult Connect(Stream innerStream)
        {
            config = new Tls12ClientConfig();
            config.EnableCipherSuites = DefaultConfigurations.CreateDefaultTls12CipherSuites();
            config.Extensions = null;

            Tls12ClientOperator clientOperator = new Tls12ClientOperator(config, innerStream);
            return clientOperator.OpenSession();
        }

        public TlsConnectionResult Connect(Stream innerStream, Tls12Session testSessionResumption)
        {
            Tls12ClientOperator clientOperator = new Tls12ClientOperator(config, innerStream);
            TlsConnectionResult result = clientOperator.OpenSession(testSessionResumption);


            return result;
        }
    }
}
