using libplctag;

namespace BasicModels{
    //Tag names
    public class TagNames
    {
        public string[] name { get; set; }
        
    }

    //Connecting data for Rockwell PLC's
    public class RocConnection
    {
        public double DEFAULT_TIMEOUT { get; set; }
        public string? GATEWAY { get; set; }
        public string? PATH { get; set; }
        public PlcType? PLC_TYPE { get; set; }
        public Protocol? PROTOCOL { get; set; }
        public string[]? TAG_NAMES { get; set; }
        public string? PROGRAM_NAME { get; set; }
        public int[]? MAX_BOOL { get; set; }
        public string[]? NAME { get; set; }

        public RocConnection()
        {
            this.DEFAULT_TIMEOUT = 5;
            this.GATEWAY = " ";
            this.PATH = " ";
            this.PLC_TYPE = PlcType.ControlLogix;
            this.PROTOCOL = Protocol.ab_eip;
            this.TAG_NAMES = new string[] {" ", " "};
            this.PROGRAM_NAME = " ";
            this.MAX_BOOL = new int[] {8, 16};
            this.NAME = new string[] {" ", " "};
        }
    }
}


