using System;

namespace TriangleClassifier
{
    public enum TriangleType
    {
        EQUILATERAL, //3 sides same length
        ISOSCELES,   //2 sides same length
        SCALENE,	 //0 sides same length
        RIGHT,		 //90º triangle
        OBTUSE,		 //one angle > 90º
        ACUTE, 		 //All 3 angles < 90º
        INVALID,	 //something is invalid in the triangle
    };
}
