using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackAMole
{
    internal class HolePool
    {

        
        private List<Hole> notPlacedHoles;
        private List<Hole> placedHoles;
        private int numOfHoles = 12;

        public void initilize()
        {
            notPlacedHoles = new List<Hole>();
            placedHoles = new List<Hole>();

            for (int i = 0; i < numOfHoles; i++)
            {
            
                notPlacedHoles.Add(new Hole());

            }

        }


        public List<Hole> getHolesNotPlaced() { return notPlacedHoles; }
        public List<Hole> getPlacedHoles() { return placedHoles; }

    }

}
