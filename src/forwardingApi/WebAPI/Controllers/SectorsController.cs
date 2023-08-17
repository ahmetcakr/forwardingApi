using Application.Features.Sectors.Commands.Create;
using Application.Features.Sectors.Commands.Delete;
using Application.Features.Sectors.Commands.Update;
using Application.Features.Sectors.Queries.GetById;
using Application.Features.Sectors.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SectorsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSectorCommand createSectorCommand)
    {
        CreatedSectorResponse response = await Mediator.Send(createSectorCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSectorCommand updateSectorCommand)
    {
        UpdatedSectorResponse response = await Mediator.Send(updateSectorCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedSectorResponse response = await Mediator.Send(new DeleteSectorCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdSectorResponse response = await Mediator.Send(new GetByIdSectorQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSectorQuery getListSectorQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSectorListItemDto> response = await Mediator.Send(getListSectorQuery);
        return Ok(response);
    }
}