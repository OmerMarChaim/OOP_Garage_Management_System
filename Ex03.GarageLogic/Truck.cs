using System;
using System.Collections.Generic;
using System.Linq;

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
        
   

        public override void SetExtraDetailsMembers(ref Dictionary<string, string> i_IoDictionaryRef)
        {
           string maxCargoWeight = i_IoDictionaryRef.ElementAt(0).Value;
           string containsDangerousMaterials = i_IoDictionaryRef.ElementAt(1).Value;
           setMaxCargo(maxCargoWeight);
           setContainsDangerousMaterials(containsDangerousMaterials);

        }

        private void setContainsDangerousMaterials(string i_ContainsDangerousMaterials)
        {
            int optionInt;
            bool isNumber = int.TryParse(i_ContainsDangerousMaterials, out optionInt);
            if (isNumber == false)
            {
                throw new FormatException("You didnt enter a Number at Contains Dangerous Materials");
            }
            else if (optionInt < 1 || optionInt > 2)
            {
                throw new ValueOutOfRangeException(1, 2, "You entered Number Out of Range at Contains Dangerous Materials");
            }
            else
            {
               m_ContainsDangerousMaterials= optionInt==1 ? true : false;
            }
        }

        private void setMaxCargo(string i_MaxCargoWeight)
        {
            bool isNumber = float.TryParse(i_MaxCargoWeight, out float optionFloat);
            if (isNumber == false)
            {
                throw new FormatException("You didnt enter a Number at Max Cargo");
            }
            else if (optionFloat < 0 || optionFloat > k_MaxAllowCargoInCountry)
            {
                throw new ValueOutOfRangeException(0, k_MaxAllowCargoInCountry, "You entered Number Out of Range at Max Cargo");
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
            string options = @"
1) Yes
2) No";
            extraDetailsMembers.Add("Contains Dangerous Materials",options);
            return extraDetailsMembers;
        }

    
        public override void SetEnergy(EnergySource.eTypeOfEnergy i_EnergySourceTypeFromUser)
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

        public override void SetWheels(string i_ManufacturerName)
        {
     
            InitWheels(i_ManufacturerName, k_MaxAirPressure, k_NumberOfWheel);
        }

        public override void GetExtraMembersContent(ref Dictionary<string, object> i_IoDictionary)
        {
            i_IoDictionary.Add("Contains dangerous materials", m_ContainsDangerousMaterials);
            i_IoDictionary.Add("Max cargo weight",m_MaxCargoWeight);
        }
    }
}
