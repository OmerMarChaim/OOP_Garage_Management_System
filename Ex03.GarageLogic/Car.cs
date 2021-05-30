using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private const float k_MaxAirPressure = 30;
        private const eNumberOfWheel k_NumberOfWheel = eNumberOfWheel.Four;

        private eCarColor m_Color;
        private eNumberOfDoors m_NumberOfDoors;

        public Car(string i_LicenseNumber, string i_ModelName)
            : base(i_LicenseNumber, i_ModelName)
        {

        }


    private enum eCarColor
        {
            Red =1,
            Silver,
            White,
            Black
        }

        private enum eNumberOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

     
        /*
        public override List<string> GetExtraDetailsMembers()
        {
            List<string> extraMembers = new List<string>();
            extraMembers.Add("Color");
            extraMembers.Add("Number of doors");

            return extraMembers;
        }
        */

        public override void SetExtraDetailsMembers(ref Dictionary<string, string> io_DictionaryRef)
        {
            setCarColor(io_DictionaryRef);
        }

        private void setCarColor(Dictionary<string, string> i_DictionaryRef)
        {
            int optionColor;
            bool isNumber = int.TryParse(i_DictionaryRef.ElementAt(0).Value, out optionColor);
            if (isNumber == false)
            {
                throw new FormatException("You didnt enter a Number");
            }
            else if (optionColor < 1 && optionColor > 4)
            {
                throw new ValueOutOfRangeException(1, 4, "You enterd Number Out of Range");
            }
            else
            {
                m_Color = (eCarColor)optionColor;
            }
        }

        public override Dictionary<string, string> GetExtraDetailsMembers()
        {
            Dictionary<string, string> extraDetailsMembers = new Dictionary<string, string>();
            extraDetailsMembers.Add("Car Color","Number as '1. Red', '2. Silver' ,'3. White' ,'4. Black' ");
            extraDetailsMembers.Add("Number Of Doors", "'2','3','4','5'");
            return extraDetailsMembers;
        }

        public override void setEnergy(EnergySource.eTypeOfEnergy i_EnergySourceTypeFromUser)
        {
            if(i_EnergySourceTypeFromUser == EnergySource.eTypeOfEnergy.Fuel)
            {
                this.InitFuelEngine(Fuel.eFuelType.Octane95,45);
            }
            else
            {
                this.InitElectricEngine(3.2f);
            }
          
        }

        public override void setWheels(string i_ManufacturerName)
        {
            InitWheels(i_ManufacturerName,k_MaxAirPressure, k_NumberOfWheel);
        }

    
    }
}