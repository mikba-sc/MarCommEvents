using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MarCommEvents.DAL.Init.LDB
{
    public class Tables
    {
        public static void Init(string connstr)
        {
            // tables
            categories(connstr);
            events(connstr);
            grtypes(connstr);
            locationmap(connstr);
            regions(connstr);
            taxonomy(connstr);

            // cross constraints
            eventCategory(connstr);
            eventGRType(connstr);
            eventRegion(connstr);
            eventTaxonomy(connstr);
        }


        /*
         * table inits
         */
        private static void categories(string connstr)
        {
            string createSql = @"CREATE TABLE[dbo].[Categories](
           [CatID][uniqueidentifier] NOT NULL,
           [CatKey] [nvarchar] (50) NOT NULL,
           [Title] [nvarchar] (255) NOT NULL,
           CONSTRAINT[PK_Categories] PRIMARY KEY CLUSTERED([CatID] ASC) ON[PRIMARY]) ON[PRIMARY]";

            DAL.UtilCalls.exNonQuery(connstr, createSql);
        }

        private static void events(string connstr)
        {
            string createSql = @"

CREATE TABLE [dbo].[Events](
	[ID] [uniqueidentifier] NOT NULL,
	[Approved] [bit] NOT NULL,
	[NonEvent] [bit] NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Location] [nvarchar](255) NOT NULL,
	[Contact] [nvarchar](255) NULL,
	[Description] [ntext] NOT NULL,
	[Starts] [datetime] NULL,
	[Ends] [datetime] NULL,
	[AllDay] [bit] NULL,
	[Cause] [uniqueidentifier] NULL,
	[Type] [uniqueidentifier] NULL,
	[ogImage] [nvarchar](255) NULL,
	[ogTitle] [nvarchar](255) NULL,
	[ogType] [nvarchar](255) NULL,
	[LandingPageURL] [nvarchar](255) NULL,
	[BrochureURL] [nvarchar](255) NULL,
	[PresentationURL] [nvarchar](255) NULL,
	[RegonlineURL] [nvarchar](255) NULL,
	[Cost] [nvarchar](255) NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED (	[ID] ASC) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Events] ADD  CONSTRAINT [DF_Events_ID]  DEFAULT (newid()) FOR [ID]
GO";

            DAL.UtilCalls.exNonQuery(connstr, createSql);
        }

        private static void grtypes(string connstr)
        {
            string createSql = @"
CREATE TABLE [dbo].[GRTypes](
	[GRTypeID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_GRTypes] PRIMARY KEY CLUSTERED ([GRTypeID] ASC) ON [PRIMARY]
) ON [PRIMARY]

GO
";

            DAL.UtilCalls.exNonQuery(connstr, createSql);
        }

        private static void locationmap(string connstr)
        {
            string createSql = @"CREATE TABLE [dbo].[LocationMap](
	[LocationID] [uniqueidentifier] NOT NULL,
	[Short] [nvarchar](5) NOT NULL,
	[Long] [nvarchar](255) NULL,
 CONSTRAINT [PK_LocationMap] PRIMARY KEY CLUSTERED ([LocationID] ASC) ON [PRIMARY]
) ON [PRIMARY]

GO

