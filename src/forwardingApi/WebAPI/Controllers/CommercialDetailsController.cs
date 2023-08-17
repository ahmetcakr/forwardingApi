using Application.Features.CommercialDetails.Commands.Create;
using Application.Features.CommercialDetails.Commands.Delete;
using Application.Features.CommercialDetails.Commands.Update;
using Application.Features.CommercialDetails.Queries.GetById;
using Application.Features.CommercialDetails.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommercialDetailsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCommercialDetailCommand createCommercialDetailCommand)
    {
        CreatedCommercialDetailResponse response = await Mediator.Send(createCommercialDetailCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCommercialDetailCommand updateCommercialDetailCommand)
    {
        UpdatedCommercialDetailResponse response = await Mediator.Send(updateCommercialDetailCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCommercialDetailResponse response = await Mediator.Send(new DeleteCommercialDetailCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCommercialDetailResponse response = await Mediator.Send(new GetByIdCommercialDetailQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCommercialDetailQuery getListCommercialDetailQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCommercialDetailListItemDto> response = await Mediator.Send(getListCommercialDetailQuery);
        return Ok(response);
    }
}