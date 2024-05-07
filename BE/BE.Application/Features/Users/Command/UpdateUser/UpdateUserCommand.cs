using AutoMapper;
using BE.Application.Common.Mappings;
using BE.Application.Features.Routes.Command.UpdateRoute;
using BE.Application.Interfaces.Persistences;
using BE.Application.Interfaces.Repositories;
using BE.Domain.Entities;
using BE.Shared;
using MediatR;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.Users.Command.UpdateUser;

public record UpdateUserCommand : IRequest<Result<int>>, IMapFrom<User>
{

	public int Id { get; set; }
	public string UserName { get; set; }

	public string Email { get; set; }

	public string Password { get; set; }

	public string FirstName { get; set; }

	public string LastName { get; set; }

	public string? Token { get; set; }
}

internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result<int>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;
	private readonly IPasswordHasing _passwordHassing;

	public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasing passwordHassing)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
		_passwordHassing = passwordHassing;
	}

	public async Task<Result<int>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
	{
		var user = new User()
		{
			Id = request.Id,
			UserName = request.UserName,
			Email = request.Email,
			Password = _passwordHassing.HassPassword(request.Password),
			FirstName = request.FirstName,
			LastName = request.LastName
		};
		await _unitOfWork.Repository<User>().UpdateAsync(user);
		user.AddDomainEvent(new UserUpdatedEvent(user));

		await _unitOfWork.Save(cancellationToken);
		return await Result<int>.SuccessAsync(user.Id, "User Updated.");
	}
}
