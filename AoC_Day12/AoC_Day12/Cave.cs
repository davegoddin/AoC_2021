using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day12
{
    class Cave
    {
        string id;
        public string Id { get { return id; } }
        bool big;
        public bool Big {  get { return big; } }
        List<Cave> connections;
        public List<Cave> Connections { get { return connections; } }

        public Cave(string id)
        {
            this.id = id;
            
            if (id.ToUpper() == id)
            {
                big = true;
            }
            else
            {
                big = false;
            }

            connections = new List<Cave>();
        }

        public void AddConnection(Cave connection)
        {
            connections.Add(connection);
        }


    }
}
