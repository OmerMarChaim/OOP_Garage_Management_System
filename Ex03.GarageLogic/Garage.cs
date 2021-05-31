using System;
using System.Collections.Generic;
using System.Linq;
using static Ex03.GarageLogic.OwnerDetails;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, Vehicle> r_VehicleInventory;
        private Dictionary<string, OwnerDetails> m_OwnerDetailsTickets;

        public Garage()
        {
            r_VehicleInventory = new Dictionary<string, Vehicle>();
            m_OwnerDetailsTickets = new Dictionary<string, OwnerDetails>();
        }

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
            return m_OwnerDetailsTickets.Keys.ToList();
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
            chosenVehicle.GetExtraMembersContent(ref resultedDictionary);

            return resultedDictionary;
        }

        private bool isElectricVehicle(string i_LicenseNumber)
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
            float i_AmountFuelToFill,
            Fuel.eFuelType i_FuelTypeFromUser)
        {
            Vehicle specificVehicle = r_VehicleInventory[i_LicenseNumber];
            if(isElectricVehicle(i_LicenseNumber) == false)
            {
                Fuel fuelEngine = (specificVehicle.Engine) as Fuel;
                // ReSharper disable once PossibleNullReferenceException
                fuelEngine.RefuelingOperation(i_AmountFuelToFill, i_FuelTypeFromUser);
            }
            else
            {
                throw new ArgumentException("this vehicle is not Fuel based");
            }
        }

        public void ChargeElectricVehicleInGarage(string i_LicenseNumber, float i_HowManyMoreHoursToAdd)
        {
            bool isElectricBased = isElectricVehicle(i_LicenseNumber);
            if(isElectricBased==false)
            {
                throw new ArgumentException("This License Number is not belongs to Electric Vehicle. ");
            }

            Vehicle specificVehicle = r_VehicleInventory[i_LicenseNumber];
            Electric electricEngine = (specificVehicle.Engine) as Electric;
            
            electricEngine.RechargeOperation(i_HowManyMoreHoursToAdd);
        }

        public void AddNewVehicle(Vehicle i_NewVehicle, string i_OwnerName, string i_PhoneNumber)
        {
            string newLicenseNumber = i_NewVehicle.LicenseNumber;
            OwnerDetails newOwner = new OwnerDetails(i_OwnerName, i_PhoneNumber, newLicenseNumber);
            m_OwnerDetailsTickets.Add(newLicenseNumber,newOwner);
            r_VehicleInventory.Add(newLicenseNumber,i_NewVehicle);
        }
       // public void SetMaxEnergy(string i_LicenseNumber)
     

        public static bool IsValidLicenseNumber(int i_Number)
        {
            if(i_Number > 999999 || i_Number < 100000)
            {
                throw new ValueOutOfRangeException(100000, 999999, "the Input is out of range");
            }

            return true;
        }
    }
}