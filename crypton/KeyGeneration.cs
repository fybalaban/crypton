using System.Security.Cryptography;

namespace crypton;

public static class KeyGeneration
{
    /// <summary>
    /// Returns cryptographically random array of bytes in supplied length 
    /// </summary>
    /// <param name="length">Size of byte array</param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when length is smaller than or equal to 0</exception>
    public static byte[] GetRandomBytes(int length)
    {
        if (length > 0 is false)
            throw new ArgumentOutOfRangeException(nameof(length), "Resulting array's length cannot be less than 1");

        byte[] randomBytes = new byte[length];
        var generator = RandomNumberGenerator.Create();
        
        generator.GetBytes(randomBytes);
        return randomBytes;
    }
}