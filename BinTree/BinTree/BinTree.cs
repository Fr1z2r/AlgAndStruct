using System;
using System.Collections.Generic;

namespace BinTree
{
    public class BinTree<T> where T:IComparable<T>
    {
        private Node<T> root;

        public void Add(T value)
        {
            if (root==null)
            {
                root=new Node<T>(value);
            }
            else
            {
                addValueToTree(root,value);
            }
        }

        public bool Contians(T value)
        {
            return ContainsInSubTree(root, value);
        }

        public void Delete(T value)
        {
            DeleteNode(root,null, value);
        }

        private void DeleteNode(Node<T> currentNode,Node<T> parentNode , T value)
        {
            if (currentNode == null) return;
            if (currentNode.Value.CompareTo(value)==0)
            {
                var children = GetChildrenFromNode(currentNode);
                children.Remove(currentNode.Value);
                if (parentNode.LeftNode == currentNode) parentNode.LeftNode = null;
                if (parentNode.RightNode == currentNode) parentNode.RightNode = null;
                
                foreach (var child in children)
                {
                    Add(child);
                }
                return;
            }
            var nextNode = currentNode.Value.CompareTo(value) < 0 ? currentNode.RightNode : currentNode.LeftNode;
            DeleteNode(nextNode,currentNode, value);
        }

        private List<T> GetChildrenFromNode(Node<T> currentNode)
        {
            if (currentNode==null)return new List<T>();
            var children = GetChildrenFromNode(currentNode.LeftNode);
            children.AddRange(GetChildrenFromNode(currentNode.RightNode));
            children.Add(currentNode.Value);
            return children;
        }

        private bool ContainsInSubTree(Node<T> currentNode, T value)
        {
            if (currentNode == null) return false;
            if (currentNode.Value.CompareTo(value)==0) return true;
            if (ContainsInSubTree(currentNode.LeftNode, value)) return true;
            if (ContainsInSubTree(currentNode.RightNode, value)) return true;
            return false;

        }

        private void addValueToTree(Node<T> currentNode,T value)
        {
            if(currentNode.Value.CompareTo(value)==0)return;
            if (currentNode.Value.CompareTo(value)>0)
            {
                if (currentNode.LeftNode == null)
                {
                    currentNode.LeftNode=new Node<T>(value);
                    return;
                }
                addValueToTree(currentNode.LeftNode,value);
            }
            else
            {
                if (currentNode.RightNode==null)
                {
                    currentNode.RightNode=new Node<T>(value);
                    return;
                }
                addValueToTree(currentNode.RightNode,value);
            }
        }

        public List<T> MaxPath()
        {
            var maxPath = MaxPathFromNode(root);
            maxPath.Reverse();
            return maxPath;
        }

        private List<T> MaxPathFromNode(Node<T> currentNode)
        {
            if(currentNode==null)
                return new List<T>();
            var leftPath = MaxPathFromNode(currentNode.LeftNode);
            var rightPath = MaxPathFromNode(currentNode.RightNode);

            var resultPath = leftPath.Count > rightPath.Count ? leftPath : rightPath;
            resultPath.Add(currentNode.Value);

            return resultPath;


        }

        public void PrintTree()
        {
            PrintLeafs(root,"");
        }

        private void PrintLeafs(Node<T> curreNode, string spaces)
        {
            if(curreNode.RightNode!=null)PrintLeafs(curreNode.RightNode,spaces+"  ");
            Console.WriteLine(spaces+curreNode.Value);
            if(curreNode.LeftNode!=null)PrintLeafs(curreNode.LeftNode,spaces+"  ");
        }
    }
}