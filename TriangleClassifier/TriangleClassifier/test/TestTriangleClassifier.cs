using System;
using NUnit.Framework;

namespace TriangleClassifier
{
    [NUnit.Framework.TestFixture]
    public class TestClassifier
    {
        [NUnit.Framework.Test]
        public void TestEquilateralDetection()
        {
            //setup
            int l0, l1, l2;
            l0 = l1 = l2 = 5;
            TriangleType expectedType = TriangleType.EQUILATERAL;
            Triangle givenTriangle = new Triangle(l0, l1, l2);
            //execute
            TriangleType actualType = new Classifier().Classify(givenTriangle);
            //assert
            Assert.AreEqual(expectedType, actualType, "A triangle with 3 equal length sides is always equilateral");
        }

        [NUnit.Framework.Test]
        public void TestIsoscelesDetection()
        {
            //setup
            int l0, l1, l2;
            l0 = l1 = 5;
            l2 = 3;
            TriangleType expectedType = TriangleType.ISOSCELES;
            Triangle givenTriangle = new Triangle(l0, l1, l2);
            //execute
            TriangleType actualType = new Classifier().Classify(givenTriangle);
            //assert
            Assert.AreEqual(expectedType, actualType, "A triangle with 2 equal length sides is always isosceles");
        }

        [NUnit.Framework.Test]
        public void TestScaleneDetection()
        {
            //setup
            int l0, l1, l2;
            l0 = 2;
            l1 = 4;
            l2 = 3;
            TriangleType expectedType = TriangleType.SCALENE;
            Triangle givenTriangle = new Triangle(l0, l1, l2);
            //execute
            TriangleType actualType = new Classifier().Classify(givenTriangle);
            //assert
            Assert.AreEqual(expectedType, actualType, "A triangle with no equal length sides is always scalene");
        }

        [NUnit.Framework.Test]
        public void TestValidationTooMuchAngle()
        {
            //setup
            float a0, a1, a2;
            a0 = 91.0f;
            a1 = 45.0f;
            a2 = 45.0f;
            TriangleType expectedType = TriangleType.INVALID;
            Triangle givenTriangle = new Triangle(a0, a1, a2);
            //execute
            TriangleType actualType = new Classifier().Classify(givenTriangle);
            //assert
            Assert.AreEqual(expectedType, actualType, "A triangle cannot have a total of all angles greater than 180 degrees");
        }

        [NUnit.Framework.Test]
        public void TestValidationTooLittleAngle()
        {
            //setup
            float a0, a1, a2;
            a0 = 89.0f;
            a1 = 45.0f;
            a2 = 45.0f;
            TriangleType expectedType = TriangleType.INVALID;
            Triangle givenTriangle = new Triangle(a0, a1, a2);
            //execute
            TriangleType actualType = new Classifier().Classify(givenTriangle);
            //assert
            Assert.AreEqual(expectedType, actualType, "A triangle cannot have a total of all angles less than 180 degrees");
        }

        [NUnit.Framework.Test]
        public void TestValidationZeroLengthSides()
        {
            //setup
            int l0, l1, l2;
            l0 = 0;
            l1 = 5;
            l2 = 3;
            TriangleType expectedType = TriangleType.INVALID;
            Triangle givenTriangle = new Triangle(l0, l1, l2);
            //execute
            TriangleType actualType = new Classifier().Classify(givenTriangle);
            //assert
            Assert.AreEqual(expectedType, actualType, "A triangle cannot have a zero length side");
        }

        [NUnit.Framework.Test]
        public void TestValidationShortSide()
        {
            //setup
            int l0, l1, l2;
            l0 = 9;
            l1 = 5;
            l2 = 3;
            TriangleType expectedType = TriangleType.INVALID;
            Triangle givenTriangle = new Triangle(l0, l1, l2);
            //execute
            TriangleType actualType = new Classifier().Classify(givenTriangle);
            //assert
            Assert.AreEqual(expectedType, actualType, "A triangle's longest side cannot be longer than the sum of the two shorter sides");
        }

        [NUnit.Framework.Test]
        public void TestRightDetection()
        {
            //setup
            float a0, a1, a2;
            a0 = 90.0f;
            a1 = 45.0f;
            a2 = 45.0f;
            TriangleType expectedType = TriangleType.RIGHT;
            Triangle givenTriangle = new Triangle(a0, a1, a2);
            //execute
            TriangleType actualType = new Classifier().Classify(givenTriangle);
            //assert
            Assert.AreEqual(expectedType, actualType, "A triangle with 1 90 degrees angle is always right");
        }

        [NUnit.Framework.Test]
        public void TestObtuseDetection()
        {
            //setup
            float a0, a1, a2;
            a0 = 100.0f;
            a1 = 40.0f;
            a2 = 40.0f;
            TriangleType expectedType = TriangleType.OBTUSE;
            Triangle givenTriangle = new Triangle(a0, a1, a2);
            //execute
            TriangleType actualType = new Classifier().Classify(givenTriangle);
            //assert
            Assert.AreEqual(expectedType, actualType, "A triangle with 1 angle > 90 degrees is always obtuse");
        }

        [NUnit.Framework.Test]
        public void TestAcuteDetection()
        {
            //setup
            float a0, a1, a2;
            a0 = 80.0f;
            a1 = 50.0f;
            a2 = 50.0f;
            TriangleType expectedType = TriangleType.ACUTE;
            Triangle givenTriangle = new Triangle(a0, a1, a2);
            //execute
            TriangleType actualType = new Classifier().Classify(givenTriangle);
            //assert
            Assert.AreEqual(expectedType, actualType, "A triangle with no angle >= 90 degrees is always acute");
        }
    }
}
