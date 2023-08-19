using Application.Features.Routes.Commands.Create;
using Application.Features.Routes.Commands.Delete;
using Application.Features.Routes.Commands.Update;
using Application.Features.Routes.Queries.GetById;
using Application.Features.Routes.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoutesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateRouteCommand createRouteCommand)
    {
        CreatedRouteResponse response = await Mediator.Send(createRouteCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRouteCommand updateRouteCommand)
    {
        UpdatedRouteResponse response = await Mediator.Send(updateRouteCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedRouteResponse response = await Mediator.Send(new DeleteRouteCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdRouteResponse response = await Mediator.Send(new GetByIdRouteQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListRouteQuery getListRouteQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListRouteListItemDto> response = await Mediator.Send(getListRouteQuery);
        return Ok(response);
    }
}