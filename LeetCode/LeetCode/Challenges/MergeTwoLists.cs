using LeetCode.Challenges.AddTwoNumbers;

namespace LeetCode.Challenges.MergeTwoLists
{
    public class MergeTwoLists
    {
        public ListNode MergeTwoList(ListNode list1, ListNode list2)
        {
            ListNode l1 = list1;
            ListNode l2 = list2;

            ListNode returnNode = new ListNode(0);
            ListNode headNode = returnNode;


            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    returnNode.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    returnNode.next = l2;
                    l2 = l2.next;
                }
                returnNode = returnNode.next;
            }

            if (l1 == null)
                returnNode.next = l2;
            else if (l2 == null)
                returnNode.next = l1;

            return headNode.next;


        }


    }
}
