using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
using Ex03.ConsoleUI;
using static Ex03.GarageLogic.VehicleFactory;
using static Ex03.GarageLogic.EnergySource;

namespace Ex03.ConsoleUI
{
    class ConsoleUserInterface
    {
        /// <summary>
        /// just check format of License NUmber
        /// </summary>
        /// <returns></returns>
        public static string GetLicenseNumber()
        {
            // the valid license number is 6 digits number
            string userInput;
            int userInputAsNumber;
            Console.WriteLine("Please enter License Number in range 100000 - 999999:");
            userInput = Console.ReadLine();
            if(userInput == String.Empty)
            {
                throw new FormatException("You have to enter number");
            }
            else if(!int.TryParse(userInput, out userInputAsNumber) || Garage.IsValidLicenseNumber(userInputAsNumber))
            {
                // TODO DEBUG
                throw new FormatException("You have you enter NUMBER in range 100000 - 999999");
            }

            return userInput;
        }

        public static string ListToString(List<string> i_ListOfLicenseNumbersInTheGarage)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// valid + in garage License NUMBER
        ///
        /// </summary>
        /// <param name="i_Garage"></param>
        /// <returns></returns>
        public static string GetValidLicenseNumberInGarage(Garage i_Garage)
        {
            string licenseNumber = GarageUiManager.GetValidLicenseNumber();
            while(i_Garage.IsLicenseNumberInGarage(licenseNumber) == false)
            {
                Console.WriteLine(
                    $@"the car with license number  {licenseNumber} is not in the garage , please enter a new one:");
                licenseNumber = ConsoleUserInterface.GetLicenseNumber();
            }

            return licenseNumber;
        }

        /// <summary>
        /// give me just valid int of amount of fuel between 0-whathever
        /// the logic check if its out of range.
        /// </summary>
        /// <param name="i_LicenseNumber"></param>
        /// <returns></returns>
        public static int GetValidAmount()
        {
            throw new NotImplementedException();
        }

        public static GarageUiManager.eMenuOpiton FromIntToeMenuOpiton(int i_IntUserInput)
        {


            GarageUiManager.eMenuOpiton userResult=default;

            switch(i_IntUserInput)
            {
                case 1:
                    userResult = GarageUiManager.eMenuOpiton.NewVehicle;

                    break;
                case 2:
                    userResult = GarageUiManager.eMenuOpiton.ListOfLicense;


                    break;
                case 3:
                    userResult = GarageUiManager.eMenuOpiton.ChangeVehiclesStatus;

                    break;
                case 4:
                    userResult = GarageUiManager.eMenuOpiton.InflateTires;


                    break;
                case 5:
                    userResult = GarageUiManager.eMenuOpiton.RefuelFuel;

                    break;
                case 6:
                    userResult = GarageUiManager.eMenuOpiton.ChargeElectricVehicle;

                    break;
                case 7:
                    userResult = GarageUiManager.eMenuOpiton.DisplayVehicleInformation;
                    break;


            }

            return userResult;
        }

        /*
                public static Fuel.eFuelType GetValidFuelType()
                {
                    ///importend flow
                    /// ask for number between 1-4,
                    /// get valid number -> turn the number to ENUM AS WE NEED -> retuen the enum
                    ///  string[] energyTypes = EnergySource.GetEnergyOptions();

                    string menuOption = @"which kind of fuel you want to fill in your car? 
        please enter by the number
        1. Soler
        2. Octane95,
        3. Octane96,
        4. Octane98";
                    string userInputInString = Console.ReadLine();
                    int userInputInt = GetValidInputInRange(userInputInString, 1, 4, menuOption)
                    Fuel.eFuelType resFuelType = fromIntToeFuelType(userInputInt);

                    return resFuelType;
                }
        */
        private static Fuel.eFuelType fromIntToeFuelType(int i_UserInputInt)
        {
            throw new NotImplementedException();
        }

        //TODO isInRagne bool
        internal static int GetValidInputInRange(string i_UserInput, int i_MinNum, int i_MaxNum, string i_MessageToShow)
        {
            bool isNumber = false;
            bool isInRange = false;
            int userInputInt = -1;
            while(isNumber == false && isInRange == false)
            {
                isNumber = int.TryParse(i_UserInput, out userInputInt);
                if(isNumber == true)
                {
                    if(userInputInt >= i_MinNum && userInputInt <= i_MaxNum)
                    {
                        isNumber = true;

                        break;
                    }

                    Console.WriteLine($@"the number {userInputInt} is not in range .");
                }
                else
                {
                    Console.WriteLine($@"You didnt enter a number, please enter one");
                }

                ///the original text that we asked from user
                Console.WriteLine(i_MessageToShow);
            }

            return userInputInt;
        }

