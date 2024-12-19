﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Dtos.MessageDto;
using SignalR.BusinessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		private readonly IMessageService _messageService;
		private readonly IMapper _mapper;
		public MessageController(IMessageService messageService, IMapper mapper)
		{
			_messageService = messageService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult MessageList()
		{
			var values = _messageService.TGetListAll();
			return Ok(_mapper.Map<List<ResultMessageDto>>(values));
		}
		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto createMessageDto)
		{
			createMessageDto.Status = false;
			createMessageDto.MessageSendDate = DateTime.Now;
			var value = _mapper.Map<Message>(createMessageDto);
			_messageService.TAdd(value);
			return Ok("Message Added");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteMessage(int id)
		{
			var value = _messageService.TGetByID(id);
			_messageService.TDelete(value);
			return Ok("Message Deleted");
		}
		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
		{
			var value = _mapper.Map<Message>(updateMessageDto);
			_messageService.TUpdate(value);
			return Ok("Message Updated");
		}
		[HttpGet("{id}")]
		public IActionResult GetMessage(int id)
		{
			var value = _messageService.TGetByID(id);
			return Ok(_mapper.Map<GetMessageDto>(value));
		}
	}
}