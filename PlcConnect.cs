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
using BasicModels;
using static ConnectionData.RockwellConnections;

namespace PlcConnect
{
    public class Connect{
        //
        List<List<bool>> outputList = new List<List<bool>>();
        public async Task<List<List<bool>>> GetBoolTags(RocConnection connection)
        {            
            //Dec
            //List<bool> areaList = new List<bool>();
            int i = 0;
            //Use the listed tag names from the connection to retrieve tag data
            foreach (string tag in connection.TAG_NAMES){
                //Dec
                List<bool> bitList = new List<bool>();
                int max;
                //Use this for other mappers
                //int max = connection.MAX_INT32[i];
                if (connection.MAX_BOOL[i] >= 31){
                    decimal intermediate = (decimal)(connection.MAX_BOOL[i] + 1) / 32;
                    max = (int)Math.Round(intermediate);
                }else{;
                    max = 1;
                }
                                             
                //Tags
                var tags = new Tag<BoolPlcMapper, bool[]>()
                {
                    Gateway = connection.GATEWAY,
                    Path = connection.PATH,
                    PlcType = connection.PLC_TYPE,
                    Protocol = Protocol.ab_eip,
                    Name = tag, //Tag name = tags.Name, Tag length = tags.Value.Length
                    ArrayDimensions = new int[] {max + 1}, //tags.GetType();
                    Timeout = TimeSpan.FromSeconds(connection.DEFAULT_TIMEOUT) 
                };
                //Read the value from the tags
                await tags.ReadAsync();
                //Add tag values to list
                bitList.AddRange(tags.Value);
                //Add tag lists to output list
                outputList.Add(bitList);
                //PLC bools reside at...              
                Console.WriteLine($"Max: {max}");
                Console.WriteLine($"Tag: {tag}");
                i += 1;
                foreach (bool l in bitList){
                        bool result = Convert.ToBoolean(l);
                        Console.WriteLine($"Bool: {l}");
                    }
                }
            //Retun the list of lists
            return outputList;
        }
    }
}

