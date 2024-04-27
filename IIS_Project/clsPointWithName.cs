using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIS_Project
{
    // this class to create a point With the name when i click 
    // create point with location on the screen and its name 
    public class clsPointWithName
    {
        // this properite ot make point(x,y) relative to the screen Pixels
        public Point Location { get; set; }
        public string Name { get; set; }

        // constractor 
        public clsPointWithName(Point location, string name)
        {
            Location = location;
            Name = name;
        }
    }
}
