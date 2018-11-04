using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_6.Business_Layer;

namespace Assignment_6
{
    class Program
    {
        static void Main(string[] args)
        {
            // AsNoTracking. Ignore changes made of Dbcontext
            //where: function looks for standard. 
            IBusinessLayer businessLayer = new BusinessLayer();


        }
    }
}
