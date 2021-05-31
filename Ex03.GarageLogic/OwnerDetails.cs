using System;

namespace Ex03.GarageLogic
{
    public struct OwnerDetails
    {
        private string m_Name;
        private string m_PhoneNumber;
        private eStatus m_CurrentStatus;
        private readonly string r_VehicleLicenseNumber;

        public OwnerDetails(string i_Name, string i_Phone, string i_VehicleLicenseNumber)
        {
            m_Name = i_Name;
            m_PhoneNumber = i_Phone;
            m_CurrentStatus = eStatus.InRepair;
            r_VehicleLicenseNumber = i_VehicleLicenseNumber;
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public string PhoneNumber
        {
            get { return m_PhoneNumber; }
            set { m_PhoneNumber = value; }
        }

        public eStatus CurrentStatus
        {
            get { return m_CurrentStatus; }
        }

        public string VehicleLicenseNumber
        {
            get { return r_VehicleLicenseNumber; }
        }

        public enum eStatus
        {
            InRepair,
            Repaired,
            Payed
        }

        public static string[] GetStatusOptions()
        {
            return Enum.GetNames(typeof(eStatus));
        }

        public eStatus CarStatus
        {
            get { return m_CurrentStatus; }
            set { m_CurrentStatus = value; }
        }
    }
}