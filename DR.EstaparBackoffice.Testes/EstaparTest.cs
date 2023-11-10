using DR.EstaparBackoffice.API.Controllers;
using DR.EstaparBackoffice.Domain.Models;
using DR.EstaparBackoffice.Domain.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Assert = Xunit.Assert;

namespace DR.EstaparBackoffice.Testes
{
    public class EstaparControllerTests
    {
        [Fact]
        public async Task BuscarPassagens()
        {
            // Arrange
            var repositoryMock = new Mock<IEstaparRepository>();
            repositoryMock.Setup(repo => repo.DadosPassagens(It.IsAny<string>())).ReturnsAsync(new List<Passagem>());
            var controller = new EstaparController(repositoryMock.Object);

            // Act
            var result = await controller.BuscarPassagens("COTO01");

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal((int)System.Net.HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task BuscarGaragens()
        {
            // Arrange
            var repositoryMock = new Mock<IEstaparRepository>();
            repositoryMock.Setup(repo => repo.DadosGaragens(It.IsAny<string>())).ReturnsAsync(new List<Garagem>());
            var controller = new EstaparController(repositoryMock.Object);

            // Act
            var result = await controller.BuscarGaragens("COTO01");

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal((int)System.Net.HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task BuscarFormasPagamento()
        {
            // Arrange
            var repositoryMock = new Mock<IEstaparRepository>();
            repositoryMock.Setup(repo => repo.FormasPagamento(It.IsAny<string>())).ReturnsAsync(new List<FormaPagamento>());
            var controller = new EstaparController(repositoryMock.Object);

            // Act
            var result = await controller.BuscarFormasPagamento("MEN");

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal((int)System.Net.HttpStatusCode.OK, okResult.StatusCode);
        }
    }
}
