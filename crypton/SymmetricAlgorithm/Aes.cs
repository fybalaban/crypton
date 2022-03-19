using System.Security.Cryptography;

namespace crypton.SymmetricAlgorithm;

public class Aes
{
    #region Properties
    /// <summary>
    /// Gets or sets the padding mode of the cryptographic operation. Default is <see langword="PaddingMode.PKCS7"/>
    /// </summary>
    public PaddingMode Padding { get; set; }

    /// <summary>
    /// Gets or sets the block cipher mode of the cryptographic operation. Default is <see langword="CipherMode.CBC"/>
    /// </summary>
    public CipherMode Mode { get; set; }

    /// <summary>
    /// Gets the block size of the cryptographic operation. AES has 128-bit blocks by design, and this cannot be changed
    /// </summary>
    public int BlockSize => _aes.BlockSize;

    /// <summary>
    /// Gets the feedback size, in bits of the cryptographic operation for <see langword="CipherMode.CFB"/> and <see langword="CipherMode.OFB"/> modes. Call SetFeedbackSize() to set this property
    /// </summary>
    public int FeedbackSize => _aes.FeedbackSize;

    /// <summary>
    /// Gets the cryptographic key used by this instance. Call SetKey() to set this property
    /// </summary>
    public byte[] Key => _aes.Key;

    /// <summary>
    /// Gets the Initialization Vector used by this instance. Call SetIV() to set this property
    /// </summary>
    public byte[] IV => _aes.IV;
    #endregion

    private readonly System.Security.Cryptography.Aes _aes;

    /// <summary>
    /// Creates an instance of <see langword="crypton.SymmetricAlgorithm.Aes"/> with default properties
    /// </summary>
    public Aes()
    {
        _aes = System.Security.Cryptography.Aes.Create();

        Padding = PaddingMode.PKCS7;
        Mode = CipherMode.CBC;
        SetFeedbackSize(128);

        _aes.Padding = Primitives.FromCrypton(Padding);
        _aes.Mode = Primitives.FromCrypton(Mode);
        _aes.FeedbackSize = FeedbackSize;
        _aes.GenerateKey();
        _aes.GenerateIV();
    }

    /// <summary>
    /// Creates an instance of <see langword="crypton.SymmetricAlgorithm.Aes"/> with default properties, using supplied key and initalization vector
    /// </summary>
    /// <param name="key"></param>
    /// <param name="iv"></param>
    public Aes(byte[] key, byte[] iv)
    {
        if (!IsKeyValid(key))
            throw new ArgumentException("Supplied key byte array is not a valid key for use in AES cryptographic operation", nameof(key));
        if (!IsInitVectorValid(iv))
            throw new ArgumentException("Supplied IV byte array is not a valid IV for use in AES cryptographic operation", nameof(iv));

        _aes = System.Security.Cryptography.Aes.Create();

        Padding = PaddingMode.PKCS7;
        Mode = CipherMode.CBC;
        SetFeedbackSize(128);

        _aes.Padding = Primitives.FromCrypton(Padding);
        _aes.Mode= Primitives.FromCrypton(Mode);
        _aes.FeedbackSize = FeedbackSize;
        _aes.Key = key;
        _aes.IV = iv;
    }

    #region Property Setter Methods
    /// <summary>
    /// Sets the symmetric key property (<see langword="Aes.Key"/>) to supplied byte array if byte array is a valid key, otherwise does nothing
    /// </summary>
    public void SetKey(byte[] key)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Sets the IV property (<see langword="Aes.IV"/>) to supplied byte array if byte array is a valid IV, otherwise does nothing
    /// </summary>
    public void SetIV(byte[] iv)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Sets the FeedbackSize property (<see langword="Aes.FeedbackSize"/>) to default feedback size.
    /// </summary>
    public void SetFeedbackSize() => _aes.FeedbackSize = _aes.BlockSize;

    /// <summary>
    /// Sets the FeedbackSize property (<see langword="Aes.FeedbackSize"/>) to supplied number if number is a valid feedback size, otherwise does nothing. Feedback size cannot be bigger than block size
    /// </summary>
    public void SetFeedbackSize(int size)
    {
        if (size <= 0)
            throw new ArgumentOutOfRangeException(nameof(size), "Feedback size cannot be zero or a negative integer");
        if (size > BlockSize)
            throw new ArgumentOutOfRangeException(nameof(size), "Feedback size cannot be greater than block size");
        _aes.FeedbackSize = size;
            
    }
    #endregion

