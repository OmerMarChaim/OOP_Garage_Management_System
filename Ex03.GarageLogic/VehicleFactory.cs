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
            Motorcycle,
            Car,
            Truck,
        }

        public static void ManufactureNewVehicle(eVehicleType i_VehicleTypeFromUser, string i_LicenseNumber)
        {
            Vehicle newVehicle;

            switch(i_VehicleTypeFromUser)
            {
                case eVehicleType.Car:
                    newVehicle = new Car(i_LicenseNumber);
                    break;
                case eVehicleType.Motorcycle:
                    newVehicle = new Motorcycle(i_LicenseNumber);
                    break;
                case eVehicleType.Truck:
                    newVehicle = new Truck(i_LicenseNumber);
                    break;
            }

        }
    }
}
