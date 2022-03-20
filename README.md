# crypton
Cryptography in .NET made easy!

crypton aims to be the one-and-only solution to do cryptography in .NET by providing wrappers for latest and suggested algorithms made available by the .NET SDK.

In its current state, .NET has more than one way to do AES operations. All of them but one () are deprecated, and needs to be removed, manually, by you. This issue can get bigger and bigger with the scale of your application. At this exact point, crypton steps in!

crypton provides simple methods and classes to do the operations you need, without impacting the performance.

## what's so special about crypton?

Even though crypton is *a wrapper*, it still provides more than the SDK has to offer. For example there are three ways to encrypt data using AES class that you can **discover by a web search**. With crypton all you need is a few clicks in your favorite IDE.

## development

I started developing cryptographic helper libraries back in 2019, when I was in high school. Currently crypton is one of my side projects that I follow professional guidelines whilst developing.

### milestones

- [x] Key Generation: Implementation of PBKDF2 that wraps [Rfc2898DeriveBytes](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Cryptography.Rfc2898DeriveBytes)
- [x] Hash Functions: Implementations of common hash functions: MD5, SHA-1 and SHA-2
- [ ] AES: Full implementation of AES with 128/256 bit key and all padding/cipher mode options
