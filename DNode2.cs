using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace trialgame
{
    public class DNode2 : IComparable<DNode2>
    {
        public readonly Vector2 Coords;

        public double Weight { get; set; }

        public DNode2(Vector2 coord)
        {
            Coords = coord;
            Weight = 9999;
        }

        public DNode2(float x, float y)
            : base()
        {
            Coords = new Vector2(x, y);
        }

        public double CalculateWeight(DNode2 n)
        {
            return Vector2.Distance(this.Coords, n.Coords);
        }

        public int CompareTo(DNode2 other)
        {
            if (other.Weight < this.Weight)
            {
                return 1;
            }
            if (other.Weight > this.Weight)
            {
                return -1;
            }
            return 0;
        }
    }
}
