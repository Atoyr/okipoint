using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Model
{
    public class Block
    {
        /// <summary>
        /// Blockのインデックス
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// ブロック生成日時
        /// </summary>
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// トランザクションデータ
        /// </summary>
        public List<Transaction> Transactions { get; set; }
        /// <summary>
        /// 前ブロック ハッシュ値
        /// </summary>
        public byte[] PreviousHash { get; set; }
        /// <summary>
        /// ナンス
        /// </summary>
        public int Nonce { get; }
        /// <summary>
        /// 計算難易度
        /// 計算したHash値の前{Difficult}桁が0になるよう計算する
        /// </summary>
        public int Difficult { set; get; }
        //public int Proof { get; set; }
        //public byte[] Hash
        //{
        //    get
        //    {
        //        var sha256 = new SHA256Managed();
        //        var bytes = new List<byte>();
        //        bytes.AddRange(PreviousHash);
        //        //bytes.AddRange(BitConverter.GetBytes(Timestamp.ToUniversalTime().ToBinary()));
        //        foreach (Transaction t in Transactions)
        //        {
        //            bytes.AddRange(t.ToBytes());
        //        }
        //        return sha256.ComputeHash(bytes.ToArray());
        //    }
        //}

        public override string ToString()
        {
            return string.Empty;
            //return $"{Index} [{Timestamp.ToString("yyyy-MM-dd HH:mm:ss")}] Proof: {Proof} | Hash: {System.Text.Encoding.ASCII.GetString(Hash)} | PrevHash: {System.Text.Encoding.ASCII.GetString(PreviousHash)} | Trx: {Transactions.Count}";
        }
    }
}
