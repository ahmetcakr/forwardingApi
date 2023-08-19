using Application.Features.BookingTypes.Commands.Create;
using Application.Features.BookingTypes.Commands.Delete;
using Application.Features.BookingTypes.Commands.Update;
using Application.Features.BookingTypes.Queries.GetById;
using Application.Features.BookingTypes.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingTypesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBookingTypeCommand createBookingTypeCommand)
    {
        CreatedBookingTypeResponse response = await Mediator.Send(createBookingTypeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBookingTypeCommand updateBookingTypeCommand)
    {
        UpdatedBookingTypeResponse response = await Mediator.Send(updateBookingTypeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedBookingTypeResponse response = await Mediator.Send(new DeleteBookingTypeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdBookingTypeResponse response = await Mediator.Send(new GetByIdBookingTypeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBookingTypeQuery getListBookingTypeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBookingTypeListItemDto> response = await Mediator.Send(getListBookingTypeQuery);
        return Ok(response);
    }
}