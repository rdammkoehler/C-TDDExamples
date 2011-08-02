using System;

namespace TriangleClassifier
{
    public class Classifier
    {
        private const float NINTY = 90.0f;

        public TriangleType Classify(Triangle givenTriangle)
        {
            TriangleType type = TriangleType.INVALID;
            if (givenTriangle != null)
            {
                if (!Validate(givenTriangle))
                {
                    type = TriangleType.INVALID;
                }
                else if (givenTriangle.Length0 != 0
                        && givenTriangle.Length1 != 0
                        && givenTriangle.Length2 != 0)
                {
                    int l0, l1, l2;
                    l0 = givenTriangle.Length0;
                    l1 = givenTriangle.Length1;
                    l2 = givenTriangle.Length2;
                    if (l0 == l1 && l1 == l2)
                    {
                        type = TriangleType.EQUILATERAL;
                    }
                    else if (l0 == l1 || l0 == l2 || l1 == l2)
                    {
                        type = TriangleType.ISOSCELES;
                    }
                    else
                    {
                        type = TriangleType.SCALENE;
                    }
                }
                else
                {
                    float a0, a1, a2;
                    a0 = givenTriangle.Angle0;
                    a1 = givenTriangle.Angle1;
                    a2 = givenTriangle.Angle2;
                    if (a0 == NINTY || a1 == NINTY || a2 == NINTY)
                    {
                        type = TriangleType.RIGHT;
                    }
                    else if (a0 > NINTY || a1 > NINTY || a2 > NINTY)
                    {
                        type = TriangleType.OBTUSE;
                    }
                    else
                    {
                        type = TriangleType.ACUTE;
                    }
                }
            }
            return type;
        }
        private bool Validate(Triangle givenTriangle)
        {
            bool valid = true;
            float sumOfAngles = givenTriangle.Angle0 + givenTriangle.Angle1 + givenTriangle.Angle2;
            valid &= sumOfAngles == 0.0f || sumOfAngles == 180.0f;
            valid &= (givenTriangle.Length0 != 0 && givenTriangle.Length1 != 0 && givenTriangle.Length2 != 0) ||
                     (givenTriangle.Length0 == 0 && givenTriangle.Length1 == 0 && givenTriangle.Length2 == 0);
            valid &= FindLengthOfLongestSide(givenTriangle) < FindSumOfShortestSides(givenTriangle) ||
                     (givenTriangle.Length0 == 0 && givenTriangle.Length1 == 0 && givenTriangle.Length2 == 0);
            return valid;
        }

        private int FindLengthOfLongestSide(Triangle givenTriangle)
        {
            int longest = -1;
            int[] sides = { givenTriangle.Length0, givenTriangle.Length1, givenTriangle.Length2, };
            for (int idx = 0; idx < sides.Length; idx++)
            {
                if (longest < sides[idx]) longest = sides[idx];
            }
            return longest;
        }

        private int FindSumOfShortestSides(Triangle givenTriangle)
        {
            int sum = 0;
            int longest = FindLengthOfLongestSide(givenTriangle);
            int[] sides = { givenTriangle.Length0, givenTriangle.Length1, givenTriangle.Length2, };
            for (int idx = 0; idx < sides.Length; sum += sides[idx++]) ;
            sum -= longest;
            return sum;
        }

    }
}
