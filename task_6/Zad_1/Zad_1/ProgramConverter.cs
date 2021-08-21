using System;
using System.Collections.Generic;
using System.Text;

namespace Zad_1
{
    class ProgramConverter : IConvertible
    {
        public string ConvertToCSharp(string vbCode)
        {
            return "Convert To CSharp Code";
        }

        public string ConvertToVB(string CSharpCode)
        {
            return "Convert To Visual Basic code";
        }
    }
}
