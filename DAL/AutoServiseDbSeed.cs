using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AutoServiseDbSeed
    {
        public static async Task InitializeAsync(ModelAutoService modelAutoService)
        {
            try
            {
                modelAutoService.Database.EnsureDeleted();
                if (!modelAutoService.Discounts.Any())
                {
                    var discounts = new Discount[]
                    {
                        new Discount{Name = "Бронзовый", Sale = 5},
                        new Discount{Name = "Серебряный", Sale = 10},
                        new Discount{Name = "Золотой", Sale = 15}
                    };

                    await modelAutoService.Discounts.AddRangeAsync(discounts);

                    await modelAutoService.SaveChangesAsync();

                }

                if (!modelAutoService.Statuses.Any())
                {
                    var statuses = new Status[]
                    {
                        new Status{Name = "На обработке"},
                        new Status{Name = "Одобрена"},
                        new Status{Name = "Отклонена"},
                        new Status{Name = "Завершена"},
                        new Status{Name = "Гарантийный ремонт"}
                    };

                    await modelAutoService.Statuses.AddRangeAsync(statuses);

                    await modelAutoService.SaveChangesAsync();
                }

                if (!modelAutoService.Breakdowns.Any())
                {
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
