using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfel.IO
{
    public class FileManager
    {
        // reads text from a file
        public string ReadFile()
        {
            string text = File.ReadAllText(@"E:\Programowanie\Ćwiczenia\Portfel\Email\RegistrationEmail.txt");
            return text;
        }
        public string ReadDebetFile()
        {
            string text = File.ReadAllText(@"E:\Programowanie\Ćwiczenia\Portfel\Email\DebetEmail.txt");
            return text;
        }
    }
}
