
namespace Ex03.GarageLogic
{
    internal struct OwnerDetails
    {
        private string m_Name;
        private string m_PhoneNumer;
        private eStatus m_CurrentStatus;
        private string m_VehicleLicenseNumber;

        internal enum eStatus
        {
            InRepair,
            Repaired,
            Payed
        }

        public eStatus CarStatus
        {
           get { return m_CurrentStatus; }
           set { m_CurrentStatus = value; }
        }
    }
}
