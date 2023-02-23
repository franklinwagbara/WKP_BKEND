CREATE TABLE [dbo].[MyDesks] (
    [DeskID]      INT            IDENTITY (1, 1) NOT NULL,
    [ProcessID]   INT            NULL,
    [StaffID]     INT            NOT NULL,
    [AppId]       INT            NULL,
    [Sort]        INT            NULL,
    [HasWork]     BIT            NOT NULL,
    [HasPushed]   BIT            NOT NULL,
    [FromStaffID] NVARCHAR (MAX) NULL,
    [FromSBU]     INT            CONSTRAINT [DF__MyDesks__FromSBU__7BBB44FE] DEFAULT ((0)) NOT NULL,
    [CreatedAt]   DATETIME2 (7)  NULL,
    [UpdatedAt]   DATETIME2 (7)  NULL,
    [Comment]     VARCHAR (MAX)  NULL,
    [FromRoleId]  INT            NULL,
    [LastJobDate] DATETIME2 (7)  CONSTRAINT [DF_MyDesks_LastJobDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_MyDesk_UT] PRIMARY KEY CLUSTERED ([DeskID] ASC)
);

