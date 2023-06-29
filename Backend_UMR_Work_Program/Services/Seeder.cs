using AutoMapper;
using Backend_UMR_Work_Program.DataModels;
using Backend_UMR_Work_Program.Models;
using static Backend_UMR_Work_Program.Models.GeneralModel;

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
                var types = new List<List<string>> {
                    new List<string>{ TYPE_OF_FEE.NoFee, PAYMENT_CATEGORY.OtherPayment },
                    new List<string>{ TYPE_OF_FEE.SubmissionFee, PAYMENT_CATEGORY.MainPayment },
                    new List<string>{ TYPE_OF_FEE.LateSubmissionFee, PAYMENT_CATEGORY.SecondaryPayment } , 
                    new List<string>{ TYPE_OF_FEE.ModificationFee, PAYMENT_CATEGORY.OtherPayment }
                    };

                types.ForEach( t =>
                {
                    if(_dbContext.TypeOfPayments.Where(x => x.Name == t[0]).FirstOrDefault() == null)
                    {
                        var fee = new TypeOfPayments
                        {
                            Name = t[0],
                            Category = t[1]
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
