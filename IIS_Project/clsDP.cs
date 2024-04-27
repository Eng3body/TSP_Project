using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS_Project
{
    internal class clsDP
    {
        public static List<clsPointWithName> HeldKarpTSP(List<clsPointWithName> cities)
        {

  

            int n = cities.Count;

            // Initialize DP table
            double[,] dp = new double[n, 1 << n];
            int[,] parent = new int[n, 1 << n];

            // Fill DP table with initial values
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < (1 << n); j++)
                {
                    dp[i, j] = double.PositiveInfinity;
                    parent[i, j] = -1;
                }
            }

            // Base case: starting from city 0 and visiting no other cities
            dp[0, 1] = 0;

            // Iterate over all subsets of cities
            for (int maskL = 1; maskL < (1 << n); maskL++)
            {
                for (int last = 0; last < n; last++)
                {
                    if ((maskL & (1 << last)) == 0) continue;

                    for (int curr = 0; curr < n; curr++)
                    {
                        if ((maskL & (1 << curr)) == 0 || curr == last) continue;

                        double prevDist = dp[last, maskL ^ (1 << curr)];
                        double newDist = prevDist +TSP_Main_Screen.Distance(cities[curr].Location, cities[last].Location);

                        if (newDist < dp[curr, maskL])
                        {
                            dp[curr, maskL] = newDist;
                            parent[curr, maskL] = last;
                        }
                    }
                }
            }

            // Reconstruct the optimal tour
            List<clsPointWithName> tour = new List<clsPointWithName>();
            int u = 0;
            int maskLFinal = (1 << n) - 1;

            // Find the last city in the tour
            double minDist = double.PositiveInfinity;
            for (int v = 1; v < n; v++)
            {
                double dist = dp[v, maskLFinal] + TSP_Main_Screen.Distance(cities[v].Location, cities[0].Location);
                if (dist < minDist)
                {
                    minDist = dist;
                    u = v;
                }
            }

            // Reconstruct the tour backwards
            int mask = maskLFinal;
            while (parent[u, mask] != -1)
            {
                tour.Add(cities[u]);
                int nextU = parent[u, mask];
                mask ^= (1 << u);
                u = nextU;
            }
            tour.Add(cities[0]); // Add the starting city to complete the tour

            tour.Reverse(); // Reverse the tour to start from the starting city

            return tour;
        }

    }
}
