using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.OwnerDetails;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, Vehicle> r_VehicleInventory;
        private Dictionary<string, OwnerDetails> m_OwnerDetailsTickets;

        /// <summary>
        /// "Insert” a new vehicle into the garage. The user will be asked to select a vehicle type out of the supported vehicle types,
        /// and to input the license number of the vehicle.
        /// If the vehicle is already in the garage (based on license number)
        /// the system will display an appropriate message
        /// and will use the vehicle in the garage (and will change the vehicle status to “In Repair”),
        /// if not, a new object of that vehicle type will be created
        /// and the user will be prompted to input the values for the properties of his vehicle,
        /// according to the type of vehicle he wishes to add.
        /// </summary>
        /// <param name="i_Vehicle"></param>
        /// <param name="i_LicenseNumber"></param>
        internal void InsertNewVehicle(Vehicle i_Vehicle, String i_LicenseNumber)
        {
        }

        /// <summary>
        /// Display a list of license numbers currently in the garage,
        /// with a filtering option based on the status of each vehicle
        /// </summary>
        /// <returns></returns>
        public List<string> ListOfLicenseNumbersInTheGarage()
        {
            return null;
        }

        /// <summary>
        /// Change a certain vehicle’s status (Prompting the user for the license number and new desired status)
        /// </summary>
        /// <param name="i_LicenseNumber"></param>
        /// <param name="i_DesiredStatus"></param>
        public void ChangeVehicleStatusInTheGarage(string i_LicenseNumber, eStatus i_DesiredStatus)
        {
            OwnerDetails specificVehicleOwner = m_OwnerDetailsTickets[i_LicenseNumber];
            specificVehicleOwner.CarStatus = i_DesiredStatus;
        }

        /// <summary>
        /// Display vehicle information (License number, Model name, Owner name, Status in garage,
        /// Tire specifications (manufacturer and air pressure),
        /// Fuel status + Fuel type / Battery status, other relevant information based on vehicle type)
        /// </summary>
        /// <param name="i_LicenseNumber"></param>
        /// <returns></returns>
        internal Dictionary<string, string> DisplayVehicleInformation(string i_LicenseNumber)
        {
            return null;
        }

        // Display vehicle information
        // (License number, v
        // Model name, v
        // Owner name, v
        // Status in garage, v
        /// Tire specifications (manufacturer and air pressure), v 
        /// Fuel status + Fuel type / Battery status,
        /// other relevant information based on vehicle type)
        public Dictionary<string, object> GetVehicleDetails(string i_InputLicenseNumber)
        {
            Dictionary<string, object> resultedDictionary = new Dictionary<string, object>();
            Vehicle chosenVehicle = this.r_VehicleInventory[i_InputLicenseNumber];
            resultedDictionary.Add("License number", i_InputLicenseNumber);
            resultedDictionary.Add("Model Name", chosenVehicle.ModelName);
            resultedDictionary.Add("Owner Name", this.m_OwnerDetailsTickets[i_InputLicenseNumber].Name);
            resultedDictionary.Add(
                "currentStatus",
                $"{this.m_OwnerDetailsTickets[i_InputLicenseNumber].CurrentStatus}");

            chosenVehicle.GetWheelsDetails(ref resultedDictionary);
            chosenVehicle.GetEngineDetails(ref resultedDictionary);
            chosenVehicle.GetExtraMembersNamesAndConditions(ref resultedDictionary);

            return resultedDictionary;
        }

        public bool IsElectricVehicle(string i_LicenseNumber)
        {
            Vehicle specificVehicle = r_VehicleInventory[i_LicenseNumber];

            bool isElectricBased = specificVehicle.Engine.Type == EnergySource.eTypeOfEnergy.Electric;

            return isElectricBased;
        }

        public bool IsLicenseNumberInGarage(string i_LicenseNumber)
        {
            return m_OwnerDetailsTickets.ContainsKey(i_LicenseNumber);
        }

        public void InflateTiresInCarToMax(string i_LicenseNumber)
        {
            Vehicle specificVehicle = r_VehicleInventory[i_LicenseNumber];
            foreach(Wheel wheel in specificVehicle.Wheels)
            {
                wheel.InflateToMaximum();
            }
        }

        public eStatus GetCurrentCarStatus(string i_LicenseNumber)
        {
            OwnerDetails specificVehicleOwner = m_OwnerDetailsTickets[i_LicenseNumber];
            eStatus currentStatus = specificVehicleOwner.CarStatus;

            return currentStatus;
        }

        public void ReFuelFuelInSpecificVehicle(
            string i_LicenseNumber,
            int i_AmountFuelToFill,
            Fuel.eFuelType i_FuelTypeFromUser)
        {
            Vehicle specificVehicle = r_VehicleInventory[i_LicenseNumber];
            GarageLogic.Fuel fuelEngine = (specificVehicle.Engine) as Fuel;
            fuelEngine.RefuelingOperation(i_AmountFuelToFill, i_FuelTypeFromUser);
        }

        public void IsDesaireFuelTypeIsFeetToSpecificCar(
            string i_LicenseNumber,
            Fuel.eFuelType i_FuelTypeFromUser,
            out bool i_IsFuel,
            out bool i_IsSameFuelType)
        {
            i_IsSameFuelType = false;
            Vehicle specificVehicle = r_VehicleInventory[i_LicenseNumber];
            if(specificVehicle.Engine.Type == EnergySource.eTypeOfEnergy.Fuel)
            {
                i_IsFuel = true;
                GarageLogic.Fuel fuelEngine = (specificVehicle.Engine) as Fuel;
                if(i_IsSameFuelType = fuelEngine.FuelType == i_FuelTypeFromUser)
                {
                    i_IsSameFuelType = true;
                }
                else
                {
                    i_IsSameFuelType = false;

                    throw new ArgumentException(@"this Fuel Type is not fit");
                }
            }
            else
            {
                i_IsFuel = false;

                throw new ArgumentException(@"this Vehicle is not Fuel Based");
            }
        }

        public VehicleFactory.eVehicleType GetVehicleType(string i_LicenseNumber)
        {
            throw new NotImplementedException();
        }

        public void ChargeElectricVehicleInGarage(string i_LicenseNumber, int i_HowManyMoreHoursToAdd)
        {
            bool isElectricBased = IsElectricVehicle(i_LicenseNumber);
            if(!isElectricBased)
            {
                throw new ArgumentException("This License Number is not belongs to Electric Vehicle. ");
            }

            Vehicle specificVehicle = r_VehicleInventory[i_LicenseNumber];
            Electric electricEngine = (specificVehicle.Engine) as Electric;
            if(electricEngine != null && i_HowManyMoreHoursToAdd > electricEngine.RemainingEnergyPercentage)
            {
                throw new ValueOutOfRangeException(0, electricEngine.RemainingEnergyPercentage, "Out of range!");
            }

            electricEngine.RechargeOperation(i_HowManyMoreHoursToAdd);
        }

        public void AddNewVehicle(Vehicle i_NewVehicle, string i_OwnerName, string i_PhoneNumber)
        {
            string newLicenseNumber = i_NewVehicle.LicenseNumber;
            OwnerDetails newOwner = new OwnerDetails(i_OwnerName, i_PhoneNumber, newLicenseNumber);
            m_OwnerDetailsTickets.Add(newLicenseNumber,newOwner);
            r_VehicleInventory.Add(newLicenseNumber,i_NewVehicle);
        }
        public void SetMaxEnergy(string i_LicenseNumber)
        {
            throw new NotImplementedException();
        }

        public static bool IsValidLicenseNumber(int i_Number)
        {
            if(i_Number > 999999 || i_Number < 100000)
            {
                throw new ArgumentException("Number is not in the valid range: 100000 - 999999");
            }

            return true;
        }
    }
}