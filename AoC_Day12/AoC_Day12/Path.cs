using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day12
{
    class Path
    {
        List<Cave> caves;
        public List<Cave> Caves { get { return caves; } }
        bool complete;
        public bool Complete { get { return complete; } }
        Cave smallDouble;

        public Path(List<Cave> caves, Cave smallDouble)
        {
            this.caves = caves;
            this.smallDouble = smallDouble;
            complete = (caves[^1].Id == "end");
        }



        public List<Path> CreateBranches()
        {
            List<Path> branches = new List<Path>();
            foreach (Cave connection in caves[^1].Connections)
            {
                
                if (connection.Big || caves.FindAll(delegate (Cave c) { return c == connection; }).Count<1 || (connection == smallDouble && caves.FindAll(delegate (Cave c) { return c == connection; }).Count < 2))
                {
                    List<Cave> branchCaves = new List<Cave>(caves);
                    branchCaves.Add(connection);

                    branches.Add(new Path(branchCaves, smallDouble));
                }
            }

            return branches;
        }
    }
}
