using System;
using PlcConnect;
using BasicModels;
using libplctag;
using static ConnectionData.RockwellConnections;

//Test Runner
public static class Run{
    //Async Main
    static public async Task Main(){
        //Run
        Console.WriteLine("Data Collector");

        //Connecton to PLC
        List<RocConnection> connectionList = data();
        Connect connect = new Connect();
        //OP40
        var bitTagsLists = await connect.GetBoolTags(connectionList[0]);
    }

    //Sync Main
    // static public async Task Main(){
    //     // See https://aka.ms/new-console-template for more information
    //     Console.WriteLine("Data Collector");
    
    //     // Connecton to PLC
    //     AutoReadTags auto = new AutoReadTags();
    //     // auto.Connect();
    // }
}

