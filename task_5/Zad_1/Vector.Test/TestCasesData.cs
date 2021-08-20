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
                yield return new TestCaseData(new task_5.Vector(1f, 2f, 3f), new task_5.Vector(1f, 2f, 3f))
                    .Returns(true);
                yield return new TestCaseData(new task_5.Vector(0f, 0.1f, 0.0001f), new task_5.Vector(0f, 0.1f, 0.0001f))
                    .Returns(true);
                yield return new TestCaseData(new task_5.Vector(1f, 2f, 3f), new task_5.Vector(1.5f, 2f, 3f))
                    .Returns(false);
                yield return new TestCaseData(new task_5.Vector(-100.123f, float.MinValue, float.MaxValue), new task_5.Vector(-10.123f, float.MinValue, float.MaxValue))
                    .Returns(false);
                yield return new TestCaseData(new task_5.Vector(-0.123f, 0.0f, -1.0f), new task_5.Vector(-0.123065f, 0.0f, -1.0f))
                    .Returns(false);
                yield return new TestCaseData(new task_5.Vector(1f, 2f, 3f), null)
                    .Returns(false);
                yield return new TestCaseData(new task_5.Vector(-0.5f, 0f, 0.5f), new task_5.Vector(-0.5f, 0.5f, 0))
                    .Returns(false);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForMultiplication
        {
            get
            {
                yield return new TestCaseData(
                    new task_5.Vector(1.21394f, 2.001f, 3.3f),
                    new task_5.Vector(0.1f, 0.002f, 0),
                    new task_5.Vector(-0.0066f, 0.33f, -0.19767212f));
                yield return new TestCaseData(
                    new task_5.Vector(-1, 0.2f, 3.313f),
                    new task_5.Vector(1.1f, -2.2f, 3.3f),
                    new task_5.Vector(7.9486f, 6.9443f, 1.98f));
                yield return new TestCaseData(
                    new task_5.Vector(-3, 0.014f, 1.004f),
                    new task_5.Vector(1, 0, 5),
                    new task_5.Vector(0.07f, 16.004f, -0.014f));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForMultiplicationNumber
        {
            get
            {
                yield return new TestCaseData(
                    new task_5.Vector(1.21394f, 2.001f, 3.3f),
                    2,
                    new task_5.Vector(2.42788f, 4.002f, 6.6f));
                yield return new TestCaseData(
                    new task_5.Vector(-1, 0.2f, 3.313f),
                    3.6f,
                    new task_5.Vector(-3.6f, 0.72f, 11.9268f));
                yield return new TestCaseData(
                    new task_5.Vector(-3, 0.014f, 1.004f),
                    0,
                    new task_5.Vector(0, 0, 0));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForDivisionNumber
        {
            get
            {
                yield return new TestCaseData(
                    new task_5.Vector(2.42788f, 4.002f, 6.6f),
                    2,
                    new task_5.Vector(1.21394f, 2.001f, 3.3f));
                yield return new TestCaseData(
                    new task_5.Vector(-3.6f, 0.72f, 11.9268f),
                    3.6f,
                    new task_5.Vector(-1, 0.2f, 3.313f));
                yield return new TestCaseData(
                    new task_5.Vector(-3, 0.014f, 1.004f),
                    1,
                    new task_5.Vector(-3, 0.014f, 1.004f));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForSubtraction
        {
            get
            {
                yield return new TestCaseData(
                    new task_5.Vector(0.1f, 0.002f, 0),
                    new task_5.Vector(1.21394f, 2.001f, 3.3f),
                    new task_5.Vector(-1.11394f, -1.999f, -3.3f));
                yield return new TestCaseData(
                    new task_5.Vector(1.21394f, 2.001f, 3.3f),
                    new task_5.Vector(0.1f, 0.002f, 0),
                    new task_5.Vector(1.11394f, 1.999f, 3.3f));
                yield return new TestCaseData(
                    new task_5.Vector(-1, 0.2f, 3.313f),
                    new task_5.Vector(1.1f, -2.2f, 3.3f),
                    new task_5.Vector(-2.1f, 2.4f, 0.013f));
                yield return new TestCaseData(
                    new task_5.Vector(-3, 0.014f, 1.004f),
                    new task_5.Vector(1, -0.0f, 5),
                    new task_5.Vector(-4, 0.014f, -3.996f));
                yield return new TestCaseData(
                    new task_5.Vector(1.204f, -2.569f, 3.987f),
                    new task_5.Vector(1, -2, -3),
                    new task_5.Vector(0.204f, -0.569f, 6.987f));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForAddition
        {
            get
            {
                yield return new TestCaseData(
                    new task_5.Vector(1.21394f, 2.001f, 3.3f),
                    new task_5.Vector(0.1f, 0.002f, 0),
                    new task_5.Vector(1.31394f, 2.003f, 3.3f));
                yield return new TestCaseData(
                    new task_5.Vector(-1, 0.2f, 3.313f),
                    new task_5.Vector(1.1f, -2.2f, 3.3f),
                    new task_5.Vector(0.1f, -2f, 6.613f));
                yield return new TestCaseData(
                    new task_5.Vector(-3, 0.014f, 1.004f),
                    new task_5.Vector(1, 0.0f, 5),
                    new task_5.Vector(-2, 0.014f, 6.004f));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForOperationException
        {
            get
            {
                yield return new TestCaseData(new task_5.Vector(1.21394f, 2.001f, 3.3f), null);
                yield return new TestCaseData(null, new task_5.Vector(-1, 0.2f, 3.313f));
                yield return new TestCaseData(null, null);
            }
        }
        
        public static IEnumerable<TestCaseData> TestCasesForOperationExceptionWithOneVector
        {
            get
            {
                yield return new TestCaseData(null, 0f);
                yield return new TestCaseData(null, 5.6f);
            }
        }
    }
}
