CREATE TABLE [dbo].[Messages] (
    [id]        INT            IDENTITY (1, 1) NOT NULL,
    [subject]   VARCHAR (250)  NULL,
    [content]   VARCHAR (MAX)  NULL,
    [read]      INT            NULL,
    [companyID] INT            NULL,
    [sender_id] NVARCHAR (200) NULL,
    [date]      DATETIME2 (7)  NULL,
    [AppId]     INT            NULL,
    [staffID]   INT            NULL,
    [UserType]  NCHAR (10)     NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED ([id] ASC)
);





