
using SDMChartApp.Models;

namespace SDMChartApp.Services // Replace with your actual namespace
{
    public class SDMService
    {
        public async Task<List<SDMData>> GetSDMPieChartDataAsync()
        {
            return new List<SDMData>
            {
                new SDMData { Label = "0-7 GB" },
                new SDMData { Label = "7-8 GB" },
                new SDMData { Label = ">8 GB" },
                new SDMData { Label = "Missing Data" }
            };
        }
        public async Task<List<SDMTableRow>> GetSDMTableDataAsync()
        {
            return new List<SDMTableRow>
            {
                new SDMTableRow { DatabaseType="SDM", Segment = "IOM LEAD", Market = "UK", StoreId = "000001", StoreName = "Store001", DBSizeGB = 7.5,  DBUsedPercent = 10,  DBAvailableGB = 2,   DBAvailablePercent = 25, LastBackupOn = DateTime.Parse("2025-01-01") },
                new SDMTableRow { DatabaseType="SDM", Segment = "IOM LEAD", Market = "US", StoreId = "000002", StoreName = "Store002", DBSizeGB = 6.2,  DBUsedPercent = 20,  DBAvailableGB = 3,   DBAvailablePercent = 35, LastBackupOn = DateTime.Parse("2025-02-01") },
                new SDMTableRow { DatabaseType="SDM", Segment = "IOM LEAD", Market = "CA", StoreId = "000003", StoreName = "Store003", DBSizeGB = 5.8,  DBUsedPercent = 30,  DBAvailableGB = 4,   DBAvailablePercent = 45, LastBackupOn = DateTime.Parse("2025-03-01") },
                new SDMTableRow { DatabaseType="SDM", Segment = "IOM LEAD", Market = "IN", StoreId = "000004", StoreName = "Store004", DBSizeGB = 8.1,  DBUsedPercent = 40,  DBAvailableGB = 2.5, DBAvailablePercent = 30, LastBackupOn = DateTime.Parse("2025-04-01") },
                new SDMTableRow { DatabaseType="SDM", Segment = "IOM LEAD", Market = "UK", StoreId = "000005", StoreName = "Store005", DBSizeGB = 9.0,  DBUsedPercent = 50,  DBAvailableGB = 1.5, DBAvailablePercent = 20, LastBackupOn = DateTime.Parse("2025-05-01") },
                new SDMTableRow { DatabaseType="SDM", Segment = "IOM LEAD", Market = "US", StoreId = "000006", StoreName = "Store006", DBSizeGB = 0.0,  DBUsedPercent = 60,  DBAvailableGB = 3.3, DBAvailablePercent = 41, LastBackupOn = DateTime.Parse("2025-06-01") },
                new SDMTableRow { DatabaseType="SDM", Segment = "IOM LEAD", Market = "CA", StoreId = "000007", StoreName = "Store007", DBSizeGB = 6.5,  DBUsedPercent = 70,  DBAvailableGB = 2.1, DBAvailablePercent = 25, LastBackupOn = DateTime.Parse("2025-07-01") },
                new SDMTableRow { DatabaseType="SDM", Segment = "IOM LEAD", Market = "IN", StoreId = "000008", StoreName = "Store008", DBSizeGB = 10.2, DBUsedPercent = 80,  DBAvailableGB = 1.2, DBAvailablePercent = 15, LastBackupOn = DateTime.Parse("2025-08-01") },
                new SDMTableRow { DatabaseType="SDM", Segment = "IOM LEAD", Market = "UK", StoreId = "000009", StoreName = "Store009", DBSizeGB = 3.5,  DBUsedPercent = 90,  DBAvailableGB = 0.5, DBAvailablePercent = 10, LastBackupOn = DateTime.Parse("2025-09-01") },
                new SDMTableRow { DatabaseType="SDM", Segment = "IOM LEAD", Market = "US", StoreId = "000010", StoreName = "Store010", DBSizeGB = 7.0,  DBUsedPercent = 35,  DBAvailableGB = 3.0, DBAvailablePercent = 30, LastBackupOn = DateTime.Parse("2025-10-01") },
                new SDMTableRow { DatabaseType="SDM", Segment = "IOM LEAD", Market = "CA", StoreId = "000011", StoreName = "Store011", DBSizeGB = 6.9,  DBUsedPercent = 55,  DBAvailableGB = 1.1, DBAvailablePercent = 15, LastBackupOn = DateTime.Parse("2025-11-01") },
                new SDMTableRow { DatabaseType="SDM", Segment = "IOM LEAD", Market = "IN", StoreId = "000012", StoreName = "Store012", DBSizeGB = 5.5,  DBUsedPercent = 25,  DBAvailableGB = 2.5, DBAvailablePercent = 40, LastBackupOn = DateTime.Parse("2025-12-01") },
                new SDMTableRow { DatabaseType="SDM", Segment = "IOM LEAD", Market = "UK", StoreId = "000013", StoreName = "Store013", DBSizeGB = 9.5,  DBUsedPercent = 15,  DBAvailableGB = 2.8, DBAvailablePercent = 32, LastBackupOn = DateTime.Parse("2025-01-15") },
                new SDMTableRow { DatabaseType="SDM", Segment = "IOM LEAD", Market = "US", StoreId = "000014", StoreName = "Store014", DBSizeGB = 8.0,  DBUsedPercent = 45,  DBAvailableGB = 3.2, DBAvailablePercent = 38, LastBackupOn = DateTime.Parse("2025-02-15") },
                new SDMTableRow { DatabaseType="SDM", Segment = "IOM LEAD", Market = "CA", StoreId = "000015", StoreName = "Store015", DBSizeGB = 7.2,  DBUsedPercent = 65,  DBAvailableGB = 1.0, DBAvailablePercent = 12, LastBackupOn = DateTime.Parse("2025-03-15") },
                new SDMTableRow { DatabaseType="SDM", Segment = "IOM LEAD", Market = "IN", StoreId = "000016", StoreName = "Store016", DBSizeGB = 4.4,  DBUsedPercent = 85,  DBAvailableGB = 2.9, DBAvailablePercent = 22, LastBackupOn = DateTime.Parse("2025-04-15") },
                new SDMTableRow { DatabaseType="SDM", Segment = "IOM LEAD", Market = "UK", StoreId = "000017", StoreName = "Store017", DBSizeGB = 8.6,  DBUsedPercent = 95,  DBAvailableGB = 0.7, DBAvailablePercent = 8,  LastBackupOn = DateTime.Parse("2025-05-15") },
                new SDMTableRow { DatabaseType="SDM", Segment = "IOM LEAD", Market = "US", StoreId = "000018", StoreName = "Store018", DBSizeGB = 6.6,  DBUsedPercent = 5,   DBAvailableGB = 6.0, DBAvailablePercent = 90, LastBackupOn = DateTime.Parse("2025-06-15") },
                new SDMTableRow { DatabaseType="SDM", Segment = "IOM LEAD", Market = "CA", StoreId = "000019", StoreName = "Store019", DBSizeGB = 9.3,  DBUsedPercent = 22,  DBAvailableGB = 7.1, DBAvailablePercent = 76, LastBackupOn = DateTime.Parse("2025-07-15") },
                new SDMTableRow { DatabaseType="SDM", Segment = "IOM LEAD", Market = "CA", StoreId = "000019", StoreName = "Store019", DBSizeGB = 0.0,  DBUsedPercent = 22,  DBAvailableGB = 7.1, DBAvailablePercent = 76, LastBackupOn = DateTime.Parse("2025-07-15") },

                new SDMTableRow { DatabaseType="SDM_IF_TR", Segment = "IOM LEAD", Market = "IN", StoreId = "000020", StoreName = "Store020", DBSizeGB = 10.0, DBUsedPercent = 100, DBAvailableGB = 0.0, DBAvailablePercent = 0,  LastBackupOn = DateTime.Parse("2025-08-15") },
                new SDMTableRow { DatabaseType="SDM_IF_TR", Segment = "IOM LEAD", Market = "UK", StoreId = "000001", StoreName = "Store001", DBSizeGB = 7.5,  DBUsedPercent = 10,  DBAvailableGB = 2,   DBAvailablePercent = 25, LastBackupOn = DateTime.Parse("2025-01-01") },
                new SDMTableRow { DatabaseType="SDM_IF_TR", Segment = "IOM LEAD", Market = "US", StoreId = "000002", StoreName = "Store002", DBSizeGB = 6.2,  DBUsedPercent = 20,  DBAvailableGB = 3,   DBAvailablePercent = 35, LastBackupOn = DateTime.Parse("2025-02-01") },
                new SDMTableRow { DatabaseType="SDM_IF_TR", Segment = "IOM LEAD", Market = "CA", StoreId = "000003", StoreName = "Store003", DBSizeGB = 5.8,  DBUsedPercent = 30,  DBAvailableGB = 4,   DBAvailablePercent = 45, LastBackupOn = DateTime.Parse("2025-03-01") },
                new SDMTableRow { DatabaseType="SDM_IF_TR", Segment = "IOM LEAD", Market = "IN", StoreId = "000004", StoreName = "Store004", DBSizeGB = 8.1,  DBUsedPercent = 40,  DBAvailableGB = 2.5, DBAvailablePercent = 30, LastBackupOn = DateTime.Parse("2025-04-01") },
                new SDMTableRow { DatabaseType="SDM_IF_TR", Segment = "IOM LEAD", Market = "UK", StoreId = "000005", StoreName = "Store005", DBSizeGB = 9.0,  DBUsedPercent = 50,  DBAvailableGB = 1.5, DBAvailablePercent = 20, LastBackupOn = DateTime.Parse("2025-05-01") },
                new SDMTableRow { DatabaseType="SDM_IF_TR", Segment = "IOM LEAD", Market = "US", StoreId = "000006", StoreName = "Store006", DBSizeGB = 0.0,  DBUsedPercent = 60,  DBAvailableGB = 3.3, DBAvailablePercent = 41, LastBackupOn = DateTime.Parse("2025-06-01") },
                new SDMTableRow { DatabaseType="SDM_IF_TR", Segment = "IOM LEAD", Market = "CA", StoreId = "000007", StoreName = "Store007", DBSizeGB = 6.5,  DBUsedPercent = 70,  DBAvailableGB = 2.1, DBAvailablePercent = 25, LastBackupOn = DateTime.Parse("2025-07-01") },
                new SDMTableRow { DatabaseType="SDM_IF_TR", Segment = "IOM LEAD", Market = "IN", StoreId = "000008", StoreName = "Store008", DBSizeGB = 10.2, DBUsedPercent = 80,  DBAvailableGB = 1.2, DBAvailablePercent = 15, LastBackupOn = DateTime.Parse("2025-08-01") },
                new SDMTableRow { DatabaseType="SDM_IF_TR", Segment = "IOM LEAD", Market = "UK", StoreId = "000009", StoreName = "Store009", DBSizeGB = 3.5,  DBUsedPercent = 90,  DBAvailableGB = 0.5, DBAvailablePercent = 10, LastBackupOn = DateTime.Parse("2025-09-01") },
                new SDMTableRow { DatabaseType="SDM_IF_TR", Segment = "IOM LEAD", Market = "US", StoreId = "000010", StoreName = "Store010", DBSizeGB = 7.0,  DBUsedPercent = 35,  DBAvailableGB = 3.0, DBAvailablePercent = 30, LastBackupOn = DateTime.Parse("2025-10-01") },
                new SDMTableRow { DatabaseType="SDM_IF_TR", Segment = "IOM LEAD", Market = "CA", StoreId = "000011", StoreName = "Store011", DBSizeGB = 6.9,  DBUsedPercent = 55,  DBAvailableGB = 1.1, DBAvailablePercent = 15, LastBackupOn = DateTime.Parse("2025-11-01") },
                new SDMTableRow { DatabaseType="SDM_IF_TR", Segment = "IOM LEAD", Market = "IN", StoreId = "000012", StoreName = "Store012", DBSizeGB = 5.5,  DBUsedPercent = 25,  DBAvailableGB = 2.5, DBAvailablePercent = 40, LastBackupOn = DateTime.Parse("2025-12-01") },
                new SDMTableRow { DatabaseType="SDM_IF_TR", Segment = "IOM LEAD", Market = "UK", StoreId = "000013", StoreName = "Store013", DBSizeGB = 9.5,  DBUsedPercent = 15,  DBAvailableGB = 2.8, DBAvailablePercent = 32, LastBackupOn = DateTime.Parse("2025-01-15") },
                new SDMTableRow { DatabaseType="SDM_IF_TR", Segment = "IOM LEAD", Market = "US", StoreId = "000014", StoreName = "Store014", DBSizeGB = 8.0,  DBUsedPercent = 45,  DBAvailableGB = 3.2, DBAvailablePercent = 38, LastBackupOn = DateTime.Parse("2025-02-15") },
                new SDMTableRow { DatabaseType="SDM_IF_TR", Segment = "IOM LEAD", Market = "CA", StoreId = "000015", StoreName = "Store015", DBSizeGB = 7.2,  DBUsedPercent = 65,  DBAvailableGB = 1.0, DBAvailablePercent = 12, LastBackupOn = DateTime.Parse("2025-03-15") },
                new SDMTableRow { DatabaseType="SDM_IF_TR", Segment = "IOM LEAD", Market = "IN", StoreId = "000016", StoreName = "Store016", DBSizeGB = 4.4,  DBUsedPercent = 85,  DBAvailableGB = 2.9, DBAvailablePercent = 22, LastBackupOn = DateTime.Parse("2025-04-15") },
                new SDMTableRow { DatabaseType="SDM_IF_TR", Segment = "IOM LEAD", Market = "UK", StoreId = "000017", StoreName = "Store017", DBSizeGB = 8.6,  DBUsedPercent = 95,  DBAvailableGB = 0.7, DBAvailablePercent = 8,  LastBackupOn = DateTime.Parse("2025-05-15") },
                new SDMTableRow { DatabaseType="SDM_IF_TR", Segment = "IOM LEAD", Market = "US", StoreId = "000018", StoreName = "Store018", DBSizeGB = 6.6,  DBUsedPercent = 5,   DBAvailableGB = 6.0, DBAvailablePercent = 90, LastBackupOn = DateTime.Parse("2025-06-15") },
                                 new SDMTableRow { DatabaseType="SDM_IF_TR", Segment = "IOM LEAD", Market = "CA", StoreId = "000019", StoreName = "Store019", DBSizeGB = 0.0,  DBUsedPercent = 22,  DBAvailableGB = 7.1, DBAvailablePercent = 76, LastBackupOn = DateTime.Parse("2025-07-15") },


                new SDMTableRow { DatabaseType="SDM_IF_POS", Segment = "IOM LEAD", Market = "IN", StoreId = "000020", StoreName = "Store020", DBSizeGB = 10.0, DBUsedPercent = 100, DBAvailableGB = 0.0, DBAvailablePercent = 0,  LastBackupOn = DateTime.Parse("2025-08-15") },
                new SDMTableRow { DatabaseType="SDM_IF_POS", Segment = "IOM LEAD", Market = "UK", StoreId = "000001", StoreName = "Store001", DBSizeGB = 7.5,  DBUsedPercent = 10,  DBAvailableGB = 2,   DBAvailablePercent = 25, LastBackupOn = DateTime.Parse("2025-01-01") },
                new SDMTableRow { DatabaseType="SDM_IF_POS", Segment = "IOM LEAD", Market = "US", StoreId = "000002", StoreName = "Store002", DBSizeGB = 6.2,  DBUsedPercent = 20,  DBAvailableGB = 3,   DBAvailablePercent = 35, LastBackupOn = DateTime.Parse("2025-02-01") },
                new SDMTableRow { DatabaseType="SDM_IF_POS", Segment = "IOM LEAD", Market = "CA", StoreId = "000003", StoreName = "Store003", DBSizeGB = 5.8,  DBUsedPercent = 30,  DBAvailableGB = 4,   DBAvailablePercent = 45, LastBackupOn = DateTime.Parse("2025-03-01") },
                new SDMTableRow { DatabaseType="SDM_IF_POS", Segment = "IOM LEAD", Market = "IN", StoreId = "000004", StoreName = "Store004", DBSizeGB = 8.1,  DBUsedPercent = 40,  DBAvailableGB = 2.5, DBAvailablePercent = 30, LastBackupOn = DateTime.Parse("2025-04-01") },
                new SDMTableRow { DatabaseType="SDM_IF_POS", Segment = "IOM LEAD", Market = "UK", StoreId = "000005", StoreName = "Store005", DBSizeGB = 9.0,  DBUsedPercent = 50,  DBAvailableGB = 1.5, DBAvailablePercent = 20, LastBackupOn = DateTime.Parse("2025-05-01") },
                new SDMTableRow { DatabaseType="SDM_IF_POS", Segment = "IOM LEAD", Market = "US", StoreId = "000006", StoreName = "Store006", DBSizeGB = 0.0,  DBUsedPercent = 60,  DBAvailableGB = 3.3, DBAvailablePercent = 41, LastBackupOn = DateTime.Parse("2025-06-01") },
                new SDMTableRow { DatabaseType="SDM_IF_POS", Segment = "IOM LEAD", Market = "CA", StoreId = "000007", StoreName = "Store007", DBSizeGB = 6.5,  DBUsedPercent = 70,  DBAvailableGB = 2.1, DBAvailablePercent = 25, LastBackupOn = DateTime.Parse("2025-07-01") },
                new SDMTableRow { DatabaseType="SDM_IF_POS", Segment = "IOM LEAD", Market = "IN", StoreId = "000008", StoreName = "Store008", DBSizeGB = 10.2, DBUsedPercent = 80,  DBAvailableGB = 1.2, DBAvailablePercent = 15, LastBackupOn = DateTime.Parse("2025-08-01") },
                new SDMTableRow { DatabaseType="SDM_IF_POS", Segment = "IOM LEAD", Market = "UK", StoreId = "000009", StoreName = "Store009", DBSizeGB = 3.5,  DBUsedPercent = 90,  DBAvailableGB = 0.5, DBAvailablePercent = 10, LastBackupOn = DateTime.Parse("2025-09-01") },
                new SDMTableRow { DatabaseType="SDM_IF_POS", Segment = "IOM LEAD", Market = "US", StoreId = "000010", StoreName = "Store010", DBSizeGB = 7.0,  DBUsedPercent = 35,  DBAvailableGB = 3.0, DBAvailablePercent = 30, LastBackupOn = DateTime.Parse("2025-10-01") },
                new SDMTableRow { DatabaseType="SDM_IF_POS", Segment = "IOM LEAD", Market = "CA", StoreId = "000011", StoreName = "Store011", DBSizeGB = 6.9,  DBUsedPercent = 55,  DBAvailableGB = 1.1, DBAvailablePercent = 15, LastBackupOn = DateTime.Parse("2025-11-01") },
                new SDMTableRow { DatabaseType="SDM_IF_POS", Segment = "IOM LEAD", Market = "IN", StoreId = "000012", StoreName = "Store012", DBSizeGB = 5.5,  DBUsedPercent = 25,  DBAvailableGB = 2.5, DBAvailablePercent = 40, LastBackupOn = DateTime.Parse("2025-12-01") },
                new SDMTableRow { DatabaseType="SDM_IF_POS", Segment = "IOM LEAD", Market = "UK", StoreId = "000013", StoreName = "Store013", DBSizeGB = 9.5,  DBUsedPercent = 15,  DBAvailableGB = 2.8, DBAvailablePercent = 32, LastBackupOn = DateTime.Parse("2025-01-15") },
                new SDMTableRow { DatabaseType="SDM_IF_POS", Segment = "IOM LEAD", Market = "US", StoreId = "000014", StoreName = "Store014", DBSizeGB = 8.0,  DBUsedPercent = 45,  DBAvailableGB = 3.2, DBAvailablePercent = 38, LastBackupOn = DateTime.Parse("2025-02-15") },
                new SDMTableRow { DatabaseType="SDM_IF_POS", Segment = "IOM LEAD", Market = "CA", StoreId = "000015", StoreName = "Store015", DBSizeGB = 7.2,  DBUsedPercent = 65,  DBAvailableGB = 1.0, DBAvailablePercent = 12, LastBackupOn = DateTime.Parse("2025-03-15") },
                new SDMTableRow { DatabaseType="SDM_IF_POS", Segment = "IOM LEAD", Market = "IN", StoreId = "000016", StoreName = "Store016", DBSizeGB = 4.4,  DBUsedPercent = 85,  DBAvailableGB = 2.9, DBAvailablePercent = 22, LastBackupOn = DateTime.Parse("2025-04-15") },
                new SDMTableRow { DatabaseType="SDM_IF_POS", Segment = "IOM LEAD", Market = "UK", StoreId = "000017", StoreName = "Store017", DBSizeGB = 8.6,  DBUsedPercent = 95,  DBAvailableGB = 0.7, DBAvailablePercent = 8,  LastBackupOn = DateTime.Parse("2025-05-15") },
                new SDMTableRow { DatabaseType="SDM_IF_POS", Segment = "IOM LEAD", Market = "US", StoreId = "000018", StoreName = "Store018", DBSizeGB = 6.6,  DBUsedPercent = 5,   DBAvailableGB = 6.0, DBAvailablePercent = 90, LastBackupOn = DateTime.Parse("2025-06-15") },
                                                 new SDMTableRow { DatabaseType="SDM_IF_POS", Segment = "IOM LEAD", Market = "CA", StoreId = "000019", StoreName = "Store019", DBSizeGB = 0.0,  DBUsedPercent = 22,  DBAvailableGB = 7.1, DBAvailablePercent = 76, LastBackupOn = DateTime.Parse("2025-07-15") },

              new SDMTableRow { DatabaseType="SDM_Log_File", Segment = "IOM LEAD", Market = "IN", StoreId = "000020", StoreName = "Store020", DBSizeGB = 10.0, DBUsedPercent = 100, DBAvailableGB = 0.0, DBAvailablePercent = 0,  LastBackupOn = DateTime.Parse("2025-08-15") },
                new SDMTableRow { DatabaseType="SDM_Log_File", Segment = "IOM LEAD", Market = "UK", StoreId = "000001", StoreName = "Store001", DBSizeGB = 7.5,  DBUsedPercent = 10,  DBAvailableGB = 2,   DBAvailablePercent = 25, LastBackupOn = DateTime.Parse("2025-01-01") },
                new SDMTableRow { DatabaseType="SDM_Log_File", Segment = "IOM LEAD", Market = "US", StoreId = "000002", StoreName = "Store002", DBSizeGB = 6.2,  DBUsedPercent = 20,  DBAvailableGB = 3,   DBAvailablePercent = 35, LastBackupOn = DateTime.Parse("2025-02-01") },
                new SDMTableRow { DatabaseType="SDM_Log_File", Segment = "IOM LEAD", Market = "CA", StoreId = "000003", StoreName = "Store003", DBSizeGB = 5.8,  DBUsedPercent = 30,  DBAvailableGB = 4,   DBAvailablePercent = 45, LastBackupOn = DateTime.Parse("2025-03-01") },
                new SDMTableRow { DatabaseType="SDM_Log_File", Segment = "IOM LEAD", Market = "IN", StoreId = "000004", StoreName = "Store004", DBSizeGB = 8.1,  DBUsedPercent = 40,  DBAvailableGB = 2.5, DBAvailablePercent = 30, LastBackupOn = DateTime.Parse("2025-04-01") },
                new SDMTableRow { DatabaseType="SDM_Log_File", Segment = "IOM LEAD", Market = "UK", StoreId = "000005", StoreName = "Store005", DBSizeGB = 9.0,  DBUsedPercent = 50,  DBAvailableGB = 1.5, DBAvailablePercent = 20, LastBackupOn = DateTime.Parse("2025-05-01") },
                new SDMTableRow { DatabaseType="SDM_Log_File", Segment = "IOM LEAD", Market = "US", StoreId = "000006", StoreName = "Store006", DBSizeGB = 0.0,  DBUsedPercent = 60,  DBAvailableGB = 3.3, DBAvailablePercent = 41, LastBackupOn = DateTime.Parse("2025-06-01") },
                new SDMTableRow { DatabaseType="SDM_Log_File", Segment = "IOM LEAD", Market = "CA", StoreId = "000007", StoreName = "Store007", DBSizeGB = 6.5,  DBUsedPercent = 70,  DBAvailableGB = 2.1, DBAvailablePercent = 25, LastBackupOn = DateTime.Parse("2025-07-01") },
                new SDMTableRow { DatabaseType="SDM_Log_File", Segment = "IOM LEAD", Market = "IN", StoreId = "000008", StoreName = "Store008", DBSizeGB = 10.2, DBUsedPercent = 80,  DBAvailableGB = 1.2, DBAvailablePercent = 15, LastBackupOn = DateTime.Parse("2025-08-01") },
                new SDMTableRow { DatabaseType="SDM_Log_File", Segment = "IOM LEAD", Market = "UK", StoreId = "000009", StoreName = "Store009", DBSizeGB = 3.5,  DBUsedPercent = 90,  DBAvailableGB = 0.5, DBAvailablePercent = 10, LastBackupOn = DateTime.Parse("2025-09-01") },
                new SDMTableRow { DatabaseType="SDM_Log_File", Segment = "IOM LEAD", Market = "US", StoreId = "000010", StoreName = "Store010", DBSizeGB = 7.0,  DBUsedPercent = 35,  DBAvailableGB = 3.0, DBAvailablePercent = 30, LastBackupOn = DateTime.Parse("2025-10-01") },
                new SDMTableRow { DatabaseType="SDM_Log_File", Segment = "IOM LEAD", Market = "CA", StoreId = "000011", StoreName = "Store011", DBSizeGB = 6.9,  DBUsedPercent = 55,  DBAvailableGB = 1.1, DBAvailablePercent = 15, LastBackupOn = DateTime.Parse("2025-11-01") },
                new SDMTableRow { DatabaseType="SDM_Log_File", Segment = "IOM LEAD", Market = "IN", StoreId = "000012", StoreName = "Store012", DBSizeGB = 5.5,  DBUsedPercent = 25,  DBAvailableGB = 2.5, DBAvailablePercent = 40, LastBackupOn = DateTime.Parse("2025-12-01") },
                new SDMTableRow { DatabaseType="SDM_Log_File", Segment = "IOM LEAD", Market = "UK", StoreId = "000013", StoreName = "Store013", DBSizeGB = 9.5,  DBUsedPercent = 15,  DBAvailableGB = 2.8, DBAvailablePercent = 32, LastBackupOn = DateTime.Parse("2025-01-15") },
                new SDMTableRow { DatabaseType="SDM_Log_File", Segment = "IOM LEAD", Market = "US", StoreId = "000014", StoreName = "Store014", DBSizeGB = 8.0,  DBUsedPercent = 45,  DBAvailableGB = 3.2, DBAvailablePercent = 38, LastBackupOn = DateTime.Parse("2025-02-15") },
                new SDMTableRow { DatabaseType="SDM_Log_File", Segment = "IOM LEAD", Market = "CA", StoreId = "000015", StoreName = "Store015", DBSizeGB = 7.2,  DBUsedPercent = 65,  DBAvailableGB = 1.0, DBAvailablePercent = 12, LastBackupOn = DateTime.Parse("2025-03-15") },
                new SDMTableRow { DatabaseType="SDM_Log_File", Segment = "IOM LEAD", Market = "IN", StoreId = "000016", StoreName = "Store016", DBSizeGB = 4.4,  DBUsedPercent = 85,  DBAvailableGB = 2.9, DBAvailablePercent = 22, LastBackupOn = DateTime.Parse("2025-04-15") },
                new SDMTableRow { DatabaseType="SDM_Log_File", Segment = "IOM LEAD", Market = "UK", StoreId = "000017", StoreName = "Store017", DBSizeGB = 8.6,  DBUsedPercent = 95,  DBAvailableGB = 0.7, DBAvailablePercent = 8,  LastBackupOn = DateTime.Parse("2025-05-15") },
                new SDMTableRow { DatabaseType="SDM_Log_File", Segment = "IOM LEAD", Market = "US", StoreId = "000018", StoreName = "Store018", DBSizeGB = 6.6,  DBUsedPercent = 5,   DBAvailableGB = 6.0, DBAvailablePercent = 90, LastBackupOn = DateTime.Parse("2025-06-15") },
                 new SDMTableRow { DatabaseType="SDM_Log_File", Segment = "IOM LEAD", Market = "CA", StoreId = "000019", StoreName = "Store019", DBSizeGB = 0.0,  DBUsedPercent = 22,  DBAvailableGB = 7.1, DBAvailablePercent = 76, LastBackupOn = DateTime.Parse("2025-07-15") }

            };
        }

    }
}


