using Application.Features.Detentions.Commands.Create;
using Application.Features.Detentions.Commands.Delete;
using Application.Features.Detentions.Commands.Update;
using Application.Features.Detentions.Queries.GetById;
using Application.Features.Detentions.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DetentionsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateDetentionCommand createDetentionCommand)
    {
        CreatedDetentionResponse response = await Mediator.Send(createDetentionCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateDetentionCommand updateDetentionCommand)
    {
        UpdatedDetentionResponse response = await Mediator.Send(updateDetentionCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedDetentionResponse response = await Mediator.Send(new DeleteDetentionCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdDetentionResponse response = await Mediator.Send(new GetByIdDetentionQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDetentionQuery getListDetentionQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListDetentionListItemDto> response = await Mediator.Send(getListDetentionQuery);
        return Ok(response);
    }
}