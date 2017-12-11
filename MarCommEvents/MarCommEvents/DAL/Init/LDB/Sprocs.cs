using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MarCommEvents.DAL.Init.LDB
{
    public class Sprocs
    {
        public static void Init(string connstr)
        {
            upsertEvent(connstr);

        }

        private static void upsertEvent(string connstr)
        {
            string createSql = @"
CREATE PROCEDURE [dbo].[spUpsertEvent] (
	@ID uniqueidentifier,
	@Approved bit,
	@NonEvent bit NULL,
	@Title nvarchar(255),
	@Location nvarchar(255),
	@Contact nvarchar(255) NULL,
	@Description ntext,
	@Starts datetime NULL,
	@Ends datetime NULL,
	@AllDay bit NULL,
	@Cause uniqueidentifier NULL,
	@Type uniqueidentifier NULL,
	@ogImage nvarchar(255) NULL,
	@ogTitle nvarchar(255) NULL,
	@ogType nvarchar(255) NULL,
	@LandingPageURL nvarchar(255) NULL,
	@BrochureURL nvarchar(255) NULL,
	@PresentationURL nvarchar(255) NULL,
	@RegonlineURL nvarchar(255) NULL,
	@Cost nvarchar(255) NULL
)
AS
BEGIN
-- =============================================
-- Author:		Mikba
-- Create date: 9/19/17
-- Description:	init
-- =============================================
	SET NOCOUNT ON;

    if @ID is null 
	BEGIN
		update Events set
			Approved = @Approved,
			NonEvent = @NonEvent,
			Title = @Title,
			Location = @Location,
			Contact = @Contact,
			Description = @Description,
			Starts = @Starts,
			Ends = @Ends,
			AllDay = @AllDay,
			Cause = @Cause,
			Type = @Type,
			ogImage = @ogImage,
			ogTitle = @ogTitle,
			ogType = @ogType,
			LandingPageURL = @LandingPageURL,
			BrochureURL = @BrochureURL,
			PresentationURL = @PresentationURL,
			RegonlineURL = @RegonlineURL,
			Cost = @Cost
		where ID = @ID
	END
	ELSE
	BEGIN
		insert into Events
			 (Approved,NonEvent,Title,Location,Contact,Description,Starts,Ends,AllDay,Cause,Type,ogImage,ogTitle,ogType,LandingPageURL,BrochureURL,PresentationURL,RegonlineURL,Cost) 
			 values (@Approved,	@NonEvent,@Title,@Location,@Contact,@Description,@Starts,@Ends,@AllDay,@Cause,@Type,@ogImage,@ogTitle,@ogType,@LandingPageURL,@BrochureURL,@PresentationURL,@RegonlineURL,@Cost)

	END
END

GO

";

            DAL.UtilCalls.exNonQuery(connstr, createSql);
        }
             
    }
}