namespace LeetCode.Challenges.InterSectionOfTwoArray
{
    public class IntersectionOfTwoArrays
    {
        // 1,2,2,1
        // 2,2
        public int[] Intersect(int[] nums1,int[] nums2)
        {
           Dictionary<int,int> dict=new Dictionary<int,int>();
            //1 2 
            //2 2
            List<int> result =new List<int>();  

            foreach(int i in nums1)
            {
                if (dict.ContainsKey(i))
                    dict[i]++;
                else
                    dict.Add(i,1);
            }

            foreach(int i in nums2)
            {

                if (dict.ContainsKey(i))
                {
                    result.Add(i);
                    dict[i]--;
                    if (dict[i] == 0)
                        dict.Remove(i);
                }
            }

            return result.ToArray();

        }  
    }
}
