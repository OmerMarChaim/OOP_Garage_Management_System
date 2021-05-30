using System;
using System.Collections.Generic;
using Ex03.GarageLogic;
using static Ex03.ConsoleUI.ConsoleUserInterface;
using static Ex03.GarageLogic.OwnerDetails.eStatus;
using static Ex03.GarageLogic.VehicleFactory;
using static Ex03.GarageLogic.EnergySource;

namespace Ex03.ConsoleUI
{
    internal class GarageUiManager
    {
        private static Garage s_Garage;

        public enum eMenuOpiton
        {
            NewVehicle = 1,
            ListOfLicense,
            ChangeVehiclesStatus,
            InflateTires,
            RefuelFuel,
            ChargeElectricVehicle,
            DisplayVehicleInformation
        }

        internal void StartMenu()
        {
            string helloMessage = string.Format("Welcome to Our garage");
            Console.WriteLine(helloMessage);

            string menuOption = @"Which service do you need ? please write the number :
1. “Insert” a new vehicle into the garage.
2. Display a list of license numbers currently in the garage
3. Change a certain vehicle’s status
4. Inflate your car tires to maximum
5. Refuel a fuel-based vehicle
6. Charge an electric-based vehicle
7. Display specific vehicle information
";
            Console.WriteLine(menuOption);
            string userInPut = Console.ReadLine();
            int intUserInput = ConsoleUserInterface.GetValidInputInRange(userInPut, 1, 7, menuOption);
            eMenuOpiton numberOfUserChoose = (eMenuOpiton)intUserInput;
            doUserChoice(numberOfUserChoose);
        }

        private void doUserChoice(eMenuOpiton i_NumberOfUserChoose)
        {
            eMenuOpiton userChoise = i_NumberOfUserChoose;
            switch(userChoise)
            {
                case eMenuOpiton.NewVehicle:
                    insertNewVehicle();

                    break;
                case eMenuOpiton.ListOfLicense:
                    displayListOfLicense();

                    break;
                case eMenuOpiton.ChangeVehiclesStatus:
                    changeVehiclesStatus();

                    break;
                case eMenuOpiton.InflateTires:
                    inflateTires();

                    break;
                case eMenuOpiton.RefuelFuel:
                    refuelFuel();

                    break;
                case eMenuOpiton.ChargeElectricVehicle:
                    chargeElectricVehicle();

                    break;
                case eMenuOpiton.DisplayVehicleInformation:
                    displayVehicleInformation();

                    break;
            }
        }

        /// <summary>
        /// OMRI
        /// Display vehicle information (License number, Model name, Owner name, Status in garage,
        /// Tire specifications (manufacturer and air pressure),
        /// Fuel status + Fuel type / Battery status, other relevant information based on vehicle type)
        /// </summary>
        private static void displayVehicleInformation()
        {
            Console.WriteLine("For displaying vehicle information, enter license number");
            string inputLicenseNumber = ConsoleUserInterface.GetValidLicenseNumberInGarage(s_Garage);
            Dictionary<string, object> detailsToPrint = s_Garage.GetVehicleDetails(inputLicenseNumber);
            Console.WriteLine("The details of the requested vehicle:");
            foreach(KeyValuePair<string, object> pair in detailsToPrint)
            {
                Console.WriteLine($"{pair.Key} : {pair.Value}");
            }
        }