    #region Public Cryptographic Operation Methods
    /// <summary>
    /// Trys to encrypt the content of byte array according to current <see langword="Mode"/> and <see langword="Padding"/> properties. This method does not throw exceptions
    /// </summary>
    /// <param name="content">The content to be encrypted, plain text</param>
    /// <param name="encryptedContent">Resulting encrypted content, ciphertext</param>
    /// <returns>Returns false if any exception is thrown, otherwise returns <see langword="true"/></returns>
    public bool TryEncrypt(byte[] content, out byte[] encryptedContent)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Trys to decrypt the content of byte array according to current <see langword="Mode"/> and <see langword="Padding"/> properties. This method does not throw exceptions
    /// </summary>
    /// <param name="content">The content to be decrypted, ciphertext</param>
    /// <param name="decryptedContent">Resulting decrypted content, plain text</param>
    /// <returns>Returns false if any exception is thrown, otherwise returns <see langword="true"/></returns>
    public bool TryDecrypt(byte[] content, out byte[] decryptedContent)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Encrypts the content of byte array according to current <see langword="Mode"/> and <see langword="Padding"/> properties
    /// </summary>
    /// <param name="content">The content to be encrypted, plain text</param>
    /// <returns>Returns the encrypted content (ciphertext) if successful</returns>
    public byte[] Encrypt(byte[] content)
    {
        if (content is null)
            throw new ArgumentNullException(nameof(content), "Supplied content byte array cannot be null");
        if (content?.Length < 0)
            throw new ArgumentOutOfRangeException(nameof(content), "Supplied content byte array cannot be empty");

        ICryptoTransform transform =  _aes.CreateEncryptor();
        return PerformCryptography(content, transform);
    }

    /// <summary>
    /// Decrypts the content of byte array according to current <see langword="Mode"/> and <see langword="Padding"/> properties
    /// </summary>
    /// <param name="content">The content to be decrypted, ciphertext</param>
    /// <returns>Returns the decrypted content (plain text) if successful</returns>
    public byte[] Decrypt(byte[] content)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Opens and reads a file into byte array, encrypts the byte array according to current <see langword="Mode"/> and <see langword="Padding"/> properties, and saves encrypted contents to a new file.
    /// </summary>
    /// <param name="filePath">Path to file to be encrypted, plain text file</param>
    /// <returns>Returns a <see langword="string"/> containing path to encrypted file</returns>
    public string EncryptFile(string filePath)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Opens and reads a file into byte array, decrypts the byte array according to current <see langword="Mode"/> and <see langword="Padding"/> properties, and saves decrypted contents to a new file.
    /// </summary>
    /// <param name="filePath">Path to encrypted (ciphertext) file</param>
    /// <returns>Returns a <see langword="string"/> containing path to decrypted file</returns>
    public string DecryptFile(string filePath)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Public Cryptographic Support Methods
    /// <summary>
    /// Checks if supplied byte array is a valid key for use in AES cryptographic operation
    /// </summary>
    /// <param name="key">Byte array to be checked</param>
    /// <returns>Returns <see langword="true"/> if key is valid, otherwise returns false</returns>
    public static bool IsKeyValid(byte[] key) => key?.Length is 16 or 24 or 32;

    /// <summary>
    /// Checks if supplied byte array is a valid initalization vector for use in AES cryptographic operation
    /// </summary>
    /// <param name="iv">Byte array to be checked</param>
    /// <returns>Returns <see langword="true"/> if IV is valid, otherwise returns false</returns>
    public static bool IsInitVectorValid(byte[] iv) => iv?.Length is 16;
    #endregion
    
    #region Private Cryptographic Support Methods
    /// <summary>
    /// Used to encrypt/decrypt bytes of data. 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="transform"></param>
    /// <returns></returns>
    private static byte[] PerformCryptography(byte[] data, ICryptoTransform transform)
    {
        using MemoryStream ms = new();
        using CryptoStream cs = new(ms, transform, CryptoStreamMode.Write);
        cs.Write(data, 0, data.Length);
        cs.FlushFinalBlock();
        return ms.ToArray();
    }
    #endregion
}