using Xunit;
using CadastroSeries_GRUD.Src;
using Moq;
using CadastroSeries_GRUD.Models;
using CadastroSeries_GRUD.Web.Controllers;
using CadastroSeries_GRUD.Web;
using Bogus;

namespace CadastroSeries_GRUD.Tests
{
    public class UnitTest1
    {
        private Faker<SerieModel> construirFakeSeries()
        {
            return new Faker<SerieModel>().RuleFor(e => e.Titulo, ob => ob.Name.FirstName());
        }
        [Fact(DisplayName ="Inserir uma serie no repositorio basico")]
        public void Test1()
        {
            var repositorio = new SerieRepository();

            repositorio.Insere(new Serie(1,Genero.Acao, "titulo ZZZZ", "", 199));

            var seriePersistida = repositorio.RetornaPorId(1);

            Assert.NotNull(seriePersistida);
            Assert.Equal("titulo ZZZZ", seriePersistida.retornaTitulo());
        }

        [Fact(DisplayName = "Inserir uma serie no repositorio via mock")]
        public void Test2() {
            var serie = construirFakeSeries().Generate();
            var repositorio = new Mock<IRepository<Serie>>();
            repositorio.Setup(e => e.ProximoId()).Returns(1);
            var controller = new SerieController(repositorio.Object);

            controller.Insere(new Web.SerieModel());

            repositorio.Verify(obj => obj.Insere(It.Is<Serie>(e => e.Id == 1 && e.retornaTitulo() == "O poderoso chefao")), Times.Once);
        }
    }
}