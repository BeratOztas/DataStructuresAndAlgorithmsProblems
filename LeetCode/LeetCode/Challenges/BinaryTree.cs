using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Challenges.BinaryTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val, TreeNode left, TreeNode right)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
        public TreeNode(int val)
        {
            this.val = val;
        }
    }
    public class BinaryTree
    { // 1 2 3
        List<int> ans = new List<int>();
        public List<int> InorderTraversal(TreeNode root)  // LEFT > ROOT > RIGHT
        {
            List<int> result = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            HashSet<TreeNode> visitedSet = new HashSet<TreeNode>();
            if (root != null)
                stack.Push(root);

            while (stack.Count > 0)
            {
                TreeNode node = stack.Peek();
                if (node.left != null && !visitedSet.Contains(node.left))
                {
                    stack.Push(node.left);
                }
                else
                {
                    TreeNode stackNode = stack.Pop();
                    visitedSet.Add(stackNode);
                    result.Add(stackNode.val);

                    if (node.right != null && !visitedSet.Contains(node.right))
                    {
                        stack.Push(node.right);
                    }
                }
            }
            return result;
        }
        public List<int> PreOrderTraversal(TreeNode root) // ROOT > LEFT > RIGHT // NO NEED HASHSET
        {
            List<int> result = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            if (root != null)
                stack.Push(root);

            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();
                result.Add(node.val);
                if (node.right != null)
                    stack.Push(node.right);
                if (node.left != null)
                    stack.Push(node.left);
            }
            return result;

        }
        public List<int> PostOrderTraversal(TreeNode root)  // LEFT > RIGHT > ROOT
        {
            List<int> result = new List<int>();
            HashSet<TreeNode> visitedSet = new HashSet<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            if (root != null)
                stack.Push(root);

            while (stack.Count > 0)
            {
                TreeNode node = stack.Peek();
                if (node.left != null && !visitedSet.Contains(node.left))
                    stack.Push(node.left);
                else if (node.right != null && !visitedSet.Contains(node.right))
                    stack.Push(node.right);
                else
                {
                    TreeNode stackNode = stack.Pop();
                    visitedSet.Add(stackNode);
                    result.Add(stackNode.val);
                }
            }
            return result;
        }
        public List<int> InorderTraversalRecursive(TreeNode root)// recursive solution
        {
            if (root == null)
                return ans;
            InorderTraversalRecursive(root.left);
            ans.Add(root.val);
            InorderTraversalRecursive(root.right);
            return ans;
        }
        public int RangeSumOfBST(TreeNode root, int low, int high) //DFS (Inorder,PostOrder,PreOrder)
        {
            if (root == null)
                return 0;
            int sum = 0;

            if (root.val > low)
                sum += RangeSumOfBST(root.left, low, high);
            if (root.val >= low && root.val <= high)
                sum += root.val;
            if (root.val < high)
                sum += RangeSumOfBST(root.right, low, high);

            return sum;
        }
        public void LevelOrderTraversal(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode treeNode = queue.Dequeue();
                Console.Write(treeNode.val + " ");

                if (treeNode.left != null)
                    queue.Enqueue(treeNode.left);

                if (treeNode.right != null)
                    queue.Enqueue(treeNode.right);
            }
        }

        public int MaximumDepth(TreeNode root) // BFS (Level Order)
        {
            if (root == null)
                return 0;
            Queue<TreeNode> elementQueue = new Queue<TreeNode>();
            elementQueue.Enqueue(root);
            int levelOfTree = 0;

            while (true)
            {
                int nodeCountAtLevel = elementQueue.Count;
                if (nodeCountAtLevel == 0)
                    return levelOfTree;
                while (nodeCountAtLevel > 0)
                {
                    TreeNode element = elementQueue.Dequeue();
                    if (element.left != null)
                        elementQueue.Enqueue(element.left);
                    if (element.right != null)
                        elementQueue.Enqueue(element.right);
                    nodeCountAtLevel--;
                }
                levelOfTree++;
            }
        }
        public int MinumumDepth(TreeNode root) // BFS (Level Order)
        {
            if (root == null) return 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            int depth = 1;
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();

                    if (node.left == null && node.right == null)
                        return depth;
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
                depth++;
            }
            return depth;

        }
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(p);
            queue.Enqueue(q);

            while (queue.Count > 0)
            {
                TreeNode first = queue.Dequeue();
                TreeNode second = queue.Dequeue();

                if (first == null && second == null)
                    continue;
                else if (first == null || second == null || first.val != second.val)
                    return false;

                queue.Enqueue(first.left);
                queue.Enqueue(second.left);
                queue.Enqueue(first.right);
                queue.Enqueue(second.right);
            }
            return true;
        }
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;
            Queue<TreeNode> leftTree = new Queue<TreeNode>();
            Queue<TreeNode> rightTree = new Queue<TreeNode>();

            leftTree.Enqueue(root.left);
            rightTree.Enqueue(root.right);


            while (leftTree.Count > 0 && rightTree.Count > 0)
            {
                TreeNode leftNode = leftTree.Dequeue();
                TreeNode rightNode = rightTree.Dequeue();

                if (leftNode == null && rightNode == null)
                    continue;
                if (leftNode == null || rightNode == null || leftNode.val != rightNode.val)
                    return false;

                leftTree.Enqueue(leftNode.left);
                leftTree.Enqueue(leftNode.right);
                rightTree.Enqueue(rightNode.right);
                rightTree.Enqueue(rightNode.left);
            }
            return true;

        }
        public List<int> RightSideView(TreeNode root) // BFS 
        {
            List<int> result = new List<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            if (root != null)
                queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();
                    if (node.right != null)
                        queue.Enqueue(node.right);
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (i == 0)
                        result.Add(node.val);
                }
            }
            return result;
        }
        public TreeNode InvertTree(TreeNode root) // BFS LEVEL ORDER TRAVERSAL
        {
            if (root == null)
                return root;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                TreeNode temp = node.left;
                node.left = node.right;
                node.right = temp;

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
            return root;
        }

        public TreeNode InvertTreeRecursive(TreeNode root) // DFS RECURSIVE
        {
            if (root == null)
                return root;

            TreeNode left = InvertTreeRecursive(root.left);
            TreeNode right = InvertTreeRecursive(root.right);

            root.left = right;
            root.right = left;

            return root;
        }

        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null)
                return new TreeNode(val);

            TreeNode currentNode = root;

            while (true)
            {
                if (currentNode.val < val)
                {
                    if (currentNode.right != null)
                    {
                        currentNode = currentNode.right;
                    }
                    else
                    {
                        currentNode.right = new TreeNode(val);
                        break;
                    }
                }
                else
                {
                    if (currentNode.left != null)
                    {
                        currentNode = currentNode.left;
                    }
                    else
                    {
                        currentNode.left = new TreeNode(val);
                        break;
                    }

                }
            }
            return root;
        }

        public bool isValidBST(TreeNode root) //Inorder Traversal(//1,2,3) descending order 
        {
            List<int> list = new List<int>();
            InOrderTraversalValid(root, list);
            int prev = list[0];

            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] <= prev)
                    return false;

                prev = list[i];
            }

            return true;
        }

        private void InOrderTraversalValid(TreeNode root, List<int> list)
        {
            if (root == null)
                return;

            InOrderTraversalValid(root.left, list);
            list.Add(root.val);
            InOrderTraversalValid(root.right, list);

        }





    }
}
