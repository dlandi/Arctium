﻿namespace Arctium.Cryptography.ASN1.ObjectSyntax.Types.BuildInTypes
{
    /// <summary>
    /// Definitions of Build-in ASN.1 Types. Enumerated values are also valid Tag numbers for specific types
    /// </summary>
    public enum Asn1Type
    {
        RESERVED_0 = 0,
        Boolean = 1,
        Integer = 2,
        Bitstring = 3,
        Octetstring = 4,
        Null = 5,
        ObjectIdentifier = 6,
        ObjectDescriptor = 7,
        External = 8,
        InstanceOf = 8,
        Real = 9,
        Enumerated = 10,
        EmbeddedPdv = 11,
        UTF8String  = 12,
        RelativeObjectIdentifier = 13,
        Time =  14,
        ReservedForFutureEditions = 15,
        Sequence = 16,
        SequenceOf = 16,
        Set = 17,
        SetOf = 17,
        NumericString = 18,
        PrintableString = 19,
        TeletexString = 20,
        VideotexString = 21,
        IA5String = 22,
        GraphicString = 25,
        VisibleString = 26,
        GeneralString = 27,
        UniversalString = 28,
        CharacterString_29 = 29,
        BMPString = 30,
        UTCTime = 23,
        GeneralizedTime = 24,
        Date = 31,
        TimeOfDay = 32,
        DateTime = 33,
        Duration = 34,
        OIDInternationalizedResourceIdentifier = 35,
        RelativeOIDInternationalizedResourceIdentifier = 36,
        RESERVED_37_AND_MORE = 37
    }
}
