namespace Ex03.GarageLogic
{
    public class ElectricBike : Bike
    {
        private const float k_MaxChargeTime = 1.9f;

        public ElectricBike(
            string i_ModelType,
            string i_LicensePlate,
            string i_WheelManufacturer,
            float[] i_TirePressures,
            float i_ChargeTimeLeft)
        {
            this.m_NumOfWheels = k_NumOfWheels;
            this.m_ModelType = i_ModelType;
            this.m_LicensePlate = i_LicensePlate;
            this.m_Wheels.Add(new Wheel(i_WheelManufacturer, i_TirePressures[0], k_MaxTirePressure));
            this.m_Wheels.Add(new Wheel(i_WheelManufacturer, i_TirePressures[1], k_MaxTirePressure));
            this.m_Engine = new ElectricEngine(i_ChargeTimeLeft, k_MaxChargeTime);
            this.m_EnergyPrecentageLeft = i_ChargeTimeLeft / k_MaxChargeTime;
        }
    }
}