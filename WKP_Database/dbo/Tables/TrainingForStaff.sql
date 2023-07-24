CREATE TABLE [dbo].[TrainingForStaff] (
    [Training_For_StaffId]    INT IDENTITY (1, 1) NOT NULL,
    [Mgt_Staff_Local]         INT NULL,
    [Mgt_Staff_Foreign]       INT NULL,
    [Senior_Staff_Local]      INT NULL,
    [Senior_Staff_Foreign]    INT NULL,
    [Junior_Staff_Local]      INT NULL,
    [Junior_Staff_Foreign]    INT NULL,
    [Partner_Staff_Local]     INT NULL,
    [Partner_Staff_Foreign]   INT NULL,
    [Regulator_Staff_Local]   INT NULL,
    [Regulator_Staff_Foreign] INT NULL,
    CONSTRAINT [PK_TrainingForStaff] PRIMARY KEY CLUSTERED ([Training_For_StaffId] ASC)
);

