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
        private int m_EngineVolume;
        private eLicenseType m_LicenseType;

        public Motorcycle(string i_LicenseNumber, string i_ModelName)
            : base(i_LicenseNumber, i_ModelName)
        {
        }

        private enum eLicenseType
        {
            A,
            B1,
            AA,
            BB
        }

        public override void InsertExtraDetailsIntoDict(ref Dictionary<string, object> i_IoDictionaryRef)
        {
            i_IoDictionaryRef.Add("Engine Volume", m_EngineVolume.ToString());
            i_IoDictionaryRef.Add("License Type", m_LicenseType.ToString());
        }

        //public void getExtraDetailsForSpecificKindOfVehicle(ref Dictionary<string, object> i_IoDictionaryRef)
        //{
          //  throw new NotImplementedException();
        //}
        public override Dictionary<string, object> GetExtraDetailsMembers()
        {
            Dictionary<string, object> extraMembers = new Dictionary<string, object>();
            extraMembers.Add("EngineVolume", typeof(int));
            extraMembers.Add("LicenseType", typeof(eLicenseType));

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
            InitWheels(i_ManufacturerName, k_MaxAirPressure, eNumberOfWheel.Two);
        }
    }
}