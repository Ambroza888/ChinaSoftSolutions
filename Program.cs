using System;
using System.Collections.Generic;

namespace China_C_
{
    class Program
    {
        static void Main(string[] args)
        {
            //////////////// CoinChange Input///////////////
            int[] coinARR = {1,2,5};
            int[] coinARR2 = {2};
            Console.WriteLine(CointChange(coinARR,11));
            Console.WriteLine(CointChange(coinARR2,3));
            /////////////////// Find triplets //////
            int[] arrayS = {-1,0,1,2,-1,-4};
            threeSum(arrayS);
        }


        ///// CoinChange 0(n^2) Solution ///////////////////////////
        public static int CointChange(int[] coins, int amount)
        {
            int N = coins.Length;
            int[] newarray = new int[amount+1];

            for (int i = 1 ; i <= amount; i++)
            {
                newarray[i] = int.MaxValue;
                for (int j =0 ; j < N; j++)
                {
                    int temp = i - coins[j];
                    if(temp >= 0 && newarray[temp] != int.MaxValue)
                    {
                        newarray[i] = Math.Min(newarray[i],newarray[temp] + 1);
                    }
                }
            }
            if (newarray[amount] == int.MaxValue)
            {
                return -1;
            }
            return newarray[amount];
        }

        //////////////////////////// LevelOrder 0(n^2) /////////////////////////
        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            var allnodes = new List<IList<int>>();
            if (root == null)
            {
                return allnodes;
            }
            Queue<TreeNode> myQueue = new Queue<TreeNode>();
            myQueue.Enqueue(root);
            
            while(myQueue.Count > 0)
            {
                int currentSizeLevel = myQueue.Count;

                List<int> levelNodes = new List<int>();

                int i = 0;

                while (i < currentSizeLevel)
                {
                    TreeNode mynode = myQueue.Peek();
                    myQueue.Dequeue();
                    levelNodes.Add(mynode.value);

                    if(mynode.left != null)
                    {
                        myQueue.Enqueue(mynode.left);
                    }
                    if(mynode.right != null)
                    {
                        myQueue.Enqueue(mynode.right);
                    }
                    i++;
                }
                allnodes.Add(levelNodes);
            }
            return allnodes;
        }
        ////////////// Find triplets  ///////////////////
        public static List<List<int>> threeSum(int[] arr)
        {
            List<List<int>> result = new List<List<int>>();
            Array.Sort(arr);

            int n = arr.Length;

            for (int i = 0; i < n; i++)
            {
                int start = i + 1;
                int end = n - 1;
                
                if(i > 0 && arr[i] == arr[i-1])
                {
                    continue;
                }
                while (start < end)
                {
                    if (end < n - 1 && arr[end] == arr[end+1])
                    {
                        end--;
                        continue;
                    }
                    if (arr[i] + arr[start] + arr[end] == 0)
                    {
                        List<int> val = new List<int>()
                        {
                            arr[i],arr[start],arr[end]
                        };
                        result.Add(val);
                        start ++;
                        end --;
                    }
                    else if( arr[i] + arr[start] + arr[end] < 0)
                    {
                        start++;
                    }
                    else
                    {
                        end--;
                    }
                }
            }
            foreach ( var i in result)
            {
                Console.WriteLine(i);
            }
            return result;
        }
    }





    // Creating TreeNode Class === could be in separate cs but for readability i keep it here.
    public class TreeNode
    {
        public int value;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val) {value = val;}
    }
}
