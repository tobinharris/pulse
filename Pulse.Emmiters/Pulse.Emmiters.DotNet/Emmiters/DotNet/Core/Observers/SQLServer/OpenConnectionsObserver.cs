using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Pulse.Emmiters.DotNet.Core.CustomMeasurments;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet.Core.Observers.SQLServer
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
            foreach (string connStr in ConnectionStrings)
            {
                var conn = new SqlConnection(connStr);
                Type sqlConnType = typeof (SqlConnection);
                object dbConnectionPoolGroup =
                    sqlConnType.GetField("_poolGroup", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(conn);
                var poolConnection =
                    dbConnectionPoolGroup.GetType().GetField("_poolCollection",
                                                             BindingFlags.NonPublic | BindingFlags.Instance).GetValue(
                        dbConnectionPoolGroup) as HybridDictionary;
                foreach (DictionaryEntry poolEntry in poolConnection)
                {
                    object foundPool = poolEntry.Value;
                    object listTDbConnectionInternal =
                        foundPool.GetType().GetField("_objectList", BindingFlags.NonPublic | BindingFlags.Instance).
                            GetValue(foundPool);
                    object numConnex =
                        listTDbConnectionInternal.GetType().GetMethod("get_Count").Invoke(listTDbConnectionInternal,
                                                                                          null);
                    observations.Add(new OpenConnectionsMeasurement(connStr, double.Parse(numConnex.ToString())));
                }
            }
            return observations.Where(o => (o != null)).ToList();
        }
    }
}