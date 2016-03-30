//Joshua Sziede

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    //implements from IComparable and specifies type IDroid so we can use TotalCost in the CompareTo method
    interface IDroid : IComparable<IDroid>
    {
        //Method to calculate the total cost of a droid
        void CalculateTotalCost();

        //property to get the total cost of a droid
        decimal TotalCost { get; set; }
    }
}
