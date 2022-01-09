using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1
{
    interface ICodeChecker
    {
        bool CodeCheckSyntax(string code, string language);
    }
}
