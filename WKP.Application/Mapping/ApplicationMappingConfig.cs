using Mapster;
using WKP.Domain.DTOs.Application;

namespace WKP.Application.Mapping
{
    public class ApplicationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Domain.Entities.Application, ApplicationDTO>()
                .Map(d => d.FieldID, s => s.Field.Field_ID)
                .Map(d => d.FieldName, s => s.Field.Field_Name)
                .Map(d => d.ConcessionName, s => s.Concession.Concession_Held)
                .Map(d => d.CompanyName, s => s.Company.NAME);

            config.NewConfig<Domain.Entities.ReturnedApplication, ApplicationDTO>()
                .Map(d => d.Id, s => s.AppId)
                .Map(d => d.FieldID, s => s.Application.Field.Field_ID)
                .Map(d => d.ConcessionID, s => s.Application.ConcessionID)
                .Map(d => d.ConcessionName, s => s.Application.Concession.Concession_Held)
                .Map(d => d.FieldName, s => s.Application.Field.Field_Name)
                .Map(d => d.ReferenceNo, s => s.Application.ReferenceNo)
                .Map(d => d.CreatedAt, s => s.Application.CreatedAt)
                .Map(d => d.SubmittedAt, s => s.Application.SubmittedAt)
                .Map(d => d.Status, s => s.Application.Status)
                .Map(d => d.PaymentStatus, s => s.Application.PaymentStatus)
                .Map(d => d.CompanyName, s => s.Application.Company.NAME)
                .Map(d => d.YearOfWKP, s => s.Application.YearOfWKP)
                .Map(d => d.Last_SBU, s => s.Staff.StrategicBusinessUnit.SBU_Name)
                .Map(d => d.SBU_Comment, s => s.Comment)
                .Map(d => d.Comment, s => s.Comment)
                .Map(d => d.SBU_Tables, s => s.SelectedTables);
        }
    }
}