using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1
{
    class ProgramHelper : ProgramConverter, ICodeChecker
    {
        public bool CodeCheckSyntax(string code, string language)
        {
            switch(language)
            {
                case "CSharp":
                    return true;
                case "VisualBasic":
                    return true;
            }
            return false;
        }
    }
}
