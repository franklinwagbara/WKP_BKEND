using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class ConcessionSituationTwo
{
    public int ConcessionSituationId { get; set; }

    public string? CompanyName { get; set; }

    public string? ContractType { get; set; }

    public string? Terrain { get; set; }

    public string? SignatureBonus { get; set; }

    public string? NoSignatureBonusReason { get; set; }

    public string? ConcessionRentals { get; set; }

    public string? NoConcessionRentalsReason { get; set; }

    public string? ApplicationRenewal { get; set; }

    public string? NoApplicationRenewalReason { get; set; }

    public string? ActualBudgetCurrentYr { get; set; }

    public string? FiveYrsProposal { get; set; }

    public int? CompanyNumber { get; set; }
}
