CREATE TABLE [dbo].[SubstainableDevelopment] (
    [Substainable_DevelopmentId]  INT           IDENTITY (1, 1) NOT NULL,
    [Descript_of_Project_Planned] VARCHAR (MAX) NULL,
    [Descript_of_Project_Actual]  VARCHAR (MAX) NULL,
    CONSTRAINT [PK_SubstainableDevelopment] PRIMARY KEY CLUSTERED ([Substainable_DevelopmentId] ASC)
);

