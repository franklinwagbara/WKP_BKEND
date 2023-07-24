CREATE TABLE [dbo].[Class_Table] (
    [ClassId] INT          IDENTITY (1, 1) NOT NULL,
    [Class]   VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_Class_Table] PRIMARY KEY CLUSTERED ([ClassId] ASC)
);

