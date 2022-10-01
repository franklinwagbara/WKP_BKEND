﻿CREATE TABLE [dbo].[Geophysical_Activities] (
    [Id]                                            INT           IDENTITY (1, 1) NOT NULL,
    [OML_ID]                                        VARCHAR (200) NULL,
    [CompanyName]                                   VARCHAR (500) NULL,
    [Companyemail]                                  VARCHAR (500) NULL,
    [Year_of_WP]                                    VARCHAR (100) NULL,
    [Actual_Year_Acquired]                          VARCHAR (500) NULL,
    [Proposed_Year]                                 VARCHAR (500) NULL,
    [Budget_Allocation]                             VARCHAR (500) NULL,
    [Any_acquired_geophysical_data]                 VARCHAR (500) NULL,
    [Area_of_Coverage]                              VARCHAR (500) NULL,
    [Method_of_Acquisition]                         VARCHAR (500) NULL,
    [Type_of_Data_Acquired]                         VARCHAR (500) NULL,
    [Quantum_of_Data]                               VARCHAR (500) NULL,
    [Quantum_Carry_Forward]                         VARCHAR (200) NULL,
    [Record_Length_of_Data]                         VARCHAR (100) NULL,
    [Completion_Status]                             VARCHAR (500) NULL,
    [Activity_Timeline]                             VARCHAR (5)   NULL,
    [Remarks]                                       VARCHAR (MAX) NULL,
    [Actual_Processed_Reprocessed_Interpreted_data] VARCHAR (500) NULL,
    [Proposed_year_processing]                      VARCHAR (MAX) NULL,
    [Budget_Allocation_pro]                         VARCHAR (500) NULL,
    [Any_Ongoing_Processing_Project]                VARCHAR (500) NULL,
    [Type_of_Data_being_Processed]                  VARCHAR (500) NULL,
    [Quantum_of_Data_pro]                           VARCHAR (500) NULL,
    [Quantum_Carry_Forward_pro]                     VARCHAR (500) NULL,
    [Completion_Status_pro]                         VARCHAR (500) NULL,
    [Activity_Timeline_pro]                         VARCHAR (500) NULL,
    [Remarks_pro]                                   VARCHAR (MAX) NULL,
    [CompanyNumber]                                 INT           NULL,
<<<<<<< HEAD
    CONSTRAINT [PK_Geophysical_Activities_] PRIMARY KEY CLUSTERED ([Id] ASC)
);

=======
    [Field_ID]                                      INT           NULL,
    CONSTRAINT [PK_Geophysical_Activities_] PRIMARY KEY CLUSTERED ([Id] ASC)
);



>>>>>>> origin/main
