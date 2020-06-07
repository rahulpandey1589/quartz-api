USE [ECart]
GO

/****** Object:  MessageType [ServiceBrokerMessage]    Script Date: 6/7/2020 10:05:50 AM ******/
CREATE MESSAGE TYPE [ServiceBrokerMessage] VALIDATION = NONE
GO
CREATE CONTRACT [ServiceBrokerContract] ([ServiceBrokerMessage] SENT BY INITIATOR)
GO
CREATE QUEUE [dbo].[PaymentOrderProcessingQueue] WITH STATUS = ON , RETENTION = OFF , POISON_MESSAGE_HANDLING (STATUS = ON)  ON [PRIMARY] 
GO
CREATE SERVICE [PaymentOrderService]  ON QUEUE [dbo].[PaymentOrderProcessingQueue] ([ServiceBrokerContract])
GO

