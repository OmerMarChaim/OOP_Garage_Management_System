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
        public static int getValidLicenseNumberBetween1To3()
        {
            throw new NotImplementedException();
        }

        public static string getValidLicenseNumberInGarage(Garage i_Garage)
        {
           string licenseNumber= getValidLicenseNumber();
           while (i_Garage.isLicenseNumberInGarage(licenseNumber) == false)
           {
               Console.WriteLine($@"the car with license number  {licenseNumber} is not in the garage , please enter a new one:"));
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
    }
}
