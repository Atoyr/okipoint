﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Core.Models
{
    public class Block
    {
        public Block(IList<Transaction> txs) => Transactions = new ReadOnlyCollection<Transaction>(txs);

        /// <summary>
        /// This Block Version
        /// </summary>
        public int Version { get; private set; }

        /// <summary>
        /// Blockのインデックス
        /// </summary>
        public long Index { get; set; }
        /// <summary>
        /// ブロック生成日時
        /// </summary>
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// トランザクションデータ
        /// </summary>
        public ReadOnlyCollection<Transaction> Transactions { get; private set; }
        /// <summary>
        /// 前ブロック ハッシュ値
        /// </summary>
        public string PreviousHash { get; set; }
        /// <summary>
        /// ナンス
        /// </summary>
        public int Nonce { get; }
        /// <summary>
        /// 計算難易度
        /// 計算したHash値の前{Difficult}桁が0になるよう計算する
        /// </summary>
        public int Difficult { set; get; }

        public override string ToString()
        {
            return $"{Index} [{Timestamp.ToString("yyyy-MM-dd HH:mm:ss")}] Difficult: {Difficult} | PrevHash: {PreviousHash} | Trx: {Transactions.Count}";
        }

        //public static Block Deserialize(string blockJson)
        //{

        //}
    }
}
