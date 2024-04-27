using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace IIS_Project
{
    internal partial class TSP_Main_Screen : Form
    {

       // initialize properties to use it 

        private List<clsPointWithName> _cities { get; set; }  // create list object from clsPointWithName for the cities we created 
        private List<clsPointWithName> _tour  { get; set; }  // create list object from clsPointWithName  for the cities we visited 
        private double _totalDistance { get; set; } 
        private bool _algorithmRun { get; set; }
        
        public TSP_Main_Screen()
        { // this is defuat Constractor when we start the programe 
            InitializeComponent();
            // initialize the new list for _Citites 
            _cities = new List<clsPointWithName>();
            // initialize the new list for _tour 
            _tour = new List<clsPointWithName>();
            _totalDistance = 0;
            _algorithmRun = false;
        }

        // this for when i click on the screen 
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
        
            // check if the algo is selectes and the mouse click or not 
            if (!_algorithmRun && e.Button == MouseButtons.Left) // O(1)
            {   
                // show the Dialog on the screen 
                string cityName = clsPrompt.ShowDialog("Enter city name:", "City Name");
                // check if the city name is exits in the _cititeslist or not && is not empty name 
                if (!string.IsNullOrWhiteSpace(cityName) && !IsCityNameRepeated(cityName))  // O(1) 
                {
                    // add the city to the list with name and location
                    _cities.Add(new clsPointWithName(e.Location, cityName)); // O(1)

                    Refresh(); // this is method in c# controls 

                    /// calling Refresh() forces the control and its children to redraw themselves immediately,
                    /// ensuring that any changes you've made to their appearance or content are immediately visible on the screen.
                }
                else
                {
                    // show invalied city 
                    MessageBox.Show("Invalid city name. Please enter a unique name.");
                }
            }
        }

        // this function for loop on Citties and check if it's reapated or not
        
        private bool IsCityNameRepeated(string cityName)
        {

            foreach (clsPointWithName city in _cities) // O(N)
            {
                // if the city is repated return True else return Fales 
                if (city.Name.Equals(cityName, StringComparison.OrdinalIgnoreCase)) // O(1)
                {
                    return true; // O(1)
                }
            }
            return false; // O(1)
        }


        // there are a funtion called OnPaint in WidowsForm 
        // But we need to Make some more Actions 
        protected override void OnPaint(PaintEventArgs e)
        {
            // send for the WidowsForm Function
            base.OnPaint(e);


            
            foreach (clsPointWithName city in _cities) //O(N)
            {
                // drow the point before we visite  
                e.Graphics.FillEllipse(Brushes.Red, city.Location.X - 5, city.Location.Y - 5, 10, 10);
                // draw the name of point 
                e.Graphics.DrawString(city.Name, Font, Brushes.Black, city.Location.X + 10, city.Location.Y - 5);
            }


            

            foreach (clsPointWithName city in _tour) //O(N)
            {
                // Chane the Color of The Cities we visited 
                e.Graphics.FillEllipse(Brushes.Blue, city.Location.X - 5, city.Location.Y - 5, 10, 10);
            }



            if (_tour.Count > 1) //O(1)
            {

                for (int i = 1; i < _tour.Count; i++) //O(N)
                { 
                    // draw the path between the cities 
                    e.Graphics.DrawLine(Pens.Black, _tour[i - 1].Location, _tour[i].Location);
                }
                // this if we want to return to the first City 
                e.Graphics.DrawLine(Pens.Black, _tour[_tour.Count - 1].Location, _tour[0].Location);
            }

            // Display total distance  on the screen 
            e.Graphics.DrawString($"Total Distance: {_totalDistance}", Font, Brushes.Black, new PointF(10, 10));

            // Display chosen path on the screen 
            if (_algorithmRun)
            {
                string pathText = "Chosen Path: ";
                foreach (clsPointWithName city in _tour)
                {
                    pathText += city.Name + " -> ";
                }
                pathText += _tour[0].Name; // Add the starting city again to complete the cycle ==> we can remove it if we don't to return to the first city 
                // Show the string 
                e.Graphics.DrawString(pathText, Font, Brushes.Black, new PointF(10, 30));
            }
        }
        
        private void btnCalculate_Click(object sender, EventArgs e) 
        {
            // All this Function Complixty is //O(1)
            // here the all code to check what kind of Alog We Chose 
            // here if we choose to solve it Manual 
            if (cbxAlgorithms.SelectedIndex == 0 && _cities.Count >= 2)
            {



                MessageBox.Show($"Here We Choosen The Path Manual");

            }
            // if We Choose Brute Force 
            else if (cbxAlgorithms.SelectedIndex == 1 && _cities.Count >= 2)
            {
                // After Applied Brute force on Citities list Return it And Save in Tour list
                _tour = clsBruteForce.BruteForceTSP(_cities);
                // Take the tour list and Calculate to total Distance and Save it in _Total Distance 
                _totalDistance = CalculateTotalDistance(_tour);
                // Change the _algorithmRun boolen= True to know that the algorithm is run   
                //and use it  to Display chosen path on the screen 
                _algorithmRun = true;
                // Show the type of Algorithm We Selected
                MessageBox.Show($"The Algorithm Applied Here is  : {cbxAlgorithms.SelectedItem}");


            }
            else if (cbxAlgorithms.SelectedIndex == 2 && _cities.Count >= 2)
            {
                // After Applied NearestNeighbor on Citities list Return it And Save in Tour list
                _tour = clsNearestNeighborsAlgo.NearestNeighbor(_cities);
                // Take the tour list and Calculate to total Distance and Save it in _Total Distance 
                _totalDistance = CalculateTotalDistance(_tour);
                // Change the _algorithmRun boolen= True to know that the algorithm is run   
                //and use it  to Display chosen path on the screen;
                _algorithmRun = true;
                // Show the type of Algorithm We Selected
                MessageBox.Show($"The Algorithm Applied Here is  : {cbxAlgorithms.SelectedItem}");

            }
            else if(cbxAlgorithms.SelectedIndex == 3 && _cities.Count >= 2) 
            {

                // After Applied HeldKarp Algo on Citities list Return it And Save in Tour list
                _tour = clsDP.HeldKarpTSP(_cities);
                // Take the tour list and Calculate to total Distance and Save it in _Total Distance 
                _totalDistance = CalculateTotalDistance(_tour);
                // Change the _algorithmRun boolen= True to know that the algorithm is run   
                //and use it  to Display chosen path on the screen;
                _algorithmRun = true;
                // Show the type of Algorithm We Selected
                MessageBox.Show($"The Algorithm Applied Here is  : {cbxAlgorithms.SelectedItem}");
            }
            else
            {
                
                if (_cities.Count < 2)
                {   // check if the citites less than 2 Do Don't Apply anything and display this message 
                    MessageBox.Show("You Have To Select Atleast Two Point !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }
                else
                {   // check if the first condition is applied but we don't choose any Algo  display this message 
                    
                        MessageBox.Show("You Have To Chose The Type of Algorithm To Calculate!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
      
            Refresh();
        }

        private void btnReset_Click(object sender, EventArgs e)
        { // reset all list to defualt Values 
          // clear() is method in C# to Make List value to null  ==>  means don't have any value
            _cities.Clear();
            _tour.Clear();
            _totalDistance = 0;
            _algorithmRun = false;
            Refresh();
        } 

        // Calculate the total Distance from The First Point to the First Point Again after loop 
        public static double CalculateTotalDistance(List<clsPointWithName> tour)
        {
            double total = 0;
            // Loop ON all Citites in The list _Tour
            //  tour.Count - 1 ==> because we start from 0 
            for (int i = 0; i < tour.Count - 1; i++) //O(N)
            {
                // loop for all tour list == add the distance to Total; 
                total += Distance(tour[i].Location, tour[i + 1].Location); //O(1)
            }
            // Add distance from last city to the first city (tour is a cycle)
            total += Distance(tour[tour.Count - 1].Location, tour[0].Location);  //O(1)

            return total; //O(1)
        }
        // Calaclate the Distance Between Two Pint 
        public static double Distance(Point p1, Point p2)
        {
            // this is A Math Function To Calculate the total Distance Between Two Points 
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));  //O(1)
        }

    }
}
