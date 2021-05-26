﻿using System;
namespace Ex03.ConsoleUI
{
    class flowMeneger
    {
        public enum eMenuOpiton 
        {
            newVehicle ,
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
            
            string MenuOption = @"which service do you need ? please write the number :
1. “Insert” a new vehicle into the garage.
2. Display a list of license numbers currently in the garage
3. Change a certain vehicle’s status
4. Inflate your car tires to maximum
5. Refuel a fuel-based vehicle
6. Charge an electric-based vehicle
7. Display specific vehicle information
";
            Console.WriteLine(MenuOption);
            string userInPut = Console.ReadLine();

          eMenuOpiton numberOfUserChoose=  isValidInput(userInPut);

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
        /// <summary>
        /// OMRI
        /// Display vehicle information (License number, Model name, Owner name, Status in garage,
        /// Tire specifications (manufacturer and air pressure),
        /// Fuel status + Fuel type / Battery status, other relevant information based on vehicle type)
        /// </summary>
        private void DisplayVehicleInformation()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// OMRI
        /// 6. Charge an electric-based vehicle
        /// (Prompting the user for the license number and number of minutes to charge)
        /// </summary>
        private void ChargeElectricVehicle()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// OMRI THE ONE AND ONLY
        /// 5. Refuel a fuel-based vehicle
        /// (Prompting the user for the license number, fuel type and amount to fill)
        /// </summary>
        private void RefuelFuel()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// OMER
        /// 4. Inflate tires to maximum (Prompting the user for the license number)
        /// </summary>
        private void InflateTires()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// OMER
        /// 3. Change a certain vehicle’s status
        /// (Prompting the user for the license number and new desired status)
        /// </summary>
        private void ChangeVehiclesStatus()
        {
        string licenseNumber =    ConsoleUserInterface.getValidLicenseNumber();
        }
        /// <summary>
        /// OMER
        /// 2. Display a list of license numbers
        /// currently in the garage, with a filtering option based on the status of each vehicle
        /// </summary>
        private void despleyListOfLicense()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// CHECK IF WE GET ONE OF the numbers as needed
        /// return int
        /// </summary>
        /// <param name="i_UserInPut"></param>
        private eMenuOpiton isValidInput(string i_UserInPut)
        {
            throw new NotImplementedException();

        }
    }
}
