using Moq;
using ppedv.ElenasUwe.Model;
using ppedv.ElenasUwe.Model.Contracts;
using System;
using System.Linq;
using Xunit;

namespace ppedv.ElenasUwe.Logic.Tests
{
    public class CoreTests
    {
        [Fact]
        public void GetSchnellstesHerzustellendesProdukt()
        {

            var repoMock = new Mock<IRepository<Produkt>>();

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x => x.GetRepository<Produkt>()).Returns(repoMock.Object);

            Core core = new Core(uowMock.Object);
            repoMock.Setup(x => x.Query()).Returns(core.GetDemoProdukte().AsQueryable());

            var result = core.GetSchnellstesHerzustellendesProdukt();

            Assert.Equal("Edelgas", result.Name);
        }
    }
}
