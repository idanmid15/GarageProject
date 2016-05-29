using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ex03.GarageLogic
{
   public class VehicleFactory
    {
        public static Vehicle CreateVehicle(GarageManager.eSupportedVehciles i_SupportedVehicle, object[] i_InputParameters, Vehicle i_CurrentVehicleObject)
        {
            Type typeOfVehicle = Type.GetType("Ex03.GarageLogic." + i_SupportedVehicle.ToString());
            MethodInfo constructMethod = typeOfVehicle.GetMethod("Construct");
            i_CurrentVehicleObject = constructMethod.Invoke(i_CurrentVehicleObject, i_InputParameters) as Vehicle;
            return i_CurrentVehicleObject;
        }
    }
}
