using System;
using System.Collections.Generic;

namespace Backend_UMR_Work_Program.DataModels;

public partial class ConcessionSituation
{
    public int Concession_situationId { get; set; }

    public string? Concession_Held { get; set; }

    public string? Date_Grant_Expiration { get; set; }

    public string? Area { get; set; }

    public int? Nbr_discovered_Field { get; set; }

    public long? Budget_Proposal { get; set; }

    public string? Company_Category { get; set; }

    public string? Equity_Shares { get; set; }

    public int? Nbr_Field_Producing { get; set; }
}
