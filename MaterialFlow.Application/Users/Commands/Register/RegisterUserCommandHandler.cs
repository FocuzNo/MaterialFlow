using MaterialFlow.Application.Abstractions.Authentication;
using MaterialFlow.Application.Abstractions.Messaging;
using MaterialFlow.Domain.Users;
using MaterialFlow.Domain.Users.ValueObjects;

namespace MaterialFlow.Application.Users.Commands.Register;

internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserCommandHandler(
        IAuthenticationService authenticationService,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _authenticationService = authenticationService;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(
        RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        var email = new Email(request.Email);

        if (!await _userRepository.IsUniqueAsync(
            email.Value,
            cancellationToken))
        {
            return Result.Failure<Guid>(UserErrors.AlreadyExists);
        }

        var user = User.Create(
            Guid.NewGuid(),
            email,
            new FirstName(request.FirstName),
            new LastName(request.LastName),
            string.Empty);

        string identityId = await _authenticationService.RegisterAsync(
            user,
            request.Password,
            cancellationToken);

        user.SetIdentityId(identityId);

        await _userRepository.AddAsync(user, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}