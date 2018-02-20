using System;
using System.Collections.Generic;
using CalServices.Models;

namespace CalServices.DataSources
{
    public class BranchDataSource
    {
        public BranchDataSource()
        {
            Branches = new List<Branch>();
            Branch b = new Branch()
            {
                Name = "Oakville Place",
                Transit = "100",
                Address = "123 Main Street Oakville, ON"
            };
            Branches.Add(b);
            b = new Branch()
            {
                Name = "Upper Abbey Center",
                Transit = "200",
                Address = "1500 Upper Middle Road Oakville, ON"
            };
            Branches.Add(b);
        }

        public List<Branch> Branches { get; private set; }
    }
}
