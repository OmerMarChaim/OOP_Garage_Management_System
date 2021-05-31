using System;
using System.Collections.Generic;
using Ex03.GarageLogic;
using static Ex03.ConsoleUI.UserInput;
using static Ex03.GarageLogic.OwnerDetails.eStatus;
using static Ex03.GarageLogic.VehicleFactory;
using static Ex03.GarageLogic.EnergySource;

namespace Ex03.ConsoleUI
{
    internal class GarageUiManager
    {
        private static Garage s_Garage;

        public enum eMenuOption
        {
            NewVehicle = 1,
            ListOfLicense,
            ChangeVehiclesStatus,
            InflateTires,
            RefuelFuel,
            ChargeElectricVehicle,
            DisplayVehicleInformation,
            Exit
        }

        internal GarageUiManager()
        {
            s_Garage = new Garage();
            startMenu();
        }

        private void startMenu()
        {
            int intUserInput;
            eMenuOption numberOfUserChoose;
            do
            {
                string menuOption = @"
=================       Welcome to Our garage       ====================
Which service do you need ? please write the number :
1. Insert a new vehicle into the garage.
2. Display a list of license numbers currently in the garage
3. Change a certain vehicle’s status
4. Inflate your car tires to maximum
5. Refuel a fuel-based vehicle
6. Charge an electric-based vehicle
7. Display specific vehicle information
8. Exit
========================================================================
";
                Console.WriteLine(menuOption);
                string userInPut = Console.ReadLine();
                intUserInput = UserInput.GetValidInputInRange(userInPut, 1, 8, menuOption);
                numberOfUserChoose = (eMenuOption)intUserInput;
                doUserChoice(numberOfUserChoose);
            }
            while(numberOfUserChoose != eMenuOption.Exit);
        }

        private void doUserChoice(eMenuOption i_NumberOfUserChoose)
        {
            eMenuOption userChoice = i_NumberOfUserChoose;
            switch(userChoice)
            {
                case eMenuOption.NewVehicle:
                    insertNewVehicle();

                    break;
                case eMenuOption.ListOfLicense:
                    displayListOfLicense();

                    break;
                case eMenuOption.ChangeVehiclesStatus:
                    changeVehiclesStatus();

                    break;
                case eMenuOption.InflateTires:
                    inflateTires();

                    break;
                case eMenuOption.RefuelFuel:
                    refuelFuel();

                    break;
                case eMenuOption.ChargeElectricVehicle:
                    chargeElectricVehicle();

                    break;
                case eMenuOption.DisplayVehicleInformation:
                    displayVehicleInformation();

                    break;
                case eMenuOption.Exit:
                    Console.WriteLine("See You in EX 4");

                    break;
            }
        }

        /// <summary>
        /// Display vehicle information (License number, Model name, Owner name, Status in garage,
        /// Tire specifications (manufacturer and air pressure),
        /// Fuel status + Fuel type / Battery status, other relevant information based on vehicle type)
        /// </summary>
        private static void displayVehicleInformation()
        {
            Console.WriteLine("For displaying vehicle information, enter license number");
            string inputLicenseNumber = UserInput.GetValidLicenseNumberInGarage(s_Garage);
            Dictionary<string, object> detailsToPrint = s_Garage.GetVehicleDetails(inputLicenseNumber);
            Console.WriteLine("The details of the requested vehicle:");
            foreach(KeyValuePair<string, object> pair in detailsToPrint)
            {
                Console.WriteLine($"{pair.Key} : {pair.Value}");
            }
        }

