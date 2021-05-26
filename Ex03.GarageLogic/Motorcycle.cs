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

        public Motorcycle()
        {
            m_EngineVolume = 0;
        }

        private enum eLicenseType
        {
            A,
            B1,
            AA,
            Bb
        }

        // ReSharper disable once InconsistentNaming
        public override void GetExtraDetails(ref Dictionary<string, string> io_DictionaryRef)
        {
            io_DictionaryRef.Add("Engine Volume", m_EngineVolume.ToString());
            io_DictionaryRef.Add("License Type", m_LicenseType.ToString());
        }
    }
}