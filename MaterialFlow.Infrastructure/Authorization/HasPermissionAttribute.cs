using Microsoft.AspNetCore.Authorization;

namespace MaterialFlow.Infrastructure.Authorization;

public sealed class HasPermissionAttribute(string permission) : AuthorizeAttribute(permission);