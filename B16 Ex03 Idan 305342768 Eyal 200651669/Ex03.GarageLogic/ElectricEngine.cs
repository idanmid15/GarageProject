namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        private float m_ChargeTimeLeft;
        private float r_MaxChargeTime;

        public ElectricEngine(float i_ChargeTimeLeft, float i_MaxChargeTime)
        {
            this.m_ChargeTimeLeft = i_ChargeTimeLeft;
            this.r_MaxChargeTime = i_MaxChargeTime;
            this.m_EngineType = eEngineType.Electric;
        }

        public override void RePower(float i_PowerAmount)
        {
            if (i_PowerAmount + this.m_ChargeTimeLeft > this.r_MaxChargeTime)
            {
                throw new Exception;
            }
            else
            {
                this.m_ChargeTimeLeft += i_PowerAmount;
            }
        }
    }
}