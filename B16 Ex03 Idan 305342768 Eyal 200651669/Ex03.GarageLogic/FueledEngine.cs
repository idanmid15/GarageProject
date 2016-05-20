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

        private readonly float r_MaxFuelAmount;
        protected eFuelType m_FuelType;
        protected float m_CurrentFuelAmount;

        public FueledEngine(float i_CurrentFuelAmount, float i_MaxFuelAmount, eFuelType i_FuelType)
        {
            this.m_CurrentFuelAmount = i_CurrentFuelAmount;
            this.r_MaxFuelAmount = i_MaxFuelAmount;
            this.m_EngineType = eEngineType.Fuel;
            this.m_FuelType = i_FuelType;
        }

        public override void RePower(float i_ChargeTime)
        {
            if (i_ChargeTime + m_CurrentFuelAmount > r_MaxFuelAmount)
            {
                throw new Exception;
            }
            else
            {
                m_CurrentFuelAmount += i_ChargeTime;
            }
        }
    }
}