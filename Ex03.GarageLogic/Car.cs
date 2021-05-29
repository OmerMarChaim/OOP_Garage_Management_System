using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private const float k_MaxAirPressure = 30;
        
        private eCarColor m_Color;
        private eNumberOfDoors m_NumberOfDoors;

        public Car(string i_LicenseNumber, string i_ModelName) : base (i_LicenseNumber, i_ModelName)
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
        /*
        public override List<string> GetExtraDetailsMembers()
        {
            List<string> extraMembers = new List<string>();
            extraMembers.Add("Color");
            extraMembers.Add("Number of doors");

            return extraMembers;
        }
        */

        public override Dictionary<string, object> GetExtraDetailsMembers()
        {
            throw new NotImplementedException();
        }

        public override void setEnergy(EnergySource.eTypeOfEnergy i_EnergySourceTypeFromUser)
        {
            if(i_EnergySourceTypeFromUser == EnergySource.eTypeOfEnergy.Fuel)
            {
                InitFuelEngine(Fuel.eFuelType.Octane95,45);
            }
            else
            {
                InitElectricEngine(3.2f);
            }
          
        }

        public override void setWheels(string i_ManufacturerName)
        {
            InitWheels(i_ManufacturerName,k_MaxAirPressure,eNumberOfWheel.Four);
        }

    
    }
}