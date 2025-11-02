using MaterialFlow.Application.Abstractions.Authentication;
using MaterialFlow.Application.Abstractions.Messaging;
using MaterialFlow.Domain.Users;
using MaterialFlow.Domain.Users.ValueObjects;

namespace MaterialFlow.Application.Users.Commands.Register;

internal sealed class RegisterUserCommandHandler(
    IAuthenticationService authenticationService,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<RegisterUserCommand, Guid>
{
    public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var email = new Email(request.Email);

        var isUnique = await userRepository.IsUniqueAsync(email.Value, cancellationToken);

        if (!isUnique)
        {
            return Result.Failure<Guid>(UserErrors.AlreadyExists);
        }

        var user = User.Create(
            Guid.NewGuid(),
            email,
            new FirstName(request.FirstName),
            new LastName(request.LastName),
            string.Empty);

        var identityId = await authenticationService.RegisterAsync(
            user,
            request.Password,
            cancellationToken);

        user.SetIdentityId(identityId);

        await userRepository.AddAsync(user, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}