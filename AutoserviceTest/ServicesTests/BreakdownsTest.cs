using BLL.Services;
using DomainModel;
using Interfaces.Repository;
using Moq;

namespace AutoserviceTest.ServicesTests
{
    public class BreakdownsTest
    {
        [Fact]
        public async void getAllTest()
        {
            var mockDb = new Mock<IDbRepository>();
            mockDb.Setup(db => db.Breakdowns.GetListAsync()).Returns(Task.FromResult(getBreakdowns()));

            var breakdownService = new BreakdownService(mockDb.Object);

            var result = await breakdownService.GetAllBreakdownsAsync();

            Assert.Equal(result.Count(), getBreakdowns().Count);
        }

        [Theory]
        [InlineData("тех")]
        [InlineData("Замена")]
        [InlineData("Зам")]
        [InlineData("Капитальный")]
        [InlineData("ремонт")]
        public async void getByQueryTest(string query)
        {
            var mockDb = new Mock<IDbRepository>();
            mockDb.Setup(db => db.Breakdowns.GetListAsync()).Returns(Task.FromResult(getBreakdowns()));

            var breakdownService = new BreakdownService(mockDb.Object);

            var result = await breakdownService.GetBreakdownsByQueryAsync(query);

            Assert.Equal(result.Count(), getBreakdowns().Where(b => b.Title.Contains(query)).Count());
        }


        private List<Breakdown> getBreakdowns()
        {
            var result = new List<Breakdown>
            {
                new Breakdown {Price = 100, Id = 1, ImageUrl = "", Title = "Тех. осмотр", Warranty = 0,  },
                new Breakdown {Price = 100, Id = 1, ImageUrl = "", Title = "Замена АКБ", Warranty = 0,  },
                new Breakdown {Price = 100, Id = 1, ImageUrl = "", Title = "Кап. ремонт двигателя", Warranty = 0,  },
                new Breakdown {Price = 100, Id = 1, ImageUrl = "", Title = "Замена шаравой опоры", Warranty = 0,  },
                new Breakdown {Price = 100, Id = 1, ImageUrl = "", Title = "Замена тормозных колодок", Warranty = 0,  }
            };
            return result;
        }
    }
}
