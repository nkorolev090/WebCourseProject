using DomainModel;
using Interfaces.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public class AutoServiseDbSeed
    {
        public static async Task InitializeAsync(ModelAutoService modelAutoService)
        {
            try
            {
                modelAutoService.Database.EnsureCreated();
                if (modelAutoService.Discounts.Any())
                {
                    return;
                }
                    var discounts = new Discount[]
                    {
                        new Discount{Name = "Бронзовый", Sale = 5},
                        new Discount{Name = "Серебряный", Sale = 10},
                        new Discount{Name = "Золотой", Sale = 15}
                    };

                    await modelAutoService.Discounts.AddRangeAsync(discounts);

                    await modelAutoService.SaveChangesAsync();



                if (modelAutoService.Statuses.Any())
                {
                    return;
                }
                    var statuses = new Status[]
                    {
                        new Status{Name = "На обработке"},
                        new Status{Name = "Одобрена"},
                        new Status{Name = "Отклонена"},
                        new Status{Name = "Завершена"}
                    };

                    await modelAutoService.Statuses.AddRangeAsync(statuses);

                    await modelAutoService.SaveChangesAsync();


                if (modelAutoService.Breakdowns.Any())
                {
                    return;
                }
                    var breakdowns = new Breakdown[]
                    {
                        new Breakdown{Title = "Тех. осмотр",
                            Info = "Это проверка технического состояния автомобиля или мотоцикла на соответствие требованиям безопасности.",
                            Price = 1500,
                            Warranty = 0
                        },
                        new Breakdown{Title = "Замена тормозных колодок",
                            Info = "Тормозные колодки — это сменные металлические пластины с фрикционными накладками. Именно благодаря им происходит замедление и остановка автомобиля.\r\n\r\nСуществует два типа колодок: для дисковых и для барабанных тормозов.",
                            Price = 2000,
                            Warranty = 3
                        },
                        new Breakdown{Title = "Капитальный ремонт двигателя",
                            Info = "Это процесс, во время которого мотор в целом и все его узлы доводятся до кондиции, максимально близкой к состоянию, в котором двигатель вышел с завода. Делается тогда, когда определяется низкая компрессия и потеря мощности, возникающая из-за естественного пробега автомобиля.",
                            Price = 60000,
                            Warranty = 15
                        }
                    };

                    await modelAutoService.Breakdowns.AddRangeAsync(breakdowns);

                    await modelAutoService.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var dbRepository = serviceProvider.GetRequiredService<IDbRepository>();

            // Создание ролей механика и пользователя
            if (await roleManager.FindByNameAsync("mechanic") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("mechanic"));
            }
            if (await roleManager.FindByNameAsync("client") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("client"));
            }
            // Создание механика
            string mechanicEmail = "mechanic@mail.com";
            string mechanicPassword = "Aa123456!";
            if (await userManager.FindByNameAsync(mechanicEmail) == null)
            {
                Mechanic mechanic = new Mechanic { FullName = "Иванов Иван Иванович" };
                mechanic = await dbRepository.Mechanics.CreateAsync(mechanic);

                User admin = new User { Email = mechanicEmail, UserName = mechanicEmail, MechanicId = mechanic.Id, Mechanic = mechanic };
                IdentityResult result = await userManager.CreateAsync(admin, mechanicPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "mechanic");
                }
            }

            mechanicEmail = "mechanic2@mail.com";
            mechanicPassword = "Aa123456!";
            if (await userManager.FindByNameAsync(mechanicEmail) == null)
            {
                Mechanic mechanic = new Mechanic { FullName = "Смирнов Виталий Иванович" };
                mechanic = await dbRepository.Mechanics.CreateAsync(mechanic);

                User admin = new User { Email = mechanicEmail, UserName = mechanicEmail, MechanicId = mechanic.Id, Mechanic = mechanic };
                IdentityResult result = await userManager.CreateAsync(admin, mechanicPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "mechanic");
                }
            }
            // Создание Пользователя
            string userEmail = "client@mail.com";
            string userPassword = "Aa123456!";
            if (await userManager.FindByNameAsync(userEmail) == null)
            {
                Discount discount = await dbRepository.Discouts.GetItemAsync(1);
                Client client = new Client { DiscountPoints = 0, DiscountId = 1, Discount = discount, BirthDate = DateTime.Parse("01.01.2001")};
                client = await dbRepository.Clients.CreateAsync(client);
                User user = new User { Email = userEmail, UserName = userEmail, ClientId = client.Id, Client = client };
                IdentityResult result = await userManager.CreateAsync(user, userPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "client");
                }
            }
        }
    }
}
