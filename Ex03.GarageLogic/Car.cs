using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
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

        public override void InsertExtraDetailsIntoDict(ref Dictionary<string, object> i_IoDictionaryRef)
        {
            i_IoDictionaryRef.Add("Color", m_Color.ToString());
            i_IoDictionaryRef.Add("Number of doors", m_NumberOfDoors.ToString());
        }

        public override List<string> GetExtraDetailsMembers()
        {
            List<string> extraMembers = new List<string>();
            extraMembers.Add("Color");
            extraMembers.Add("Number of doors");

            return extraMembers;
        }

        public override void getExtraDetailsForSpecificKindOfVehicle(ref Dictionary<string, object> i_IoDictionaryRef)
        {
            throw new NotImplementedException();
        }
        
    }
}