using Backend_UMR_Work_Program.DataModels;

namespace Backend_UMR_Work_Program.ViewModels
{
    public class CompanyDataCollection
    {
        public RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE? Reserves   {get; set;}                                                                                         
        public RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Addition? ExRAddition    {get; set;}                                                                                              
        public FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDP? fdfApproved   {get; set;}                                                                                    
        public List<GEOPHYSICAL_ACTIVITIES_ACQUISITION>? seismicAcquisition {get; set;}                  
        public List<GEOPHYSICAL_ACTIVITIES_PROCESSING>? seismicProcessing  {get; set;}                
        public List<DRILLING_OPERATIONS_CATEGORIES_OF_WELL>? drillingOperations {get; set;}                      
        public List<INITIAL_WELL_COMPLETION_JOB1>? wellCompletion  {get; set;}           
        public List<WORKOVERS_RECOMPLETION_JOB1>? wellWorkOver {get; set;}           
        public OIL_CONDENSATE_PRODUCTION_ACTIVITy? productionOilCondensate{get; set;}                                                                                    
        public GAS_PRODUCTION_ACTIVITy? productionGas {get; set;}                                                                        
        public List<OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECT>? facilitiesDevProjects {get; set;}                        
        public List<BUDGET_CAPEX_OPEX>? capexOpex {get; set;}  
        public HSE_ENVIRONMENTAL_STUDIES_NEW? envStudies {get; set;}                                                                             
        public HSE_SAFETY_CULTURE_TRAINING? safetyCulTrainings  {get; set;}                                                                          
        public HSE_HOST_COMMUNITIES_DEVELOPMENT? hostComms {get; set;}                                                                                           
        public HSE_OPERATIONS_SAFETY_CASE? opSafetyCases {get; set;}                                                                          
        public HSE_REMEDIATION_FUND? remediationFunds  {get; set;}                                                                               
        public DECOMMISSIONING_ABANDONMENT? DAs  {get; set;}                                                                      
    }

    public class AllCompanyDataCollection
    {
        public List<IGrouping<int?, RESERVES_UPDATES_OIL_CONDENSATE_STATUS_OF_RESERVE>>? Reserves { get; set; }
        public List<IGrouping<int?, RESERVES_UPDATES_OIL_CONDENSATE_Reserves_Addition>>? ExRAddition { get; set; }
        public List<IGrouping<int?, 
            FIELD_DEVELOPMENT_FIELDS_TO_SUBMIT_FDP>>? fdfApproved { get; set; }
        public List<IGrouping<int?, 
            GEOPHYSICAL_ACTIVITIES_ACQUISITION>>? seismicAcquisition { get; set; }
        public List<IGrouping<int?, 
            GEOPHYSICAL_ACTIVITIES_PROCESSING>>? seismicProcessing { get; set; }
        public List<IGrouping<int?, 
            DRILLING_OPERATIONS_CATEGORIES_OF_WELL>>? drillingOperations { get; set; }
        public List<IGrouping<int?, 
            INITIAL_WELL_COMPLETION_JOB1>>? wellCompletion { get; set; }
        public List<IGrouping<int?, 
            WORKOVERS_RECOMPLETION_JOB1>>? wellWorkOver { get; set; }
        public List<IGrouping<int?, 
            OIL_CONDENSATE_PRODUCTION_ACTIVITy>>? productionOilCondensate { get; set; }
        public List<IGrouping<int?, 
            GAS_PRODUCTION_ACTIVITy>>? productionGas { get; set; }
        public List<IGrouping<int?,
            OIL_AND_GAS_FACILITY_MAINTENANCE_PROJECT>>? facilitiesDevProjects { get; set; }
        public List<IGrouping<int?, 
            BUDGET_CAPEX_OPEX>>? capexOpex { get; set; }
        public List<IGrouping<int?, 
            HSE_ENVIRONMENTAL_STUDIES_NEW>>? envStudies { get; set; }
        public List<IGrouping<int?, 
            HSE_SAFETY_CULTURE_TRAINING>>? safetyCulTrainings { get; set; }
        public List<IGrouping<string?,
            HSE_HOST_COMMUNITIES_DEVELOPMENT>>? hostComms { get; set; }
        public List<IGrouping<int?, 
            HSE_OPERATIONS_SAFETY_CASE>>? opSafetyCases { get; set; }
        public List<IGrouping<string?, 
            HSE_REMEDIATION_FUND>>? remediationFunds { get; set; }
        public List<IGrouping<string, 
            DECOMMISSIONING_ABANDONMENT>>? DAs { get; set; }
    }
}
