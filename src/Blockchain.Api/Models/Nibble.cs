using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.Api.Models
{
    public class Nibble
    {
        private int value;
        public int Value
        {
            get => value;
            set
            {
                if(value >= 0 && value < 16)
                {
                    this.value = value;
                }
                else
                {
                    this.value = 0;
                }
            }
        }

        public Nibble()
        {
            Value = 0;
        }

        public Nibble(int value)
        {
            Value = value;
        }

        public Nibble(byte b ,bool isFront)
        {
            SetValue(b, isFront);
        }

        public void SetValue(byte b,bool isFront)
        {
            Value = 0;
            var bitArray = new BitArray(new byte[] { b });
            Value = isFront
                ? ConvertNibbleValue(bitArray[0], bitArray[1], bitArray[2], bitArray[3])
                : ConvertNibbleValue(bitArray[4], bitArray[5], bitArray[6], bitArray[7]);
        }

        public static List<Nibble> GetList(byte[] bytes)
        {
            var list = new List<Nibble>(bytes.Length * 2);
            foreach(byte b in bytes)
            {
                list.Add(new Nibble(b, true));
                list.Add(new Nibble(b, false));
            }
            return list;
        }

        public static byte[] ConvertNibblesToBytes(params Nibble[] nibbles)
        {
            if(nibbles.Length % 2 != 0) return new byte[0];
            var bytes = new List<byte>(nibbles.Length / 2);

            for(int i = 0;i < nibbles.Length; i = i + 2)
            {
                int value = nibbles[i].Value * 16 + nibbles[i + 1].Value;
                bytes.Add(BitConverter.GetBytes(value)[0]);
            }
            return bytes.ToArray();
        }


        private int ConvertNibbleValue(bool b0, bool b1, bool b2, bool b3)
        { 
            int temp = 0;
            if (b0) temp += 8;
            if (b1) temp += 4;
            if (b2) temp += 2;
            if (b3) temp += 1;
            return temp;
        }
    }
}
