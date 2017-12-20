using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Blockchain.Api.Models
{
    public class Coin : IEquatable<Coin>
    {
        private readonly decimal _value;

        private Coin(decimal value) => _value = value;

        public decimal Value { get => _value;}

        public static Coin Zero => new Coin(0);
        public static Coin operator +(Coin x, Coin y) => new Coin(x.Value + y.Value);
        public static Coin operator -(Coin x, Coin y) => new Coin(x.Value - y.Value);
        public static Coin operator *(Coin x, Coin y) => new Coin(x.Value * y.Value);
        public static Coin operator /(Coin x, Coin y) => new Coin(x.Value / y.Value);

        public bool Equals(Coin other) => this._value == other._value;
        public override bool Equals(object other) => (other is Coin coin) ? this._value == coin._value : false;
        public override int GetHashCode() => _value.GetHashCode();
        public override string ToString() => _value.ToString();
    }
}
