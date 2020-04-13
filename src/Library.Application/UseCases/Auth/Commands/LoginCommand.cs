﻿using MediatR;

namespace Library.Application.UseCases.Auth.Commands
{
    public class LoginCommand : IRequest<LoginCommandResponse>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
