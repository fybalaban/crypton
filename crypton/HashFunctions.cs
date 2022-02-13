using System.Security.Cryptography;
using System.Text;

namespace crypton;

public class HashFunctions
{
    public enum HashFunction
    {
        Sha1, Sha256, Sha384, Sha512, Md5
    }

    /// <summary>
    /// Returns exact HashAlgorithmName instance of given HashFunction
    /// </summary>
    /// <param name="name">Hash function to get HashAlgorithmName instance of</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when given enum name is not in range</exception>
    /// <returns></returns>
    public static HashAlgorithmName FromHashFunction(HashFunction name)
    {
        return name switch
        {
            HashFunction.Md5 => HashAlgorithmName.MD5,
            HashFunction.Sha1 => HashAlgorithmName.SHA1,
            HashFunction.Sha256 => HashAlgorithmName.SHA256,
            HashFunction.Sha384 => HashAlgorithmName.SHA384,
            HashFunction.Sha512 => HashAlgorithmName.SHA512,
            _ => throw new ArgumentOutOfRangeException(nameof(name), "Enum is not in range")
        };
    }

    /// <summary>
    /// Hashes supplied byte array using the given hash function
    /// </summary>
    /// <param name="content">Byte array to be hashed</param>
    /// <param name="method">Hash method to be used</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">Thrown when supplied byte array is null</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when supplied byte array is empty</exception>
    public static byte[] PerformHash(byte[] content, HashFunction method) => content is null
            ? throw new ArgumentNullException(nameof(content), "Byte array to be hashed cannot be null")
            : content.Length is 0
            ? throw new ArgumentOutOfRangeException(nameof(content), "Byte array to be hashed cannot be empty")
            : method switch
            {
                HashFunction.Sha1 => Sha1(content),
                HashFunction.Sha256 => Sha256(content),
                HashFunction.Sha384 => Sha384(content),
                HashFunction.Sha512 => Sha512(content),
                HashFunction.Md5 => Md5(content),
                _ => throw new ArgumentOutOfRangeException(nameof(method), method, null)
            };

    /// <summary>
    /// Hashes supplied string value using the given hash function
    /// </summary>
    /// <param name="content">String object to be hashed</param>
    /// <param name="method">Hash method to be used</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">Thrown when supplied string is null or empty</exception>
    public static string PerformHash(string content, HashFunction method) =>
        string.IsNullOrEmpty(content)
            ? throw new ArgumentNullException(nameof(content), "String to be hashed cannot be null or empty")
            : BitConverter.ToString(PerformHash(Encoding.UTF8.GetBytes(content), method)).Replace("-", "").ToLower();

    private static byte[] Sha1(byte[] plain)
    {
        using var algorithm = SHA1.Create();
        return algorithm.ComputeHash(plain);
    }
    
    private static byte[] Sha256(byte[] plain)
    {
        using var algorithm = SHA256.Create();
        return algorithm.ComputeHash(plain);
    }
    
    private static byte[] Sha384(byte[] plain)
    {
        using var algorithm = SHA384.Create();
        return algorithm.ComputeHash(plain);
    }
    
    private static byte[] Sha512(byte[] plain)
    {
        using var algorithm = SHA512.Create();
        return algorithm.ComputeHash(plain);
    }

    private static byte[] Md5(byte[] plain)
    {
        using var algorithm = MD5.Create();
        return algorithm.ComputeHash(plain);
    }
}