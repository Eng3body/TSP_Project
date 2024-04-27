using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IIS_Project
{
    internal static class clsBruteForce
    {

        // here a problem this Algo don't Take more than 10 points :-(
        // The Brute Force algorithm is a straightforward approach for solving problems by systematically checking all possible solutions.
        // It works well for small input sizes but becomes impractical for large input sizes due to its exponential time complexity.
        // give us the optimal Solution but not the Effictient 

        public static List<clsPointWithName> BruteForceTSP(List<clsPointWithName> cities)
        {
            // Generate all possible permutations of cities
            var permutations = GeneratePermutations(cities);

            // Initialize variables to store the best tour and its distance
            List<clsPointWithName> bestTour = null;
            double bestDistance = double.MaxValue;

            // Iterate through all permutations and calculate the total distance for each tour
            
            foreach (var permutation in permutations)
            {
                // Compute the total distance for each permutation: For each permutation, calculate the total distance traveled by visiting the cities in that order.

                double distance = TSP_Main_Screen.CalculateTotalDistance(permutation);

                // Select the permutation with the minimum total distance: Choose the permutation with the shortest total distance as the solution to the TSP.
                if (distance < bestDistance)
                {
                    bestDistance = distance;
                    bestTour = permutation;
                }
            }

            return bestTour;
        }



        // permutations ==> means تباديل او احتمالات

        // Brute Force Algorithm for TSP:
        // 1-Generate all possible permutations: Generate all possible permutations of the cities.
        // Each permutation represents a possible order in which the cities can be visited.
      
        public static List<List<clsPointWithName>> GeneratePermutations(List<clsPointWithName> cities)
        {
            List<List<clsPointWithName>> permutations = new List<List<clsPointWithName>>();

            // Base case: if there is only one city, return a list containing just that city
            if (cities.Count == 1)
            {
                permutations.Add(cities);
                return permutations;
            }

            
            clsPointWithName firstCity = cities[0]; // add the first city 

            // Skip the first city and add the remaining  
            List<clsPointWithName> remainingCities = cities.Skip(1).ToList();
            // Recursively generate permutations for all cities except the first one
            var subPermutations = GeneratePermutations(remainingCities);

            // After that 
            // Insert the first city at all possible positions in each sub-permutation
            foreach (var subPermutation in subPermutations)
            {
                for (int i = 0; i <= subPermutation.Count; i++)
                { 
                    List<clsPointWithName> permutation = new List<clsPointWithName>(subPermutation);
                    permutation.Insert(i, firstCity);
                    permutations.Add(permutation);
                }
            }

            return permutations;
        }
    }
}
