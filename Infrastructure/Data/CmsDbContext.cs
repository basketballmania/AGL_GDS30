using AGL.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace AGL.Api.Infrastructure.Data
{
	public class CmsDbContext : DbContext
	{

		private readonly ILogger<CmsDbContext> _logger;
		public CmsDbContext(
			DbContextOptions<CmsDbContext> options,

			ILogger<CmsDbContext> logger = null) : base(options)
		{

			_logger = logger;
		}

		public DbSet<TA_Checkin_TeeTime> TA_Checkin_TeeTime { get; set; }
		public DbSet<TA_GolfField> TA_GolfField { get; set; }
		public DbSet<TA_GolfField_RequestURL> TA_GolfField_RequestURL { get; set; }
		public DbSet<TA_FieldPlayDate> TA_FieldPlayDate { get; set; }
		public DbSet<TA_TeeTime> TA_TeeTime { get; set; }
		public DbSet<TA_CheckIn> TA_CheckIn { get; set; }
		public DbSet<TA_Daemon_Field> TA_Daemon_Field { get; set; }
		public DbSet<TA_SalesItem_GDS_Master> TA_SalesItem_GDS_Master { get; set; }
		public DbSet<TA_SalesItem_GDS_Plan> TA_SalesItem_GDS_Plan { get; set; }
		public DbSet<TA_SalesItem_GDS_Plan_History> TA_SalesItem_GDS_Plan_History { get; set; }
		public DbSet<TA_SalesItem_GDS> TA_SalesItem_GDS { get; set; }
		public DbSet<TA_SalesItem> TA_SalesItem { get; set; }
		public DbSet<TA_SalesItemKind> TA_SalesItemKind { get; set; }
		public DbSet<TA_Holiday> TA_Holiday { get; set; }
		public DbSet<TA_FieldCourse> TA_FieldCourse { get; set; }
		public DbSet<TA_TeetimePrice_Master> TA_TeetimePrice_Master { get; set; }
		public DbSet<TA_OuterPricing> TA_OuterPricing { get; set; }
		public DbSet<TA_Teetime_HTT> TA_Teetime_HTT { get; set; }
		public DbSet<TA_ACCORDIA_MINMEMBERS> TA_ACCORDIA_MINMEMBERS { get; set; }
		public DbSet<APS_GolfField_Sync> APS_GolfField_Sync { get; set; }
		public DbSet<APS_Daemon_Field_Sync> APS_Daemon_Field_Sync { get; set; }
		public DbSet<APS_FieldCourse_Sync> APS_FieldCourse_Sync { get; set; }
		public DbSet<APS_OuterPricing_Sync> APS_OuterPricing_Sync { get; set; }
		public DbSet<APS_Accordia_MinMembers_Sync> APS_Accordia_MinMembers_Sync { get; set; }
		public DbSet<APS_TeetimePrice_Master_Sync> APS_TeetimePrice_Master_Sync { get; set; }
		public DbSet<APS_TeeTime_Sync> APS_TeeTime_Sync { get; set; }
		public DbSet<APS_Holiday_Sync> APS_Holiday_Sync { get; set; }
		public DbSet<APS_DailyCurrencyRate_Sync> APS_DailyCurrencyRate_Sync { get; set; }
		public DbSet<TA_DailyCurrencyRate> TA_DailyCurrencyRate { get; set; }
		public DbSet<TA_Sales> TA_Sales { get; set; }
		public DbSet<TA_GolfField_API> TA_GolfField_API { get; set; }
		public DbSet<TA_Client> TA_Client { get; set; }
		public DbSet<TA_FieldClient_Ratio> TA_FieldClient_Ratio { get; set; }
		public DbSet<TA_Transactions> TA_Transactions { get; set; }
		public DbSet<TA_Payment> TA_Payment { get; set; }
        public DbSet<TA_MONITOR_ERROR_LOG> TA_MONITOR_ERROR_LOG { get; set; }
        public DbSet<APS_PAYMENT_ALARMN> APS_PAYMENT_ALARMN { get; set; }
        public DbSet<TA_GolfField_CurrencyRatio> TA_GolfField_CurrencyRatio { get; set; }
        public DbSet<TA_CheckinLock> TA_CheckinLock { get; set; }
        public DbSet<TA_ClientTeeTime> TA_ClientTeeTime { get; set; }
        public DbSet<TA_ClientSales> TA_ClientSales { get; set; }
        public DbSet<TA_SalesItem_Accommodation> TA_SalesItem_Accommodation { get; set; }
        public DbSet<TA_CheckIn_Members> TA_CheckIn_Members { get; set; }
        public DbSet<TA_Resnumber> TA_Resnumber { get; set; }
        public DbSet<TA_OTAPayment> TA_OTAPayment { get; set; }
        public DbSet<TA_BOOKING_PENALTY> TA_BOOKING_PENALTY { get; set; }

        [DbFunction("Encode", "dbo")]
        public string Encode (int code)
        {
            throw new NotImplementedException();
        }

        [DbFunction("Decoder", "dbo")]
        public int Decoder(string code)
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var foreignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }



			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
