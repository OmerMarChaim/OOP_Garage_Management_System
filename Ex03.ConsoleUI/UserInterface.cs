using System;

namespace Ex03.ConsoleUI
{
    class UserInterface
    {
        internal void startMenu()
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
        }
    }
}
