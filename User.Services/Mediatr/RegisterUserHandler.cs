using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ResponceModel;
using User.Services.Data;
using User.Services.Data.Models;
using User.Services.Models;

namespace User.Services.Mediatr;

internal class RegisterUserHandler : IRequestHandler<RegisterUser, ResponseData<UserM>>
{
    #region Fields
    private readonly ILogger<RegisterUserHandler> _logger;
    private readonly IDbRepositoryContextFactory _contextFactory;
    #endregion

    #region Constructor
    public RegisterUserHandler(ILogger<RegisterUserHandler> logger, IDbRepositoryContextFactory contextFactory)
    {
        _logger = logger;
        _contextFactory = contextFactory;
    }
    #endregion

    #region IRequestHandler
    public async Task<ResponseData<UserM>> Handle(RegisterUser registerUser, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Register new user");

        if (string.IsNullOrWhiteSpace(registerUser.UserName))
            return new ResponseData<UserM>("Имя пользователя не может быть пустым");

        if (string.IsNullOrWhiteSpace(registerUser.Login))
            return new ResponseData<UserM>("Логин не может быть пустым");

        if (string.IsNullOrWhiteSpace(registerUser.Password))
            return new ResponseData<UserM>("Пароль не может быть пустым");

        using var dbContext = _contextFactory.CreateDbContext();

        var existUser = await dbContext.Users.AsNoTracking().FirstOrDefaultAsync(w => w.Login == registerUser.Login);

        if (existUser is not null)
            return new ResponseData<UserM>(System.Net.HttpStatusCode.BadRequest, "Пользователь с таким логином уже существует");

        var userType = await dbContext.UserTypes.AsNoTracking().FirstOrDefaultAsync(w => w.Id == registerUser.UserTypeId);

        if (userType is null)
            return new ResponseData<UserM>(System.Net.HttpStatusCode.BadRequest, "Такой роли не существует");

        var userDb = GetUserDb(registerUser);

        await dbContext.Users.AddAsync(userDb);
        await dbContext.SaveChangesAsync();
        await dbContext.Entry(userDb).Reference(w => w.UserType).LoadAsync();
        return new ResponseData<UserM>(GetCreatedUser(userDb));
    }
    #endregion

    #region Private methods
    private UserDb GetUserDb(RegisterUser registerUser)
    {
        return new UserDb
        {
            CreateDate = DateTime.Now,
            Login = registerUser.Login,
            Password = BCrypt.Net.BCrypt.HashPassword(registerUser.Password),
            UserTypeId = registerUser.UserTypeId,
            UserName = registerUser.UserName
        };
    }

    private UserM GetCreatedUser(UserDb userDb)
    {
        return new UserM
        {
            Id = userDb.Id,
            Login = userDb.Login,
            UserName = userDb.UserName,
            CreateDateInternal = userDb.CreateDate,
            UserType = new UserType
            {
                Id = userDb.UserTypeId,
                Name = userDb.UserType.Name
            }
        };
    }
    #endregion
}