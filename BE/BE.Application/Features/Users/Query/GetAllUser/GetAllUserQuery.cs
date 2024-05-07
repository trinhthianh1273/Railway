using AutoMapper;
using AutoMapper.QueryableExtensions;
using BE.Application.Interfaces.Repositories;
using BE.Domain.Entities;
using BE.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.Users.Query.GetAllUser;

public record GetAllUserQuery : IRequest<Result<List<GetAllUserDto>>>;

public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, Result<List<GetAllUserDto>>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetAllUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<Result<List<GetAllUserDto>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
	{
		var users = await _unitOfWork.Repository<User>().Entities
							.ProjectTo<GetAllUserDto>(_mapper.ConfigurationProvider)
							.ToListAsync(cancellationToken);

		return await Result<List<GetAllUserDto>>.SuccessAsync(users);
	}
}
