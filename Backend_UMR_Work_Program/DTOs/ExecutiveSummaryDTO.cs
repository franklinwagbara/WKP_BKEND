using Backend_UMR_Work_Program.DataModels;

namespace Backend_UMR_Work_Program.DTOs
{
    public class ExecutiveSummaryDTO
    {
        public List<ExecutiveSummaryRowDTO> Summary { get; set; } = new List<ExecutiveSummaryRowDTO>();
    }

    public class ExecutiveSummaryRowDTO
    {
        public ADMIN_COMPANY_INFORMATION Company { get; set; }
        public ADMIN_CONCESSIONS_INFORMATION Concession { get; set; }
        public COMPANY_FIELD Field { get; set; }
        public string ReservesOil { get; set; }
        public string ReservesGas { get; set; }
        public string ExReservesAdditionOil { get; set; }
        public string ExReservesAdditionGas { get; set; }
        public string FDPApproved { get; set; }
        public string SeismicAcquisition { get; set; }
        public string SeismicProcessing { get; set; }
        public string WellsDrilling { get; set; }
        public string WellsCompletion { get; set; }
        public string WellsWorkover { get; set; }
        public string ProductionOilCondensate { get; set; }
        public string ProductionGas { get; set; }
        public string FDPPlanProjects { get; set; }
        public string FDPCompletionTimeline { get; set; }
        public string CapexExploration { get; set; }
        public string CapexOthers { get; set; }
        public string OpexOperations { get; set; }
        public string OpexOthers { get; set; }
        public string HSESafety { get; set; }
        public string HSETrainings { get; set; }
        public string HSEIncidentRIP { get; set; }
        public string FEHostCommFund { get; set; }
        public string FEERFFund { get; set; }
        public string FEDAFund { get; set; }
    }
}
