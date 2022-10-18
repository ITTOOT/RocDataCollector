//https://github.com/libplctag/libplctag.net
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using ConsoleTables;
using libplctag;
using libplctag.DataTypes;


namespace PlcConnect
{
    // public class Connect{
    //     //This is built for testing the basic functions until unit testing without hardware is feasible

    //     private const int DEFAULT_TIMEOUT = 5;
    //     private const string GATEWAY = "172.16.100.1";
    //     const string PATH = "1,0";
    //     const PlcType PLC_TYPE = PlcType.ControlLogix;
    //     const Protocol PROTOCOL = Protocol.ab_eip;
    //     const string PROGRAM_NAME = "Sta040";
	// 	//Name = "F2F3Injector_08329_01.Sta040.A31Seq.Step"
    //     public async Task GetTags()
    //     {
    //         //This example will list all tags at the controller-scoped level

    //         var tags = new Tag<BoolPlcMapper, bool[]>()
    //         {
    //             Gateway = GATEWAY,
    //             Path = PATH,
    //             PlcType = PLC_TYPE,
    //             Protocol = Protocol.ab_eip,
    //             Name = "Sta040.A31Seq.Step", //Tag name = tags.Name, Tag length = tags.Value.Length
    //             ArrayDimensions = new int[] {1}, //tags.GetType();
    //             Timeout = TimeSpan.FromSeconds(DEFAULT_TIMEOUT) 
    //         };
            
    //         // Read the value from the PLC
    //         await tags.ReadAsync();
    //         var t = tags.Value;
            
    //         int i = 0;
    //         //Test for data
    //         foreach (bool b in t){
    //             var result = Convert.ToBoolean(b);
    //             Console.WriteLine(i);
    //             Console.WriteLine(result);
    //             i += 1;
    //         };


    //         /* ConsoleTable
    //             .From(tags.Value.Select(t => new
    //             {
    //                 t.Id,
    //                 Type = $"0x{t.Type:X}",
    //                 t.Name,
    //                 t.Length,
    //                 Dimensions = string.Join(',', t.Dimensions)
    //             }))
    //             .Configure(o => o.NumberAlignment = Alignment.Right)
    //             .Write(Format.Default);*/
    //     } 
    // }


    //  public class AutoReadTags
    // {
    //     //Controller Info
    //     private const int DEFAULT_TIMEOUT = 5;
    //     private const string GATEWAY = "172.16.100.1";
    //     const string PATH = "1,0";
    //     const PlcType PLC_TYPE = PlcType.ControlLogix;
    //     const Protocol PROTOCOL = Protocol.ab_eip;
    //     //const string PROGRAM_NAME = "Sta040";
    //     const string PROGRAM_NAME = "Sta040";
    //     //public async Task Connect()
    //     public void Connect()
    //     {
    //         ///////////////////////////////////////////////////
    //         ///////////////// BASE TAG INFO ///////////////////
    //         // Get controller tags
    //         Console.WriteLine("Controller Tags");
    //         Console.WriteLine("===============");

    //         var tags = new Tag<TagInfoPlcMapper, TagInfo[]>()
    //         {
    //             Gateway = GATEWAY,
    //             Path = PATH,
    //             PlcType = PLC_TYPE,
    //             Protocol = PROTOCOL,
    //             Name = "@tags",
    //             //ArrayDimensions = new int[] {1},
    //             Timeout = TimeSpan.FromSeconds(DEFAULT_TIMEOUT)
    //         };
    //         Console.WriteLine("Reading tags");
    //         tags.Read();
    //         //Console.WriteLine(tags.Value);
    //         Console.WriteLine("Reading tags complete");
    //         /* foreach (var tag in tags.Value)
    //             Console.WriteLine($"Id={tag.Id} Name={tag.Name} Type={tag.Type} Length={tag.Length}");
    //         */
            

