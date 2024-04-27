using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
namespace IIS_Project
{
    internal class clsNearestNeighborsAlgo
    {

        // The Nearest Neighbor algorithm is a simple heuristic method used to find an approximate solution for the Traveling Salesman Problem(TSP).
        // It starts from a chosen city and repeatedly selects the closest unvisited city to the current city until all cities have been visited, forming a tour
        // What we visited We cann't back to it again even that the cost is small 
        //Time Complexity: The time complexity of the Nearest Neighbor algorithm is O(n^2), where n is the number of cities.
        // This is because, in each iteration, the algorithm needs to find the nearest unvisited city, which requires comparing distances between the current city and all unvisited cities.
        // Space Complexity: The space complexity is O(n), as the algorithm needs to store information about the visited cities and the tour.
        public static List<clsPointWithName> NearestNeighbor(List<clsPointWithName> cities)
        {
            List<clsPointWithName> tour = new List<clsPointWithName>(); // Initialize variable to store the best tour

            if (cities.Count < 2)
            {
                return tour; // return null 
            }

            // Initialize hashset variable to store the visited citites 
            HashSet<int> visited = new HashSet<int>(); // hashset prevent repating 
            tour.Add(cities[0]); // add first City 
            visited.Add(0);  // add to visited hashset  ==> mark as Visited 


            
            while (visited.Count < cities.Count)
            {
                int nearest = -1;
                double minDist = double.MaxValue; // maxvalue for make comparison 
                // the first time is tour[0] 
                // and then +1 
                clsPointWithName currentCity = tour[tour.Count - 1]; 

                // loop 
                for (int i = 0; i < cities.Count; i++)
                {   
                    // is the hashset contains this value or not 
                    
                    if (!visited.Contains(i))
                    {   // if not contains the value 
                        // Calculate the distance between this point and the next one  
                        double dist = TSP_Main_Screen.Distance(currentCity.Location, cities[i].Location);
                        // first time will be small and then will check the distance is smaller than the last city or not  
                        if (dist < minDist)
                        {
                            minDist = dist;
                            // make the nearest city what we are standing on
                            nearest = i;
                        }
                    }
                }


                if (nearest != -1)
                { // add the nearest city to the tour 
                    tour.Add(cities[nearest]);
                    // add the nearest city to the visited elso
                    visited.Add(nearest);
                }
            }

            // After all itration return the tour list with the 

            return tour;
        }

    }
}
