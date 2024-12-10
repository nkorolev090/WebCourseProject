//using BLL.Services;
//using DomainModel;
//using Interfaces.DTO;
//using Interfaces.Repository;
//using Interfaces.Services;
//using Moq;
//using System.Security.Claims;

//namespace AutoserviceTest.ServicesTests
//{
//    public class ReqistrationsTest
//    {
//        [Fact]
//        public async Task getAllForClients()
//        {
//            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal();

//            var mockDb = new Mock<IDbRepository>();
//            mockDb.Setup(db => db.Registrations.GetListAsync()).Returns(Task.FromResult(GetTestRegs()));

//            var mockUser = new Mock<IUserService>();
//            mockUser.Setup(serv=>
//            serv.IsAuthenticatedAsync(claimsPrincipal))
//                .Returns(Task.FromResult(client));

//            var mockCart = new Mock<ICartService>();

//            var regService = new RegistrationService(mockDb.Object, mockUser.Object, mockCart.Object);

//            var result = await regService.GetRegistrationsAsync(claimsPrincipal);

//            Assert.Equal(result?.Count, GetTestRegs().Count);
//        }

//        [Fact]
//        public async Task getAllForMechanic()
//        {
//            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal();

//            var mockDb = new Mock<IDbRepository>();
//            mockDb.Setup(db => db.Registrations.GetListAsync()).Returns(Task.FromResult(GetTestRegs()));
//            mockDb.Setup(db => db.Slots.GetListAsync()).Returns(Task.FromResult(GetTestSlots()));

//            var mockUser = new Mock<IUserService>();
//            mockUser.Setup(serv =>
//            serv.IsAuthenticatedAsync(claimsPrincipal))
//                .Returns(Task.FromResult(mechanic));

//            var mockCart = new Mock<ICartService>();

//            var regService = new RegistrationService(mockDb.Object, mockUser.Object, mockCart.Object);

//            var result = await regService.GetRegistrationsAsync(claimsPrincipal);

//            Assert.Equal(result?.Count, GetTestSlots().Count-1);
//        }

//        [Fact]
//        public async Task getAllForMechanicWithDuplicate()
//        {
//            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal();

//            var mockDb = new Mock<IDbRepository>();
//            mockDb.Setup(db => db.Slots.GetListAsync()).Returns(Task.FromResult(GetTestSlots2()));

//            var mockUser = new Mock<IUserService>();
//            mockUser.Setup(serv =>
//            serv.IsAuthenticatedAsync(claimsPrincipal))
//                .Returns(Task.FromResult(mechanic));

//            var mockCart = new Mock<ICartService>();

//            var regService = new RegistrationService(mockDb.Object, mockUser.Object, mockCart.Object);

//            var result = await regService.GetRegistrationsAsync(claimsPrincipal);

//            Assert.Equal(result?.Count, GetTestSlots2().Count - 2);
//        }

//        [Fact]
//        public async Task getAllForGuest()
//        {
//            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal();

//            var mockDb = new Mock<IDbRepository>();
//            mockDb.Setup(db => db.Registrations.GetListAsync()).Returns(Task.FromResult(GetTestRegs()));

//            var mockUser = new Mock<IUserService>();
//            mockUser.Setup(serv =>
//            serv.IsAuthenticatedAsync(claimsPrincipal))
//                .Returns(Task.FromResult<UserDTO?>(null));

//            var mockCart = new Mock<ICartService>();

//            var regService = new RegistrationService(mockDb.Object, mockUser.Object, mockCart.Object);

//            var result = await regService.GetRegistrationsAsync(claimsPrincipal);

//            Assert.Null(result);
//        }

