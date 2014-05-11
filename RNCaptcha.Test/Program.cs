using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RNCaptcha;

namespace RNCaptcha.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            RNCaptcha cap = new RNCaptcha(RNCaptcha.GenerateRandomString());

            System.IO.StreamWriter outFile = new System.IO.StreamWriter("C:\\temp\\outfile.html");
            outFile.Write(RNCaptcha.GenerateMarkup(cap.GetCaptcha()));
            outFile.Close();

            Console.Read();
            

        }
    }
}
