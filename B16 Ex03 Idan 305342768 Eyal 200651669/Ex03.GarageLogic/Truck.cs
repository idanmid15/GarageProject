namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        protected const float k_MaxTirePressure = 28;
        protected const int k_NumOfWheels = 16;
        protected const FueledEngine.eFuelType k_FuelType = FueledEngine.eFuelType.Soler;
        private const float k_MaxFuelCapacity = 135f;

        public Truck(
         string i_ModelType,
         string i_LicensePlate,
         string i_WheelManufacturer,
         float[] i_TirePressures,
         FueledEngine.eFuelType i_FuelType,
         float i_CurrentFuelAmount)
        {
            this.m_NumOfWheels = k_NumOfWheels;
            this.m_ModelType = i_ModelType;
            this.m_LicensePlate = i_LicensePlate;

            foreach (float currentTirePressure in i_TirePressures)
            {
                this.m_Wheels.Add(new Wheel(i_WheelManufacturer, currentTirePressure, k_MaxTirePressure));
            }

            this.m_Engine = new FueledEngine(i_CurrentFuelAmount, k_MaxFuelCapacity, k_FuelType);
            this.m_EnergyPrecentageLeft = i_CurrentFuelAmount / k_MaxFuelCapacity;
        }
    }
}