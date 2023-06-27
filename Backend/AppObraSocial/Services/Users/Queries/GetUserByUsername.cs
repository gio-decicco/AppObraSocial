using AppObraSocial.Data;
using AppObraSocial.Models;
using AppObraSocial.Validations.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppObraSocial.Services.Users.Queries
{
    public class GetUserByUsernameQuery : IRequest<User>
    {
        public string Username { get; set; } = null!;
    }

    public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQuery, User>
    {
        private readonly ApplicationContext _context;
        private readonly GetUserByUsernameValidator _validator;

        public GetUserByUsernameQueryHandler(ApplicationContext context, GetUserByUsernameValidator validator)
        {
            _context = context;
            _validator = validator;
        }
        public async Task<User> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            _validator.Validate(request);
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new Exception("Ingrese un nombre de usuario válido");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
