using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Motorcycle : Vehicle
    {
        private const int k_MaxAirPressure = 30;
        private const eNumberOfWheel k_NumberOfWheel = eNumberOfWheel.Two;
        private const int k_MaxEngineVolume = 2000;

        private int m_EngineVolume;
        private eLicenseType m_LicenseType;

        public Motorcycle(string i_LicenseNumber, string i_ModelName)
            : base(i_LicenseNumber, i_ModelName)
        {
        }

        private enum eLicenseType
        {
            A= 1,
            B1,
            AA,
            BB
        }

 

        public override void SetExtraDetailsMembers(ref Dictionary<string, string> io_IoDictionaryRef)
        {
            string optionEngineVolume = io_IoDictionaryRef.ElementAt(0).Value;
            string optionLicenseType = io_IoDictionaryRef.ElementAt(1).Value;
            setEngineVolume(optionEngineVolume);
            setLicenseType(optionLicenseType);
        }

        private void setLicenseType(string i_OptionLicenseType)
        {
            int OptioninInt;
            bool isNumber = int.TryParse(i_OptionLicenseType, out OptioninInt);
            if (isNumber == false)
            {
                throw new FormatException("You didn't enter a Number");
            }
            else if (OptioninInt < 1 && OptioninInt > 4)
            {
                throw new ValueOutOfRangeException(1, 4, "You enterd Number Out of Range");
            }
            else
            {
                m_LicenseType = (eLicenseType)OptioninInt;
            }
        }

        private void setEngineVolume(string i_OptionEngineVolume)
        {
            int optionEngineVolumeInt;
            bool isNumber = int.TryParse(i_OptionEngineVolume, out optionEngineVolumeInt);
            if(isNumber == false)
            {
                throw new FormatException("You didn't enter a Number");
            }
            else if (optionEngineVolumeInt < 0 && optionEngineVolumeInt > k_MaxEngineVolume)
            {
                throw new ValueOutOfRangeException(0, k_MaxEngineVolume, "You enter Number Out of Range");
            }
            else
            {
                m_EngineVolume = optionEngineVolumeInt;
            }
        }

    
        public override Dictionary<string, string> GetExtraMembersNamesAndConditions()
        {
            Dictionary<string, string> extraMembers = new Dictionary<string, string>();
            extraMembers.Add("Engine Volume", $"Number between 0-{k_MaxEngineVolume}");
            extraMembers.Add("License Type", " Number as '1' for A, '2' for B1 , 'AA' , 'BB' ");

            return extraMembers;
        }

        public override void GetExtraMembersContent(ref Dictionary<string, object> missing_name)
        {
            throw new NotImplementedException();
        }

        public override void setEnergy(EnergySource.eTypeOfEnergy i_EnergySourceTypeFromUser)
        {
            if (i_EnergySourceTypeFromUser == EnergySource.eTypeOfEnergy.Fuel)
            {
                InitFuelEngine(Fuel.eFuelType.Octane98, 6);
            }
            else
            {
                InitElectricEngine(1.8f);
            }
        }

        public override void setWheels(string i_ManufacturerName)
        {
            InitWheels(i_ManufacturerName, k_MaxAirPressure, k_NumberOfWheel);
        }
    }
}