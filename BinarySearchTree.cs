//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace huffmanCoding
//{

//    class BinarySearchTree
//    {
//        TNode root;
//        //public void insert(string symbols, int freq)
//        //{
//        //    TNode newNode = new TNode(symbols,freq);
//        //    if (root == null)
//        //        root = newNode;
//        //    else
//        //    {
//        //        TNode iterator = root;
//        //        while (iterator != null)
//        //        {
//        //            if (iterator.Value.CompareTo(val) >= 0)
//        //            {
//        //                if (iterator.Left == null)
//        //                {
//        //                    iterator.Left = newNode;
//        //                    break;
//        //                }
//        //                else
//        //                    iterator = iterator.Left;
//        //            }
//        //            else
//        //            {
//        //                if (iterator.Right == null)
//        //                {
//        //                    iterator.Right = newNode;
//        //                    break;
//        //                }
//        //                else
//        //                    iterator = iterator.Right;
//        //            }

//        //        }

//        //    }


//        //}
     
//        //public void insertRecursively(T val)
//        //{
//        //    root = insertRecursively(root, val);
//        //}
//        //public TNode insertRecursively(TNode currentRoot, T val)
//        //{
//        //    if (currentRoot == null)
//        //        return new TNode(val);
//        //    else if (currentRoot.Value.CompareTo(val) >= 0)
//        //        currentRoot.Left = insertRecursively(currentRoot.Left, val);
//        //    else
//        //        currentRoot.Right = insertRecursively(currentRoot.Right, val);

//        //    return currentRoot;
//        //}
       
        
//        public bool search(T val)
//        {
//            TNode iterator = root;
//            while (iterator != null)
//            {
//                if (iterator.Value.CompareTo(val) == 1)
//                    iterator = iterator.Left;
//                else if (iterator.Value.CompareTo(val) == -1)
//                    iterator = iterator.Right;
//                else
//                    return true;
//            }
//            return false;
//        }
//        public bool searchRecursively(T val)
//        {
//            return searchRecursively(root, val);
//        }
//        public bool searchRecursively(TNode currentRoot, T val)
//        {
//            if (currentRoot == null)
//                return false;
//            else if (currentRoot.Value.CompareTo(val) == 1)
//                return searchRecursively(currentRoot.Left, val);
//            else if (currentRoot.Value.CompareTo(val) == -1)
//                return searchRecursively(currentRoot.Right, val);
//            else
//                return true;

//        }
//        public void inorder()
//        {
//            inorder(root);
//            Console.WriteLine();
//        }
//        public void inorder(TNode currentRoot)
//        {
//            if (currentRoot != null)
//            {
//                inorder(currentRoot.Left);
//                Console.WriteLine(currentRoot.Value);
//                inorder(currentRoot.Right);
//            }
//        }
//        public void postOrder()
//        {
//            postOrder(root);
//            Console.WriteLine();
//        }
//        public void postOrder(TNode currentRoot)
//        {
//            if (currentRoot != null)
//            {
//                postOrder(currentRoot.Left);
//                postOrder(currentRoot.Right);
//                Console.WriteLine(currentRoot.Value);
//            }
//        }
//        public void preOrder()
//        {
//            preOrder(root);
//            Console.WriteLine();
//        }
//        public void preOrder(TNode currentRoot)
//        {
//            if (currentRoot != null)
//            {
//                Console.WriteLine(currentRoot.Value);
//                preOrder(currentRoot.Left);
//                preOrder(currentRoot.Right);
//            }
//        }

//        public TNode findNode(T val)
//        {
//            TNode iterator = root;
//            while (iterator != null)
//            {
//                if (iterator.Value.CompareTo(val) == 1)
//                    iterator = iterator.Left;
//                else if (iterator.Value.CompareTo(val) == -1)
//                    iterator = iterator.Right;
//                else
//                    return iterator;
//            }
//            return null;
//        }
//        public TNode findParent(T val)
//        {
//            if (!search(val) || root.Value.CompareTo(val) == 0)
//                return null;//or throw exception
//            else
//            {
//                TNode parent = root, iterator = root;
//                while (iterator != null)
//                {
//                    if (iterator.Value.CompareTo(val) == 0)
//                        return parent;
//                    else
//                        parent = iterator;
//                    if (iterator.Value.CompareTo(val) == 1)
//                        iterator = iterator.Left;
//                    else
//                        iterator = iterator.Right;
//                }
//                return parent;

//            }
//        }

//        public TNode findInorderSuccessor(T val)
//        {
//            TNode current = findNode(val);
//            TNode parent = findParent(val);
//            if (current != null)
//            {
//                if (current.Right != null)//sağ cocuk varsa
//                {
//                    TNode iterator = current.Right;
//                    while (iterator.Left != null)
//                        iterator = iterator.Left;
//                    return iterator;
//                }//parent varsa ve parentin solundaysa
//                else if (parent != null && parent.Left == current)
//                    return parent;

//            }
//            return null;

//        }
//        public void delete(T val)
//        {
//            if (root != null && root.Right == null && root.Value.CompareTo(val) == 0)
//                root = root.Left;
//            else
//            {
//                TNode current = findNode(val);
//                TNode parent = findParent(val);
//                if (current != null)
//                {
//                    if (current.Left == null && current.Right == null)
//                    {
//                        if (parent.Left == current)
//                            parent.Left = null;
//                        else
//                            parent.Right = null;

//                    }
//                    else if (current.Left != null && current.Right != null)
//                    {
//                        TNode successor = findInorderSuccessor(val);
//                        delete(successor.Value);
//                        current.Value = successor.Value;

//                    }
//                    else
//                    {
//                        TNode child;
//                        if (current.Left == null)
//                            child = current.Right;
//                        else
//                            child = current.Left;
//                        if (parent.Left == current)
//                            parent.Left = child;
//                        else
//                            parent.Right = child;
//                    }

//                }
//            }
//        }

//    }
//}
