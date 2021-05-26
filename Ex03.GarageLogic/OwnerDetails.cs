
namespace Ex03.GarageLogic
{
    public struct OwnerDetails
    {
        private string m_Name;
        private string m_PhoneNumer;
        private eStatus m_CurrentStatus;
        private string m_VehicleLicenseNumber;

        public string Name
        {
            get { return m_Name; }
        }
        
        public string PhoneNumer
        {
            get { return m_PhoneNumer; }
        }
        
        public eStatus CurrentStatus
        {
            get { return m_CurrentStatus; }
        }
        
        public string VehicleLicenseNumber
        {
            get { return m_VehicleLicenseNumber; }
        }

        public enum eStatus
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
