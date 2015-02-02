using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huffmanCoding
{
    class Test
    {
        static void Main(string[] args)
        {

            HuffmanC hcLetter = new HuffmanC("letter.txt");
            hcLetter.findSymFreqCode();
            hcLetter.displaySymFreqCode();

            
            HuffmanC hcSource = new HuffmanC("source.txt");
            hcSource.findSymFreqCode();
            hcSource.displaySymFreqCode();
            hcSource.encode();
            hcSource.displayFile();
            hcSource.displayFile("encode.txt");
            hcSource.decode();
            hcSource.displayFile("decode.txt");
            

            Console.ReadLine();


        }
    }
}
