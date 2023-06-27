using AppObraSocial.Data;
using AppObraSocial.Models;
using AppObraSocial.Validations.Users;
using MediatR;

namespace AppObraSocial.Services.Users.Commands
{
    public class SaveUserCommand : IRequest<User>
    {
        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;
    }

    public class SaveUserCommandHandler : IRequestHandler<SaveUserCommand, User>
    {
        private readonly ApplicationContext _context;
        private readonly SaveUserValidator _validator;

        public SaveUserCommandHandler(ApplicationContext context, SaveUserValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task<User> Handle(SaveUserCommand request, CancellationToken cancellationToken)
        {
            _validator.Validate(request);
            try
            {
                User u = new User();
                u.Username = request.Username;
                u.Password = request.Password;
                await _context.Users.AddAsync(u);

                Log log = new Log();
                log.Evento = "Creación del usuario: " + request.Username;
                log.Date = DateOnly.FromDateTime(DateTime.Now);
                await _context.Logs.AddAsync(log);

                await _context.SaveChangesAsync();
                return u;
            }
            catch
            {
                throw;
            }
        }
    }
}
