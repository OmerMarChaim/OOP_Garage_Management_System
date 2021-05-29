using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
   public class VehicleFactory
    {
        public enum eVehicleType
        {
            Car,
            Motorcycle,
            Truck
        }

        public static Vehicle CreateNewVehicle(eVehicleType i_VehicleTypeFromUser, string i_LicenseNumber, string i_ModelName)
        {
            Vehicle newVehicle = null;

            switch(i_VehicleTypeFromUser)
            {
                case eVehicleType.Car:
                    newVehicle = new Car(i_LicenseNumber,  i_ModelName);

                    break;
                case eVehicleType.Motorcycle:
                    newVehicle = new Motorcycle(i_LicenseNumber, i_ModelName);

                    break;
                case eVehicleType.Truck:
                    newVehicle = new Truck(i_LicenseNumber, i_ModelName);

                    break;
            }

            return newVehicle;

        }

        public static string[] GetVehicleOptions()
        {
            return Enum.GetNames(typeof(eVehicleType));
        }
    }
}
