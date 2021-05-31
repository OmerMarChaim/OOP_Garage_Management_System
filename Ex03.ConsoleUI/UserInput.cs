using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using static Ex03.GarageLogic.EnergySource;

namespace Ex03.ConsoleUI
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class UserInput
    {
        /// <summary>
        /// just check format of License NUmber
        /// </summary>
        /// <returns></returns>
        public static string GetLicenseNumber()
        {
            // the valid license number is 6 digits number
            Console.WriteLine("Please enter License Number in range 100000 - 999999:");
            string userInput = Console.ReadLine();
            if(userInput == String.Empty)
            {
                throw new FormatException("You have to enter number");
            }

            bool isNumber = int.TryParse(userInput, out int userInputAsNumber);
            if(isNumber == true)
            {
                Garage.IsValidLicenseNumber(userInputAsNumber);
            }
            else
            {
                throw new FormatException("you didn't enter a number");
            }

            return userInput;
        }

        public static string ListToString(List<string> i_ListOfLicenseNumbersInTheGarage)
        {
            StringBuilder result = new StringBuilder();
            if(i_ListOfLicenseNumbersInTheGarage.Count > 0)
            {
                foreach(string str in i_ListOfLicenseNumbersInTheGarage)
                {
                    result.AppendLine(str);
                    result.AppendLine();
                }
            }
            else
            {
                result.AppendLine("The Garage is empty");
            }

            return result.ToString();
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
                licenseNumber = UserInput.GetLicenseNumber();
            }

            return licenseNumber;
        }

        /// give me just valid int of amount of fuel between 0- what over
        /// the logic check if its out of range.
        public static float GetValidAmount()
        {
            string userInput = Console.ReadLine();
            bool isValidPositiveNumber = float.TryParse(userInput, out float userInputInNumber);
            if(!isValidPositiveNumber)
            {
                throw new FormatException();
            }

            return userInputInNumber;
        }

        internal static int GetValidInputInRange(string i_UserInput, int i_MinNum, int i_MaxNum, string i_MessageToShow)
        {
            bool isNumber = false;
            bool inRange = false;
            int userInputInt = -1;
            while(isNumber == false || inRange==false)
            {
                isNumber = int.TryParse(i_UserInput, out userInputInt);
                if(isNumber == true)
                {
                    inRange = userInputInt >= i_MinNum && userInputInt <= i_MaxNum;
                    if (inRange==true)
                    {
                        break;
                    }

                    Console.WriteLine($@"the number {userInputInt} is not in range .");
                }
                else
                {
                    Console.WriteLine($@"You didnt enter a number, please enter one");
                }

                
                Console.WriteLine(i_MessageToShow);
            }

            return userInputInt;
        }

        // out of a list we ask from factory
        public static T GetValidChoice<T>(string[] i_Options, string i_Message)
        {
            Console.WriteLine(i_Message);

            return printOptionsAndGetChoice<T>(i_Options);
        }

        private static T printOptionsAndGetChoice<T>(string[] i_Options)
        {
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
            string userInput = Console.ReadLine();

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

            T valueChoice = default;
            bool isNumber = int.TryParse(i_NumberOfChoice, out int choice);
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
        internal static string GetNonEmptyInput()
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

        public static void SetEnergyUi(eTypeOfEnergy i_EnergySourceTypeFromUser, ref Vehicle i_NewVehicle)
        {
            eTypeOfEnergy energySourceTypeFromUser = i_EnergySourceTypeFromUser;
            bool isValid = false;
            while(isValid == false)
            {
                try
                {
                    i_NewVehicle.SetEnergy(energySourceTypeFromUser);
                    isValid = true;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    string[] energyTypes = EnergySource.GetEnergyOptions();
                    energySourceTypeFromUser = UserInput.GetValidChoice<eTypeOfEnergy>(
                        energyTypes,
                        "Please chose one of the following types of energy vehicles:");
                }
            }
        }
    }
}