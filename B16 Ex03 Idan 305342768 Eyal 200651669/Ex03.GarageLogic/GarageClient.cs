namespace Ex03.GarageLogic
{
    public class GarageClient
    {
        public enum eVehicleStatus
        {
            InRepair = 1,
            NotInRepair = 2,
            None = 3
        }

        public string m_ClientName;
        public string m_ClientPhone;
        public Vehicle m_Vehicle;
        public eVehicleStatus m_Status;

        public GarageClient(string i_ClientName, string i_ClientPhone, Vehicle i_Vehicle, eVehicleStatus i_Status)
        {
            m_ClientName = i_ClientName;
            m_ClientPhone = i_ClientPhone;
            m_Vehicle = i_Vehicle;
            m_Status = i_Status;
        }
    }
}
