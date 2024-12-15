using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace hashes
{
	public class ReadonlyBytes : IEnumerable<byte>
	{
		readonly byte[] bytes;

		public ReadonlyBytes(params byte[] items)
		{
			if (items == null) throw new ArgumentNullException();
            bytes = items;
		}

		public int Length => bytes.Length;

		public byte this[int index] => bytes[index];

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(ReadonlyBytes)) return false;
            var item = (ReadonlyBytes)obj;
            IEnumerator<byte> our = GetEnumerator();
            IEnumerator<byte> their = item.GetEnumerator();
            bool inRange = our.MoveNext();
            while (inRange == their.MoveNext())
            {
                if (!inRange) return true;
                if (our.Current != their.Current) return false;
                inRange = our.MoveNext();
            }
            return false;
        }

        public override int GetHashCode()
        {
            int offset_basis = 1469598333;
            int FNV_prime = 1099511623;
            int hash = offset_basis;
            int p = 1;
            for (int i = 0; i < Length - 1; i += p)
            {
                unchecked
                {
                    hash ^= bytes[i];
                    hash *= FNV_prime;
                }
                p = i / 100 + 1;
            }
            if (Length > 0)
                unchecked
                {
                    hash ^= bytes[Length - 1];
                    hash *= FNV_prime;
                }
            return hash;
        }

        public override string ToString()
        {
            var sb = new StringBuilder("[");
            if (bytes.Length != 0) sb.Append(bytes[0]);
            for (int i = 1; i < bytes.Length; i++)
                sb.Append(string.Format(", {0}", bytes[i]));
            sb.Append(']');
            return sb.ToString();
        }

        public IEnumerator<byte> GetEnumerator() =>
            ((IEnumerable<byte>)bytes).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}