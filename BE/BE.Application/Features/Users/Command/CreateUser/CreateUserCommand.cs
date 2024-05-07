using AutoMapper;
using BE.Application.Common.Mappings;
using BE.Application.Interfaces.Persistences;
using BE.Application.Interfaces.Repositories;
using BE.Domain.Entities;
using BE.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.Users.Command.CreateUser;

public record CreateUserCommand : IRequest<Result<int>>, IMapFrom<User>
{
	public string UserName { get; set; } = null!;

	public string Email { get; set; } = null!;

	public string Password { get; set; } = null!;

	public string FirstName { get; set; } = null!;

	public string LastName { get; set; } = null!;

	public string? Token { get; set; }
}

internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<int>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;
	private readonly IPasswordHasing _passwordHassing;

	public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasing passwordHasing)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
		_passwordHassing = passwordHasing;
	}

	public async Task<Result<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		var user = new User()
		{
			UserName = request.UserName,
			Email = request.Email,
			Password = _passwordHassing.HassPassword(request.Password),
			FirstName = request.FirstName,
			LastName = request.LastName,
			Token = "",
		};

		await _unitOfWork.Repository<User>().AddAsync(user);
		user.AddDomainEvent(new UserCreatedEvent(user));

		await _unitOfWork.Save(cancellationToken);
		return await Result<int>.SuccessAsync(user.Id, "User Created.");
	}
}
