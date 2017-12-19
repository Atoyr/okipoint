using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Blockchain.Api.Models
{
    public class Coin : IEquatable<Coin>
    {
        private readonly decimal _value;

        public decimal Value { get; private set; }

        public bool Equals(Coin other)
        {
            throw new NotImplementedException();
        }
    }
}
