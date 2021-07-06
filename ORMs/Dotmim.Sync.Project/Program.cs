using Dotmim.Sync.Enumerations;
using Dotmim.Sync.SqlServer;
using System;
using System.Threading.Tasks;

namespace Dotmim.Sync.Project
{
    class Program
    {
        static void Main(string[] args)
        {
            var serverSideConnStr = "Data Source=192.168.137.1;Initial Catalog=BtlCore_HangZhouLiLong;user id=sa;password=P@ssw0rd;MultipleActiveResultSets=True;Connect Timeout=120;persist security info=True;";
            var clientSideConnStr = "Data Source=192.168.137.1;Initial Catalog=BtlCore_HangZhouLiLong_Middle;user id=sa;password=P@ssw0rd;MultipleActiveResultSets=True;Connect Timeout=120;persist security info=True;";

            // First provider on the server side, is using the Sql change tracking feature.
            var serverProvider = new SqlSyncChangeTrackingProvider(serverSideConnStr);

            // IF you want to try with a MySql Database, use the [MySqlSyncProvider] instead
            // var serverProvider = new MySqlSyncProvider(serverConnectionString);

            var clientProvider = new SqlSyncChangeTrackingProvider(clientSideConnStr);


            // Tables involved in the sync process:
            var tables = new string[] { "TraceCatalogs" };

            var syncSetup = new SyncSetup(tables);

            syncSetup.Tables["TraceCatalogs"].SyncDirection = SyncDirection.DownloadOnly;

            var clientOptions = new SyncOptions { BatchSize = 500 };

            // Creating an agent that will handle all the process
            var agent = new SyncAgent(clientProvider, serverProvider, clientOptions, tables);

            // Intercept a table changes selecting stage.
            agent.LocalOrchestrator.OnTableChangesSelecting(args =>
            {
                Console.WriteLine($"-- Getting changes from table {args.Table.GetFullName()} ...");
            });

            // Intercept a table changes applying stage, with a particular state [Upsert] or [Deleted]
            // The rows included in the args.Changes table will be applied right after.
            agent.LocalOrchestrator.OnTableChangesBatchApplying(args =>
            {
                Console.WriteLine($"-- Applying changes {args.State} to table {args.Changes.GetFullName()}");

                if (args.Changes == null || args.Changes.Rows.Count == 0)
                    return;

                if (args.State == System.Data.DataRowState.Deleted)
                {
                    args.Cancel = true;
                }

                foreach (var row in args.Changes.Rows)
                    Console.WriteLine(row);
            });

            do
            {
                // Launch the sync process
                var s1 = agent.SynchronizeAsync().Result;
                // Write results
                Console.WriteLine(s1);

            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine("End");
        }
    }
}
