namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(float i_ChargeTimeLeft, float i_MaxChargeTime) : base(i_MaxChargeTime, i_ChargeTimeLeft)
        {
            this.m_EngineType = eEngineType.Electric;
        }

        public override string ToString()
        {
            return string.Format("Engine type: {0}{1}Charge amount: {2}{1}", m_EngineType.ToString(), System.Environment.NewLine, m_CurrentPowerAmount);                            
        }
    }
}