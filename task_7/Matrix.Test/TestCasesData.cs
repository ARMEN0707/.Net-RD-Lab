using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using task_7;

namespace Test
{
    class TestCasesData
    {
        public static IEnumerable<TestCaseData> TestCasesForConstructor
        {
            get
            {
                yield return new TestCaseData(2,2,new double[] { 1, 2, 3});
                yield return new TestCaseData(1,2,new double[] { -1, 0.2, 3, 4 });
                yield return new TestCaseData(2,1,new double[] { -3, 0.014, 1.004, 0 });
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForIndexer
        {
            get
            {
                yield return new TestCaseData(new Matrix(2,2, 1,2,3,4), 1, 1).Returns(4);
                yield return new TestCaseData(new Matrix(1, 2, 1, 3), 0, 1).Returns(3);
                yield return new TestCaseData(new Matrix(2, 3, 1.5, 2.05, 0, 4,6.666,4.5), 0, 1).Returns(2.05);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForIndexerException
        {
            get
            {
                yield return new TestCaseData(new Matrix(2, 2, 1, 2, 3, 4), -1, 1);
                yield return new TestCaseData(new Matrix(1, 2, 1, 3), 0, 2);
                yield return new TestCaseData(new Matrix(2, 3, 1.5, 2.05, 0, 4, 6.666, 4.5), 0, 9);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForToString
        {
            get
            {
                yield return new TestCaseData(new Matrix(2, 2, 1, 2, 3, 4), 1, 1).Returns("1 2 \n3 4 \n");
                yield return new TestCaseData(new Matrix(1, 2, 1, 3), 0, 1).Returns("1 3 \n");
                yield return new TestCaseData(new Matrix(2, 3, 1.5, 2.05, 0, 4, 6.666, 4.5), 0, 1).Returns("1,5 2,05 0 \n4 6,666 4,5 \n");
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForOperationException
        {
            get
            {
                yield return new TestCaseData(new Matrix(2, 2, 1, 2, 3, 4), null);
                yield return new TestCaseData(null, new Matrix(2, 3, 2.5, 5.05, 6.424, 4, 19.006, 7.5));
                yield return new TestCaseData(null, null);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForAddition
        {
            get
            {
                yield return new TestCaseData(
                    new Matrix(2, 2, 1, 2, 3, 4),
                    new Matrix(2, 2, 1, 2, 3, 4),
                    new Matrix(2, 2, 2, 4, 6, 8));
                yield return new TestCaseData(
                    new Matrix(2, 3, 1.5, 2.05, 0, 4, 6.666, 4.5),
                    new Matrix(2, 3, 1, 3, 6.424, 0, 12.34, 3),
                    new Matrix(2, 3, 2.5, 5.05, 6.424, 4, 19.006, 7.5));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForSubtraction
        {
            get
            {
                yield return new TestCaseData(
                    new Matrix(2, 2, 1, 2, 3, 4),
                    new Matrix(2, 2, 1, 2, 3, 4),
                    new Matrix(2, 2, 0, 0, 0, 0));
                yield return new TestCaseData(
                    new Matrix(2, 3, 1.5, 2.05, 0, 4, 6.666, 4.5),
                    new Matrix(2, 3, 1, 3, 6.424, 0, 12.34, 3),
                    new Matrix(2, 3, 0.5, -0.95, -6.424, 4, -5.674, 1.5));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForMultiplication
        {
            get
            {
                yield return new TestCaseData(
                    new Matrix(2, 2, 1, 2, 3, 4),
                    new Matrix(2, 2, 5, 6, 7, 8),
                    new Matrix(2, 2, 19, 22, 43, 50));
                yield return new TestCaseData(
                    new Matrix(3, 3, 1.5, 2.05, 0, 4, 6.666, 4.5, 5, 8.99, -4.54),
                    new Matrix(3, 3, 1, 3, 6.424, 0, 12.34, 3, 5.3, 6.534, 4.56),
                    new Matrix(3, 3, 1.5, 29.797, 15.786, 27.85, 123.66144, 66.214, -19.062, 96.27224, 38.3876));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForEquals
        {
            get
            {
                yield return new TestCaseData(new Matrix(2, 2, 1, 2, 3, 4), new Matrix(2, 2, 5, 6, 7, 8))
                    .Returns(false);
                yield return new TestCaseData(new Matrix(2, 2, 1, 2, 3, 4), new Matrix(2, 3, 5, 6, 7, 8, 9, 0))
                    .Returns(false);
                yield return new TestCaseData(new Matrix(3, 3, 1.5, 2.05, 0, 4, 6.666, 4.5, 5, 8.99, -4.54), new Matrix(3, 3, 1.5, 2.05, 0, 4, 6.666, 4.5, 5, 8.99, -4.54))
                    .Returns(true);
                yield return new TestCaseData(new Matrix(3, 3, 1.5, 2.05, 0, 4, 6.666, 4.5, 5, 8.99, -4.54), null)
                    .Returns(false);
            }
        }
    }
}
