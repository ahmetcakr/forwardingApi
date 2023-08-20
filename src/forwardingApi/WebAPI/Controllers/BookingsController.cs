using Application.Features.Bookings.Commands.Create;
using Application.Features.Bookings.Commands.Delete;
using Application.Features.Bookings.Commands.Update;
using Application.Features.Bookings.Queries.GetById;
using Application.Features.Bookings.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebAPI.Controllers;

public class BookingsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBookingCommand createBookingCommand)
    {
        CreatedBookingResponse response = await Mediator.Send(createBookingCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBookingCommand updateBookingCommand)
    {
        UpdatedBookingResponse response = await Mediator.Send(updateBookingCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedBookingResponse response = await Mediator.Send(new DeleteBookingCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdBookingResponse response = await Mediator.Send(new GetByIdBookingQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBookingQuery getListBookingQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBookingListItemDto> response = await Mediator.Send(getListBookingQuery);
        return Ok(response);
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetListAll([FromQuery] PageRequest pageRequest)
    {
        Application.Features.Models.Queries.GetList.GetListBookingQuery getListBookingQuery = new() { PageRequest = pageRequest };
        GetListResponse<Application.Features.Models.Queries.GetList.GetListBookingListItemDto> response = await Mediator.Send(getListBookingQuery);
        return Ok(response);
    }
}