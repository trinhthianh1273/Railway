using AutoMapper;
using BE.Application.Common.Mappings;
using BE.Application.Features.Routes.Command.DeleteRoute;
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

namespace BE.Application.Features.Users.Command.DeleteUser;

public record DeleteUserCommand : IRequest<Result<int>>, IMapFrom<User>
{
	public int Id { get; set; }

	public DeleteUserCommand()
	{
	}

	public DeleteUserCommand(int id)
	{
		Id = id;
	}
}

internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result<int>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public DeleteUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<Result<int>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
	{
		var user = await _unitOfWork.Repository<User>().GetByIdAsync(request.Id);
		if (user == null)
		{
			return await Result<int>.FailureAsync("User Not Found");
		}

		await _unitOfWork.Repository<User>().DeleteAsync(user);
		user.AddDomainEvent(new UserDeletedEvent(user));

		await _unitOfWork.Save(cancellationToken);
		return await Result<int>.SuccessAsync(user.Id, "User Deleted");
	}
}