        /// <summary>
        /// OMRI
        /// 6. Charge an electric-based vehicle
        /// (Prompting the user for the license number and number of minutes to charge)
        /// </summary>
        private static void chargeElectricVehicle()
        {
            string licenseNumber = ConsoleUserInterface.GetValidLicenseNumberInGarage(s_Garage);
            bool isValid = false;
            while(!isValid)
            {
                try
                {
                    int howManyMoreHoursToAdd = ConsoleUserInterface.GetValidAmount();
                    s_Garage.ChargeElectricVehicleInGarage(licenseNumber, howManyMoreHoursToAdd);
                    isValid = true;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        /// <summary>
        /// OMRI THE ONE AND ONLY
        /// 5. Refuel a fuel-based vehicle
        /// (Prompting the user for the license number, fuel type and amount to fill)
        /// </summary>
        private void refuelFuel()
        {
            bool isValidAmountOfFuel = false;
            bool isFuel = false;
            bool isSameFuelType = false;
            string licenseNumber = ConsoleUserInterface.GetValidLicenseNumberInGarage(s_Garage);
            while(isValidAmountOfFuel == false)
            {
                ///TODO -DEBUG
                try
                {
                    isFuel = !s_Garage.IsElectricVehicle(licenseNumber);
                    if(isFuel == true)
                    {
                        int amountFuelToFill = ConsoleUserInterface.GetValidAmount();

                        string[] fuelTypes = Fuel.GetFuelOptions();
                        Fuel.eFuelType desireFuelType = ConsoleUserInterface.GetValidChoice<Fuel.eFuelType>(
                            fuelTypes,
                            "Please chose one of the following types of Fuel:");
                        s_Garage.ReFuelFuelInSpecificVehicle(licenseNumber, amountFuelToFill, desireFuelType);
                    }
                    else
                    {
                        throw new ArgumentException("this Vehicle is not fuel based");
                    }
                }
                catch(ArgumentException e)
                {
                    ///Todo
                    /// we need undersnt how to define each exception here
                    /// best by ErorMessege.
                    /*
                   if(isFuel == false)
                    {

                    }
                    else if (isSameFuelType)
                    {
                        /// throw no fit to fuel type.
                    }
                    */
                    continue;
                }

                isValidAmountOfFuel = true;
            }
        }

        /// <summary>
        /// OMER
        /// 4. Inflate tires to maximum (Prompting the user for the license number)
        /// </summary>
        private void inflateTires()
        {
            string licenseNumber = ConsoleUserInterface.GetValidLicenseNumberInGarage(s_Garage);
            s_Garage.InflateTiresInCarToMax(licenseNumber);
        }

        /// <summary>
        /// OMER
        /// 3. Change a certain vehicle’s status
        /// (Prompting the user for the license number and new desired status)
        /// </summary>
        private void changeVehiclesStatus()
        {
            string licenseNumber = ConsoleUserInterface.GetValidLicenseNumberInGarage(s_Garage);

            ///todo -
            /// get the current car status
            OwnerDetails.eStatus currentStatus = s_Garage.GetCurrentCarStatus(licenseNumber);
            Console.WriteLine($@"***Your current status is {currentStatus}***");
            /*
             string menuOption = $@"To which status you want to change the car :
 1. In Repair,
 2. Repaired,
 3. Payed";
             Console.WriteLine(menuOption);
             string userInputInString = Console.ReadLine();
             int userInputNumber = ConsoleUserInterface.GetValidLicenseNumberBetween1To3(userInputInString, menuOption);

             */
            string[] statusTypes = OwnerDetails.GetStatusOptions();
            OwnerDetails.eStatus desireStatus = ConsoleUserInterface.GetValidChoice<OwnerDetails.eStatus>(
                statusTypes,
                "Please chose one of the following types of Fuel:");

            switch(desireStatus)
            {
                case InRepair:
                    desireStatus = InRepair;

                    break;
                case Payed:
                    desireStatus = Payed;

                    break;
                default:
                    desireStatus = default;

                    break;
            }

            s_Garage.ChangeVehicleStatusInTheGarage(licenseNumber, desireStatus);
        }

        /// <summary>
        /// OMER
        /// 2. Display a list of license numbers
        /// currently in the garage, with a filtering option based on the status of each vehicle
        /// </summary>
        private void displayListOfLicense()
        {
            List<string> listOfLicenseNumbersInTheGarage = s_Garage.ListOfLicenseNumbersInTheGarage();
            string listOfLicenseNumberString = ConsoleUserInterface.ListToString(listOfLicenseNumbersInTheGarage);
            string displayMessage = string.Format("this is the list of the License Numbers in The Garage");
            Console.WriteLine(
                $@"{displayMessage}
{listOfLicenseNumbersInTheGarage}");
        }

        /// <summary>
        /// 1. “Insert” a new vehicle into the garage.
        /// The user will be asked to select a vehicle type out of the supported vehicle types,
        /// and to input the license number of the vehicle.
        /// If the vehicle is already in the garage (based on license number)
        /// the system will display an appropriate message and will use the vehicle in the garage
        /// (and will change the vehicle status to “In Repair”),
        /// if not, a new object of that vehicle type will be created and the user will be prompted to
        /// input the values for the properties of his vehicle, according to the type of vehicle he wishes to add.
        /// </summary>
        private void insertNewVehicle()
        {
            string licenseNumber;
            Vehicle newVehicle;
            bool isValid = false;
            eVehicleType vehicleTypeFromUser;

            licenseNumber = GetValidLicenseNumber();

            if(s_Garage.IsLicenseNumberInGarage(licenseNumber))
            {
                // Change status and show some messege
                s_Garage.ChangeVehicleStatusInTheGarage(licenseNumber, OwnerDetails.eStatus.InRepair);
                Console.WriteLine("The vehicle is already in the garage, so now vehicle status is change to In Repair");
            }
            else
            {
                ///build new Vehicle
                string[] vehicleTypes = VehicleFactory.GetVehicleOptions();
                vehicleTypeFromUser = ConsoleUserInterface.GetValidChoice<eVehicleType>(
                    vehicleTypes,
                    "Please chose one of the following types of vehicles:");
                string[] energyTypes = EnergySource.GetEnergyOptions();
                EnergySource.eTypeOfEnergy energySourceTypeFromUser;

                Console.WriteLine("Please enter Model Name:");
                string modelName = ConsoleUserInterface.getNonEmptyInput();
                newVehicle = VehicleFactory.CreateNewVehicle(vehicleTypeFromUser, licenseNumber, modelName);
                // get all the require details from the given type after validation.

                // Dictionary<string, object> vhicledetails =new Dictionary<string, object>();
                //   = ConsoleUserInterface.GetDetailsForNewVehicle(vehicleTypeFromUser);

                energySourceTypeFromUser = ConsoleUserInterface.GetValidChoice<eTypeOfEnergy>(
                    energyTypes,
                    "Please chose one of the following types of energy vehicles:");
                ConsoleUserInterface.setEnergyUi(energySourceTypeFromUser, ref newVehicle);

                Console.WriteLine("Please chose Wheels Manufacturer Name:");
                string manufacturerName = getNonEmptyInput();
                newVehicle.setWheels(manufacturerName);

                // set all details function 

                setExtraDetailsMembersUI(ref newVehicle);

                s_Garage.AddNewVehicle(newVehicle);
                s_Garage.InflateTiresInCarToMax(licenseNumber);
                s_Garage.SetMaxEnergy(licenseNumber);
            }
        }

        private void setExtraDetailsMembersUI(ref Vehicle io_NewVehicle)
        {
            Dictionary<string, string> extraDetails = io_NewVehicle.GetExtraMembersNamesAndConditions();
            Dictionary<string, string> attributeFromUser = new Dictionary<string, string>();
            foreach(KeyValuePair<string, string> member in extraDetails)
            {
                Console.WriteLine($"Please enter {member.Key} ,Please insert by the following : {member.Value}");
                attributeFromUser.Add(member.Key, Console.ReadLine());
            }

            try
            {
                io_NewVehicle.SetExtraDetailsMembers(ref attributeFromUser);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);

                throw;
            }
        }

        // This method using GETLicenseNumber and Continues to request inputs according to the type of errors it receives
        public static string GetValidLicenseNumber()
        {
            bool isValid = false;
            string licenseNumber = "";
            while(!isValid)
            {
                try
                {
                    licenseNumber = ConsoleUserInterface.GetLicenseNumber();
                    isValid = true;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return licenseNumber;
        }

        // private Vehicle CreatNewVehicle(
        //     Dictionary<string, string> i_Details,
        //     VehicleFactory.eVehicleType i_VehicleTypeFromUser)
        // {
        //     throw new NotImplementedException();
        // }
    }
}