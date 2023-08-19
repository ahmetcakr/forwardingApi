using Application.Features.Feeders.Commands.Create;
using Application.Features.Feeders.Commands.Delete;
using Application.Features.Feeders.Commands.Update;
using Application.Features.Feeders.Queries.GetById;
using Application.Features.Feeders.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeedersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateFeederCommand createFeederCommand)
    {
        CreatedFeederResponse response = await Mediator.Send(createFeederCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFeederCommand updateFeederCommand)
    {
        UpdatedFeederResponse response = await Mediator.Send(updateFeederCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedFeederResponse response = await Mediator.Send(new DeleteFeederCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdFeederResponse response = await Mediator.Send(new GetByIdFeederQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListFeederQuery getListFeederQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListFeederListItemDto> response = await Mediator.Send(getListFeederQuery);
        return Ok(response);
    }
}