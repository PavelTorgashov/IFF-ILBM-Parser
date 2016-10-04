// (c) Pavel Torgashov, 2016.
// GPL3

using System;
using System.IO;
using IffParserNS;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            //------------------------------------
            // Extracts bitmap from IFF ILBM file
            //------------------------------------
            var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.iff");
            var outputFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.png");

            try
            {
                //create IFF parser
                var iff = new IFF();
                //parse file
                iff.Parse(file);

                //check Bitmap
                if (iff.Bitmap != null)
                {
                    iff.Bitmap.Save(outputFile);
                }

                //check JPEG chunk
                if (iff.JPEG != null)
                {
                    var path = Path.GetDirectoryName(outputFile);
                    var fileName = Path.GetFileNameWithoutExtension(outputFile) + "_preview.jpg";
                    File.WriteAllBytes(Path.Combine(path, fileName), iff.JPEG);
                }

                if (iff.JPEG == null && iff.Bitmap == null)
                    throw new Exception("There are no Images.");

                Console.WriteLine("Conversion is successfull.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
