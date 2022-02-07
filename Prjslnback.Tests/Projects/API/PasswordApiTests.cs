using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Prjslnback.API.Controllers;
using Prjslnback.API.ViewModels;
using Prjslnback.Infra.Interfaces;
using Prjslnback.Services.Interfaces;
using Prjslnback.Services.Services;
using Prjslnback.Tests.Configurations.AutoMapper;
using Prjslnback.Tests.Fixtures;
using Xunit;

namespace Prjslnback.Tests.Projects.Services
{
    public class PasswordApiTests
    {
        private readonly IEPasswordService _service;

        //Mocks
        private readonly IMapper _mapper;
        private readonly Mock<IEPasswordRepository> _repositoryMock;

        PasswordController _controller;
        
        public PasswordApiTests()
        {
            _mapper = AutoMapperConfiguration.GetConfiguration();
            _repositoryMock = new Mock<IEPasswordRepository>();

            _service = new EPasswordService(
                mapper: _mapper,
                repository: _repositoryMock.Object);

            _controller = new PasswordController(_mapper, _service);
        }

        #region Create

        [Fact]
        public void Post_ReturnsOkResult()
        {
            CreatePasswordViewModel viewModel = new CreatePasswordViewModel()
            {
                Password = PasswordFixture.Password[0]
            };

            // Act
            var okResult = _controller.Create(viewModel);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Post_ReturnsOkSenhaValidaCriadaResult()
        {
            var viewModel = new CreatePasswordViewModel()
            {
                Password = PasswordFixture.Password[0]
            };

            // Act
            var okResult = _controller.Create(viewModel);


            // Assert
            var item = okResult.Result as OkObjectResult;
            var resultViewModel = item.Value as ResultViewModel;

            Assert.Equal("Senha válida criada!", resultViewModel.Message);
            Assert.True(resultViewModel.Success);
        }

        [Fact]
        public void Post_DigitePeloMenosUmCaracterEspecialResult()
        {
            var viewModel = new CreatePasswordViewModel()
            {
                Password = PasswordFixture.Password[1]
            };

            // Act
            var okResult = _controller.Create(viewModel);

            // Assert
            var item = okResult.Result as OkObjectResult;

            Assert.IsType<BadRequestObjectResult>(okResult.Result);
        }

        [Fact]
        public void Post_ASenhaDeveTerNoMinimo15CaracteresResult()
        {
            var viewModel = new CreatePasswordViewModel()
            {
                Password = PasswordFixture.Password[2]
            };

            // Act
            var okResult = _controller.Create(viewModel);

            // Assert
            var item = okResult.Result as OkObjectResult;

            Assert.IsType<BadRequestObjectResult>(okResult.Result);
        }

        [Fact]
        public void Post_SenhaDeveTerPeloMenos1CaracterMinusculoResult()
        {
            var viewModel = new CreatePasswordViewModel()
            {
                Password = PasswordFixture.Password[3]
            };

            // Act
            var okResult = _controller.Create(viewModel);

            // Assert
            var item = okResult.Result as OkObjectResult;

            Assert.IsType<BadRequestObjectResult>(okResult.Result);
        }

        [Fact]
        public void Post_SenhaDeveTerPeloMenos1CaracterMaiusculoResult()
        {
            var viewModel = new CreatePasswordViewModel()
            {
                Password = PasswordFixture.Password[4]
            };

            // Act
            var okResult = _controller.Create(viewModel);

            // Assert
            var item = okResult.Result as OkObjectResult;

            Assert.IsType<BadRequestObjectResult>(okResult.Result);
        }

        [Fact]
        public void Post_SenhaCaracteresRepetidosEmSequenciaMaiusculoResult()
        {
            var viewModel = new CreatePasswordViewModel()
            {
                Password = PasswordFixture.Password[5]
            };

            // Act
            var okResult = _controller.Create(viewModel);

            // Assert
            var item = okResult.Result as OkObjectResult;

            Assert.IsType<BadRequestObjectResult>(okResult.Result);
        }

        [Fact]
        public void Post_SenhaCaracteresRepetidosEmSequenciaMinusculoResult()
        {
            var viewModel = new CreatePasswordViewModel()
            {
                Password = PasswordFixture.Password[6]
            };

            // Act
            var okResult = _controller.Create(viewModel);

            // Assert
            var item = okResult.Result as OkObjectResult;

            Assert.IsType<BadRequestObjectResult>(okResult.Result);
        }


        [Fact]
        public void Post_SenhaCaracteresRepetidosEmSequenciaCaseSensitiveResult()
        {
            var viewModel = new CreatePasswordViewModel()
            {
                Password = PasswordFixture.Password[7]
            };

            // Act
            var okResult = _controller.Create(viewModel);

            // Assert
            var item = okResult.Result as OkObjectResult;

            Assert.IsType<BadRequestObjectResult>(okResult.Result);
        }
        #endregion
    }
}
