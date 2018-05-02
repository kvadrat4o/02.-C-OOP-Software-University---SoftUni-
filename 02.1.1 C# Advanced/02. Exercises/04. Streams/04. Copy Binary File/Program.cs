using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace _04.Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream reader = new FileStream("..//..//copyMe.png",FileMode.Open))
            {
                using (FileStream destination = new FileStream("..//..//copied.png",FileMode.Create))
                {
                    
                    byte[] buffer = new byte[10240];

                    while (true)
                    {
                        var byteread = reader.Read(buffer, 0, buffer.Length);
                        if (byteread == 0)
                        {
                            break;
                        }
                        destination.Write(buffer, 0, byteread);
                    }
                }
            }
        }
    }
}
