using Application.Features.Consignes.Commands.Create;
using Application.Features.Consignes.Commands.Delete;
using Application.Features.Consignes.Commands.Update;
using Application.Features.Consignes.Queries.GetById;
using Application.Features.Consignes.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConsignesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateConsigneCommand createConsigneCommand)
    {
        CreatedConsigneResponse response = await Mediator.Send(createConsigneCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateConsigneCommand updateConsigneCommand)
    {
        UpdatedConsigneResponse response = await Mediator.Send(updateConsigneCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedConsigneResponse response = await Mediator.Send(new DeleteConsigneCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdConsigneResponse response = await Mediator.Send(new GetByIdConsigneQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListConsigneQuery getListConsigneQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListConsigneListItemDto> response = await Mediator.Send(getListConsigneQuery);
        return Ok(response);
    }
}