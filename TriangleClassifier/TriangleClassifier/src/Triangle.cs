using System;

namespace TriangleClassifier
{
    public class Triangle
    {
        public int Length0 { get; set; }
        public int Length1 { get; set; }
        public int Length2 { get; set; }
        public float Angle0 { get; set; }
        public float Angle1 { get; set; }
        public float Angle2 { get; set; }

        public Triangle(int l0, int l1, int l2)
        {
            Length0 = l0;
            Length1 = l1;
            Length2 = l2;
        }

        public Triangle(float a0, float a1, float a2)
        {
            Angle0 = a0;
            Angle1 = a1;
            Angle2 = a2;
        }

    }
}