        /// <summary>
        /// 6. Charge an electric-based vehicle
        /// (Prompting the user for the license number and number of minutes to charge)
        /// </summary>
        private static void chargeElectricVehicle()
        {
            string licenseNumber = UserInput.GetValidLicenseNumberInGarage(s_Garage);
            bool isValid = false;
            while(!isValid)
            {
                try
                {
                    Console.WriteLine("How much hours do you want to add to your battery?");
                    float howManyMoreHoursToAdd = UserInput.GetValidAmount();
                    s_Garage.ChargeElectricVehicleInGarage(licenseNumber, howManyMoreHoursToAdd);
                    isValid = true;
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Return to Menu");

                    break;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// 5. Refuel a fuel-based vehicle
        /// (Prompting the user for the license number, fuel type and amount to fill)
        /// </summary>
        private void refuelFuel()
        {
            bool isValidAmountOfFuel = false;
            string licenseNumber = UserInput.GetValidLicenseNumberInGarage(s_Garage);
            while(isValidAmountOfFuel == false)
            {
                try
                {
                    Console.WriteLine("How much fuel do you want to put in?");
                    float amountFuelToFill = UserInput.GetValidAmount();

                    string[] fuelTypes = Fuel.GetFuelOptions();
                    Fuel.eFuelType desireFuelType = UserInput.GetValidChoice<Fuel.eFuelType>(
                        fuelTypes,
                        "Please chose one of the following types of Fuel:");
                    s_Garage.ReFuelFuelInSpecificVehicle(licenseNumber, amountFuelToFill, desireFuelType);
                    isValidAmountOfFuel = true;
                }

                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Return to Menu");

                    break;
                }

                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// 4. Inflate tires to maximum (Prompting the user for the license number)
        /// </summary>
        private void inflateTires()
        {
            string licenseNumber = UserInput.GetValidLicenseNumberInGarage(s_Garage);
            s_Garage.InflateTiresInCarToMax(licenseNumber);
        }

        /// <summary>
        /// 3. Change a certain vehicle’s status
        /// (Prompting the user for the license number and new desired status)
        /// </summary>
        private void changeVehiclesStatus()
        {
            string licenseNumber = UserInput.GetValidLicenseNumberInGarage(s_Garage);

            OwnerDetails.eStatus currentStatus = s_Garage.GetCurrentCarStatus(licenseNumber);
            Console.WriteLine($@"***Your current status is {currentStatus}***");

            string[] statusTypes = OwnerDetails.GetStatusOptions();
            OwnerDetails.eStatus desireStatus = UserInput.GetValidChoice<OwnerDetails.eStatus>(
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
            string listOfLicenseNumberString = UserInput.ListToString(listOfLicenseNumbersInTheGarage);
            string displayMessage = string.Format("This is the list of the License Numbers in The Garage:");
            Console.WriteLine(
                $@"{displayMessage}
{listOfLicenseNumberString}");
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
            Vehicle newVehicle;
            eVehicleType vehicleTypeFromUser;

            string licenseNumber = GetValidLicenseNumber();

            if(s_Garage.IsLicenseNumberInGarage(licenseNumber))
            {
                s_Garage.ChangeVehicleStatusInTheGarage(licenseNumber, OwnerDetails.eStatus.InRepair);
                Console.WriteLine("The vehicle is already in the garage, so now vehicle status is change to In Repair");
            }
            else
            {
                string[] vehicleTypes = VehicleFactory.GetVehicleOptions();
                vehicleTypeFromUser = UserInput.GetValidChoice<eVehicleType>(
                    vehicleTypes,
                    "Please chose one of the following types of vehicles:");
                string[] energyTypes = EnergySource.GetEnergyOptions();

                Console.WriteLine("Please enter Model Name:");
                string modelName = UserInput.GetNonEmptyInput();
                newVehicle = VehicleFactory.CreateNewVehicle(vehicleTypeFromUser, licenseNumber, modelName);

                eTypeOfEnergy energySourceTypeFromUser = UserInput.GetValidChoice<eTypeOfEnergy>(
                    energyTypes,
                    "Please chose one of the following types of energy vehicles:");
                UserInput.SetEnergyUi(energySourceTypeFromUser, ref newVehicle);

                Console.WriteLine("Please chose Wheels Manufacturer Name:");
                string manufacturerName = GetNonEmptyInput();
                newVehicle.SetWheels(manufacturerName);

                // set all details function 

                setExtraDetailsMembersUi(ref newVehicle);

                Console.WriteLine("Please enter Car owner Name:");
                string ownerName = GetNonEmptyInput();
                Console.WriteLine("Please enter owner Phone Number:");
                string phoneNumber = GetNonEmptyInput();

                s_Garage.AddNewVehicle(newVehicle, ownerName, phoneNumber);
                s_Garage.InflateTiresInCarToMax(licenseNumber);
                //  s_Garage.SetMaxEnergy(licenseNumber);
                Console.WriteLine("We enter your car :)");
            }
        }

        private void setExtraDetailsMembersUi(ref Vehicle i_IoNewVehicle)
        {
            Dictionary<string, string> extraDetails = i_IoNewVehicle.GetExtraMembersNamesAndConditions();
            Dictionary<string, string> attributeFromUser = new Dictionary<string, string>();
            foreach(KeyValuePair<string, string> member in extraDetails)
            {
                Console.WriteLine($"Please enter {member.Key}. insert from the following : {member.Value}");
                attributeFromUser.Add(member.Key, Console.ReadLine());
            }

            {
                try
                {
                    i_IoNewVehicle.SetExtraDetailsMembers(ref attributeFromUser);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    setExtraDetailsMembersUi(ref i_IoNewVehicle);
                }
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
                    licenseNumber = UserInput.GetLicenseNumber();
                    isValid = true;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
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