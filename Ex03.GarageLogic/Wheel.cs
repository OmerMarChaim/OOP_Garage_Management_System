using System;

namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        private String m_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;

        public Wheel(string i_ManufacturerName, float i_MaxAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            r_MaxAirPressure = i_MaxAirPressure;
        }
       

        public string ManufacturerName
        {
            get { return m_ManufacturerName; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
        }

        private void addAirPressure(float i_AmountAirToAdd)
        {
            float wantedAmount = i_AmountAirToAdd + m_CurrentAirPressure;
            
            if(wantedAmount>r_MaxAirPressure)
            {
                float maxToAdd = r_MaxAirPressure - m_CurrentAirPressure;
                throw new ValueOutOfRangeException(0, maxToAdd,$@"{i_AmountAirToAdd} is too high ");
            }
            else
            {
                m_CurrentAirPressure = wantedAmount;
            }
        }

        public void InflateToMaximum()
        {
            float addToMax = r_MaxAirPressure - m_CurrentAirPressure;
            addAirPressure(addToMax);
        }
    }
}