//        private List<Registration> GetTestRegs()
//        {
//            var regs = new List<Registration>
//            {
//                new Registration() {Id = 1, Slots = new List<Slot>(){ new Slot() { MechanicId = 2 } }, CarId = 1, Car = new Car(){OwnerId = client.Client!.id, Brand = "", Model = ""}, Status = 1, StatusNavigation = new Status(){Name = ""} },
//                new Registration() {Id = 2, Slots = new List<Slot>(){ new Slot() { MechanicId = 2 } }, CarId = 1, Car = new Car(){OwnerId = client.Client!.id, Brand = "", Model = ""}, Status = 1, StatusNavigation = new Status(){Name = ""} },
//                new Registration() {Id = 3, Slots = new List<Slot>(){ new Slot() { MechanicId = 2 } }, CarId = 1, Car = new Car(){OwnerId = client.Client!.id, Brand = "", Model = ""}, Status = 1, StatusNavigation = new Status(){Name = ""} },
//                new Registration() {Id = 4, Slots = new List<Slot>(){ new Slot() { MechanicId = 2 } }, CarId = 1, Car = new Car(){OwnerId = client.Client!.id, Brand = "", Model = ""}, Status = 1, StatusNavigation = new Status(){Name = ""} },
//                new Registration() {Id = 5, Slots = new List<Slot>(){ new Slot() { MechanicId = 2 } }, CarId = 1, Car = new Car(){OwnerId = client.Client!.id, Brand = "", Model = ""}, Status = 1, StatusNavigation = new Status(){Name = ""} },
//                new Registration() {Id = 6, Slots = new List<Slot>(){ new Slot() { MechanicId = 2 } }, CarId = 1, Car = new Car(){OwnerId = client.Client!.id, Brand = "", Model = ""}, Status = 1, StatusNavigation = new Status(){Name = ""} },
//            };
//            return regs;
//        }

//        private List<Slot> GetTestSlots()
//        {
//            var slots = new List<Slot>
//            {
//                new Slot() { MechanicId = 1, RegistrationId = 1, Registration = new Registration() {Id = 1, CarId = 1, Car = new Car(){OwnerId = client.Client!.id, Brand = "", Model = ""}, Status = 1, StatusNavigation = new Status(){Name = ""} }, },
//                new Slot() { MechanicId = 2, RegistrationId = 2, Registration = new Registration() {Id = 2, CarId = 1, Car = new Car(){OwnerId = client.Client!.id, Brand = "", Model = ""}, Status = 1, StatusNavigation = new Status(){Name = ""} }, },
//                new Slot() { MechanicId = 2, RegistrationId = 3, Registration = new Registration() {Id = 3, CarId = 1, Car = new Car(){OwnerId = client.Client!.id, Brand = "", Model = ""}, Status = 1, StatusNavigation = new Status(){Name = ""} }, },
//                new Slot() { MechanicId = 2, RegistrationId = 4, Registration = new Registration() {Id = 4, CarId = 1, Car = new Car(){OwnerId = client.Client!.id, Brand = "", Model = ""}, Status = 1, StatusNavigation = new Status(){Name = ""} }, },
//            };
//            return slots;
//        }

//        private List<Slot> GetTestSlots2()
//        {
//            var slots = new List<Slot>
//            {
//                new Slot() { MechanicId = 2, RegistrationId = 1, Registration = new Registration() {Id = 1, CarId = 1, Car = new Car(){OwnerId = client.Client!.id, Brand = "", Model = ""}, Status = 1, StatusNavigation = new Status(){Name = ""} }, },
//                new Slot() { MechanicId = 2, RegistrationId = 1, Registration = new Registration() {Id = 1, CarId = 1, Car = new Car(){OwnerId = client.Client!.id, Brand = "", Model = ""}, Status = 1, StatusNavigation = new Status(){Name = ""} }, },
//                new Slot() { MechanicId = 2, RegistrationId = 3, Registration = new Registration() {Id = 3, CarId = 1, Car = new Car(){OwnerId = client.Client!.id, Brand = "", Model = ""}, Status = 1, StatusNavigation = new Status(){Name = ""} }, },
//                new Slot() { MechanicId = 2, RegistrationId = 3, Registration = new Registration() {Id = 3, CarId = 1, Car = new Car(){OwnerId = client.Client!.id, Brand = "", Model = ""}, Status = 1, StatusNavigation = new Status(){Name = ""} }, },
//            };
//            return slots;
//        }

//        private UserDTO client = new UserDTO()
//        {
//            Client = new ClientDTO(
//                new Client()
//                {
//                    Id = 1,
//                    DiscountId = 1,
//                    DiscountPoints = 0,
//                })
//        };

//        private UserDTO mechanic = new UserDTO()
//        {
//            Mechanic = new MechanicDTO(
//        new Mechanic()
//        {
//            Id = 2
//        })
//        };
//    }
//}