    //         ///////////////////////////////////////////////////
    //         ///////////////// PROGRAMS INFO ///////////////////
    //         //Get program names - i.e. Sta040, which is a UDT_Station -> 
    // Need to read the fields, then field name to get the next UDT i.e. UDT_Inputs
    // repeat process untill all parts of UDT are known
    //         Console.WriteLine();
    //         Console.WriteLine("Programs");
    //         Console.WriteLine("========");

    //         var prog = new Tag<TagInfoPlcMapper, TagInfo[]>();

    //         foreach (var tag in tags.Value)
    //         {
    //             if (TagIsProgram(tag, PROGRAM_NAME, out string programTagListingPrefix))
    //             {
    //                 var programTags = new Tag<TagInfoPlcMapper, TagInfo[]>()
    //                 {
    //                     Gateway = GATEWAY,
    //                     Path = PATH,
    //                     PlcType = PLC_TYPE,
    //                     Protocol = PROTOCOL,
    //                     //Name = $"{programTagListingPrefix}.@tags",
    //                     Name = "@tags",
    //                     Timeout = TimeSpan.FromSeconds(DEFAULT_TIMEOUT)
    //                 };
    //                 prog = programTags;
    //             }
    //         }

    //         Console.WriteLine("Reading program");
    //         prog.Read();

    //         List<string> programList = new List<string>();
    //         foreach (var p in prog.Value){
    //             //Store available program names as strings
    //             if (p.Name == PROGRAM_NAME){
    //                 programList.Add(p.Name.ToString());
    //                 var innerTags = new Tag<TagInfoPlcMapper, TagInfo[]>()
    //                 {
    //                     Gateway = GATEWAY,
    //                     Path = PATH,
    //                     PlcType = PLC_TYPE,
    //                     Protocol = PROTOCOL,
    //                     //Name = $"{programTagListingPrefix}.@tags",
    //                     Name = programList[0],
    //                     Timeout = TimeSpan.FromSeconds(DEFAULT_TIMEOUT)
    //                 };
    //                 //prog = innerTags;
    //                 Console.WriteLine(innerTags.Name);
    //             } // TESTING
                

                
    //         }
    //         Console.WriteLine(programList[0]);

    //         //Console.WriteLine(programTags.GetType());
    //         Console.WriteLine("Reading program complete");





















    //         ///////////////////////////////////////////////////
    //         //////////////////// TAG INFO /////////////////////
    //         //Get UDT names
    //         Console.WriteLine();
    //         Console.WriteLine("UDTs");
    //         Console.WriteLine("====");

    //         var uniqueUdtTypeIds = prog.Value
    //             .Where(tagInfo => TagIsUdt(tagInfo))
    //             .Select(tagInfo => GetUdtId(tagInfo))
    //             .Distinct();

    //         Console.WriteLine("Reading UDTs");
    //         foreach (var udtId in uniqueUdtTypeIds)
    //         {
    //             var udtTag = new Tag<UdtInfoPlcMapper, UdtInfo>()
    //             {
    //                 Gateway = GATEWAY,
    //                 Path = PATH,
    //                 PlcType = PLC_TYPE,
    //                 Protocol = PROTOCOL,
    //                 Name = $"@udt/{udtId}",
    //                 Timeout = TimeSpan.FromSeconds(DEFAULT_TIMEOUT)
    //             };
    //             udtTag.Read();
    //             var udt = udtTag.Value;

    //             Console.WriteLine($"Id={udt.Id} Name={udt.Name} Size={udt.Size}");
    //             /* foreach (var f in udt.Fields)
    //                 Console.WriteLine($"    Name={f.Name}"); */

    //         }
    //         //Console.WriteLine("Reading UDTs complete");
            
    //         /* List<string> programList = new List<string>();
    //         foreach (var p in prog.Value){
    //             //Store available program names as strings
    //             if (p.Name == PROGRAM_NAME) // TESTING
    //             programList.Add(p.Name.ToString());
    //         }
    //         Console.WriteLine(programList[0]); */


    //         ///////////////////////////////////////////////////
    //         //////////////////// UDT INFO /////////////////////
    // Gets the names of the type - i.e. UDT_Station -> UDT_Inputs
    //         //Get UDT names
    //         Console.WriteLine();
    //         Console.WriteLine("UDTs");
    //         Console.WriteLine("====");

