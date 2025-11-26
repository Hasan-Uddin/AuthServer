using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Businesses;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Businesses.Delete;

internal sealed class DeleteBusinessCommandHandler : ICommandHandler<DeleteBusinessCommand>
{
    private readonly IApplicationDbContext _context;
    public DeleteBusinessCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(DeleteBusinessCommand command, CancellationToken cancellationToken)
    {
        Business? business = await _context.Businesses
            .SingleOrDefaultAsync(b => b.Id == command.Id, cancellationToken);

        if (business is null)
        {
            return Result.Failure(
                Error.NotFound(
                    "Business.NotFound",
                    $"Business with Id {command.Id} not found."
                )
            );
        }

        _context.Businesses.Remove(business);
        await _context.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
