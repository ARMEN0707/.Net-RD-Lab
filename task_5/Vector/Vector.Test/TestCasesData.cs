using System.Collections.Generic;
using NUnit.Framework;

namespace Vector.Test
{
    public class TestCasesData
    {
        public static IEnumerable<TestCaseData> TestCasesForEquals
        {
            get
            {
                yield return new TestCaseData(new task_5.Vector(1, 2, 3), new task_5.Vector(1, 2, 3))
                    .Returns(true);
                yield return new TestCaseData(new task_5.Vector(0, 0.1, 0.0001), new task_5.Vector(0, 0.1, 0.0001))
                    .Returns(true);
                yield return new TestCaseData(new task_5.Vector(1, 2, 3), new task_5.Vector(1.5, 2, 3))
                    .Returns(false);
                yield return new TestCaseData(new task_5.Vector(-100.123, double.MinValue, double.MaxValue), new task_5.Vector(-10.123, double.MinValue, double.MaxValue))
                    .Returns(false);
                yield return new TestCaseData(new task_5.Vector(-0.123, 0.0, -1.0), new task_5.Vector(-0.123065, 0.0, -1.0))
                    .Returns(false);
                yield return new TestCaseData(new task_5.Vector(1, 2, 3), null)
                    .Returns(false);
                yield return new TestCaseData(new task_5.Vector(-0.5, 0, 0.5), new task_5.Vector(-0.5, 0.5, 0))
                    .Returns(false);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForMultiplication
        {
            get
            {
                yield return new TestCaseData(
                    new task_5.Vector(1.21394, 2.001, 3.3),
                    new task_5.Vector(0.1, 0.002, 0),
                    new task_5.Vector(-0.0066, 0.33, -0.19767212));
                yield return new TestCaseData(
                    new task_5.Vector(-1, 0.2, 3.313),
                    new task_5.Vector(1.1, -2.2, 3.3),
                    new task_5.Vector(7.9486, 6.9443, 1.98));
                yield return new TestCaseData(
                    new task_5.Vector(-3, 0.014, 1.004),
                    new task_5.Vector(1, 0, 5),
                    new task_5.Vector(0.07, 16.004, -0.014));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForMultiplicationNumber
        {
            get
            {
                yield return new TestCaseData(
                    new task_5.Vector(1.21394, 2.001, 3.3),
                    2,
                    new task_5.Vector(2.42788, 4.002, 6.6));
                yield return new TestCaseData(
                    new task_5.Vector(-1, 0.2, 3.313),
                    3.6,
                    new task_5.Vector(-3.6, 0.72, 11.9268));
                yield return new TestCaseData(
                    new task_5.Vector(-3, 0.014, 1.004),
                    0,
                    new task_5.Vector(0, 0, 0));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForDivisionNumber
        {
            get
            {
                yield return new TestCaseData(
                    new task_5.Vector(2.42788, 4.002, 6.6),
                    2,
                    new task_5.Vector(1.21394, 2.001, 3.3));
                yield return new TestCaseData(
                    new task_5.Vector(-3.6, 0.72, 11.9268),
                    3.6,
                    new task_5.Vector(-1, 0.2, 3.313));
                yield return new TestCaseData(
                    new task_5.Vector(-3, 0.014, 1.004),
                    1,
                    new task_5.Vector(-3, 0.014, 1.004));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForSubtraction
        {
            get
            {
                yield return new TestCaseData(
                    new task_5.Vector(0.1, 0.002, 0),
                    new task_5.Vector(1.21394, 2.001, 3.3),
                    new task_5.Vector(-1.11394, -1.999, -3.3));
                yield return new TestCaseData(
                    new task_5.Vector(1.21394, 2.001, 3.3),
                    new task_5.Vector(0.1, 0.002, 0),
                    new task_5.Vector(1.11394, 1.999, 3.3));
                yield return new TestCaseData(
                    new task_5.Vector(-1, 0.2, 3.313),
                    new task_5.Vector(1.1, -2.2, 3.3),
                    new task_5.Vector(-2.1, 2.4, 0.013));
                yield return new TestCaseData(
                    new task_5.Vector(-3, 0.014, 1.004),
                    new task_5.Vector(1, -0.0, 5),
                    new task_5.Vector(-4, 0.014, -3.996));
                yield return new TestCaseData(
                    new task_5.Vector(1.204, -2.569, 3.987),
                    new task_5.Vector(1, -2, -3),
                    new task_5.Vector(0.204, -0.569, 6.987));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForAddition
        {
            get
            {
                yield return new TestCaseData(
                    new task_5.Vector(1.21394, 2.001, 3.3),
                    new task_5.Vector(0.1, 0.002, 0),
                    new task_5.Vector(1.31394, 2.003, 3.3));
                yield return new TestCaseData(
                    new task_5.Vector(-1, 0.2, 3.313),
                    new task_5.Vector(1.1, -2.2, 3.3),
                    new task_5.Vector(0.1, -2, 6.613));
                yield return new TestCaseData(
                    new task_5.Vector(-3, 0.014, 1.004),
                    new task_5.Vector(1, 0.0, 5),
                    new task_5.Vector(-2, 0.014, 6.004));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForOperationException
        {
            get
            {
                yield return new TestCaseData(new task_5.Vector(1.21394, 2.001, 3.3), null);
                yield return new TestCaseData(null, new task_5.Vector(-1, 0.2, 3.313));
                yield return new TestCaseData(null, null);
            }
        }
        
        public static IEnumerable<TestCaseData> TestCasesForOperationExceptionWithOneVector
        {
            get
            {
                yield return new TestCaseData(null, 0);
                yield return new TestCaseData(null, 5.6);
            }
        }
    }
}
