using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ReadOnlyVector
{
    public class ReadOnlyVector
    {
        public readonly double X;
        public readonly double Y;
            
        public ReadOnlyVector(double x, double y)
        {
            X = x;
            Y = y;
        }

        public ReadOnlyVector Add(ReadOnlyVector other)
        {
            return new ReadOnlyVector(other.X + X, other.Y + Y);
        }

        public ReadOnlyVector WithX(double x)
        {
            return new ReadOnlyVector(x, Y);
        }
        public ReadOnlyVector WithY(double y)
        {
            return new ReadOnlyVector(X, y);
        }
    }
}
