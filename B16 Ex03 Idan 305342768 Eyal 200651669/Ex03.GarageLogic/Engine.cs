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

        public abstract void RePower(float powerAmount);

        public eEngineType GetEngineType()
        {
            return m_EngineType;
        }
    }
}