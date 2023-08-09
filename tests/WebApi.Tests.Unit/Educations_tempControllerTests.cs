using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;

namespace WebApi.Tests.Unit
{
    public class Educations_tempControllerTests
    {
        #region Get
        [Fact]
        public async Task Get_ExistingList_Should_Return_OkResult_With_List()
        {
            // Arrange
            var expectedEducations = new List<EducationDTO>
        {
            new EducationDTO { Id = Guid.NewGuid(), },
            new EducationDTO { Id = Guid.NewGuid(), },
            new EducationDTO { Id = Guid.NewGuid(), }
        };

            var educationsRepositoryMock = new Mock<IEducationRepository_temp>();
            educationsRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(expectedEducations);

            var educationController = new Educations_tempController(educationsRepositoryMock.Object);

            // Act
            var result = await educationController.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedEducations = Assert.IsAssignableFrom<IEnumerable<EducationDTO>>(okResult.Value);
            Assert.Equal(expectedEducations.Count, returnedEducations.Count());
        }

        [Fact]
        public async Task Get_On_Exception_Should_Return_InternalServerError()
        {
            // Arrange
            var educationsRepositoryMock = new Mock<IEducationRepository_temp>();
            educationsRepositoryMock.Setup(repo => repo.GetAll()).ThrowsAsync(new Exception("Simulated exception"));

            var educationController = new Educations_tempController(educationsRepositoryMock.Object);

            // Act
            var result = await educationController.Get();

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetById_ExistingId_Should_Return_OkResult_With_Education()
        {
            // Arrange
            var expectedId = Guid.NewGuid();
            var expectedEducation = new EducationDTO { Id = expectedId, };

            var educationsRepositoryMock = new Mock<IEducationRepository_temp>();
            educationsRepositoryMock.Setup(repo => repo.GetById(expectedId)).ReturnsAsync(expectedEducation);

            var educationController = new Educations_tempController(educationsRepositoryMock.Object);

            // Act
            var result = await educationController.Get(expectedId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedEducation = Assert.IsType<EducationDTO>(okResult.Value);
            Assert.Equal(expectedId, returnedEducation.Id);
        }

        [Fact]
        public async Task GetById_NonExistingId_Should_Return_NoContentResult()
        {
            // Arrange
            var nonExistingId = Guid.NewGuid();

            var educationsRepositoryMock = new Mock<IEducationRepository_temp>();
            educationsRepositoryMock.Setup(repo => repo.GetById(nonExistingId)).ReturnsAsync((EducationDTO)null);

            var educationController = new Educations_tempController(educationsRepositoryMock.Object);

            // Act
            var result = await educationController.Get(nonExistingId);

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status204NoContent, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetById_On_Exception_Should_Return_InternalServerError()
        {
            // Arrange
            var existingId = Guid.NewGuid();
            var educationsRepositoryMock = new Mock<IEducationRepository_temp>();
            educationsRepositoryMock.Setup(repo => repo.GetById(existingId)).ThrowsAsync(new Exception("Simulated exception"));
            var educationController = new Educations_tempController(educationsRepositoryMock.Object);

            // Act
            var result = await educationController.Get(existingId);

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }

        #endregion

        #region Post
        [Fact]
        public async Task Post_Valid_Model_Should_Return_OkResult_With_Education()
        {
            // Arrange
            var validModel = new EducationDTO { };
            var expectedResult = new EducationDTO { Id = Guid.NewGuid(), };
            var educationsRepositoryMock = new Mock<IEducationRepository_temp>();
            educationsRepositoryMock.Setup(repo => repo.Add(validModel)).ReturnsAsync(expectedResult);
            var educationController = new Educations_tempController(educationsRepositoryMock.Object);

            // Act
            var result = await educationController.Post(validModel);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedEducation = Assert.IsType<EducationDTO>(okResult.Value);
            Assert.Equal(expectedResult.Id, returnedEducation.Id);
        }

        [Fact]
        public async Task Post_Invalid_Model_Should_Return_BadRequest()
        {
            // Arrange
            var invalidModel = new EducationDTO { };
            var educationsRepositoryMock = new Mock<IEducationRepository_temp>();
            var educationController = new Educations_tempController(educationsRepositoryMock.Object);
            educationController.ModelState.AddModelError("PropertyName", "Some error message");

            // Act
            var result = await educationController.Post(invalidModel);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Post_Null_Input_Should_Return_BadRequest()
        {
            // Arrange
            var educationsRepositoryMock = new Mock<IEducationRepository_temp>();
            var educationController = new Educations_tempController(educationsRepositoryMock.Object);

            // Act
            var result = await educationController.Post(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Post_On_Exception_Should_Return_InternalServerError()
        {
            // Arrange
            var validModel = new EducationDTO { };
            var educationsRepositoryMock = new Mock<IEducationRepository_temp>();
            educationsRepositoryMock.Setup(repo => repo.Add(validModel)).ThrowsAsync(new Exception("Simulated exception"));
            var educationController = new Educations_tempController(educationsRepositoryMock.Object);

            // Act
            var result = await educationController.Post(validModel);

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }
        #endregion

        #region Put 
        [Fact]
        public async Task Put_ValidModel_Should_Return_OkResult_With_UpdatedEducation()
        {
            // Arrange
            var id = Guid.NewGuid();
            var validModel = new EducationDTO { Id = id, };
            var expectedResult = new EducationDTO { Id = id, };
            var educationsRepositoryMock = new Mock<IEducationRepository_temp>();
            educationsRepositoryMock.Setup(repo => repo.Update(id, validModel)).ReturnsAsync(expectedResult);
            var educationController = new Educations_tempController(educationsRepositoryMock.Object);

            // Act
            var result = await educationController.Put(id, validModel);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedEducation = Assert.IsType<EducationDTO>(okResult.Value);
            Assert.Equal(expectedResult.Id, returnedEducation.Id);
        }

        [Fact]
        public async Task Put_InvalidModel_Should_Return_BadRequest()
        {
            // Arrange
            var id = Guid.NewGuid();
            var invalidModel = new EducationDTO { Id = id, };
            var educationsRepositoryMock = new Mock<IEducationRepository_temp>();
            var educationController = new Educations_tempController(educationsRepositoryMock.Object);
            educationController.ModelState.AddModelError("PropertyName", "Some error message");

            // Act
            var result = await educationController.Put(id, invalidModel);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Put_Id_Mismatch_Should_Return_BadRequest()
        {
            // Arrange
            var id = Guid.NewGuid();
            var validModel = new EducationDTO { Id = Guid.NewGuid(), };
            var educationsRepositoryMock = new Mock<IEducationRepository_temp>();
            var educationController = new Educations_tempController(educationsRepositoryMock.Object);

            // Act
            var result = await educationController.Put(id, validModel);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Put_Null_Input_Should_Return_BadRequest()
        {
            // Arrange
            var id = Guid.NewGuid();
            var educationsRepositoryMock = new Mock<IEducationRepository_temp>();
            var educationController = new Educations_tempController(educationsRepositoryMock.Object);

            // Act
            var result = await educationController.Put(id, null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Put_On_Exception_Should_Return_InternalServerError()
        {
            // Arrange
            var id = Guid.NewGuid();
            var validModel = new EducationDTO { Id = id, };
            var educationsRepositoryMock = new Mock<IEducationRepository_temp>();
            educationsRepositoryMock.Setup(repo => repo.Update(id, validModel)).ThrowsAsync(new Exception("Simulated exception"));
            var educationController = new Educations_tempController(educationsRepositoryMock.Object);

            // Act
            var result = await educationController.Put(id, validModel);

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task Delete_ExistingId_Should_Return_OkResult_With_DeletedEducation()
        {
            // Arrange
            var id = Guid.NewGuid();
            var expectedResult = new EducationDTO { Id = id, };
            var educationsRepositoryMock = new Mock<IEducationRepository_temp>();
            educationsRepositoryMock.Setup(repo => repo.Delete(id)).ReturnsAsync(expectedResult);
            var educationController = new Educations_tempController(educationsRepositoryMock.Object);

            // Act
            var result = await educationController.Delete(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedEducation = Assert.IsType<EducationDTO>(okResult.Value);
            Assert.Equal(expectedResult.Id, returnedEducation.Id);
        }

        [Fact]
        public async Task Delete_NonExistingId_Should_Return_BadRequest()
        {
            // Arrange
            var nonExistingId = Guid.NewGuid();
            var educationsRepositoryMock = new Mock<IEducationRepository_temp>();
            educationsRepositoryMock.Setup(repo => repo.Delete(nonExistingId)).ReturnsAsync((EducationDTO)null);
            var educationController = new Educations_tempController(educationsRepositoryMock.Object);

            // Act
            var result = await educationController.Delete(nonExistingId);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Delete_On_Exception_Should_Return_InternalServerError()
        {
            // Arrange
            var id = Guid.NewGuid();
            var educationsRepositoryMock = new Mock<IEducationRepository_temp>();
            educationsRepositoryMock.Setup(repo => repo.Delete(id)).ThrowsAsync(new Exception("Simulated exception"));
            var educationController = new Educations_tempController(educationsRepositoryMock.Object);

            // Act
            var result = await educationController.Delete(id);

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }
        #endregion
    }
}
