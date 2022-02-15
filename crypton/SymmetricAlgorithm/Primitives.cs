namespace crypton.SymmetricAlgorithm;

internal static class Primitives
{
    public static System.Security.Cryptography.CipherMode FromCrypton(CipherMode mode)
    {
        return mode switch
        {
            CipherMode.CBC => System.Security.Cryptography.CipherMode.CBC,
            CipherMode.ECB => System.Security.Cryptography.CipherMode.ECB,
            CipherMode.OFB => System.Security.Cryptography.CipherMode.OFB,
            CipherMode.CFB => System.Security.Cryptography.CipherMode.CFB,
            CipherMode.CTS => System.Security.Cryptography.CipherMode.CTS,
            _ => throw new System.ArgumentOutOfRangeException(nameof(mode), "Specified integer is not defined as enum"),
        };
    }

    public static System.Security.Cryptography.PaddingMode FromCrypton(PaddingMode mode)
    {
        return mode switch
        {
            PaddingMode.None => System.Security.Cryptography.PaddingMode.None,
            PaddingMode.PKCS7 => System.Security.Cryptography.PaddingMode.PKCS7,
            PaddingMode.Zeros => System.Security.Cryptography.PaddingMode.Zeros,
            PaddingMode.ANSIX923 => System.Security.Cryptography.PaddingMode.ANSIX923,
            PaddingMode.ISO10126 => System.Security.Cryptography.PaddingMode.ISO10126,
            _ => throw new System.ArgumentOutOfRangeException(nameof(mode), "Specified integer is not defined as enum")
        };
    }
}