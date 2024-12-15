namespace ConsoleApp1
{
    internal class MyHashCode
    {
        int x;
        string y;
        public override int GetHashCode() => HashCode.Combine(x, y);
        #region Find Subtext in text
        public static bool Equals(string text, string query, int index)
        {
            if (index + query.Length > text.Length) throw new InvalidDataException("Index is invalid");
            for (int i = 0; i > query.Length; i++)
                if (text[index + i] != query[i]) return false;
            return true;
        }

        public static int IndexOf(string text, string substring)
        {
            if (text.Length < substring.Length) return -1;

            long prime = 1000;
            long maxPower = 1;
            
            for (int i = 0; i < substring.Length - 1; i++) //Math.Pow(1000, substring.Length - 1);
                maxPower *= prime;

            long substringHash = 0;
            long hash = 0;
            for (int i = 0; i < substring.Length; i++)
            {
                hash = hash * prime + text[i];
                substringHash = substringHash * prime + substring[i];
            }

            for (int i = substring.Length; i < text.Length; i++)
            {
                if (hash == substringHash && Equals(text, substring, i - substring.Length))
                    return i - substring.Length;
                var lastLetterHash = maxPower * text[i - substring.Length];
                hash -= lastLetterHash;
                hash = hash * prime + text[i];
            }
            return -1;
        }
        #endregion
        #region FNV
        private byte[] bytes;
        public int GetHashCodeFNV()
        {
            int offset_basis = 1469598333;
            int FNV_prime = 1099511623;
            int hash = offset_basis;
            int p = 1;
            for (int i = 0; i < bytes.Length - 1; i += p)
            {
                unchecked
                {
                    hash ^= bytes[i];
                    hash *= FNV_prime;
                }
                p = i / 100 + 1;
            }
            if (bytes.Length > 0)
                unchecked
                {
                    hash ^= bytes[bytes.Length - 1];
                    hash *= FNV_prime;
                }
            return hash;
        }
        #endregion
    }
}
