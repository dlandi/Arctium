﻿using Arctium.Cryptography.ASN1.ObjectSyntax.Types.BuildInTypes;
using Arctium.Cryptography.ASN1.Serialization.Exceptions;
using System.Collections.Generic;

namespace Arctium.Cryptography.ASN1.Serialization.X690v2.DER.BuildInTypeDecoders
{
    public class ObjectIdentifierDecoder : IDerTypeDecoder<ObjectIdentifier>
    {
        const byte ContinueSubidentifier = 0x80;

        public ObjectIdentifier Decode(byte[] buffer, long offset, long length)
        {
            
            long i = offset;
            List<byte[]> subi = new List<byte[]>();

            int subLength = 1;

            while (i < offset + length)
            {
                while ((buffer[i + subLength - 1] & ContinueSubidentifier) > 0)
                {
                    if (i + subLength > offset + length) throw new X690DecoderException($"Invalid encoded OID at {offset} at position {i}." +
                                    " Length exceed encoded expected length encoded in frame.");
                    subLength++;
                }

                byte[] subidentifier = ConvertToOidSubidentifier(buffer, i, subLength);
                subi.Add(subidentifier);

                i += subLength;
                subLength = 1;
            }

            ObjectIdentifier objectIdentifier = new ObjectIdentifier(subi.ToArray());
            return objectIdentifier;
        }

        private byte[] ConvertToOidSubidentifier(byte[] buffer, long offset, int subLength)
        {
            // every first bit is removed from bit string
            // round to bytes
            int length = ((((8 * subLength) - 1) - subLength) / 8) + 1;

            byte[] converted = new byte[length];

            int freeBits = 7;

            for (long i = subLength - 1; i >= 0; i--)
            {
                if (freeBits == 7)
                {
                    converted[i] = (byte)(buffer[offset + i] & 0x7F);
                    freeBits = 1;
                    continue;
                }

                converted[i + 1] |= (byte)(buffer[offset + i] << (8 - freeBits));
                converted[i] |= (byte)((buffer[offset + i] & 0x7F) >> freeBits);

                freeBits++;
            }

            int bitLength = (8 * subLength) - subLength;

            return converted;

        }
    }
}
