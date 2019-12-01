# NETCore.Encrypt [中文文档](http://www.cnblogs.com/piscesLoveCc/p/7423205.html)
[![NuGet](https://img.shields.io/nuget/v/NETCore.Encrypt.svg)](https://nuget.org/packages/NETCore.Encrypt)
[![NETCore CLR](https://img.shields.io/badge/.NETCore%20Clr-2.0-brightgreen.svg)](https://www.microsoft.com/net/core)
[![NetStandard 2.0.3](https://img.shields.io/badge/NetStandard-2.0.3-orange.svg)](https://www.microsoft.com/net/core)
[![license](https://img.shields.io/github/license/myloveCc/NETCore.Encrypt.svg)](https://github.com/myloveCc/NETCore.Encrypt/blob/master/License)

NETCore encrypt and decrpty tool，Include AES，RSA，MD5，SAH1，SAH256，SHA384，SHA512 and more

To install NETCore.Encrypt, run the following command in the [Package Manager Console](https://docs.microsoft.com/zh-cn/nuget/tools/package-manager-console)
```
Install-Package NETCore.Encrypt -Version 2.0.7
```

***

# Easy to use with `EncryptProvider`

## AES

#### Create AES Key

  ```csharp
  var aesKey = EncryptProvider.CreateAesKey();
  
  var key = aesKey.Key;
  var iv = aesKey.IV;
  ```

#### AES encrypt
  - AES encrypt without iv

    ```csharp
    var srcString = "aes encrypt";
    var encrypted = EncryptProvider.AESEncrypt(srcString, key);

    ```
  - AES encrypt with iv

    ```csharp
    var srcString = "aes encrypt";
    var encrypted = EncryptProvider.AESEncrypt(srcString, key, iv);

    ```
  - AES encrypt bytes at version 2.0.6

    ```csharp
    var srcBytes = new byte[]{xxx};
    var encryptedBytes = EncryptProvider.AESEncrypt(srcBytes, key, iv);

    ```
#### ASE decrypt

  - AES decrypt without iv
    
    ```csharp
    var encryptedStr = "xxxx";
    var decrypted = EncryptProvider.AESDecrypt(encryptedStr, key);
    ```
  
  - AES decrypt with iv
   
    ```csharp
    var encryptedStr = "xxxx";
    var decrypted = EncryptProvider.AESDecrypt(encryptedStr, key, iv);
    ```

  - AES decrypt bytes at version 2.0.6
   
    ```csharp
    var encryptedBytes =  new byte[]{xxx};
    var decryptedBytes = EncryptProvider.AESDecrypt(encryptedBytes, key, iv);
    ```

## DES (version 2.0.2)

- #### Create DES Key

  ```csharp
  
  //des key length is 24 bit
  var desKey = EncryptProvider.CreateDesKey();
  
  ```

- #### DES encrypt

    ```csharp
    var srcString = "des encrypt";
    var encrypted = EncryptProvider.DESEncrypt(srcString, key);
    ```
- #### DES encrypt bytes at version 2.0.6
   
    ```csharp
    var srcBytes =  new byte[]{xxx};
    var decryptedBytes = EncryptProvider.DESEncrypt(srcBytes, key);
    ```
- #### DES decrypt

    ```csharp
    var encryptedStr = "xxxx";
    var decrypted = EncryptProvider.DESDecrypt(encryptedStr, key);
    ```

- #### DES decrypt bytes at version 2.0.6
   
    ```csharp
    var encryptedBytes =  new byte[]{xxx};
    var decryptedBytes = EncryptProvider.DESDecrypt(encryptedBytes, key);
    ```

## RSA

  - #### Enum RsaSize

    ```csharp
     public enum RsaSize
    {
        R2048=2048,
        R3072=3072,
        R4096=4096
    }
    ```
  
  - #### Create RSA Key with RsaSize(update at version 2.0.1)

    ```csharp
    var rsaKey = EncryptProvider.CreateRsaKey();    //default is 2048

	// var rsaKey = EncryptProvider.CreateRsaKey(RsaSize.R3072);

    var publicKey = rsaKey.PublicKey;
    var privateKey = rsaKey.PrivateKey;
    var exponent = rsaKey.Exponent;
    var modulus = rsaKey.Modulus;
    ```
  - #### RSA encrypt
  
    ```csharp
    var publicKey = rsaKey.PublicKey;
    var srcString = "rsa encrypt";

    
    var encrypted = EncryptProvider.RSAEncrypt(publicKey, srcString);

    // On mac/linux at version 2.0.5
    var encrypted = EncryptProvider.RSAEncrypt(publicKey, srcString, RSAEncryptionPadding.Pkcs1);
    ```
  
  - #### RSA decrypt

    ```csharp
    var privateKey = rsaKey.PrivateKey;
    var encryptedStr = "xxxx";

    var decrypted = EncryptProvider.RSADecrypt(privateKey, encryptedStr);

    // On mac/linux at version 2.0.5
    var decrypted = EncryptProvider.RSADecrypt(privateKey, encryptedStr, RSAEncryptionPadding.Pkcs1);
    ```

  - #### RSA from string (add at version 2.0.1)

    ```csharp
    var privateKey = rsaKey.PrivateKey;
    RSA rsa = EncryptProvider.RSAFromString(privateKey);
    ```
  
  ## MD5
  
  ```csharp
  
  var srcString = "Md5 hash";
  var hashed = EncryptProvider.Md5(srcString);
  
  ```
  
  ```csharp
  
  var srcString = "Md5 hash";
  var hashed = EncryptProvider.Md5(srcString, MD5Length.L16);
  
  ```
  
  ## SHA
  
  - #### SHA1
    ```csharp
    var srcString = "sha hash";    
    var hashed = EncryptProvider.Sha1(srcString); 
    ```
  - #### SHA256
    ```csharp  
    var srcString = "sha hash";    
    var hashed = EncryptProvider.Sha256(srcString); 
    ```  
  - #### SHA384
    ```csharp  
    var srcString = "sha hash";    
    var hashed = EncryptProvider.Sha384(srcString); 
    ```
  - #### SHA512
    ```csharp
    var srcString = "sha hash";    
    var hashed = EncryptProvider.Sha512(srcString);
    ```
  
  ## HMAC
  
  - #### HMAC-MD5
    ```csharp
    var key="xxx";
    var srcString = "hmac md5 hash";     
    var hashed = EncryptProvider.HMACMD5(srcString,key);
    ```
  - #### HMAC-SHA1
    ```csharp
    var key="xxx";
    var srcString = "hmac sha hash";    
    var hashed = EncryptProvider.HMACSHA1(srcString,key);
    ```
  - #### HMAC-SHA256
    ```csharp
    var key="xxx";
    var srcString = "hmac sha hash";    
    var hashed = EncryptProvider.HMACSHA256(srcString,key);
    ```
  - #### HMAC-SHA384
    ```csharp
    var key="xxx";
    var srcString = "hmac sha hash";    
    var hashed = EncryptProvider.HMACSHA384(srcString,key);
    ```
  - #### HMAC-SHA512
    ```csharp
    var key="xxx";
    var srcString = "hmac sha hash";    
    var hashed = EncryptProvider.HMACSHA512(srcString，key);
    ```

  ## Base64 
  
  - #### Base64Encrypt
    ```csharp
    var srcString = "base64 string";    
    var hashed = EncryptProvider.Base64Encrypt(srcString);   //default encoding is UTF-8
    ```
	```csharp
    var srcString = "base64 string";    
    var hashed = EncryptProvider.Base64Encrypt(srcString,Encoding.ASCII);  
    ```
  - #### Base64Decrypt
    ```csharp  
    var encryptedStr = "xxxxx";    
    var strValue = EncryptProvider.Base64Decrypt(encryptedStr);   //default encoding is UTF-8
    ```  
	```csharp  
    var encryptedStr = "xxxxx";    
    var strValue = EncryptProvider.Base64Decrypt(encryptedStr,Encoding.ASCII); 
    ```  
***
# Easy to use hash with `EncryptExtensions`

## MD5 Extensions

   - ### String to MD5

   ```csharp
   var hashed="some string".MD5();
   ```
## SHA Extensions

   - ### String to SHA1

   ```csharp
   var hashed="some string".SHA1();
   ```
   
 ### `Tips：SHA256,SHA384,SHA512 the same usage like SHA1 `
 
 ## HMACSHA Extensions

   - ### String to HMACSHA1

   ```csharp
   var key="xxx";
   var hashed="some string".HMACSHA1(key);
   ```
   
 ### `Tips：HMACSHA256,HMACSHA384,HMACSHA512 the same usage like HMACSHA1 `


# LICENSE

[MIT License](https://github.com/myloveCc/NETCore.Encrypt/blob/master/License)
