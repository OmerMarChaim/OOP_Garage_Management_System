namespace Ex03.GarageLogic
{
   public class Electric : EnergySource
    {
        private float m_MaxTimeOfEngineOperationInHours;

        public Electric(float i_MaxTimeOfEngineOperationInHours)
        {
            m_MaxTimeOfEngineOperationInHours = i_MaxTimeOfEngineOperationInHours;
        }
      //  public float RemainingEnergy
      //  {
            //get { return m_RemainingTimeOfEngineOperationInHours; }
       // }


        /// <summary>
        /// method that receives how many more hours to add, and charges the battery,
        /// while not crossing the max limit)
        /// </summary>
        /// <param name="i_HowManyMoreHoursToAdd"></param>
        public void RechargeOperation(float i_HowManyMoreHoursToAdd)
        {
            float wantedHours = i_HowManyMoreHoursToAdd + m_RemainingEnergy;
            if(wantedHours>m_MaxTimeOfEngineOperationInHours)
            {
                throw new ValueOutOfRangeException(
                    0,
                    m_MaxTimeOfEngineOperationInHours - m_RemainingEnergy,
                    $@"{i_HowManyMoreHoursToAdd} is to high and out of range");
            }
            else
            {
                this.m_RemainingEnergy = wantedHours;
            }
        }
    }
}
