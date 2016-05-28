namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly float r_MaxTirePressure;
        public string m_Manufacturer;

        private float m_CurrentTirePressure;

        public float GetMaxTirePressure()
        {
            return r_MaxTirePressure;
        }

        public string GetManufacturer()
        {
            return m_Manufacturer;
        }

        public float GetCurrentTirePressure()
        {
            return m_CurrentTirePressure;
        }

        public void SetTirePressure(float i_TirePressure)
        {
            this.m_CurrentTirePressure = i_TirePressure;
        }

        public Wheel(string i_Manufacturer, float i_TirePressure, float i_MaxTirePressure)
        {
            this.m_Manufacturer = i_Manufacturer;
            this.m_CurrentTirePressure = i_TirePressure;
            this.r_MaxTirePressure = i_MaxTirePressure;
        }

        public override string ToString()
        {
            return string.Format("Tire pressure: {0}{1}", m_CurrentTirePressure, System.Environment.NewLine);
        }
    }
}