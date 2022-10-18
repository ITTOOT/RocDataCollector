using libplctag;
using BasicModels;

namespace ConnectionData{
    //Conection data required for Rockwell PLC's
    public static class RockwellConnections
    {
        //Connection list for a single PLC
        public static List<RocConnection> data(){
            //Dec
            int numOfConnections = 1;
            RocConnection roc = new RocConnection();
            List<RocConnection> connectionList = new List<RocConnection>();

            //Add a connection for locations listed location
            for (int i = 0; i < numOfConnections; i++){
                connectionList.Add(roc);
            }
            
            //Connection 0
            connectionList[0].DEFAULT_TIMEOUT = 5;
            connectionList[0].GATEWAY = "172.16.100.1";
            connectionList[0].PATH = "1,0";
            connectionList[0].PLC_TYPE = PlcType.ControlLogix;
            connectionList[0].PROTOCOL = Protocol.ab_eip;
            connectionList[0].TAG_NAMES = new string[] {"Sta040.A31Seq.Step", "Sta040.A02Inputs.Bits", "Sta040.A60Outputs.Bits"};
            connectionList[0].PROGRAM_NAME = "Sta040";
            connectionList[0].MAX_BOOL = new int[] {1, 2, 3};
            
            // //Connection 1
            // connectionList[1].DEFAULT_TIMEOUT = 5;
            // connectionList[1].GATEWAY = "172.16.100.1";
            // connectionList[1].PATH = "1,0";
            // connectionList[1].PLC_TYPE = PlcType.ControlLogix;
            // connectionList[1].PROTOCOL = Protocol.ab_eip;
            // connectionList[1].TAG_NAMES = new String[] {"Sta040.A31Seq.Step", "Sta040.A02Inputs.Bits", "Sta040.A60Outputs.Bits"};
            // connectionList[1].PROGRAM_NAME = "Sta040";
            // connectionList[1].MAX_ELEMENT = new int[] {61, 32, 16};

            // //Connection 2
            // connectionList[2].DEFAULT_TIMEOUT = 5;
            // connectionList[2].GATEWAY = "172.16.100.1";
            // connectionList[2].PATH = "1,0";
            // connectionList[2].PLC_TYPE = PlcType.ControlLogix;
            // connectionList[2].PROTOCOL = Protocol.ab_eip;
            // connectionList[2].TAG_NAMES = new String[] {"Sta040.A31Seq.Step", "Sta040.A02Inputs.Bits", "Sta040.A60Outputs.Bits"};
            // connectionList[2].PROGRAM_NAME = "Sta040";
            // connectionList[2].MAX_ELEMENT = new int[] {4, 6, 8};

            //Return the populated list
            return connectionList;
        }
    }
}