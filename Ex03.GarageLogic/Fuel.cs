using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Fuel :EnergySource
    {
        private eFuelType m_FuelType;
       public enum eFuelType
        {
            Soler,
            Octane95,
            Octane96,
            Octane98
        }

      
       public eFuelType FuelType
       {
           get { return m_FuelType; }
        }

       private float m_CurrentAmountOfFuelInLiters;
       private float m_MaxAmountOfFuelInLiters;


      // public override void UpdateAmountOfEnergy(float i_HowMuchMoreFuelToAdd, eFuelType i_FuelTypeEnter)
     

       public float CurrentAmountOfFuel
       {

           get { return m_CurrentAmountOfFuelInLiters; }

       }
       /// <summary>
       /// A method that receives how much more fuel to add, and changes the amount of fuel,
       /// if the fuel type is correct, and the fuel tank is less than full)
       /// </summary>
       /// <param name="i_HowMuchMoreFuelToAdd"></param>
       /// <param name="i_FuelTypeEnter"></param>
        public void refuelingOperation(float i_HowMuchMoreFuelToAdd, eFuelType i_FuelTypeEnter)
       {
           if(i_FuelTypeEnter != m_FuelType)
           {
               throw new ArgumentException($@"{i_FuelTypeEnter} not much to the Vehicle fuel Type");
           }
           else
           {
               float wantedAmount = i_HowMuchMoreFuelToAdd + m_CurrentAmountOfFuelInLiters;
               if (wantedAmount > m_MaxAmountOfFuelInLiters)
               {
                   throw new ValueOutOfRangeException(0, (m_MaxAmountOfFuelInLiters - m_CurrentAmountOfFuelInLiters), $@"{wantedAmount} is to high,");
               }
               else
               {
                   m_CurrentAmountOfFuelInLiters = wantedAmount;
               }
           }
          


       }
    }
}
