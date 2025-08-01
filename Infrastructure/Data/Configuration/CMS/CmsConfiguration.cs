using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AGL.Api.Domain.Entities;

namespace AGL.Api.Infrastructure.Data.Configuration
{
    class CheckinTeeTimeConfiguration : IEntityTypeConfiguration<TA_Checkin_TeeTime>
    {
        public void Configure(EntityTypeBuilder<TA_Checkin_TeeTime> builder)
        {
            builder.ToTable("TA_Checkin_TeeTime");
            builder.HasKey(e => new { e.TimeId }).HasName("PK_TA_Checkin_TeeTime");

        }

    }

    class TA_GolfField_Configuration : IEntityTypeConfiguration<TA_GolfField>
    {
        public void Configure(EntityTypeBuilder<TA_GolfField> builder)
        {
            builder.ToTable("TA_GolfField");
            builder.HasKey(e => new { e.FieldId }).HasName("PK_TA_GolfField");

        }

    }

    class TA_GolfField_RequestURL_Configuration : IEntityTypeConfiguration<TA_GolfField_RequestURL>
    {
        public void Configure(EntityTypeBuilder<TA_GolfField_RequestURL> builder)
        {
            builder.ToTable("TA_GolfField_RequestURL");
            builder.HasKey(e => new { e.FieldId, e.locale }).HasName("PK_TA_GolfField_RequestURL");

        }

    }