";

            DAL.UtilCalls.exNonQuery(connstr, createSql);
        }

        private static void regions(string connstr)
        {
            string createSql = @"
CREATE TABLE [dbo].[Regions](
	[RegionID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED ([RegionID] ASC) ON [PRIMARY])
  ON [PRIMARY]

GO
";

            DAL.UtilCalls.exNonQuery(connstr, createSql);
        }
        private static void taxonomy(string connstr)
        {
            string createSql = @"CREATE TABLE [dbo].[Taxonomy](
	[TaxID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](255) NULL,
 CONSTRAINT [PK_Taxonomy] PRIMARY KEY CLUSTERED ([TaxID] ASC) ON [PRIMARY]
) ON [PRIMARY]

GO

";

            DAL.UtilCalls.exNonQuery(connstr, createSql);
        }

        /*
         * cross tab inits
         */

        private static void eventCategory(string connstr)
        {
            string createSql = @"

CREATE TABLE [dbo].[EventCategory](
	[EventID] [uniqueidentifier] NOT NULL,
	[CatID] [uniqueidentifier] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[EventCategory]  WITH CHECK ADD  CONSTRAINT [FK_EventCategory_Categories] FOREIGN KEY([CatID])
REFERENCES [dbo].[Categories] ([CatID])
GO

ALTER TABLE [dbo].[EventCategory] CHECK CONSTRAINT [FK_EventCategory_Categories]
GO

ALTER TABLE [dbo].[EventCategory]  WITH CHECK ADD  CONSTRAINT [FK_EventCategory_Events] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([ID])
GO

ALTER TABLE [dbo].[EventCategory] CHECK CONSTRAINT [FK_EventCategory_Events]
GO


";

            DAL.UtilCalls.exNonQuery(connstr, createSql);
        }

        private static void eventGRType(string connstr)
        {
            string createSql = @"CREATE TABLE [dbo].[EventGRType](
	[EventID] [uniqueidentifier] NOT NULL,
	[GRTypeID] [uniqueidentifier] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[EventGRType]  WITH CHECK ADD  CONSTRAINT [FK_EventGRType_Events] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([ID])
GO

ALTER TABLE [dbo].[EventGRType] CHECK CONSTRAINT [FK_EventGRType_Events]
GO

ALTER TABLE [dbo].[EventGRType]  WITH CHECK ADD  CONSTRAINT [FK_EventGRType_GRTypes] FOREIGN KEY([GRTypeID])
REFERENCES [dbo].[GRTypes] ([GRTypeID])
GO

ALTER TABLE [dbo].[EventGRType] CHECK CONSTRAINT [FK_EventGRType_GRTypes]
GO";

            DAL.UtilCalls.exNonQuery(connstr, createSql);
        }

        private static void eventRegion(string connstr)
        {
            string createSql = @"CREATE TABLE [dbo].[EventRegion](
	[EventID] [uniqueidentifier] NOT NULL,
	[RegionID] [uniqueidentifier] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[EventRegion]  WITH CHECK ADD  CONSTRAINT [FK_EventRegion_Events] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([ID])
GO

ALTER TABLE [dbo].[EventRegion] CHECK CONSTRAINT [FK_EventRegion_Events]
GO

ALTER TABLE [dbo].[EventRegion]  WITH CHECK ADD  CONSTRAINT [FK_EventRegion_Regions] FOREIGN KEY([RegionID])
REFERENCES [dbo].[Regions] ([RegionID])
GO

ALTER TABLE [dbo].[EventRegion] CHECK CONSTRAINT [FK_EventRegion_Regions]
GO
";

            DAL.UtilCalls.exNonQuery(connstr, createSql);
        }

        private static void eventTaxonomy(string connstr)
        {
            string createSql = @"CREATE TABLE [dbo].[EventTaxonomy](
	[EventID] [uniqueidentifier] NOT NULL,
	[TaxID] [uniqueidentifier] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[EventTaxonomy]  WITH CHECK ADD  CONSTRAINT [FK_EventTaxonomy_Events1] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([ID])
GO

ALTER TABLE [dbo].[EventTaxonomy] CHECK CONSTRAINT [FK_EventTaxonomy_Events1]
GO

ALTER TABLE [dbo].[EventTaxonomy]  WITH CHECK ADD  CONSTRAINT [FK_EventTaxonomy_Taxonomy1] FOREIGN KEY([TaxID])
REFERENCES [dbo].[Taxonomy] ([TaxID])
GO

ALTER TABLE [dbo].[EventTaxonomy] CHECK CONSTRAINT [FK_EventTaxonomy_Taxonomy1]
GO";

            DAL.UtilCalls.exNonQuery(connstr, createSql);
        }

        
    }
}