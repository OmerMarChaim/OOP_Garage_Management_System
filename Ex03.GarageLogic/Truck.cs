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
        private const float k_MaxAllowCargoInCountry = 100000;


        private bool m_ContainsDangerousMaterials;
        private float m_MaxCargoWeight;

        public Truck(string i_LicenseNumber, string i_ModelName)
            : base(i_LicenseNumber, i_ModelName)
        {
         
        }
        
   

        public override void SetExtraDetailsMembers(ref Dictionary<string, string> io_DictionaryRef)
        {
           string maxCargoWeight = io_DictionaryRef.ElementAt(0).Value;
           string ContainsDangerousMaterials = io_DictionaryRef.ElementAt(1).Value;
           setMaxCargo(maxCargoWeight);
           setContainsDangerousMaterials(ContainsDangerousMaterials);

        }

        private void setContainsDangerousMaterials(string i_ContainsDangerousMaterials)
        {
            int optionInt;
            bool isNumber = int.TryParse(i_ContainsDangerousMaterials, out optionInt);
            if (isNumber == false)
            {
                throw new FormatException("You didnt enter a Number");
            }
            else if (optionInt < 1 && optionInt > 2)
            {
                throw new ValueOutOfRangeException(1, 2, "You enterd Number Out of Range");
            }
            else
            {
               m_ContainsDangerousMaterials= optionInt==1 ? true : false;
            }
        }

        private void setMaxCargo(string i_MaxCargoWeight)
        {
            float optionFloat;
            bool isNumber = float.TryParse(i_MaxCargoWeight, out optionFloat);
            if (isNumber == false)
            {
                throw new FormatException("You didnt enter a Number");
            }
            else if (optionFloat < 0 && optionFloat > k_MaxAllowCargoInCountry)
            {
                throw new ValueOutOfRangeException(0, k_MaxAllowCargoInCountry, "You enterd Number Out of Range");
            }
            else
            {
                m_MaxCargoWeight = optionFloat;
            }
        }

        public override Dictionary<string, string> GetExtraMembersNamesAndConditions()
        {
            Dictionary<string, string> extraDetailsMembers = new Dictionary<string, string>();
            extraDetailsMembers.Add("Max Cargo Weight", $"Number between 0-{k_MaxAllowCargoInCountry}");
            extraDetailsMembers.Add("Contains Dangerous Materials", "'1' for Yes,'2' for No");
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
