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

namespace Seperater
{
    public class Seperate{
        //
        public async Task GetBoolLists(List<List<bool>> bitList)
        {
            foreach (List<bool> l in bitList){
                //Transform list to dataframe & move to pre-processor
                
            }
        }
    }
}