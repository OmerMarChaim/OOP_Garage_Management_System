﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static Ex03.GarageLogic.OwnerDetails;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, Vehicle> m_VehicleInventory;
        private Dictionary<string, OwnerDetails> m_OwnerDetailsTickets;

        
        

        /// <summary>
        /// "Insert” a new vehicle into the garage. The user will be asked to select a vehicle type out of the supported vehicle types,
        /// and to input the license number of the vehicle.
        /// If the vehicle is already in the garage (based on license number)
        /// the system will display an appropriate message
        /// and will use the vehicle in the garage (and will change the vehicle status to “In Repair”),
        /// if not, a new object of that vehicle type will be created
        /// and the user will be prompted to input the values for the properties of his vehicle,
        /// according to the type of vehicle he wishes to add.
        /// </summary>
        /// <param name="i_Vehicle"></param>
        /// <param name="i_LicenseNumber"></param>
        internal void InsertNewVehicle (Vehicle i_Vehicle , String i_LicenseNumber)
        {

        }

        /// <summary>
        /// Display a list of license numbers currently in the garage,
        /// with a filtering option based on the status of each vehicle
        /// </summary>
        /// <returns></returns>
        public List<string> ListOfLicenseNumbersInTheGarage()
        {

            return null;
        }

        /// <summary>
        /// Change a certain vehicle’s status (Prompting the user for the license number and new desired status)
        /// </summary>
        /// <param name="i_LicenseNumber"></param>
        /// <param name="i_DesiredStatus"></param>
        internal void ChangeVehicleStatusInTheGarage(string i_LicenseNumber, eStatus i_DesiredStatus) 
        {
            
        }

        /// <summary>
        /// Display vehicle information (License number, Model name, Owner name, Status in garage,
        /// Tire specifications (manufacturer and air pressure),
        /// Fuel status + Fuel type / Battery status, other relevant information based on vehicle type)
        /// </summary>
        /// <param name="i_LicenseNumber"></param>
        /// <returns></returns>
        internal Dictionary<string,string> DisplayVehicleInformation(string i_LicenseNumber)
        {
            return null;
        }

        public Dictionary<string,string> GetVehicleDetails(string i_InputLicenseNumber)
        {
            Vehicle chosenVehicle = this.m_VehicleInventory[i_InputLicenseNumber];
            string modelName = chosenVehicle.ModelName,
                   ownerName = this.m_OwnerDetailsTickets[i_InputLicenseNumber].Name,
                   currentStatus = this.m_OwnerDetailsTickets[i_InputLicenseNumber].CurrentStatus.ToString(),
                   tiresDetails = chosenVehicle.GetWheelsDetails();
            Vehicle 
            
            string currentDetails = $@"License Number: {i_InputLicenseNumber}
Model Name: {chosenVehicle.ModelName}
Owner's name: {ownerName}
Status in garage: {currentStatus}
Tire specifications: {tiresDetails}
}
