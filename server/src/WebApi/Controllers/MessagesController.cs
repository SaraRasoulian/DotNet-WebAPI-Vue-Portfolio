using Application.DTOs;
using Application.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/messages")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var result = await _messageService.GetAll();
            return Ok(result);
        }

        [HttpGet("unread")]
        [Authorize]
        public async Task<IActionResult> GetNumberOfUnread()
        {
            var result = await _messageService.GetNumberOfUnread();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await _messageService.GetById(id);
            if (result is null) return NoContent();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MessageDto dto)
        {
            if (!ModelState.IsValid || dto is null) return BadRequest(ModelState);
            var result = await _messageService.Add(dto);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _messageService.Delete(id);
            if (!result) return BadRequest();
            return Ok();
        }

        [HttpPut("mark-as-read/{id:guid}")]
        [Authorize]
        public async Task<IActionResult> MarkAsRead([FromRoute] Guid id)
        {
            var result = await _messageService.MarkAsRead(id);
            if (!result) return BadRequest();
            return Ok();
        }

    }
}
