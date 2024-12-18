using LeetCode.Challenges.BinaryTree;

namespace LeetCode.Challenges.AddTwoNumbers
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public class AddTwoNumbers
    {

        public void printList(ListNode listNode)
        {
            ListNode print = listNode;
            if (print != null)
            {
                Console.WriteLine(listNode + "List Contains : ");
                while (print != null)
                {
                    Console.WriteLine(print.val);
                    print = print.next;
                }
            }
            else
            {
                Console.WriteLine("List is empty");
            }
        }
        public ListNode insertAtBeginning(ListNode head, int data)
        {
            ListNode new_node = new ListNode(data); // Create a node to insert
            new_node.next = head;
            head = new_node;
            return head;
        }
        public ListNode insertInMiddle(ListNode head, int data, int position)
        {
            ListNode new_node = new ListNode(data);
            ListNode ptr = head;

            for (int i = 1; i < position; i++)
            {
                ptr = ptr.next;
            }

            new_node.next = ptr.next;
            ptr.next = new_node;


            return head;


        }
        public ListNode insertAtEnd(ListNode head, int data)
        {
            ListNode new_node = new ListNode(data); //Create a node to insert

            ListNode ptr = head; // Head'ı  Listeyi gezeceğimiz pointer 'a atıyoruz.
            while (ptr.next != null)
                ptr = ptr.next; // listenini sonuna gidiyoruz.

            ptr.next = new_node; // listeninin sonunun nextini yeni düğümüüze atadık

            return head; // sonradan listemizi döndük.

        }

        public ListNode deletefromBeginning(ListNode head)
        {
            head = head.next; // Just move the head to the next position

            return head; // return the new head
        }

        public ListNode deletefromMiddle(ListNode head, int position)
        {
            ListNode ptr = head;
            for (int i = 1; i < position; i++)
            {
                ptr = ptr.next;
            }

            ListNode nodeToDelete = ptr.next; // Get the node to delete

            ListNode nextNode = nodeToDelete.next;// Point the next of ptr to nextNode

            ptr.next = nextNode;

            //return the original head
            return head;

        }
        public ListNode removeElements(ListNode head, int val)
        {
            ListNode temp = new ListNode(0);  // boş bir temp node oluşturuyoruz onu head önce yapıyoruzki ilk head node'nu nda kontrol edebilelim.
            temp.next = head;
            ListNode ptr = temp;

            while (ptr.next != null)
            {
                if (ptr.next.val == val)
                {
                    ptr.next = ptr.next.next;
                }
                else
                {
                    ptr = ptr.next;
                }
            }
            return temp.next;
        }
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            //1 2 3 4 5  n =1
            //
            ListNode dummyNode = new ListNode(0);
            dummyNode.next = head;
            ListNode firstPtr = head;
            ListNode secondPtr = head;

            for (int i = 0; i < n; i++)
            {
                secondPtr = secondPtr.next;
            }

            while (secondPtr.next != null)
            {
                firstPtr = firstPtr.next;
                secondPtr = secondPtr.next;
            }
            firstPtr.next = firstPtr.next.next;

            return dummyNode.next;
        }

        public void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }

        public ListNode deleteAtEnd(ListNode head)

        {
            ListNode ptr = head; // move to the second last node

            while (ptr.next.next != null)
                ptr = ptr.next;

            ptr.next = null; // point the next of second last node to null 

            return head; // return the original head
        }


        public ListNode reverseWithStack(ListNode head)
        {
            Stack<int> stack = new Stack<int>();
            // 1 2 3 4 5  
            while (head != null)
            {
                stack.Push(head.val);
                head = head.next;
            }
            ListNode ans = new ListNode(0);
            ListNode reversedList = ans;

            while (stack.Count != 0)
            {
                ans.next = new ListNode(stack.Pop());
                ans = ans.next;
            }
            return reversedList.next;

        }//With Stack

        public ListNode ReverseListWithNode(ListNode head)//With Ptr
        {
            if (head == null)
                return null;
            if (head.next == null)
                return head;

            ListNode prev = null;
            ListNode curr = head;

            while (curr != null)
            {
                ListNode nextNode = curr.next;
                curr.next = prev;
                prev = curr;
                curr = nextNode;
            }
            return prev;
        }

        public ListNode MiddleNode(ListNode head)
        {
            ListNode ptr = head;
            ListNode temp = head;
            int count = 0;

            // 1 2 3
            while (ptr != null)
            {
                count++;
                ptr = ptr.next;
            }

            int middle = count / 2;

            while (middle > 0)
            {
                middle--;
                temp = temp.next;
            }
            return temp;
        }

        public ListNode MiddleNodeTwoPointers(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode fast = head;
            ListNode slow = head;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }
        public ListNode GetIntersectionNodeWithSet(ListNode headA, ListNode headB) //Solution with set Time O(n+m) Space O(n)
        {
            HashSet<ListNode> set = new HashSet<ListNode>();

            while (headA != null)
            {
                set.Add(headA);
                headA = headA.next;
            }
            while (headB != null)
            {
                if (set.Contains(headB))
                    return headB;
                headB = headB.next;
            }
            return null; //Otherwise we dont have intersection so return null
        }
        public ListNode GetIntersection(ListNode headA, ListNode headB) //Space Optimized Solution Time O(n+m) Space O(1)
        {
            int lenA = getListLength(headA);
            int lenB = getListLength(headB);

            while (lenA > lenB)
            {
                lenA--;
                headA = headA.next;
            }

            while (lenB > lenA)
            {
                lenB--;
                headB = headB.next;
            }
            //Now both heads are the same distance from intersection
            //Start moving them both until they meet

            while (headA != headB)
            {
                headA = headA.next;
                headB = headB.next;
            }
            return headA;
        }

        private int getListLength(ListNode head)
        {
            ListNode ptr = head;
            int count = 0;
            while (ptr != null)
            {
                ptr = ptr.next;
                count++;
            }
            return count;
        }



        public ListNode AddTwoNumber(ListNode l1, ListNode l2)
        {
            ListNode returnNode = new ListNode(0);
            ListNode ptr = returnNode;
            int carry = 0;

            while (l1 != null || l2 != null)
            {
                int sum = 0 + carry;
                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }
                carry = sum / 10;
                sum = sum % 10;
                ptr.next = new ListNode(sum);
                ptr = ptr.next;


            }
            if (carry == 1) // eğer en son kalan 1  ise en son node'a 1 yaz
                ptr.next = new ListNode(1);
            return returnNode.next;

        }

    }
}


