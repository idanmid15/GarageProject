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

        protected readonly float r_MaxPowerAmount;
        protected eEngineType m_EngineType;
        protected float m_CurrentPowerAmount;

        public float MaxPowerAmount
        {
            get
            {
                return r_MaxPowerAmount;
            }
        }

        public Engine(float i_MaxPowerAmount, float i_CurrentPowerAmount)
        {
            r_MaxPowerAmount = i_MaxPowerAmount;
            if (i_CurrentPowerAmount > i_MaxPowerAmount)
            {
                throw new ValueOutOfRangeException(0, i_MaxPowerAmount);
            }

            m_CurrentPowerAmount = i_CurrentPowerAmount;
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