        // out of a list we ask from factory
        public static T GetValidChoice<T>(string[] i_Options, string i_Message)
        {
            Console.WriteLine(i_Message);

            return PrintOptionsAndGetChoice<T>(i_Options);
        }

        private static T PrintOptionsAndGetChoice<T>(string[] i_Options)
        {
            string userInput;
            bool isValid = false;
            T valueChoice = default;
            // first build options:
            StringBuilder options = new StringBuilder();
            int indexOfOption = 1;
            foreach(string option in i_Options)
            {
                options.AppendLine($"{indexOfOption}) {option}");
                indexOfOption += 1;
            }

            // and print the options:
            Console.WriteLine(options);
            userInput = Console.ReadLine();

            while(!isValid)
            {
                try
                {
                    valueChoice = getValueChoice<T>(userInput);
                    isValid = true;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    userInput = Console.ReadLine();
                }
            }

            return valueChoice;
        }

        private static T getValueChoice<T>(string i_NumberOfChoice)
        {
            if(i_NumberOfChoice == string.Empty)
            {
                throw new FormatException("Cant press enter without chose number. Try again");
            }

            int choice;
            T valueChoice = default;
            bool isNumber = int.TryParse(i_NumberOfChoice, out choice);
            bool isOneOfTheOptions = Enum.IsDefined(typeof(T), choice);

            if(isNumber && isOneOfTheOptions)
            {
                valueChoice = (T)Enum.Parse(typeof(T), i_NumberOfChoice);
            }
            else
            {
                throw new FormatException("Please chose one of the options.");
            }

            return valueChoice;
        }

        public static void GetOwnerDetails(out string i_OwnersName, out string i_OwnersPhoneNumber)
        {
            throw new NotImplementedException();
        }

        public static Dictionary<string, object> GetDetailsForNewVehicle(
            VehicleFactory.eVehicleType i_VehicleTypeFromUser)
        {
            Dictionary<string, object> allDetails = new Dictionary<string, object>();
            // first get basic information for all the vehicles 
            Console.WriteLine("Insert The Following attributes:");
            bool isValid = false;
            while(isValid)
            {
                //  AskForGenericVehicleDetails(ref allDetails);
                //need to enter constant by nedded

                //  AskForExtraOfVehicleDetails();
                // AskForOwnerOfVehicleDetails();
            }

            return allDetails;
        }

        /*
        private static void AskForGenericVehicleDetails(ref Dictionary<object, object> i_AllDetailsDictionary)
        {
            /// private String m_ModelName;
           /// private String m_LicenseNumber - we have;
            ///private readonly List<Wheel> r_Wheels ;
           /// private EnergySource m_Engine;
           /// private readonly eNumberOfWheel r_NumberOfWheels - depend on type.;
        Console.WriteLine("Please enter Model Name:");
            string modelName = getNonEmptyInput();
            i_AllDetailsDictionary.Add("Model Name", modelName);
            string[] energyTypes = EnergySource.GetEnergyOptions();
          
            i_AllDetailsDictionary.Add(typeof(eTypeOfEnergy), energySourceTypeFromUser);
            Console.WriteLine("Please chose Wheels Manufacturer Name:");
            string manufacturerName = getNonEmptyInput();
            i_AllDetailsDictionary.Add("Manufacturer Name", manufacturerName);
        }
        */
        internal static string getNonEmptyInput()
        {
            string userInput = Console.ReadLine();
            bool isValid = false;
            while(isValid == false)
            {
                try
                {
                    if(userInput == string.Empty)
                    {
                        throw new FormatException();
                    }
                    else
                    {
                        isValid = true;
                    }

                }
                catch(Exception e)
                {
                    Console.WriteLine(@"You enterd empty Word, please insert new one");
                    userInput = Console.ReadLine();
                    isValid = false;
                }

            }

            return userInput;
        }

        public static void setEnergyUi(eTypeOfEnergy i_EnergySourceTypeFromUser, ref Vehicle i_NewVehicle)
        {
            bool isValid = false;
            while(isValid == false)
                try
                {
                    i_NewVehicle.setEnergy(i_EnergySourceTypeFromUser);
                    isValid = true;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    string[] energyTypes = EnergySource.GetEnergyOptions();
                    EnergySource.eTypeOfEnergy energySourceTypeFromUser;
                    energySourceTypeFromUser = ConsoleUserInterface.GetValidChoice<eTypeOfEnergy>(
                        energyTypes,
                        "Please chose one of the following types of energy vehicles:");

                }
        }



    }
}