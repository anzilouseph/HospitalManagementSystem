//using AutoMapper;
//using HMS.Context;
//using HMS.DTO;
//using HMS.Entity;
//using HMS.IRepo;
//using HMS.Utility;

//namespace HMS.Repo
//{
//    public class PatientManagementRepo : IPatientManagementRepo
//    {
//        private readonly AppDbContext _context;
//        private readonly IMapper _mapper;
//        public PatientManagementRepo(AppDbContext context,IMapper mapper)
//        {
//            _context = context;
//            _mapper = mapper;
//        }

//        //for patient registratuon
//        public async Task<ApiHelper<bool>> PatientRegistration(PatientForCreationDto patient)
//        {
//            await _context.CreateTransactionAsync();
//            var hashedPassword = Utility.PasswordHashHelper.HashPassword(patient.Password, out string salt);

//            var ifExistEmail = _context.Logins.Where(x=>!x.IsDeleted && x.Email.ToLower()==patient.Email.ToLower());
//            if(ifExistEmail.Any())
//            {
//                return ApiHelper<bool>.Error("Invalid email, Email Already Exist");
//            }
//            var newPatient = _mapper.Map<Patient>(patient);
//            var newLogin = new Login()
//            {
//                Email = patient.Email,
//                Password = hashedPassword,
//                Salt = salt
//            };

//            await _context.Logins.AddAsync(newLogin);
//            var rowAffected = _context.SaveChanges();
//            if(rowAffected<=0)
//            {
//                return ApiHelper<bool>.Error("cannot create credentials");
//            }

//            await _context.AddAsync(newPatient);
//            var rowAffected1 = _context.SaveChanges();
//            if(rowAffected1<=0)
//            {
//                return ApiHelper<bool>.Error("cannot create Patient");

//            }
//            await _context.CommitTransactionAsync();
//        }

//    }
//}
