using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huffmanCoding
{
    class LinkedList_SF
    {
        Node_SF headAndRoot;

        public void addToFront(string val)
        {
            Node_SF newNode = new Node_SF(val);

            if (headAndRoot == null)
                headAndRoot = newNode;
            else
            {
                newNode.next = headAndRoot;
                headAndRoot = newNode;
            }
        }
        public void addToFront(string symbol, int freq)
        {
            Node_SF newNode = new Node_SF(symbol, freq);

            if (headAndRoot == null)
                headAndRoot = newNode;
            else
            {
                newNode.next = headAndRoot;
                headAndRoot = newNode;
            }
        }
        public void addSorted(Node_SF node)
        {
            Node_SF newNode = node;
            if (headAndRoot == null)
                headAndRoot = newNode;
            else if (headAndRoot.frequence.CompareTo(newNode.frequence) >= 0)
            {
                newNode.next = headAndRoot;
                headAndRoot = newNode;
            }
            else
            {
                Node_SF iterator = headAndRoot.next;
                Node_SF previous = headAndRoot;
                while (iterator != null)
                {
                    if (iterator.frequence.CompareTo(node.frequence) >= 0)
                    {
                        previous.next = node;
                        node.next = iterator;
                        break;
                    }
                    previous = iterator;
                    iterator = iterator.next;
                }
                if (iterator == null)
                    previous.next = newNode;



            }
        }
        public bool haveChar(string symbols, string oneSymbol)
        {
            for (int i = 0; i < symbols.Length; i++)
            {
                if (symbols[i].ToString() == oneSymbol)
                    return true;
            }

            return false;
        }
        public bool haveSameSym(string chr)
        {
            if (headAndRoot != null)
            {
                Node_SF iterator = headAndRoot;

                while (iterator != null)
                {
                    if (iterator.Symbol.CompareTo(chr) == 0)
                        return true;
                    iterator = iterator.next;
                }
            }
            return false;
        }
        public bool haveSameCode(string code)
        {
            if (headAndRoot != null) 
            {
                Node_SF iterator = headAndRoot;

                while (iterator != null)
                {
                    if (iterator.code.CompareTo(code) == 0)
                        return true;
                    iterator = iterator.next;
                }
            }
            return false;
        }
        public Node_SF findNodeBySymbol(string sym)
        {
            Node_SF iterator = headAndRoot;
            while (iterator != null)
            {
                if (iterator.Symbol.CompareTo(sym) == 0)
                    return iterator;
                iterator = iterator.next;
            }
            return null;
        }
        public Node_SF findNodeByCode(string code)
        {
            Node_SF iterator = headAndRoot;
            while (iterator != null)
            {
                if (iterator.code.CompareTo(code) == 0)
                    return iterator;
                iterator = iterator.next;
            }
            return null;
        }
        public string getSymbol(string code)
        {
            if (findNodeByCode(code) != null)
                return findNodeByCode(code).Symbol;
            else
                return "";
        }
        public string getCode(char symbol)
        {
            return findNodeBySymbol(symbol.ToString()).code;
        }
        public void increaseFreq(string ch)           // verilen karakterin oldugu node un frekansını  arttıran metod
        {
            findNodeBySymbol(ch).frequence += 1;

        }
        public LinkedList_SF copy()
        {
            LinkedList_SF newList = new LinkedList_SF();
            Node_SF iterator = headAndRoot;
            while (iterator != null)
            {
                newList.addToFront(iterator.Symbol, iterator.frequence);
                iterator = iterator.next;
            }
            return newList;
        }
        public void display()
        {
            if (headAndRoot != null)
            {
                Node_SF iterator = headAndRoot;

                while (iterator != null)
                {
                    Console.WriteLine(iterator.getString());
                    iterator = iterator.next;

                }

            }
        }
        public void sort()
        {
            Node_SF iterator = headAndRoot;
            Node_SF previous = headAndRoot;
            int tempF;
            string tempS;

            while (previous.next != null)
            {
                while (iterator.next != null)
                {
                    if (iterator.frequence > iterator.next.frequence)
                    {
                        tempF = iterator.frequence;
                        iterator.frequence = iterator.next.frequence;
                        iterator.next.frequence = tempF;

                        tempS = iterator.Symbol;
                        iterator.Symbol = iterator.next.Symbol;
                        iterator.next.Symbol = tempS;


                    }
                    iterator = iterator.next;
                }

                iterator = headAndRoot;
                previous = previous.next;

            }

        }
        public Node_SF getAndRemoveFirstNode()  //listenin ilk elemanını dondurup listeden silen metod
        {
            Node_SF temp = null;  // return etmeden once head e baska atamalar yapmak icin gecici kullandik

            if (headAndRoot != null)
            {
                temp = headAndRoot;
                headAndRoot = headAndRoot.next;

            }
            return temp;
        }
        public int Length()
        {
            Node_SF iterator = headAndRoot;
            int counter = 0;
            while (iterator != null)
            {
                counter++;
                iterator = iterator.next;
            }
            return counter;
        }
        public void findCode(LinkedList_SF getTree) // harflerin kodunu bulup döndüren metod
        {
            LinkedList_SF tree = getTree;

            string code = "";

            if (headAndRoot != null)
            {
                Node_SF iteratorSingleSymbol = headAndRoot;    // her bir sembolun kodunu bulmak için bütün elemanları dolasacak olan iterator.

                if (haveChar(tree.headAndRoot.Symbol, iteratorSingleSymbol.Symbol))  // eğer root un içinde o sembol yoksa boşuna arama yapmayacak
                {
                    while (iteratorSingleSymbol != null)
                    {
                        Node_SF iteratorTree = tree.headAndRoot;

                        while (iteratorTree != null)
                        {
                            while (iteratorTree.Left != null && iteratorTree.Right != null)
                            {
                                if (haveChar(iteratorTree.Left.Symbol, iteratorSingleSymbol.Symbol))     // eğer aradığı sembol soldaki parent ın içinde varsa
                                {
                                    iteratorTree = iteratorTree.Left;       // sembolü bulamamışsa iteratörü bir alt node a taşıyacak...
                                    code += 0;                        //ve koda 0 ekleyece
                                }

                                else if (haveChar(iteratorTree.Right.Symbol, iteratorSingleSymbol.Symbol))            // aradığı sembol sağdaysa
                                {
                                    iteratorTree = iteratorTree.Right;       // sembolü bulamamışsa iteratörü bir alt node a taşıyacak...
                                    code += 1;
                                }
                            }
                            iteratorSingleSymbol.code = code;   // eğer node un lefti ve right ı boşsa yapraga gelmistir ve kod hazırdır.
                            code = "";  // diğer semboller icin kodu bosalttik
                            break;  //kodu bulduktan sonra donguden cikip diger sembole gececek.
                        }
                        iteratorSingleSymbol = iteratorSingleSymbol.next;   //sonraki sembolu atadik.
                    }
                }
            }
        }







        //kullanılmayan metodlar

        public void inorder(Node_SF currentRoot)
        {
            if (currentRoot != null)
            {
                inorder(currentRoot.Left);
                Console.WriteLine(currentRoot.getString());
                inorder(currentRoot.Right);
            }
        }
        public void inorder()
        {
            inorder(headAndRoot);
            Console.WriteLine();
        }
        public void addToFront(Node_SF node)
        {
            Node_SF newNode = node;

            if (headAndRoot == null)
                headAndRoot = newNode;
            else
            {
                newNode.next = headAndRoot;
                headAndRoot = newNode;
            }
        }
        public void addToEnd(string val)
        {
            Node_SF newNode = new Node_SF(val);

            if (headAndRoot == null)
                headAndRoot = newNode;
            else
            {
                Node_SF iterator = headAndRoot;
                while (iterator.next != null)
                {
                    iterator = iterator.next;
                }
                iterator.next = newNode;

            }

        }
        public void deleteOne(string val)
        {
            if (headAndRoot == null)
                return;

            if (headAndRoot.Symbol.CompareTo(val) == 0)
                headAndRoot = headAndRoot.next;
            else
            {
                Node_SF iterator = headAndRoot;

                while (iterator.next != null)
                {
                    if (iterator.next.Symbol.CompareTo(val) == 0)
                    {
                        iterator.next = iterator.next.next;
                        break;
                    }
                    iterator = iterator.next;
                }


            }


        }
        public void addSortedToCopy(Node_SF nodeControl, LinkedList_SF list)
        {
            if (list.headAndRoot == null)
                list.headAndRoot = nodeControl;
            else if (list.headAndRoot.frequence.CompareTo(nodeControl.frequence) >= 0)
            {
                nodeControl.next = list.headAndRoot;
                list.headAndRoot = nodeControl;
            }
            else
            {
                Node_SF iterator = list.headAndRoot.next;
                Node_SF previous = list.headAndRoot;
                while (iterator != null)
                {
                    if (iterator.frequence.CompareTo(nodeControl.frequence) >= 0)
                    {
                        previous.next = nodeControl;
                        nodeControl.next = iterator;
                        break;
                    }
                    previous = iterator;
                    iterator = iterator.next;
                }
                if (iterator == null)
                    previous.next = nodeControl;
            }
        }
        public void addSorted(string s, int f)
        {
            Node_SF node = new Node_SF(s, f);

            if (headAndRoot == null)
                headAndRoot = node;
            else if (headAndRoot.frequence.CompareTo(node.frequence) >= 0)
            {
                node.next = headAndRoot;
                headAndRoot = node;
            }
            else
            {
                Node_SF iterator = headAndRoot.next;
                Node_SF previous = headAndRoot;
                while (iterator != null)
                {
                    if (iterator.frequence.CompareTo(node.frequence) >= 0)
                    {
                        previous.next = node;
                        node.next = iterator;
                        break;
                    }
                    previous = iterator;
                    iterator = iterator.next;
                }
                if (iterator == null)
                    previous.next = node;

            }
        }


    }
}
