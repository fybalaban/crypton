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

    /// <summary>
    /// Password Based Key Derivation Function. Resulting byte array's length depends on used hash algorithm
    /// </summary>
    /// <param name="password">Password in bytes</param>
    /// <param name="salt">Salt in bytes, use of a cryptographically secure salt is advised</param>
    /// <param name="repetition">Count of hashing the byte array will get applied</param>
    /// <param name="length">Length of resulting key's byte array</param>
    /// <param name="method">Hashing method to be used</param>
    /// <returns>Returns a byte array as the key to be used in encryption or decryption</returns>
    public static byte[] Pbkdf2(byte[] password, byte[] salt, int repetition, int length, HashFunctions.HashFunction method)
    {
        throw new NotImplementedException();
    }
}