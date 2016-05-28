namespace Ex03.GarageLogic
{
    public class FueledEngine : Engine
    {
        public enum eFuelType
        {
            Octan95,
            Octan98,
            Octan96,
            Soler,
            None
        }

        protected eFuelType m_FuelType;

        public FueledEngine(
            float i_CurrentFuelAmount,
            float i_MaxFuelAmount,
            eFuelType i_FuelType) : base(i_MaxFuelAmount, i_CurrentFuelAmount)
        {
            
            m_EngineType = eEngineType.Fuel;
            m_FuelType = i_FuelType;
        }

        public eFuelType GetFuelType()
        {
            return this.m_FuelType;
        }

        public override string ToString()
        {
            return string.Format("Engine type: {0}{1}Fuel amount: {2}{1}Fuel Type: {3}{1}",
                m_EngineType.ToString(), System.Environment.NewLine, m_CurrentPowerAmount, m_FuelType.ToString());
        }
    }
}