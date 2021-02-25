using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageModJson
{

    public class DepositaryData
    {
        public string m_SteamID { get; set; }
        public string m_PlayerName { get; set; }

        public List<VehicleData> vehicleData { get; set; }
    }

    public class NewDepositaryData
    {
        public string m_SteamID { get; set; }
        public string m_PlayerName { get; set; }

        public List<VehicleDataNew> vehicleData { get; set; }
    }

    public class VehicleData
    {
        public int indexID { get; set; }
        public int VehiclesHash { get; set; }
        public int GarageID { get; set; }

        public double EngineHealth { get; set; }

        public double FuelAmmount { get; set; }

        public string VehiclesName { get; set; }


        public double[] SpawnPos = new double[] { 0.0, 0.0, 0.0 };
        public double[] SpawnOri = new double[] { 0.0, 0.0, 0.0 };

        public List<VehicleCargo> m_Cargo;
    }

    public class Vector
    {
        public double X = 0;
        public double Z = 0;
        public double Y = 0;
    }

    public class VehicleCargo
    {
        public string ItemName;
        public int VehicleCargoAmmount;
        public int KeyHash;
        public double Health;
    }

    public class VehicleDataNew
    {
        public int indexID { get; set; }
        public int VehiclesHash { get; set; }
        public int GarageID { get; set; }

        public double EngineHealth { get; set; }

        public double FuelAmmount { get; set; }

        public string VehiclesName { get; set; }

        public Vector SpawnPos;

        public Vector SpawnOri;

        public List<VehicleCargo> m_Cargo;
    }
}
