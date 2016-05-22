namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        private const float k_MaxChargeTime = 3.3f;

        public ElectricCar(
            string i_ModelType,
            string i_LicensePlate,
            eCarColor i_CarColor,
            eNumOfDoors i_NumOfDoors,
            string i_WheelManufacturer,
            float[] i_TirePressures,
            float i_ChargeTimeLeft)
        {
            this.m_NumOfWheels = k_NumOfWheels;
            this.m_ModelType = i_ModelType;
            this.m_LicensePlate = i_LicensePlate;
            foreach (float currentTirePressure in i_TirePressures)
            {
                this.m_Wheels.Add(new Wheel(i_WheelManufacturer, currentTirePressure, k_MaxTirePressure));
            }

            this.m_CarColor = i_CarColor;
            this.m_NumOfDoors = i_NumOfDoors;
            this.m_Engine = new ElectricEngine(i_ChargeTimeLeft, k_MaxChargeTime);
            this.m_EnergyPrecentageLeft = i_ChargeTimeLeft / k_MaxChargeTime;
        }
    }
}