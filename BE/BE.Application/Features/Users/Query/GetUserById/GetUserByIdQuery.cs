using AutoMapper;
using AutoMapper.QueryableExtensions;
using BE.Application.Interfaces.Repositories;
using BE.Domain.Entities;
using BE.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Application.Features.Users.Query.GetUserById;

public record GetUserByIdQuery : IRequest<Result<GetUserByIdDto>>
{
	public int Id { get; set; }

	public GetUserByIdQuery(){}

	public GetUserByIdQuery(int id)
	{
		Id = id;
	}
}

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Result<GetUserByIdDto>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<Result<GetUserByIdDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
	{
		var entity = await _unitOfWork.Repository<User>().GetByIdAsync(request.Id);
		var users = _mapper.Map<GetUserByIdDto>(entity);

		return await Result<GetUserByIdDto>.SuccessAsync(users);
	}
}