    class TA_FieldPlayDate_Configuration : IEntityTypeConfiguration<TA_FieldPlayDate>
    {
        public void Configure(EntityTypeBuilder<TA_FieldPlayDate> builder)
        {
            builder.ToTable("TA_FieldPlayDate");
            builder.HasKey(e => new { e.FieldId, e.PlayDate }).HasName("PK_TA_FieldPlayDate");

        }

    }

    }
    class TA_TeeTime_Configuration : IEntityTypeConfiguration<TA_TeeTime>
    {
        public void Configure(EntityTypeBuilder<TA_TeeTime> builder)
        {
            builder.ToTable("TA_TeeTime");
            builder.HasKey(e => new { e.TimeId }).HasName("PK_TA_TeeTime");

        }

    }
    class TA_CheckIn_Configuration : IEntityTypeConfiguration<TA_CheckIn>
    {
        public void Configure(EntityTypeBuilder<TA_CheckIn> builder)
        {
            builder.ToTable("TA_CheckIn");
            builder.HasKey(e => new { e.CheckinId }).HasName("TA_CheckIn");

        }

    }

    

    class TA_SalesItemKind_Configuration : IEntityTypeConfiguration<TA_SalesItemKind>
    {
        public void Configure(EntityTypeBuilder<TA_SalesItemKind> builder)
        {
            builder.ToTable("TA_SalesItemKind");
            builder.HasKey(e => new { e.ItemKind }).HasName("PK_TA_SaleItemKind");

        }

    }
    class TA_SalesItem_Configuration : IEntityTypeConfiguration<TA_SalesItem>
    {
        public void Configure(EntityTypeBuilder<TA_SalesItem> builder)
        {
            builder.ToTable("TA_SalesItem");
            builder.HasKey(e => new { e.SalesItemId }).HasName("PK_TA_ShopItem");

        }

    }

    class TA_Daemon_Field_Configuration : IEntityTypeConfiguration<TA_Daemon_Field>
    {
        public void Configure(EntityTypeBuilder<TA_Daemon_Field> builder)
        {
            builder.ToTable("TA_Daemon_Field");
            builder.HasKey(e => new { e.FieldId }).HasName("PK_TA_Daemon_Field");

        }

    }
    class TA_FieldCourse_Configuration : IEntityTypeConfiguration<TA_FieldCourse>
    {
        public void Configure(EntityTypeBuilder<TA_FieldCourse> builder)
        {
            builder.ToTable("TA_FieldCourse");
            builder.HasKey(e => new { e.CourseID }).HasName("PK_TA_FieldCourse");

        }

    class TA_SalesItem_GDS_Configuration : IEntityTypeConfiguration<TA_SalesItem_GDS>
    {
        public void Configure(EntityTypeBuilder<TA_SalesItem_GDS> builder)
        {
            builder.ToTable("TA_SalesItem_GDS");
            builder.HasKey(e => new { e.SalesItemId }).HasName("PK_TA_SalesItem_GDS");

        }

    }
    class TA_SalesItem_GDS_Plan_History_Configuration : IEntityTypeConfiguration<TA_SalesItem_GDS_Plan_History>
    {
        public void Configure(EntityTypeBuilder<TA_SalesItem_GDS_Plan_History> builder)
        {
            builder.ToTable("TA_SalesItem_GDS_Plan_History");
            builder.HasKey(e => new { e.MPlanId }).HasName("PK_TA_SalesItem_GDS_Plan_History");

        }

    }


    class TA_SalesItem_GDS_Plan_Configuration : IEntityTypeConfiguration<TA_SalesItem_GDS_Plan>
    {
        public void Configure(EntityTypeBuilder<TA_SalesItem_GDS_Plan> builder)
        {
            builder.ToTable("TA_SalesItem_GDS_Plan");
            builder.HasKey(e => new { e.PlanId }).HasName("PK_TA_SalesItem_GDS_Plan");

        }

    }
    class TA_SalesItem_GDS_Master_Configuration : IEntityTypeConfiguration<TA_SalesItem_GDS_Master>
    {
        public void Configure(EntityTypeBuilder<TA_SalesItem_GDS_Master> builder)
        {
            builder.ToTable("TA_SalesItem_GDS_Master");
            builder.HasKey(e => new { e.SalesMasterId }).HasName("PK__TA_Sales__E6CE9E26FACD4FDE");

        }

    }

    class TA_Holiday_Configuration : IEntityTypeConfiguration<TA_Holiday>
    {
        public void Configure(EntityTypeBuilder<TA_Holiday> builder)
        {
            builder.ToTable("TA_Holiday");
            builder.HasKey(e => new { e.id }).HasName("PK_TA_Holiday");

        }

    }



    class TA_TeetimePrice_Master_Configuration : IEntityTypeConfiguration<TA_TeetimePrice_Master>
    {
        public void Configure(EntityTypeBuilder<TA_TeetimePrice_Master> builder)
        {
            builder.ToTable("TA_TeetimePrice_Master");
            builder.HasKey(e => new { e.TPMId }).HasName("PK_TA_TeetimePrice_Master");

        }

    }

    class TA_OuterPricing_Configuration : IEntityTypeConfiguration<TA_OuterPricing>
    {
        public void Configure(EntityTypeBuilder<TA_OuterPricing> builder)
        {
            builder.ToTable("TA_OuterPricing");
            builder.HasKey(e => new { e.ID }).HasName("PK_TA_OuterPricing");
        }

    }

    class TA_Teetime_HTT_Configuration : IEntityTypeConfiguration<TA_Teetime_HTT>
    {
        public void Configure(EntityTypeBuilder<TA_Teetime_HTT> builder)
        {
            builder.ToTable("TA_Teetime_HTT");
            builder.HasKey(e => new { e.ResNumber }).HasName("PK__TA_Teeti__1145D993D9EB564F");
        }

    }
    class TA_ACCORDIA_MINMEMBERS_Configuration : IEntityTypeConfiguration<TA_ACCORDIA_MINMEMBERS>
    {
        public void Configure(EntityTypeBuilder<TA_ACCORDIA_MINMEMBERS> builder)
        {
            builder.ToTable("TA_ACCORDIA_MINMEMBERS");
            builder.HasKey(e => new { e.MinMembersId }).HasName("PK_TA_Accordia_MinMembers");
        }

    }
    class TA_DailyCurrencyRate_Configuration : IEntityTypeConfiguration<TA_DailyCurrencyRate>
    {
        public void Configure(EntityTypeBuilder<TA_DailyCurrencyRate> builder)
        {
            builder.ToTable("TA_DailyCurrencyRate");
            builder.HasKey(e => new { e.RateId }).HasName("PK_TA_CurrencyRate");
        }

    }
	class APS_TeeTime_Sync_Configuration : IEntityTypeConfiguration<APS_TeeTime_Sync>
	{
		public void Configure(EntityTypeBuilder<APS_TeeTime_Sync> builder)
		{
			builder.ToTable("APS_TeeTime_Sync");
			builder.HasKey(e => new { e.Id, e.CreateDate }).HasName("PK_APS_TeeTime_Sync");
		}

	}

	class APS_Accordia_MinMembers_Sync_Configuration : IEntityTypeConfiguration<APS_Accordia_MinMembers_Sync>
	{
		public void Configure(EntityTypeBuilder<APS_Accordia_MinMembers_Sync> builder)
		{
			builder.ToTable("APS_Accordia_MinMembers_Sync");
			builder.HasKey(e => new { e.Id, e.CreateDate }).HasName("PK_APS_Accordia_MinMembers_Sync");
		}

	}

	class APS_Daemon_Field_Sync_Configuration : IEntityTypeConfiguration<APS_Daemon_Field_Sync>
	{
		public void Configure(EntityTypeBuilder<APS_Daemon_Field_Sync> builder)
		{
			builder.ToTable("APS_Daemon_Field_Sync");
			builder.HasKey(e => new { e.Id, e.CreateDate }).HasName("PK_APS_Daemon_Field_Sync");
		}

	}

	class APS_DailyCurrencyRate_Sync_Configuration : IEntityTypeConfiguration<APS_DailyCurrencyRate_Sync>
	{
		public void Configure(EntityTypeBuilder<APS_DailyCurrencyRate_Sync> builder)
		{
			builder.ToTable("APS_DailyCurrencyRate_Sync");
			builder.HasKey(e => new { e.Id, e.CreateDate }).HasName("PK_APS_DailyCurrencyRate_Sync");
		}

	}

	class APS_FieldCourse_Sync_Configuration : IEntityTypeConfiguration<APS_FieldCourse_Sync>
	{
		public void Configure(EntityTypeBuilder<APS_FieldCourse_Sync> builder)
		{
			builder.ToTable("APS_FieldCourse_Sync");
			builder.HasKey(e => new { e.Id, e.CreateDate }).HasName("PK_APS_FieldCourse_Sync");
		}

	}



	class APS_GolfField_Sync_Configuration : IEntityTypeConfiguration<APS_GolfField_Sync>
	{
		public void Configure(EntityTypeBuilder<APS_GolfField_Sync> builder)
		{
			builder.ToTable("APS_GolfField_Sync");
			builder.HasKey(e => new { e.Id, e.CreateDate }).HasName("PK_APS_GolfField_Sync");
		}

	}

	class APS_Holiday_Sync_Configuration : IEntityTypeConfiguration<APS_Holiday_Sync>
	{
		public void Configure(EntityTypeBuilder<APS_Holiday_Sync> builder)
		{
			builder.ToTable("APS_Holiday_Sync");
			builder.HasKey(e => new { e.Id, e.CreateDate }).HasName("PK_APS_Holiday_Sync");
		}

	}

	class APS_OuterPricing_Sync_Configuration : IEntityTypeConfiguration<APS_OuterPricing_Sync>
	{
		public void Configure(EntityTypeBuilder<APS_OuterPricing_Sync> builder)
		{
			builder.ToTable("APS_OuterPricing_Sync");
			builder.HasKey(e => new { e.Id, e.CreateDate }).HasName("PK_APS_OuterPricing_Sync");
		}

	}
	class APS_TeetimePrice_Master_Sync_Configuration : IEntityTypeConfiguration<APS_TeetimePrice_Master_Sync>
	{
		public void Configure(EntityTypeBuilder<APS_TeetimePrice_Master_Sync> builder)
		{
			builder.ToTable("APS_TeetimePrice_Master_Sync");
			builder.HasKey(e => new { e.Id, e.CreateDate }).HasName("PK_APS_TeetimePrice_Master_Sync");
		}

	}


	class TA_Sales_Configuration : IEntityTypeConfiguration<TA_Sales>
	{
		public void Configure(EntityTypeBuilder<TA_Sales> builder)
		{
			builder.ToTable("TA_Sales");
			builder.HasKey(e => new { e.StoreSaleId }).HasName("PK_TA_StoreSale");
		}

	}
	class TA_GolfField_API_Configuration : IEntityTypeConfiguration<TA_GolfField_API>
	{
		public void Configure(EntityTypeBuilder<TA_GolfField_API> builder)
		{
			builder.ToTable("TA_GolfField_API");
			builder.HasKey(e => new { e.FieldName }).HasName("PK_TA_GolfField_API");
		}

	}

    class TA_MONITOR_ERROR_LOG_Configuration : IEntityTypeConfiguration<TA_MONITOR_ERROR_LOG>
    {
        public void Configure(EntityTypeBuilder<TA_MONITOR_ERROR_LOG> builder)
        {
            builder.ToTable("TA_MONITOR_ERROR_LOG");
            builder.HasKey(e => new { e.IDX }).HasName("PK_TA_MONITOR_ERROR_LOG");
        }

    }
}