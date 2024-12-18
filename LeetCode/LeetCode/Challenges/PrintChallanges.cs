using LeetCode.Challanges.IsValid;
using LeetCode.Challenges;
using LeetCode.Challenges.AddTwoNumbers;
using LeetCode.Challenges.BackTrack;
using LeetCode.Challenges.BinarySearch;
using LeetCode.Challenges.BinaryTree;
using LeetCode.Challenges.CloneGraphs;
using LeetCode.Challenges.CoderByte.CityTraffic;
using LeetCode.Challenges.EquiavalentKey;
using LeetCode.Challenges.InterSectionOfTwoArray;
using LeetCode.Challenges.LongestCommonPrefix;
using LeetCode.Challenges.Maximumnumberofwords;
using LeetCode.Challenges.MaxWidthOfVerticalAreas;
using LeetCode.Challenges.MergeTwoLists;
using LeetCode.Challenges.RemoveDuplicates;
using LeetCode.Challenges.SlidingWindow;
using LeetCode.Challenges.ThreeSums;
using LeetCode.Challenges.TopKFrequents;
using LeetCode.Challenges.TreeConstructors;
using LeetCode.Challenges.TripleFibonaccis;
using LeetCode.Challenges.TwoSum;
using System.Text.RegularExpressions;


namespace LeetCode.Challanges;
public class PrintChallanges()
{
    static void Main(string[] args)
    {
        int[] numbers = { 1, 1, 1 };
        int target = 2;
        TwoSums twoSums = new TwoSums();
        int[] resultTwoSums = twoSums.TwoSumBinarySearch(numbers, target);
        Console.Write("Target indices : ");
        foreach (int i in resultTwoSums)
            Console.Write(i + " ");
        Console.WriteLine();
        BinarySearch binarySearch = new BinarySearch();
        int[] binarySearchArray = { -3, 0, 4, 6, 14, 16, 19 };
        Console.Write("BinarySearch Target Indices : " + binarySearch.Search(binarySearchArray, 14));
        Console.WriteLine();
        string[] words = new string[] { "flower", "flow", "flight" };
        LongestCommonPrefixs solution = new LongestCommonPrefixs();
        Console.WriteLine(solution.LongestCommonPrefix(words));

        string brackets = "()[]{}";
        string a = "A man, a plan, a canal: Panama";
        IsValidSolution isValidSolution = new IsValidSolution();
        Console.WriteLine("IsPalindrome : " + isValidSolution.IsPalindrome(a));
        Console.WriteLine("IsBrackets : " + isValidSolution.IsValid(brackets));
        Console.WriteLine(isValidSolution.FirstReverse("berat"));

        AddTwoNumbers addTwoNumbers = new AddTwoNumbers();
        ListNode l1 = new ListNode(3);
        l1 = addTwoNumbers.insertAtBeginning(l1, 7); // listenin başına ekleme
        l1 = addTwoNumbers.insertAtBeginning(l1, 2);
        l1 = addTwoNumbers.insertAtBeginning(l1, 4);
        addTwoNumbers.printList(l1);
        l1 = addTwoNumbers.insertInMiddle(l1, 1, 2);
        l1 = addTwoNumbers.insertAtEnd(l1, 9);  // listemizin sonuna ekleme
        ListNode l4 = new ListNode(4);
        ListNode l5 = new ListNode(6);
        ListNode l6 = new ListNode(5);
        l4.next = l5;
        l5.next = l6;
        l6.next = null;
        addTwoNumbers.MiddleNode(l1);
        addTwoNumbers.printList(l4);
        addTwoNumbers.printList(l1);
        l4 = addTwoNumbers.deleteAtEnd(l4);
        l1 = addTwoNumbers.deletefromMiddle(l1, 2);
        l1 = addTwoNumbers.deletefromBeginning(l1);
        addTwoNumbers.printList(l4);
        addTwoNumbers.printList(l1);
        ListNode addedList = addTwoNumbers.AddTwoNumber(l1, l4);
        addTwoNumbers.printList(addedList);
        //addTwoNumbers.ReverseList(l1);
        addTwoNumbers.reverseWithStack(l4);
        Console.WriteLine("REVERSED LIST : ");
        addTwoNumbers.printList(l4);


        MergeTwoLists mergeTwoLists = new MergeTwoLists();
        ListNode list1 = new ListNode(1);
        ListNode list2 = new ListNode(2);
        ListNode list3 = new ListNode(4);
        list1.next = list2;
        list2.next = list3;
        list3.next = null;
        ListNode list4 = new ListNode(1);
        ListNode list5 = new ListNode(3);
        ListNode list6 = new ListNode(4);
        list4.next = list5;
        list5.next = list6;
        list6.next = null;
        ListNode mergedTwoList = mergeTwoLists.MergeTwoList(list1, list4);
        addTwoNumbers.printList(mergedTwoList);
        int[] candies = new int[] { 1, 23, 4, 5, 6 };

        int[][] array2d = { [3, 1], [9, 0], [1, 0], [1, 4], [5, 3], [8, 8] };
        Console.WriteLine("Arrayın ilk elamanı :" + array2d[0][0]);
        MaxWidthOfVerticalAreas maxWidthOfVertical = new MaxWidthOfVerticalAreas();
        int[] sortArray = new int[] { 1, 8, 3, 2, 4, 6 };


        Console.WriteLine("RichestCustomer : " + maxWidthOfVertical.MaximumWealth(array2d));
        Console.WriteLine("En büyük eleman: " + maxWidthOfVertical.returnMax(candies));
        Console.WriteLine(" MaxWidthOfVerticalArea :" + maxWidthOfVertical.MaxWidthOfVerticalArea(array2d));

        Maximum_number_of_words maxWords = new Maximum_number_of_words();
        string[] sentences = ["alice and bob love leetcode", "i think so too", "this is great thanks very much"];
        maxWords.MostWordsFound(sentences);

        RemoveDuplicates remove = new RemoveDuplicates();
        int[] nums = { 0, 0, 1, 1, 2, 2, 3, 3, 4, };
        Console.WriteLine("Tekrar eden duplicate sayısı : " + remove.RemoveDuplicate(nums));

        PlusOne plusOne = new PlusOne();
        int[] digits = { 1, 2, 9 };



        int[] arr1 = { 1, 2, 2, 1 };
        int[] arr2 = { 2, 2 };
        IntersectionOfTwoArrays intersection = new IntersectionOfTwoArrays();
        int[] intersectedArr = intersection.Intersect(arr1, arr2);
        foreach (int i in intersectedArr)
            Console.WriteLine(i);



        TreeNode root = new TreeNode(1, null, null);

        root.left = new TreeNode(2, null, null);
        root.right = new TreeNode(3, null, null);

        TreeNode root2 = new TreeNode(1, null, null);
        root2.left = new TreeNode(2, null, null);
        root2.right = new TreeNode(3, null, null);

        BinaryTree binaryTree = new BinaryTree();

        List<int> inorderList = binaryTree.InorderTraversal(root);
        List<int> inorderListRecursive = binaryTree.InorderTraversalRecursive(root);

        Console.Write("InorderRecursive : ");
        foreach (int i in inorderListRecursive)
            Console.Write(i + " ");
        Console.WriteLine();
        Console.Write("InorderRecursive : ");
        foreach (int i in inorderList)
            Console.Write(i + " ");
        Console.WriteLine();
        Console.WriteLine("LEVEL ORDER TRAVERSAL ");
        binaryTree.LevelOrderTraversal(root);
        Console.WriteLine();
        TripleFibonacci trip = new TripleFibonacci();
        Console.Write("TRIPLE FIBONACCI : ");
        int[] array = trip.Tripple(6);
        foreach (int i in array)
            Console.Write(i + " ");
        Console.WriteLine();
        TopKFrequentSol topK = new TopKFrequentSol();
        int[] topKArray = topK.TopKFrequent(new int[] { 1, 1, 2, 2, 3 }, 2);
        Console.Write("TOPKFrequent :");
        foreach (int i in topKArray)
            Console.Write(i + " ");
        TreeConstructor treeConstructor = new TreeConstructor();
        Console.WriteLine();
        Console.WriteLine("TreeConstructor: " + treeConstructor.IsBinaryTree(new string[] { "(1,2)", "(2,4)", "(5,7)", "(7,2)", "(9,5)" }));
        EquivalentKeypresses equivalentKeypresses = new EquivalentKeypresses();
        Console.WriteLine();
        Console.WriteLine("EquivalentKey : " + equivalentKeypresses.EquivalentKey(new string[] { "a,b,c,d", "a,b,c,d,-B,d" }));
        Console.WriteLine();
        Console.WriteLine("MAXIMUM DEPTH OF TREE : " + binaryTree.MaximumDepth(root));
        Console.WriteLine();
        Console.Write("IsSameTree : " + binaryTree.IsSameTree(root, root2));

        int[] stones = { 2, 7, 4, 1, 8, 1 };
        PriorityQueue<int, int> stoneQueue = new PriorityQueue<int, int>();
        foreach (int i in stones)
            stoneQueue.Enqueue(i, -i);

        Console.WriteLine("Queue Count :" + stoneQueue.Count);
        while (stoneQueue.Count > 0)
            Console.WriteLine("Item Popped From Queue:" + stoneQueue.Dequeue());
        SlidingWindow slidingWindow = new SlidingWindow();
        int[] maximumAverageArray = { 1, 12, -5, -6, 50, 3 };
        String s = "abcabcbb";
        Console.WriteLine("MaximumAverageSubArray : " + slidingWindow.MaximumAverageSubArray(maximumAverageArray, 4));
        Console.WriteLine("LongestSubstringWithoutRepetingCharacter : " + slidingWindow.LongestSubstringWithoutRepatingCharacter(s));
        int[] minumumSubArray = { 1, 1, 1, 1, 1 };
        Console.WriteLine("MinumumSubArrayLen : " + slidingWindow.MinSubArrayLen(7, minumumSubArray));
        int x = 1;
        int y = 2;
        Console.Write("x: " + x + "y: " + y);
        Console.WriteLine();
        Swap(ref x, ref y);
        Console.Write("x: " + x + "y: " + y);
        void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        Console.WriteLine();

        string strParam = "<div>abc</div><p><em><i>test test test</b></em></p>";
        HtmlElements html = new HtmlElements();
        Console.WriteLine("HTML ELEMENTS RETURN : " + html.HtmlElement(strParam));

        Console.WriteLine();
        int[] rotateArrLeft = { 1, 2, 3, 4, 5, 6, 7 };
        Console.WriteLine(string.Join(",", rotateArrLeft));
        RotateArray rotateArray = new RotateArray();
        Console.WriteLine("Rotated Left");
        Console.WriteLine(string.Join(",", rotateArray.RotateLeft(rotateArrLeft, 3)));
        Console.WriteLine();
        int[] rotateArrRight = { 1, 2, 3, 4, 5, 6, 7 };
        Console.WriteLine(string.Join(",", rotateArrRight));
        Console.WriteLine("Rotated Right");
        Console.WriteLine(string.Join(",", rotateArray.RotateRight(rotateArrRight, 3)));

        BackTracking backtracking = new BackTracking();
        int[] backTrackNums = { 1, 2, 3 };
        int[] backTrackDuplicateNums = { 1, 2, 2 };
        IList<IList<int>> returnSubset = backtracking.Subsets(backTrackNums);
        foreach (List<int> i in returnSubset)
        {
            Console.WriteLine(string.Join(" ", i));
        }
        IList<IList<int>> returnSubset2 = backtracking.Subsets2(backTrackDuplicateNums);
        Console.WriteLine("------BackTrackWithoutDuplicate---------");
        foreach (List<int> i in returnSubset2)
        {
            Console.WriteLine(string.Join(" ", i));
        }
        IList<IList<int>> permutations = backtracking.Permute(backTrackNums);
        Console.WriteLine("-----Permutations-----");
        foreach (List<int> i in permutations)
            Console.WriteLine(string.Join(" ", i));
        IList<string> parentheses = backtracking.GenerateParentheses(3);
        Console.WriteLine("------PARENTHESES-----");
        foreach (string str in parentheses)
            Console.WriteLine(str);

        Console.WriteLine("------PhoneLetters-------");
        IList<string> phoneLetters = backtracking.LetterCombinations("2");
        foreach (string str in phoneLetters)
            Console.WriteLine(str);


        Console.WriteLine("------ThreeSumArray-------");
        ThreeSum sum = new ThreeSum();
        int[] threeSumArray = { -1, 0, 1, 2, -1, -4 };
        IList<IList<int>> threeSumList = sum.threeSum(threeSumArray);
        foreach (List<int> i in threeSumList)
            Console.WriteLine(string.Join(" ", i));

        Graph g = new Graph(4);
        g.PrintMatrix();
        g.AddEdge(1, 2);
        g.AddEdge(1, 4);
        g.AddEdge(2, 3);
        g.AddEdge(4, 3);
        g.AddEdge(1, 3);
        Console.WriteLine("Added Edges (1,2),(1,4),(1,3),(2,3),(3,4)");
        g.PrintMatrix();
        g.RemoveEdge(3, 1);
        Console.WriteLine("Removed Edge (1,3)");
        g.PrintMatrix();
        g.AddVertex();
        Console.WriteLine("Added Vertex");
        g.PrintMatrix();
        g.AddEdge(1, 5);
        g.AddEdge(2, 5);
        Console.WriteLine("Added Edge (1,5),(2,5)");
        g.PrintMatrix();
        g.RemoveEdge(1, 5);
        Console.WriteLine("Removed Edge (1,5)");
        g.PrintMatrix();
        g.RemoveVertex(5);
        Console.WriteLine("Removed Vertex (5)");
        g.PrintMatrix();

        AdjacencyListGraph listGraph = new AdjacencyListGraph();
        listGraph.AddVertex(1);
        listGraph.AddVertex(2);
        listGraph.AddVertex(3);
        listGraph.AddVertex(4);
        listGraph.AddVertex(5);
        listGraph.AddEdge(1, 2);
        listGraph.AddEdge(1, 3);
        listGraph.AddEdge(1, 4);
        listGraph.AddEdge(2, 3);
        listGraph.AddEdge(3, 5);
        listGraph.PrintListGraph();
        Console.WriteLine("-----DFS ITERATE GRAPH-----");
        listGraph.DFSIterative(1);
        Console.WriteLine();
        Console.WriteLine("-----DFS RECURSIVE GRAPH-----");
        listGraph.DFS(1);
        Console.WriteLine();
        Console.WriteLine("-----BFS ITERATE GRAPH-----");
        listGraph.BFSIterative(1);

        Console.WriteLine();

        string sl = "ADOBECODEBANC";
        string t = "ABC";
        Console.WriteLine("MinumumWindowSubstring :" + slidingWindow.MinWindowSubstring(sl, t));

        CityTraffic city = new CityTraffic();
        string[] cities = { "1:[5]", "4:[5]", "3:[5]", "5:[1,4,3,2]", "2:[5,15,7]", "7:[2,8]", "8:[7,38]", "15:[2]", "38:[8]" };

        Console.WriteLine(city.cityTraffic(cities));


        Console.WriteLine("-----Cloned Graph-----");

        Node node1 = new Node(1);
        Node node2 = new Node(2);
        Node node3 = new Node(3);
        Node node4 = new Node(4);

        node1.neighbors = new List<Node>() { node2, node3 };
        node2.neighbors = new List<Node>() { node1, node4 };
        node3.neighbors = new List<Node>() { node1, node4 };
        node4.neighbors = new List<Node>() { node2, node3 };

        CloneGraph cloneGraph = new CloneGraph();

        Node clonedGraph = cloneGraph.Clone(node1);

        Console.Write(clonedGraph.val+"--->");
        foreach(Node node  in clonedGraph.neighbors)
        {
            Console.Write(node.val+" ");
        }

        



    }

}

