using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_1
{
    class ProgramHelper : ProgramConverter, ICodeChecke
    {
        public bool CodeCheckSyntax(string code, string language)
        {
            switch(language)
            {
                case "CSharp":
                    Console.WriteLine("Check CSharp code.");
                    return true;
                case "VisualBasic":
                    Console.WriteLine("Check VisualBasic code.");
                    return true;
            }
            return false;
        }
    }
}