    //         var uniqueUdtTypeIds = prog.Value
    //             .Where(tagInfo => TagIsUdt(tagInfo))
    //             .Select(tagInfo => GetUdtId(tagInfo))
    //             .Distinct();

    //         Console.WriteLine("Reading UDTs");
    //         foreach (var udtId in uniqueUdtTypeIds)
    //         {
    //             var udtTag = new Tag<UdtInfoPlcMapper, UdtInfo>()
    //             {
    //                 Gateway = GATEWAY,
    //                 Path = PATH,
    //                 PlcType = PLC_TYPE,
    //                 Protocol = PROTOCOL,
    //                 Name = $"@udt/{udtId}",
    //                 Timeout = TimeSpan.FromSeconds(DEFAULT_TIMEOUT)
    //             };
    //             udtTag.Read();
    //             var udt = udtTag.Value;

    //             Console.WriteLine($"Id={udt.Id} Name={udt.Name} Size={udt.Size}");
    //             /* foreach (var f in udt.Fields)
    //                 Console.WriteLine($"    Name={f.Name}"); */

    //         }
    //         //Console.WriteLine("Reading UDTs complete");
            
    //         /* List<string> programList = new List<string>();
    //         foreach (var p in prog.Value){
    //             //Store available program names as strings
    //             if (p.Name == PROGRAM_NAME) // TESTING
    //             programList.Add(p.Name.ToString());
    //         }
    //         Console.WriteLine(programList[0]); */
            


    //     }
    //     /////////////////////// END ///////////////////////
    //     ///////////////////////////////////////////////////


    //     ///////////////////////////////////////////////////
    //     ///////////////////////////////////////////////////
    //     ///////////////////////////////////////////////////
    //     ///////////////////// HELPERS /////////////////////
    //     //Is tag a structure (UDT)
    //     static bool TagIsUdt(TagInfo tag)
    //     {
        //      const ushort TYPE_IS_???? = 0x7000;
    //         const ushort TYPE_IS_STRUCT = 0x8000;
    //         const ushort TYPE_IS_SYSTEM = 0x1000;

    //         return ((tag.Type & TYPE_IS_STRUCT) != 0) && !((tag.Type & TYPE_IS_SYSTEM) != 0);
    //     }

    //     //What is tag type?
    //     static bool TagIsType(TagInfo tag)
    //     {
    //         const ushort TYPE_IS_SYSTEM = 0x1000;
    //          const ushort TYPE_IS_BOOL = 0x2000;
    //          const ushort TYPE_IS_???? = 0x3000;
    //          const ushort TYPE_IS_???? = 0x4000;
    //          const ushort TYPE_IS_???? = 0x5000;
    //          const ushort TYPE_IS_???? = 0x6000;
    //         const ushort TYPE_IS_???? = 0x7000;
    //         const ushort TYPE_IS_STRUCT = 0x8000;

                // switch (tag.type)
                // {
                //     case "boolean":
                //         // code
                //          return ((tag.Type & TYPE_IS_BOOL) != 0) && !((tag.Type & TYPE_IS_SYSTEM) != 0);
                //         break;
                //     default:
                // }
    

    //         return ((tag.Type & TYPE_IS_STRUCT) != 0) && !((tag.Type & TYPE_IS_SYSTEM) != 0);
    //     }

    //     // Get the ID of the UDT
    //     static int GetUdtId(TagInfo tag)
    //     {
    //         const ushort TYPE_UDT_ID_MASK = 0x0FFF;
    //         return tag.Type & TYPE_UDT_ID_MASK;
    //     }

    //     //Is tag a program tag
    //     static bool TagIsProgram(TagInfo tag, string programName, out string prefix)
    //     {
    //         if (tag.Name.StartsWith(programName))
    //         {
    //             prefix = tag.Name;
    //             return true;
    //         }
    //         else
    //         {
    //             prefix = string.Empty;
    //             return false;
    //         }
    //     }
    // }  
}

