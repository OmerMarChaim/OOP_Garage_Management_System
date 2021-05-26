using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Fuel :EnergySource
    {
       public enum eFuelType
        {
            Soler,
            Octane95,
            Octane96,
            Octane98
        }

       private float m_CurrentAmountOfFuelInLiters;
       private float m_MaxAmountOfFuelInLiters;

       /// <summary>
       /// A method that receives how much more fuel to add, and changes the amount of fuel,
       /// if the fuel type is correct, and the fuel tank is less than full)
       /// </summary>
       /// <param name="i_HowMuchMoreFuelToAdd"></param>
       /// <param name="i_FuelTypeEnter"></param>
      // public override void UpdateAmountOfEnergy(float i_HowMuchMoreFuelToAdd, eFuelType i_FuelTypeEnter)
     

       public float CurrentAmountOfFuel
       {

           get { return m_CurrentAmountOfFuelInLiters; }

       }

       public void refuelingOperation(float i_HowMuchMoreFuelToAdd, eFuelType i_FuelTypeEnter)
       {

       }
    }
}
