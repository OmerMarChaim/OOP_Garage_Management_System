using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        private enum eCarColor
        {
            Red,
            Silver,
            White,
            Black
        }

        private int m_I;
        private enum eNumberOfDoors
        {
        Two = 2,Three = 3,Four = 4,Five = 5
        }
        
        public override Dictionary<string, string> GetExtraDetails()
        {
            
            throw new NotImplementedException();
        }
    }
}
