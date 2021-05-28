using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        private eCarColor m_Color;
        private eNumberOfDoors m_NumberOfDoors;

        public Car(string i_LicenseNumber) : base (i_LicenseNumber)
        {

        }

        private enum eCarColor
        {
            Red,
            Silver,
            White,
            Black
        }

        private enum eNumberOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

        public override void GetExtraDetails(ref Dictionary<string, object> io_DictionaryRef)
        {
            io_DictionaryRef.Add("Color", m_Color.ToString());
            io_DictionaryRef.Add("Number of doors", m_NumberOfDoors.ToString());
        }

        public override void getExtraDetailsForSpecificKindOfVehicle(ref Dictionary<string, object> io_DictionaryRef)
        {
            throw new NotImplementedException();
        }
    }
}