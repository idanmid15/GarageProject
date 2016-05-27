namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        public enum eEngineType
        {
            Fuel,
            Electric,
            Other
        }

        protected eEngineType m_EngineType;
        protected readonly float r_MaxPowerAmount;
        protected float m_CurrentPowerAmount;

        public Engine(float i_MaxPowerAmount)
        {
            r_MaxPowerAmount = i_MaxPowerAmount;
        }

        public void RePower(float i_PowerAmount)
        {
            if (i_PowerAmount + m_CurrentPowerAmount > r_MaxPowerAmount)
            {
                throw new ValueOutOfRangeException(0, r_MaxPowerAmount);
            }
            else
            {
                m_CurrentPowerAmount += i_PowerAmount;
            }
        }

        public eEngineType GetEngineType()
        {
            return m_EngineType;
        }

        public float getMaxPowerAmount()
        {
            return r_MaxPowerAmount;
        }
    }
}