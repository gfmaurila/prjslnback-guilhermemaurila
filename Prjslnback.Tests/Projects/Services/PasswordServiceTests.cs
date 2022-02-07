using AutoMapper;
using Bogus.DataSets;
using FluentAssertions;
using Moq;
using Prjslnback.API.Controllers;
using Prjslnback.Core.Exceptions;
using Prjslnback.Domain.Entities;
using Prjslnback.Infra.Interfaces;
using Prjslnback.Services.DTO;
using Prjslnback.Services.Interfaces;
using Prjslnback.Services.Services;
using Prjslnback.Tests.Configurations.AutoMapper;
using Prjslnback.Tests.Fixtures;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Prjslnback.Tests.Projects.Services
{
    public class PasswordServiceTests
    {
        private readonly IEPasswordService _service;

        //Mocks
        private readonly IMapper _mapper;
        private readonly Mock<IEPasswordRepository> _repositoryMock;

        PasswordController _controller;
        
        public PasswordServiceTests()
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
        public async Task Create_PasswordDTO()
        {
            // Arrange
            var passwordToCreate = PasswordFixture.CreatePasswordDTO();

            var encryptedPassword = new Lorem().Sentence();
            var passwordCreated = _mapper.Map<EPassword>(passwordToCreate);
            passwordCreated.ChangePassword(PasswordFixture.Password[0]);

            _repositoryMock.Setup(x => x.Create(It.IsAny<EPassword>())).ReturnsAsync(() => passwordCreated);

            // Act
            var result = await _service.Create(passwordToCreate);

            // Assert
            result.Should().BeEquivalentTo(_mapper.Map<EPasswordDTO>(passwordCreated));
        }

        [Fact]
        public void Create_ValidatorDTO()
        {
            // Arrange
            var passwordToCreate = PasswordFixture.ValidatorDTO();

            // Act
            bool result = _service.Validator(passwordToCreate);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Core_DomainException()
        {
            // Arrange
            var userToCreate = PasswordFixture.CreateInvalidPasswordDTO();

            // Act
            Func<Task<EPasswordDTO>> act = async () =>
            {
                return await _service.Create(userToCreate);
            };

            // Act
            act.Should().ThrowAsync<DomainException>();
        }
        #endregion
    }
}
