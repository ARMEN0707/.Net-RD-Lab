using System;
using System.Collections.Generic;
using NUnit.Framework;


namespace Polynomial.Test
{
    class TestCasesData
    {
        public static IEnumerable<TestCaseData> TestCasesForEquals
        {
            get
            {
                yield return new TestCaseData(
                    new Polynomial(new Monomial(1,1d), new Monomial(2, 2d), new Monomial(3, 3d)),
                    new Polynomial(new Monomial(1, 1d), new Monomial(2, 2d), new Monomial(3, 3d))
                    ).Returns(true);
                yield return new TestCaseData(
                    new Polynomial(new Monomial(1, 0.5)),
                    new Polynomial(new Monomial(1, 0.49999999))
                    ).Returns(true);
                yield return new TestCaseData(
                    new Polynomial(new Monomial(1, 0), new Monomial(2, 0.1), new Monomial(3, 0.0001)),
                    new Polynomial(new Monomial(1, 0), new Monomial(2, 0.1), new Monomial(3, 0.00010091))
                    ).Returns(true);
                yield return new TestCaseData(
                    new Polynomial(new Monomial(1, 0), new Monomial(2, 0.1), new Monomial(3, 0.0001)),
                    new Polynomial(new Monomial(1, 0), new Monomial(2, 0.1), new Monomial(3, 0.0001))
                    ).Returns(true);
                yield return new TestCaseData(
                    new Polynomial(new Monomial(1, -10.123), new Monomial(2, 5.89)),
                    new Polynomial(new Monomial(1, -10.1230004), new Monomial(2, 5.89))
                    ).Returns(true);
                yield return new TestCaseData(
                    new Polynomial(new Monomial(1, 1d), new Monomial(2, 2d), new Monomial(3, 3d)),
                    new Polynomial(new Monomial(1, 1.5), new Monomial(2, 2d), new Monomial(3, 3d))
                    ).Returns(false);
                yield return new TestCaseData(
                    new Polynomial(new Monomial(1, -100.123), new Monomial(2, 5.89), new Monomial(3, double.MinValue), new Monomial(4, double.MaxValue)), 
                    new Polynomial(new Monomial(1, -10.123), new Monomial(2, 5.89), new Monomial(3, double.MinValue), new Monomial(4, double.MaxValue))
                    ).Returns(false);
                yield return new TestCaseData(
                    new Polynomial(new Monomial(1, -0.123), new Monomial(2, 0.0), new Monomial(3, -0.0)),
                    new Polynomial(new Monomial(1, -0.123065), new Monomial(2, 0.0), new Monomial(3, -0.0))
                    ).Returns(false);
                yield return new TestCaseData(new Polynomial(new Monomial(1, 1d), new Monomial(2, 2d), new Monomial(3, 3d)), null)
                    .Returns(false);
                yield return new TestCaseData(
                    new Polynomial(new Monomial(1, 1d), new Monomial(4, 2d), new Monomial(6, 3d)),
                    new Polynomial(new Monomial(1, 1d), new Monomial(2, 2d), new Monomial(3, 3d))
                    ).Returns(false);
                yield return new TestCaseData(
                    new Polynomial(new Monomial(1, 1d), new Monomial(4, 2d), new Monomial(6, 3d)),
                    new Polynomial(new Monomial(1, 1d), new Monomial(4, 2d), new Monomial(6, 3d))
                    ).Returns(true);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForMultiplication
        {
            get
            {
                yield return new TestCaseData(
                    new Polynomial(new Monomial(1, 1.21394), new Monomial(2, 2.001), new Monomial(3, 3.3)),
                    new Polynomial(new Monomial(1, 0.1), new Monomial(2, 0.002)),
                    new Polynomial(new Monomial(2, 0.12139), new Monomial(3, 0.20253), new Monomial(4, 0.334), new Monomial(5, 0.0066)));
                yield return new TestCaseData(
                    new Polynomial(new Monomial(1, -1), new Monomial(2, 0.2), new Monomial(3, 3.313), new Monomial(4, 0.004), new Monomial(5, 0.05), new Monomial(6, 0.16)),
                    new Polynomial(new Monomial(1, 1.1), new Monomial(2, -2.2), new Monomial(3, 3.3), new Monomial(4, -4.4)),
                    new Polynomial(new Monomial(2, -1.1), new Monomial(3, 2.42), new Monomial(4, -0.0957), new Monomial(5, -2.2242), new Monomial(6, 10.0991), new Monomial(7, -14.498), new Monomial(8, -0.2046), new Monomial(9, 0.308), new Monomial(10, -0.704)));
                yield return new TestCaseData(
                    new Polynomial(new Monomial(1, -3), new Monomial(2, 0.014), new Monomial(3, 1.004)),
                    new Polynomial(new Monomial(1, 1), new Monomial(2, 0), new Monomial(3, 5)),
                    new Polynomial(new Monomial(2, -3), new Monomial(3, 0.014), new Monomial(4, -13.996), new Monomial(5, 0.07), new Monomial(6, 5.02)));
                yield return new TestCaseData(
                    new Polynomial(new Monomial(1, 1.204), new Monomial(2, -2.569), new Monomial(3, 3.987), new Monomial(4, 4.879), new Monomial(5, -0.896), new Monomial(6, 9)),
                    new Polynomial(new Monomial(1, 1), new Monomial(2, -2), new Monomial(3, -3), new Monomial(4, 4)),
                    new Polynomial(new Monomial(2, 1.204), new Monomial(3, -4.977), new Monomial(4, 5.513), new Monomial(5, 9.428), new Monomial(6, -32.891), new Monomial(7, 12.103), new Monomial(8, 4.204), new Monomial(9, -30.584), new Monomial(10, 36)));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForSubtraction
        {
            get
            {
                yield return new TestCaseData(
                    new Polynomial(new Monomial(1, 0.1), new Monomial(2, 0.002)),
                    new Polynomial(new Monomial(1, 1.21394), new Monomial(2, 2.001), new Monomial(3, 3.3)),
                    new Polynomial(new Monomial(1, -1.11394), new Monomial(2, -1.999), new Monomial(3, -3.3)));
                yield return new TestCaseData(
                    new Polynomial(new Monomial(1, 1.21394), new Monomial(2, 2.001), new Monomial(3, 3.3)),
                    new Polynomial(new Monomial(1, 0.1), new Monomial(2, 0.002)),
                    new Polynomial(new Monomial(1, 1.11394), new Monomial(2, 1.999), new Monomial(3, 3.3)));
                yield return new TestCaseData(
                    new Polynomial(new Monomial(1, -1), new Monomial(2, 0.2), new Monomial(3, 3.313), new Monomial(4, 0.004), new Monomial(5, 0.05), new Monomial(6, 0.16)),
                    new Polynomial(new Monomial(1, 1.1), new Monomial(2, -2.2), new Monomial(3, 3.3), new Monomial(4, -4.4)),
                    new Polynomial(new Monomial(1, -2.1), new Monomial(2, 2.4), new Monomial(3, 0.013), new Monomial(4, 4.404), new Monomial(5, 0.05), new Monomial(6, 0.16)));
                yield return new TestCaseData(
                    new Polynomial(new Monomial(1, -3), new Monomial(2, 0.014), new Monomial(3, 1.004), new Monomial(4, 0)),
                    new Polynomial(new Monomial(1, 1), new Monomial(2, -0.0d), new Monomial(3, 5)),
                    new Polynomial(new Monomial(1, -4), new Monomial(2, 0.014), new Monomial(3, -3.996), new Monomial(4, 0)));
                yield return new TestCaseData(
                    new Polynomial(new Monomial(1, 1.204), new Monomial(2, -2.569), new Monomial(3, 3.987), new Monomial(4, 4.879), new Monomial(5, -0.896), new Monomial(6, 9)),
                    new Polynomial(new Monomial(1, 1), new Monomial(2, -2), new Monomial(3, -3), new Monomial(4, 4)),
                    new Polynomial(new Monomial(1, 0.204), new Monomial(2, -0.569), new Monomial(3, 6.987), new Monomial(4, 0.879), new Monomial(5, -0.896), new Monomial(6, 9)));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForAddition
        {
            get
            {
                yield return new TestCaseData(
                    new Polynomial(new Monomial(1, 1.21394), new Monomial(2, 2.001), new Monomial(3, 3.3)),
                    new Polynomial(new Monomial(1, 0.1), new Monomial(2, 0.002)),
                    new Polynomial(new Monomial(1, 1.31394), new Monomial(2, 2.003), new Monomial(3, 3.3)));
                yield return new TestCaseData(
                    new Polynomial(new Monomial(1, -1), new Monomial(2, 0.2), new Monomial(3, 3.315), new Monomial(4, 0.004), new Monomial(5, 0.05), new Monomial(6, 0.16)),
                    new Polynomial(new Monomial(1, 1.1), new Monomial(2, -2.2), new Monomial(3, 3.3), new Monomial(4, -4.4)),
                    new Polynomial(new Monomial(1, 0.1), new Monomial(2, -2), new Monomial(3, 6.615), new Monomial(4, -4.396), new Monomial(5, 0.05), new Monomial(6, 0.16)));
                yield return new TestCaseData(
                    new Polynomial(new Monomial(1, -3), new Monomial(2, 0.014), new Monomial(3, 1.004), new Monomial(4, 0)),
                    new Polynomial(new Monomial(1, 1), new Monomial(2, -0.0d), new Monomial(3, 5)),
                    new Polynomial(new Monomial(1, -2), new Monomial(2, 0.014), new Monomial(3, 6.004), new Monomial(4, 0)));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForIndexer
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new Monomial(1, 1.21394), new Monomial(2, 2.001), new Monomial(3, 3.3)), 1).Returns(2.001);
                yield return new TestCaseData(new Polynomial(new Monomial(1, -1), new Monomial(2, 0.2), new Monomial(3, 3.313)), 2).Returns(3.313);
                yield return new TestCaseData(new Polynomial(new Monomial(1, -1), new Monomial(2, 0.2), new Monomial(3, 3.313), new Monomial(4, 0.004), new Monomial(5, 0.05), new Monomial(6, 0.16)), 5).Returns(0.16);
                yield return new TestCaseData(new Polynomial(new Monomial(1, -3), new Monomial(2, 0.014), new Monomial(3, 1.004), new Monomial(4, 0)), 0).Returns(-3);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForIndexerException
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new Monomial(1, 1.21394), new Monomial(2, 2.001), new Monomial(3, 3.3)), -1);
                yield return new TestCaseData(new Polynomial(new Monomial(1, -1), new Monomial(2, 0.2), new Monomial(3, 3.313), new Monomial(4, 0.004), new Monomial(5, 0.05), new Monomial(6, 0.16)), -2);
                yield return new TestCaseData(new Polynomial(new Monomial(1, -1), new Monomial(2, 0.2), new Monomial(3, 3.313), new Monomial(4, 0.004), new Monomial(5, 0.05), new Monomial(6, 0.16)), 9);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForOperationException
        {
            get
            {
                yield return new TestCaseData(new Polynomial(new Monomial(1, 1.21394), new Monomial(2, 2.001), new Monomial(3, 3.3)), null);
                yield return new TestCaseData(null, new Polynomial(new Monomial(1, -1), new Monomial(2, 0.2), new Monomial(3, 3.313), new Monomial(4, 0.004), new Monomial(5, 0.05), new Monomial(6, 0.16)));
                yield return new TestCaseData(null, null);
            }
        }
    }

}

