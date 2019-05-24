﻿using System;

namespace Arctium.Connection.Tls.Protocol.HandshakeProtocol.Extensions
{
    class MaximumFragmentLength
    {
        public int Length;

        public MaximumFragmentLength(MaxFragmentLength maxLength)
        {
            switch (maxLength)
            {
                case MaxFragmentLength.Pow9:  Length = 2 << 9; break;
                case MaxFragmentLength.Pow10: Length = 2 << 10; break;
                case MaxFragmentLength.Pow11: Length = 2 << 11; break;
                case MaxFragmentLength.Pow12: Length = 2 << 12; break;
                default: throw new ApplicationException("Invalid value of the maxLength param");
            }
        }
    }
}
