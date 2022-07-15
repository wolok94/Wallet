using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.IO
{
    public class FileManager
    {
        public string ReadFile()
        {
            string text = File.ReadAllText(@"E:\Programowanie\Ćwiczenia\Portfel\Email.txt");
            return text;
        }
    }
}
