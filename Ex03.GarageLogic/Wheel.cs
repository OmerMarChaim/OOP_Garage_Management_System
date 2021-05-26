using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Wheel
    {
        private String m_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float m_MaxAirPressure;

        public Wheel(string i_ManufacturerName, int i_MaxAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public string ManufacturerName
        {
            get { return m_ManufacturerName; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
        }

        /// <summary>
        /// be out not to cross the MaxAirPressure 
        /// </summary>
        /// <param name="i_AmountAirToAdd"></param>
        internal void AddAirPressure(float i_AmountAirToAdd)
        {
            bool lessThenMaxAirAfterAdd = (m_MaxAirPressure - (i_AmountAirToAdd + m_CurrentAirPressure)) >= 0;
            if(lessThenMaxAirAfterAdd)
            {
                m_CurrentAirPressure += i_AmountAirToAdd;
            }
            else
            {
                float maxToAdd = m_MaxAirPressure - m_CurrentAirPressure;
                float minToAdd = m_MaxAirPressure;

                throw new ValueOutOfRangeException(minToAdd, maxToAdd);
            }
        }

        public void InflateToMaximum()
        {
            float addToMax = m_MaxAirPressure - m_CurrentAirPressure;
            AddAirPressure(addToMax);
        }
    }
}