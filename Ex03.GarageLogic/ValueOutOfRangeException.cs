using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MinValue;
        private readonly float r_MaxValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue )
            : base($"Value is out of range. Value must be in the range: {i_MinValue} - {i_MaxValue}")
        {
            r_MinValue = i_MinValue;
            r_MaxValue = i_MaxValue;
        }
    }
}