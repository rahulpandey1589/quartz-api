USE [ECart]
GO

/****** Object:  StoredProcedure [dbo].[ReadFromQueue]    Script Date: 6/7/2020 10:07:28 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[ReadFromQueue]
	@targetQueueName VARCHAR(100)
AS
BEGIN
	DECLARE @execQuery VARCHAR(MAX);

	SET @execQuery='DECLARE @RecvReplyMsg NVARCHAR(MAX);
		DECLARE @RecvReplyDlgHandle UNIQUEIDENTIFIER;

		BEGIN TRANSACTION;

		WAITFOR
		( RECEIVE TOP(1)
		@RecvReplyDlgHandle = conversation_handle,
		@RecvReplyMsg = message_body
		FROM '+@targetQueueName+'
		), TIMEOUT 100


		SELECT @RecvReplyDlgHandle AS [MessageID], @RecvReplyMsg AS [Message];

		COMMIT TRANSACTION'
	EXEC(@execQuery)
END
GO


