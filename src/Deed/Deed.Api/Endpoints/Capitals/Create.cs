﻿using Deed.Api.Extensions;
using Deed.Application.Capitals.Commands.Create;
using Deed.Application.Capitals.Requests;
using MediatR;

namespace Deed.Api.Endpoints.Capitals;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("api/capitals", async (AddCapitalRequest request, ISender sender) =>
            (await sender
                .Send(new CreateCapitalCommand(request.Name, request.Balance, request.Currency)))
                .Process())
            .WithTags(nameof(Capitals));
    }
}
