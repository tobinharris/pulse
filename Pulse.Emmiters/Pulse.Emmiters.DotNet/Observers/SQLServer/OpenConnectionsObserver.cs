using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Pulse.Domain;


namespace Pulse.Observers.SQLServer
{
    public class OpenConnectionsObserver : Observer
    {
        public OpenConnectionsObserver(params string[] connectionStrings)
        {
            ConnectionStrings = connectionStrings;
        }

        public string[] ConnectionStrings { get; set; }

        public override void RegisterTypes()
        {
            PulseManager.RegisterType(new ObservationType("SQLServer.OpenConnections", "Number of open database connections in a SQL server instance", "Open Connections (SQL SERVER)", "conns"));
        }

        public override IList<Observation> GetObservations()
        {
            IList<Observation> observations = new List<Observation>();
            foreach (var connStr in ConnectionStrings)
            {
                var conn = new SqlConnection(connStr);
                var sqlConnType = typeof (SqlConnection);
                var dbConnectionPoolGroup =
                    sqlConnType.GetField("_poolGroup", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(conn);
                var poolConnection =
                    dbConnectionPoolGroup.GetType().GetField("_poolCollection",BindingFlags.NonPublic | BindingFlags.Instance).GetValue(
                        dbConnectionPoolGroup) as HybridDictionary;
                if (poolConnection != null)
                    foreach (DictionaryEntry poolEntry in poolConnection)
                    {
                        var foundPool = poolEntry.Value;
                        var listTDbConnectionInternal =
                            foundPool.GetType().GetField("_objectList", BindingFlags.NonPublic | BindingFlags.Instance).
                                GetValue(foundPool);
                        var numConnex =
                            listTDbConnectionInternal.GetType().GetMethod("get_Count").Invoke(listTDbConnectionInternal,
                                                                                              null);
                        observations.Add(new OpenConnectionsMeasurement(connStr, double.Parse(numConnex.ToString())));
                    }
            }
            return observations.Where(o => (o != null)).ToList();
        }
    }
}

public sealed class OpenConnectionsMeasurement : Measurement
{
    public OpenConnectionsMeasurement(string connectionString, double value)
        : base("SQLServer.OpenConnections", value)
    {
        ConnectionString = connectionString;
        Value = value;
    }

    [JsonProperty]
    public string ConnectionString { get; set; }
}