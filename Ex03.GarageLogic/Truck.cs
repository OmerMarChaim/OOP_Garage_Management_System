using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private const float k_MaxAirPressure = 28;
        private bool m_ContainsDangerousMaterials;
        private float m_MaxCargoWeight;

        public Truck(string i_LicenseNumber, string i_ModelName)
            : base(i_LicenseNumber, i_ModelName)
        {
         
        }

        public override void InsertExtraDetailsIntoDict(ref Dictionary<string, object> i_IoDictionaryRef)
        {
            i_IoDictionaryRef.Add("Contains dangerous materials", m_ContainsDangerousMaterials);
            i_IoDictionaryRef.Add("Max cargo weight",m_MaxCargoWeight);
        }

        public override Dictionary<string, object> GetExtraDetailsMembers()
        {
            throw new NotImplementedException();
        }

        public override void setEnergy(EnergySource.eTypeOfEnergy i_EnergySourceTypeFromUser)
        {
            if (i_EnergySourceTypeFromUser == EnergySource.eTypeOfEnergy.Fuel)
            {
                InitFuelEngine(Fuel.eFuelType.Soler, 120);
            }
            else
            {
                throw new ArgumentException("Truck can not be with Electric Engine");
            }
        }

        public override void setWheels(string i_ManufacturerName)
        {
     
            InitWheels(i_ManufacturerName, k_MaxAirPressure,eNumberOfWheel.Sixteen);
        }
    }
}
