﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Pulse.Emmiters.DotNet.Core.Measurments.Database;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet.Core.Observers.SQLServer
{
    public class OpenConnectionsObserver : Observer
    {
        public override IList<Observation> GetObservations()
        {
            IList<Observation> observations = new List<Observation>();
            foreach (ConnectionStringSettings connStr in ConfigurationManager.ConnectionStrings)
            {
                var conn = new SqlConnection(connStr.ConnectionString);
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
                    observations.Add(new OpenConnectionsMeasurment(double.Parse(numConnex.ToString())));
                }
            }
            return observations.Where(delegate(Observation o) { return (o != null); }).ToList();
        }
    }
}