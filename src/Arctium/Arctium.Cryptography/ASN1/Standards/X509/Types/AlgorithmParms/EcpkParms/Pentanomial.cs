﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Arctium.Cryptography.ASN1.Standards.X509.Types
{
    /// <summary>
    /// Represents Pentanomial parameters for Basic = Pp  for <see cref="CharacteristicTwo"/>
    /// </summary>
    public struct Pentanomial
    {
        public byte[] K1;
        public byte[] K2;
        public byte[] K3;
    }
}