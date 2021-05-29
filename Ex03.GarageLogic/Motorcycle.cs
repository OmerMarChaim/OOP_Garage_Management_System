using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Motorcycle : Vehicle
    {
        private int m_EngineVolume;
        private eLicenseType m_LicenseType;

        public Motorcycle(string i_LicenseNumber)
            : base(i_LicenseNumber)
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

        public override void getExtraDetailsForSpecificKindOfVehicle(ref Dictionary<string, object> i_IoDictionaryRef)
        {
            throw new NotImplementedException();
        }
        public override Dictionary<string, object> GetExtraDetailsMembers()
        {
            Dictionary<string, object> extraMembers = new Dictionary<string, object>();
            extraMembers.Add("EngineVolume", typeof(int));
            extraMembers.Add("LicenseType", typeof(eLicenseType));

            return extraMembers;
        }
    }
}