using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Models;

namespace Backend_UMR_Work_Program.Services
{
    public class Seeder
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration; 
        private readonly WKP_DBContext _dbContext;
        private readonly IServiceProvider _serviceProvider;
        
        public Seeder(IServiceProvider serviceProvider, IMapper mapper, IConfiguration configuration, WKP_DBContext wKP_DBContext)
        {
            _mapper = mapper;
            _configuration = configuration;
            _dbContext = wKP_DBContext;
            _serviceProvider = serviceProvider;

            //Seed();
        }

        public void Seed()
        {
            SeedTypeOfPayments();
        }

        private void SeedTypeOfPayments()
        {
            try
            {
                var types = new List<string>();
                types.Add(GeneralModel.SubmissionFee);
                types.Add(GeneralModel.LateSubmissionFee);
                types.Add(GeneralModel.ModificationFee);

                types.ForEach( t =>
                {
                    if(_dbContext.TypeOfPayments.Where(x => x.Name == t).FirstOrDefault() == null)
                    {
                        var fee = new TypeOfPayments
                        {
                            Name = t,
                            Category = GeneralModel.MainPayment
                        };

                        _dbContext.TypeOfPayments.Add(fee);
                    }
                });

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
