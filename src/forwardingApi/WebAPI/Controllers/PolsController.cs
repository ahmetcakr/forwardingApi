using Application.Features.Pols.Commands.Create;
using Application.Features.Pols.Commands.Delete;
using Application.Features.Pols.Commands.Update;
using Application.Features.Pols.Queries.GetById;
using Application.Features.Pols.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PolsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreatePolCommand createPolCommand)
    {
        CreatedPolResponse response = await Mediator.Send(createPolCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePolCommand updatePolCommand)
    {
        UpdatedPolResponse response = await Mediator.Send(updatePolCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedPolResponse response = await Mediator.Send(new DeletePolCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdPolResponse response = await Mediator.Send(new GetByIdPolQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPolQuery getListPolQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListPolListItemDto> response = await Mediator.Send(getListPolQuery);
        return Ok(response);
    }
}