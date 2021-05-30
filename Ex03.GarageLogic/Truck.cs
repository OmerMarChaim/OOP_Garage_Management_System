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
        private const eNumberOfWheel k_NumberOfWheel = eNumberOfWheel.Sixteen;

        private bool m_ContainsDangerousMaterials;
        private float m_MaxCargoWeight;

        public Truck(string i_LicenseNumber, string i_ModelName)
            : base(i_LicenseNumber, i_ModelName)
        {
         
        }

   

        public override void SetExtraDetailsMembers(ref Dictionary<string, string> io_DictionaryRef)
        {
            throw new NotImplementedException();
        }

        public override Dictionary<string, string> GetExtraMembersNamesAndConditions()
        {
            Dictionary<string, string> extraDetailsMembers = new Dictionary<string, string>();
            extraDetailsMembers.Add("Max Cargo Weight", "Number big then Zero");
            extraDetailsMembers.Add("Contains Dangerous Materials", "'Yes','No'");
            return extraDetailsMembers;
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
     
            InitWheels(i_ManufacturerName, k_MaxAirPressure, k_NumberOfWheel);
        }

        public override void GetExtraMembersContent(ref Dictionary<string, object> io_Dictionary)
        {
            io_Dictionary.Add("Contains dangerous materials", m_ContainsDangerousMaterials);
            io_Dictionary.Add("Max cargo weight",m_MaxCargoWeight);
        }
    }
}
