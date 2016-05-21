namespace Ex03.GarageLogic
{
    public class FueledEngine : Engine
    {
        public enum eFuelType
        {
            Octan96,
            Octan95,
            Octan98,
            Soler
        }

        protected eFuelType m_FuelType;

        public FueledEngine(
            float i_CurrentFuelAmount,
            float i_MaxFuelAmount,
            eFuelType i_FuelType) : base(i_MaxFuelAmount)
        {
            m_CurrentPowerAmount = i_CurrentFuelAmount;
            m_EngineType = eEngineType.Fuel;
            m_FuelType = i_FuelType;
        }

    }
}