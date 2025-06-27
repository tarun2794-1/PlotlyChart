namespace SDMChartApp.Models
{
    public class SDMTableRow
    {
        public String DatabaseType { get; set; }
        public string Segment { get; set; }
        public string Market { get; set; }
        public string StoreId { get; set; }
        public string StoreName { get; set; }
        public double DBSizeGB { get; set; }
        public double DBUsedPercent { get; set; }
        public double DBAvailableGB { get; set; }
        public double DBAvailablePercent { get; set; }
        public DateTime LastBackupOn { get; set; }
    }
}
