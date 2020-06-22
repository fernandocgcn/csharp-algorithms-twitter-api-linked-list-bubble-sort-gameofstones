namespace Challenges
{
    public static class Solution
    {
        /*
         * The first player always loses when the same pattern is repeated; 
         * the number of stones is divisible by seven or 
         * is an additional number from a number divisible by seven.
         */
        public static string GameOfStones(int n)
        {
            return n % 7 == 0 || (n - 1) % 7 == 0 ? "Second" : "First";
        }
    }
}
