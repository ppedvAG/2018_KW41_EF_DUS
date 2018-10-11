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
            var mock = new Mock<IRepository>();
            Core core = new Core(mock.Object);
            mock.Setup(x => x.Query<Produkt>()).Returns(core.GetDemoProdukte().AsQueryable());

            var result = core.GetSchnellstesHerzustellendesProdukt();

            Assert.Equal("Edelgas", result.Name);
        }
    }
}
