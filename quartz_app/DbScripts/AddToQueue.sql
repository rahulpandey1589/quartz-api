USE [ECart]
GO
/****** Object:  StoredProcedure [dbo].[AddMessageToQueue]    Script Date: 6/7/2020 10:07:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddMessageToQueue]
	@sourceServiceName VARCHAR(100),
	@targetServiceName VARCHAR(100),
	@contractName VARCHAR(100),
	@messageName VARCHAR(100),
	@message NVARCHAR(MAX)
AS
BEGIN
	DECLARE @conversationHandle UNIQUEIDENTIFIER ;
	BEGIN DIALOG CONVERSATION @conversationHandle
		FROM SERVICE @sourceServiceName
		TO SERVICE @targetServiceName
		ON CONTRACT @contractName 
		WITH ENCRYPTION = OFF;
		
	-- Send Message
	SEND ON CONVERSATION @conversationHandle MESSAGE TYPE @messageName(@message);
END
GO


exec [dbo].[AddMessageToQueue] 'PaymentOrderService','PaymentOrderService','ServiceBrokerContract','ServiceBrokerMessage','Rahul|Pandey|New|Message'