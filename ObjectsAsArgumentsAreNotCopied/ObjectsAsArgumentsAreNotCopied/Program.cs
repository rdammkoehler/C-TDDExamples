using System;

/* *************************************************
 * The following code shows that passing an object with
 * or without 'ref' does NOT change your ability to mainipulate
 * the object passed, 'ref' actually allows you to
 * change the calling scope's value of the reference; 
 * in otherwords, change which instance it references.
 * 
 * Furthermore, this example code, by way of the GetHashCode
 * method endevors to illustrate that the object is
 * NOT copied when passed in the absense of the 'ref'
 * keyword.
 * 
 * Note that when using integral types (int, long, etc.)
 * this the 'ref' keyword has the same net effect, but by
 * not using the 'ref' keyword the integral type is reallocated
 * on the stack for the duration of the call.
 * 
 * Also note, in documentation where you see that the arguments
 * are 'copied' remember that a Reference Type is copied
 * by duplicating the Reference, not the the object it
 * referes too; so you're not copying the object, your copying
 * the reference to it. This is congruent with the default
 * 'pass by value' semantics of the C# language.
 * 
 * See Also:
 * Microsoft Visual C#.NET Step By Step, ISBN: 0-7356-189-7
 * http://www.yoda.arachsys.com/csharp/parameters.html
 * http://msdn.microsoft.com/en-us/library/14akc2c7.aspx (see first 'Note' and the later example)
 * http://msdn.microsoft.com/en-us/library/s6938f28.aspx
 * http://stackoverflow.com/questions/436986/c-pass-by-value-ref/437029#437029
 * 
 * 
 * Assumption: If C# actually copied an object when
 * passing it into a method (which it does not) it
 * would get a new base hash value.
 ************************************************ */
namespace ObjectsAsArgumentsAreNotCopied
{
    class Program
    {
        static void Main(string[] args)
        {
            new Part0().Main(); Console.WriteLine();
            new Part1().Main(); Console.WriteLine();
            new Part2().Main(); Console.WriteLine();
            new Part3().Main(); Console.WriteLine();
            new Part4().Main(); Console.WriteLine();
            new Part5().Main(); Console.WriteLine();
            new Part6().Main();

            Console.In.ReadLine();
        }
    }

    class Part0
    {
        public void Main()
        {
            Y y0 = new Y();
            Console.WriteLine("y0: " + y0.ToString());
            Y y1 = new Y();
            Console.WriteLine("y1: " + y1.ToString());
            Console.WriteLine("y0 == y1? " + y0.Equals(y1));
            Console.WriteLine("y0 same as y1? " + (y0 == y1));
            Y y2 = y0;
            Console.WriteLine("y2: " + y2.ToString());
            Console.WriteLine("y0 == y2? " + y0.Equals(y2));
            Console.WriteLine("y0 same as y2? " + (y0 == y2));
        }
    }

    class Part1
    {
        public void Main()
        {
            Console.WriteLine("Part 1: All instances of Y are the same without 'ref'");
            Y myY = new Y();
            X anX = new X();

            Console.WriteLine("Main Starts with: " + myY.ToString());
            anX.Foo(myY);
            Console.WriteLine("  Main Ends with: " + myY.ToString());

        }
    }

    class Part2
    {
        public void Main()
        {

            Console.WriteLine("Part 2: All instances of Y are the same with 'ref'");
            Y myY = new Y();
            X2 anX = new X2();

            Console.WriteLine("Main Starts with: " + myY.ToString());
            anX.Foo(ref myY);
            Console.WriteLine("  Main Ends with: " + myY.ToString());
        }
    }

    class Part3
    {
        public void Main()
        {
            Console.WriteLine("Part 3: All instances of Y are the same without 'ref', and changes are seen in both places");
            Y myY = new Y();
            X3 anX = new X3();

            Console.WriteLine("Main Starts with: " + myY.ToString());
            anX.Foo(myY);
            Console.WriteLine("  Main Ends with: " + myY.ToString());
        }
    }

    class Part4
    {
        public void Main()
        {

            Console.WriteLine("Part 4: All instances of Y are the same with 'ref', and changes are seen in both places");
            Y myY = new Y();
            X4 anX = new X4();

            Console.WriteLine("Main Starts with: " + myY.ToString());
            anX.Foo(ref myY);
            Console.WriteLine("  Main Ends with: " + myY.ToString());
        }
    }

    class Part5
    {

        public void Main()
        {
            Console.WriteLine("Part 5: Main's local Y is the same instance as anX.Foo()'s argument Y, changing anX.Foo()'s reference Y has no effect on Main");
            Y myY = new Y();
            X5 anX = new X5();

            Console.WriteLine("Main Starts with: " + myY.ToString());
            anX.Foo(myY);
            Console.WriteLine("  Main Ends with: " + myY.ToString());
        }
    }

    class Part6
    {
        public void Main()
        {
            Console.WriteLine("Part 6: Main's local Y is the same instance as anX.Foo()'s argument Y, changing anX.Foo()'s reference Y changes Main's Y");
            Y myY = new Y();
            X6 anX = new X6();

            Console.WriteLine("Main Starts with: " + myY.ToString());
            anX.Foo(ref myY);
            Console.WriteLine("  Main Ends with: " + myY.ToString());
        }
    }

    class X
    {
        public void Foo(Y y)
        {
            Console.WriteLine("      X received: " + y.ToString());
        }
    }

    class X2
    {
        public void Foo(ref Y y)
        {
            Console.WriteLine("      X received: " + y.ToString());
        }
    }

    class X3
    {
        public void Foo(Y y)
        {
            Console.WriteLine("      X received: " + y.ToString());
            y.Change();
            Console.WriteLine("  X changed Y to: " + y.ToString());
        }
    }

    class X4
    {
        public void Foo(ref Y y)
        {
            Console.WriteLine("      X received: " + y.ToString());
            y.Change();
            Console.WriteLine("  X changed Y to: " + y.ToString());
        }
    }

    class X5
    {
        public void Foo(Y y)
        {
            Console.WriteLine("      X received: " + y.ToString());
            y = new Y();
            Console.WriteLine("  X changed Y to: " + y.ToString());
        }
    }

    class X6
    {
        public void Foo(ref Y y)
        {
            Console.WriteLine("      X received: " + y.ToString());
            y = new Y();
            Console.WriteLine("  X changed Y to: " + y);
        }
    }

    class Y
    {
        static int instanceCt = 0;
        int instanceId = ++instanceCt;
        bool changed = false;

        public override int GetHashCode()
        {
            return instanceId;
        }

        public override bool Equals(object obj)
        {
            return this == obj;
        }

        public override string ToString()
        {
            String rval = null;
            if (changed)
            {
                rval = "Y[hashCode:" + this.GetHashCode() + "{" + base.GetHashCode() + "}]<was changed>";
            }
            else
            {
                rval = "Y[hashCode:" + this.GetHashCode() + "{" + base.GetHashCode() + "}]";
            }
            return rval;
        }

        public void Change()
        {
            changed = true;
        }
    }
}
