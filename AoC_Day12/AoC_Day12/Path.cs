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

        public Path(List<Cave> caves)
        {
            this.caves = caves;
            complete = (caves[^1].Id == "end");
        }



        public List<Path> CreateBranches()
        {
            List<Path> branches = new List<Path>();
            foreach (Cave connection in caves[^1].Connections)
            {
                
                if (connection.Big || caves.FindAll(delegate (Cave c) { return c == connection; }).Count<1)
                {
                    List<Cave> branchCaves = new List<Cave>(caves);
                    branchCaves.Add(connection);

                    branches.Add(new Path(branchCaves));
                }
            }

            return branches;
        }
    }
}
