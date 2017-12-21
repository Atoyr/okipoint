using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Core.Utility
{
    public static class ElectronicSignature
    {
        ///// <summary>
        ///// デジタル署名を作成する
        ///// </summary>
        ///// <param name="message">署名を付けるメッセージ</param>
        ///// <param name="privateKey">署名に使用する秘密鍵</param>
        ///// <returns>作成された署名</returns>
        //public static string CreateDigitalSignature(
        //    string message, string privateKey)
        //{
        //    byte[] msgData = Encoding.UTF8.GetBytes(message);
        //    System.Security.Cryptography.SHA256 sha =
        //        new System.Security.Cryptography.SHA256Managed();
        //    byte[] hashData = sha.ComputeHash(msgData);

        //    //RSACryptoServiceProviderオブジェクトの作成
        //    System.Security.Cryptography.RSACryptoServiceProvider rsa =
        //        new System.Security.Cryptography.RSACryptoServiceProvider();
        //    //秘密鍵を使って初期化
        //    rsa.FromXmlString(privateKey);

        //    //RSAPKCS1SignatureFormatterオブジェクトを作成
        //    System.Security.Cryptography.RSAPKCS1SignatureFormatter rsaFormatter =
        //        new System.Security.Cryptography.RSAPKCS1SignatureFormatter(rsa);
        //    //署名の作成に使用するハッシュアルゴリズムを指定
        //    rsaFormatter.SetHashAlgorithm("SHA1");

        //    //署名を作成
        //    byte[] signedValue = rsaFormatter.CreateSignature(hashData);

        //    //バイト型配列を文字列に変換して返す
        //    return System.Convert.ToBase64String(signedValue);
        //}

        ///// <summary>
        ///// デジタル署名を検証する
        ///// </summary>
        ///// <param name="message">署名の付いたメッセージ</param>
        ///// <param name="signature">署名</param>
        ///// <param name="publicKey">送信者の公開鍵</param>
        ///// <returns>認証に成功した時はTrue。失敗した時はFalse。</returns>
        //public static bool VerifyDigitalSignature(
        //    string message, string signature, string publicKey)
        //{
        //    //メッセージをバイト型配列にして、SHA1ハッシュ値を計算
        //    byte[] msgData = System.Text.Encoding.UTF8.GetBytes(message);
        //    System.Security.Cryptography.SHA1Managed sha =
        //        new System.Security.Cryptography.SHA1Managed();
        //    byte[] hashData = sha.ComputeHash(msgData);

        //    //RSACryptoServiceProviderオブジェクトの作成
        //    System.Security.Cryptography.RSACryptoServiceProvider rsa =
        //        new System.Security.Cryptography.RSACryptoServiceProvider();
        //    //公開鍵を使って初期化
        //    rsa.FromXmlString(publicKey);

        //    System.Security.Cryptography.RSAPKCS1SignatureDeformatter rsaDeformatter =
        //        new System.Security.Cryptography.RSAPKCS1SignatureDeformatter(rsa);
        //    //署名の検証に使用するハッシュアルゴリズムを指定
        //    rsaDeformatter.SetHashAlgorithm("SHA1");

        //    //署名を検証し、結果を返す
        //    return rsaDeformatter.VerifySignature(hashData,
        //        System.Convert.FromBase64String(signature));
        //}

        ///// <summary>
        ///// 公開鍵と秘密鍵を作成して返す
        ///// </summary>
        ///// <param name="publicKey">作成された公開鍵(XML形式)</param>
        ///// <param name="privateKey">作成された秘密鍵(XML形式)</param>
        //public static void CreateKeys(out string publicKey, out string privateKey)
        //{
        //    //RSACryptoServiceProviderオブジェクトの作成
        //    System.Security.Cryptography.RSACryptoServiceProvider rsa =
        //        new System.Security.Cryptography.RSACryptoServiceProvider();

        //    //公開鍵をXML形式で取得
        //    publicKey = rsa.ToXmlString(false);
        //    //秘密鍵をXML形式で取得
        //    privateKey = rsa.ToXmlString(true);
        //}
    }
}
