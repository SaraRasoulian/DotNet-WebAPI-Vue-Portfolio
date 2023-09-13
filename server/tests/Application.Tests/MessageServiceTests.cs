using Application.DTOs;
using Application.Interfaces;
using Application.Service;
using Domain.Entities;
using Domain.Interfaces;
using FakeItEasy;
using Mapster;

namespace Application.Tests
{
    public class MessageServiceTests
    {
        IUnitOfWork unitOfWork;
        IMessageRepository messageRepository;

        public MessageServiceTests()
        {
            unitOfWork = A.Fake<IUnitOfWork>();
            messageRepository = A.Fake<IMessageRepository>();
            A.CallTo(() => unitOfWork.Message).Returns(messageRepository);
        }

        [Fact]
        public async Task GetAll_With_Data_Returns_List_Of_MessageDto()
        {
            // Arrange
            var messageData = new List<Message>();
            A.CallTo(() => messageRepository.GetAll()).Returns(messageData);
            var messageService = new MessageService(unitOfWork);

            // Act
            var result = await messageService.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<MessageDto>>(result);
            Assert.Equal(messageData.Count, result.Count());
        }

        [Fact]
        public async Task GetById_With_Data_Returns_MessageDto()
        {
            // Arrange
            var messageId = Guid.NewGuid();
            var messageData = A.Dummy<Message>();
            A.CallTo(() => messageRepository.GetById(messageId)).Returns(messageData);
            var messageService = new MessageService(unitOfWork);

            // Act
            var result = await messageService.GetById(messageId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<MessageDto>(result);
        }

        [Fact]
        public async Task Add_Returns_Added_MessageDto()
        {
            // Arrange
            var messageDto = A.Dummy<MessageDto>();
            var addedMessage = messageDto.Adapt<Message>();
            addedMessage.Id = Guid.NewGuid();
            A.CallTo(() => messageRepository.Add(A<Message>._)).Returns(addedMessage);

            var messageService = new MessageService(unitOfWork);

            // Act
            var result = await messageService.Add(messageDto);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<MessageDto>(result);
            Assert.Equal(addedMessage.Id, result.Id);
        }
     
        [Fact]
        public async Task Delete_With_Existing_Id_Returns_True()
        {
            // Arrange
            var existingId = Guid.NewGuid();
            var existingMessage = A.Dummy<Message>();
            A.CallTo(() => messageRepository.GetById(existingId)).Returns(existingMessage);

            var messageService = new MessageService(unitOfWork);

            // Act
            var result = await messageService.Delete(existingId);

            // Assert
            Assert.True(result);
            A.CallTo(() => unitOfWork.Message.Delete(existingMessage)).MustHaveHappenedOnceExactly();
            A.CallTo(() => unitOfWork.SaveChangesAsync(default)).MustHaveHappenedOnceExactly();
        }
    }
}
