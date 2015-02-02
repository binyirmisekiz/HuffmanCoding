using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huffmanCoding
{
    class HuffmanC
    {
        LinkedList_SF llTree;
        LinkedList_SF llSemFrqCode;
        FileOperation fileOpr;


        public HuffmanC(string fileName)
        {
            fileOpr = new FileOperation(fileName);
        }
        public void encode()
        {
            if (System.IO.File.Exists("encode.txt"))//aynı dosyaya tekrar tekrar yazmasın diye silip tekrar olusturuyoruz
                File.Delete("encode.txt");
            fileOpr.writeNew("", "encode.txt");

            string content = fileOpr.readFrom();  // belge icerigini aldik
            for (int i = 0; i < content.Length; i++)    // belgenin icinde teker teker dolasip karakterlere bakacagiz
            {
                fileOpr.appendTo(llSemFrqCode.getCode(content[i]), "encode.txt");  // sembole ait kodu dosyaya ekliyoruz
            }
        } 
        public void decode()
        {
            if (System.IO.File.Exists("decode.txt"))    //aynı dosyaya tekrar tekrar yazmasın diye silip tekrar olusturuyoruz
                File.Delete("decode.txt");
            fileOpr.writeNew("", "decode.txt");

            string content = fileOpr.readFrom("encode.txt");  // belge icerigini aldik
            string code = "";
            for (int i = 0; i < content.Length; i++)    // belgenin icinde teker teker dolasip karakterlere bakacagiz
            {
                code += content[i];
                if (llSemFrqCode.haveSameCode(code))    // eger bu koda ait sembol varsa onu dosyaya ekleyip kodu basa kuruyoruz
                {
                    fileOpr.appendTo(llSemFrqCode.getSymbol(code), "decode.txt");
                    code = "";
                }

            }
        }
        public void findSymFreqCode()   //find symbol frequence code
        {
            llTree = findCharFreq();    // once sembollerin frekanslarini buluyoruz.
            makeTree();                 // sonra bu frekanslara gore agac olusturuyoruz
            llSemFrqCode.findCode(llTree);      // agac uzerinden sembollerin kodlarini buluyoruz.
        }
        private LinkedList_SF findCharFreq()
        {
            LinkedList_SF lList = new LinkedList_SF();
            string content = fileOpr.readFrom();  // belge icerigini aldik
            for (int i = 0; i < content.Length; i++)    // belgenin icinde teker teker dolasip karakterlere bakacagiz
            {
                if (lList.haveSameSym(content[i].ToString()))          // böyle bir karakter listede varsa
                    lList.increaseFreq(content[i].ToString());  // var olan karakterin frekansını 1 arttırdık.
                else
                    lList.addToFront(content[i].ToString().ToString());         // listeye yeni karakteri ekledik(yeni eklediğimiz karakterin frq ı ) oluyor
            }
            lList.sort();
            return lList;
        }
        private void makeTree()
        {
            Node_SF first, second;

            llSemFrqCode = new LinkedList_SF();
            llSemFrqCode = llTree.copy();       //sadece harflerin kodlarını bulmak icin listeyi bozulmadan once yedekliyoruz.

            while (llTree.Length() > 1)     // bu döngünün içinde ağaç oluşturuluyor.
            { //ilk iki eleman alıp, yeni bir nod olusturulup, olusturulan yeni node un yaprakları oluyor.
                first = llTree.getAndRemoveFirstNode();
                second = llTree.getAndRemoveFirstNode();
                Node_SF addedNode = new Node_SF((first.Symbol + second.Symbol), (first.frequence + second.frequence));
                addedNode.Left = first;
                addedNode.Right = second;
                //olusturulan yeni node listeye tekrar sirali bir sekiilde ekleniyor.
                llTree.addSorted(addedNode);
            }
        }
        public void displayFile()
        {
            Console.WriteLine();
            Console.Write(" " + fileOpr.fileName + " dosyasının içeriği:  ");
            Console.Write("  " + fileOpr.readFrom());
            Console.WriteLine();
        }
        public void displayFile(string fileName)
        {
            Console.WriteLine();
            Console.Write(" " + fileName + " dosyasının içeriği:  ");
            Console.Write("  " + fileOpr.readFrom(fileName));
            Console.WriteLine();
        }
        public void displaySymFreqCode()
        {
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            Console.WriteLine(" " + fileOpr.fileName + " dosyasının içeriğinin sembol, frekans ve kodları: ");
            Console.WriteLine();
            Console.WriteLine("      Symbol     Freq      Code");
            Console.WriteLine("      ------     ----      ----");
            llSemFrqCode.display();
            Console.WriteLine("     ---------------------------");
        }

    }
}
