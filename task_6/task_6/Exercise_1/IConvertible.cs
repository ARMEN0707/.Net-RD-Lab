using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1
{
    interface IConvertible
    {
        string ConvertToCSharp(string vbCode);
        string ConvertToVB(string CSharpCode);
    }
}
