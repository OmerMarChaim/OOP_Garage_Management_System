using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;


namespace Ex03.ConsoleUI
{
    class ConsoleUserInterface
    {
        /// <summary>
        /// just check format of License NUmber
        /// </summary>
        /// <returns></returns>
        public static string getValidLicenseNumber()
        {
            throw new NotImplementedException();
        }

        public static string listToString(List<string> i_ListOfLicenseNumbersInTheGarage)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// chack if the input is between 1-3
        /// </summary>
        /// <param name="i_UserInputInString"></param>
        public static int getValidLicenseNumberBetween1To3(string i_UserInputInString, string i_MenuOption)
        {
            return getValidInputInSpecifIcRange(i_UserInputInString, 1, 3, i_MenuOption);
        }
        /// <summary>
        /// valid + in garage License NUMBER
        ///
        /// </summary>
        /// <param name="i_Garage"></param>
        /// <returns></returns>
        public static string getValidLicenseNumberInGarage(Garage i_Garage)
        {
           string licenseNumber= getValidLicenseNumber();
           while (i_Garage.isLicenseNumberInGarage(licenseNumber) == false)
           {
               Console.WriteLine($@"the car with license number  {licenseNumber} is not in the garage , please enter a new one:");
               licenseNumber = ConsoleUserInterface.getValidLicenseNumber();
           }

           return licenseNumber;

        }
        /// <summary>
        /// give me just valid int of amount of fuel between 0-whathever
        /// the logic check if its out of range.
        /// </summary>
        /// <param name="i_LicenseNumber"></param>
        /// <returns></returns>
        public static int getValidAmount()
        {
            throw new NotImplementedException();
        }

        public static int getValidInputBetween1To7(string i_UserInPut, string i_MenuOption)
        {
          return getValidInputInSpecifIcRange(i_UserInPut,1,7, i_MenuOption)
        }

        public static flowMeneger.eMenuOpiton fromIntToeMenuOpiton(int i_IntUserInput)
        {
            throw new NotImplementedException();
        }

        public static Fuel.eFuelType getValideFuelType()
        {
            ///importend flow
            /// ask for number between 1-4,
            /// get valid number -> turn the number to ENUM AS WE NEED -> retuen the enum
            string MenuOption = @"which kind of fuel you want to fill in your car? 
please enter by the number
1. Soler
2. Octane95,
3. Octane96,
4. Octane98";
            string userInputInString = Console.ReadLine();
            int userInputInt = getValidInputBetween1To4(userInputInString, MenuOption);
            Fuel.eFuelType resFuelType = fromIntToeFuelType(userInputInt);
            return resFuelType;
        }

        private static Fuel.eFuelType fromIntToeFuelType(int i_UserInputInt)
        {
            throw new NotImplementedException();
        }

        private static int getValidInputBetween1To4(string i_UserInput, string i_MenuOption)
        {
         return   getValidInputInSpecifIcRange(i_UserInput,1,4, i_MenuOption);
        }

        private static int getValidInputInSpecifIcRange(string i_UserInput,int i_minNum ,int i_maxNum , string i_messageToShowIfNotGood)
        {
            bool isNumber = false;
            bool isInRange = false;
            int userInputInt = -1;
            while (isNumber == false && isInRange == false)
            {
                isNumber = int.TryParse(i_UserInput, out  userInputInt);
                if(isNumber == true)
                {
                    if(userInputInt >= i_minNum && userInputInt <= i_maxNum)
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
                Console.WriteLine(i_messageToShowIfNotGood);

            }

            return userInputInt;

        }
        // out of a list we ask from factory
        public static VehicleFactory.eVehicleType getValidVehicleType()
        {
            throw new NotImplementedException();
        }
    }
}
