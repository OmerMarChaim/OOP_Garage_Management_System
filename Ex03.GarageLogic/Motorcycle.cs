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

        public override void InsertExtraDetailsIntoDict(ref Dictionary<string, object> i_IoDictionaryRef)
        {
    
        }

        //public void getExtraDetailsForSpecificKindOfVehicle(ref Dictionary<string, object> i_IoDictionaryRef)
        //{
          //  throw new NotImplementedException();
        //}
        public override Dictionary<string, string> GetExtraMembersNamesAndConditions()
        {
            Dictionary<string, string> extraMembers = new Dictionary<string, string>();
            extraMembers.Add("Engine Volume", "Number big then 0");
            extraMembers.Add("License Type", " Number as '1' for A, '2' for B1 , 'AA' , 'BB' ");

            return extraMembers;
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