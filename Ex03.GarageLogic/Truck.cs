using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private bool m_ContainsDangerousMaterials;
        private float m_MaxCargoWeight;

        public Truck(string i_LicenseNumber)
            : base(i_LicenseNumber)
        {
        }

        public override void InsertExtraDetailsIntoDict(ref Dictionary<string, object> i_IoDictionaryRef)
        {
            i_IoDictionaryRef.Add("Contains dangerous materials", m_ContainsDangerousMaterials);
            i_IoDictionaryRef.Add("Max cargo weight",m_MaxCargoWeight);
        }
    }
}
