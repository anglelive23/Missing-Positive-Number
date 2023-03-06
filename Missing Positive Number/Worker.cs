using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Missing_Positive_Number
{
    public class Worker
    {
        public Worker()
        {
            Work();
        }

        public void Work()
        {
            int[] nums = new int[] { 2, 3, 4, 7, 11 };
            int num = FindKthPositive(nums, 1);
            Console.WriteLine(num);
        }

        private int FindKthPositive(int[] nums, int target)
        {
            int iter = 0;
            int[] temp = new int[target];
            if (nums[0] != 1)
                temp[iter++] = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                var current = nums[i];
                var previous = nums[i - 1];

                if (current - previous != 1)
                {
                    var indexer = 0;
                    while (indexer < (current - previous) - 1 && iter < target)
                    {
                        temp[iter++] = previous + (++indexer);
                    }
                }
            }

            while (iter < target)
            {
                temp[iter] = nums[nums.Length - 1] + (iter++ + 1);
            }

            return temp[target - 1];
        }
    }
}
