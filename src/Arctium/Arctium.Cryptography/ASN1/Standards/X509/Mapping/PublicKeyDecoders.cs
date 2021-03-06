﻿using System;
using Arctium.Cryptography.ASN1.ObjectSyntax.Types.BuildInTypes;
using Arctium.Cryptography.ASN1.Serialization.X690;
using Arctium.Cryptography.ASN1.Serialization.X690.DER;
using Arctium.Cryptography.ASN1.Standards.X509.Mapping;
using Arctium.Cryptography.ASN1.Standards.X509.X509Cert;

namespace Arctium.Cryptography.ASN1.Standards.X509.Mapping
{
    class PublicKeyDecoders
    {
        X690Validation valid;
        AlgorithmIdentifierSharedDecoder algoShared;
        DerDeserializer der;

        public PublicKeyDecoders()
        {
            valid = new X690Validation(nameof(PublicKeyDecoders));
            algoShared = new AlgorithmIdentifierSharedDecoder();
            der = new DerDeserializer();
        }

        internal object ECPublicKeyParms(byte[] algoParms)
        {
            return algoShared.ECPublicKeyParms(algoParms);
        }

        internal object RSAPublicKey(byte[] keyRawValue)
        {
            var node = der.Deserialize(keyRawValue)[0];
            valid.CLength(node, 2);
            valid.Tag(node[0], BuildInTag.Integer);
            valid.Tag(node[1], BuildInTag.Integer);

            byte[] n = DerDecoders.DecodeWithoutTag<Integer>(node[0]).BinaryValue;
            byte[] e = DerDecoders.DecodeWithoutTag<Integer>(node[1]).BinaryValue;

            return new RSAPublicKey(n, e);
        }

        internal object ECPublicKey(byte[] keyRawValue)
        {
            return keyRawValue;
        }
    }
}
