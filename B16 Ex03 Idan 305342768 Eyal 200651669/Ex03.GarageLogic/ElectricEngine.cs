namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_ChargeTimeLeft, float i_MaxChargeTime) : base(i_MaxChargeTime)
        {
            this.m_CurrentPowerAmount = i_ChargeTimeLeft;
            this.m_EngineType = eEngineType.Electric;
        }
    }
}