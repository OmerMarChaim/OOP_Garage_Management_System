using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using Ex03.GarageLogic;
using static Ex03.ConsoleUI.ConsoleUserInterface;
using static Ex03.GarageLogic.OwnerDetails.eStatus;

namespace Ex03.ConsoleUI
{
    class flowMeneger
    {
        private static Garage s_Garage;

        public enum eMenuOpiton
        {
            newVehicle,
            listOfLicense,
            ChangeVehiclesStatus,
            InflateTires,
            RefuelFuel,
            ChargeElectricVehicle,
            DisplayVehicleInformation
        }

        void startMenu()
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
            int intUserInput = ConsoleUserInterface.getValidInputBetween1To7(userInPut, menuOption);
            eMenuOpiton numberOfUserChoose = ConsoleUserInterface.fromIntToeMenuOpiton(intUserInput);

            doUserChoice(numberOfUserChoose);
        }

        private void doUserChoice(eMenuOpiton i_NumberOfUserChoose)
        {
            eMenuOpiton userChoise = i_NumberOfUserChoose;
            switch(userChoise)
            {
                case eMenuOpiton.newVehicle:
                    InsertNewVehicle();

                    break;
                case eMenuOpiton.listOfLicense:
                    despleyListOfLicense();

                    break;
                case eMenuOpiton.ChangeVehiclesStatus:
                    ChangeVehiclesStatus();

                    break;
                case eMenuOpiton.InflateTires:
                    InflateTires();

                    break;
                case eMenuOpiton.RefuelFuel:
                    RefuelFuel();

                    break;
                case eMenuOpiton.ChargeElectricVehicle:
                    ChargeElectricVehicle();

                    break;
                case eMenuOpiton.DisplayVehicleInformation:
                    DisplayVehicleInformation();

                    break;
            }
        }

        private void despleyListOfLicense()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// OMRI
        /// Display vehicle information (License number, Model name, Owner name, Status in garage,
        /// Tire specifications (manufacturer and air pressure),
        /// Fuel status + Fuel type / Battery status, other relevant information based on vehicle type)
        /// </summary>
        private void DisplayVehicleInformation()
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
            string licenseNumber = ConsoleUserInterface.GetValidLicenseNumberInGarage(s_Garage);
            Dictionary<string, object> detailsDictionary = s_Garage.GetVehicleDetails(licenseNumber);


        /// <summary>
        /// OMRI
        /// 6. Charge an electric-based vehicle
        /// (Prompting the user for the license number and number of minutes to charge)
        /// </summary>
        private void ChargeElectricVehicle()
        {
            string licenseNumber = ConsoleUserInterface.GetValidLicenseNumberInGarage(s_Garage);
            s_Garage.isElectricVehicle(licenseNumber);
        }

        /// <summary>
        /// OMRI THE ONE AND ONLY
        /// 5. Refuel a fuel-based vehicle
        /// (Prompting the user for the license number, fuel type and amount to fill)
        /// </summary>
        private void RefuelFuel()
        {
            bool isValidAmountOfFuel = false;
            bool isFuel=false;
            bool isSameFuelType=false;
            string licenseNumber = ConsoleUserInterface.GetValidLicenseNumberInGarage(s_Garage);
            while(isValidAmountOfFuel==false)
            { 
                ///TODO -DEBUG
                try
                {
                    int amountFuelToFill = ConsoleUserInterface.GetValidAmount();
                    Fuel.eFuelType desaierFuelType = ConsoleUserInterface.getValideFuelType();
                    s_Garage.isDesaireFuelTypeIsFeetToSpecificCar(licenseNumber, desaierFuelType, out  isFuel, out  isSameFuelType);
                    if(isFuel == true && isSameFuelType == true)
                    {
                        s_Garage.ReFuelFuelInSpecificVehicle(licenseNumber, amountFuelToFill, desaierFuelType);

                    }
                   
                }
                catch(ArgumentException e)
                {
                    if(isFuel == false)
                    {

                    }
                    else if (isSameFuelType)
                    {
                        /// throw no fit to fuel type.
                    }
continue;
                }

                isValidAmountOfFuel = true;
            }
        }

        /// <summary>
        /// OMER
        /// 4. Inflate tires to maximum (Prompting the user for the license number)
        /// </summary>
        private void InflateTires()
        {
            string licenseNumber = ConsoleUserInterface.GetValidLicenseNumberInGarage(s_Garage);
            s_Garage.inflateTiresInCarToMax(licenseNumber);
        }

        /// <summary>
        /// OMER
        /// 3. Change a certain vehicle’s status
        /// (Prompting the user for the license number and new desired status)
        /// </summary>
        private void ChangeVehiclesStatus()
        {
            string licenseNumber = ConsoleUserInterface.GetValidLicenseNumberInGarage(s_Garage);

            ///todo -
            /// get the current car status
            OwnerDetails.eStatus currentStatus = s_Garage.getCurrentCarStatus(licenseNumber);
            Console.WriteLine($@"***Your current status is {currentStatus}***");
            string MenuOption = $@"To which status you want to change the car :
1. In Repair,
2. Repaired,
3. Payed";
            Console.WriteLine(MenuOption);
            string userInputInString = Console.ReadLine();
            int userInputNumber = ConsoleUserInterface.GetValidLicenseNumberBetween1To3(userInputInString, MenuOption);
            OwnerDetails.eStatus desireStatus;
            switch(userInputNumber)
            {
                case 1:
                    desireStatus = InRepair;

                    break;
                case 2:
                    desireStatus = Repaired;

                    break;
                default:
                    desireStatus = Payed;

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
        private void InsertNewVehicle()
        {
            VehicleFactory.eVehicleType VehicleTypeFromUser = ConsoleUserInterface.getValidVehicleType();
            string licenseNumber = ConsoleUserInterface.getValidLicenseNumber();
            if(s_Garage.isLicenseNumberInGarage(licenseNumber))
            {
                //change status and show some messege
                VehicleFactory.eVehicleType VehicleTypeInGarage =  s_Garage.getVehicleType(licenseNumber); 
                 if (VehicleTypeFromUser == VehicleTypeInGarage)
                 {
                     s_Garage.ChangeVehicleStatusInTheGarage(licenseNumber,OwnerDetails.eStatus.InRepair);
                 }
                 else
                 {
                     //todo
                     ///enter a new Vehicle type its not feet 

                 }

            }
            else
            {
                ///build new Vehicle
                VehicleFactory.ManufactureNewVehicle(VehicleTypeFromUser,licenseNumber);
            }


        }

        
    }
}