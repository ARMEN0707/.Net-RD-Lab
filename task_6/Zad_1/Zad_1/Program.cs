using System;

namespace Zad_1
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramConverter[] programConverters = new ProgramConverter[3];
            programConverters[0] = new ProgramConverter();
            programConverters[1] = new ProgramHelper();
            programConverters[2] = new ProgramHelper();

            foreach(ProgramConverter item in programConverters)
            {
                string vbCode = item.ConvertToVB("CSharpCode");
                Console.WriteLine(vbCode);

                string CSharpCode = item.ConvertToCSharp("VBCode");
                Console.WriteLine(CSharpCode);

                if (item is ProgramHelper)
                {
                    ProgramHelper programHelper = item as ProgramHelper;
                    if (programHelper.CodeCheckSyntax(vbCode, "VisualBasic"))
                        Console.WriteLine("Verification VisualBasic is successful.");

                    if (programHelper.CodeCheckSyntax(CSharpCode, "CSharp"))
                        Console.WriteLine("Verification CSharp is successful.");
                }
                else
                {
                    Console.WriteLine("Verification is not available");
                }
            }

            Console.ReadLine();
        }
    }
}
