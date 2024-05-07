using BE.Application.Interfaces.Repositories;
using BE.Domain.Commons;
using BE.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseAuditableEntity
{
	private readonly BEContext _context;

	public GenericRepository(BEContext context)
	{
		_context = context;
	}

	public IQueryable<T> Entities => _context.Set<T>();

	public async Task<T> AddAsync(T entity)
	{
		await _context.Set<T>().AddAsync(entity);
		return entity;
	}

	public Task DeleteAsync(T entity)
	{
		_context.Set<T>().Remove(entity);
		return Task.CompletedTask;	
	}

	public async Task<List<T>> GetAllAsync()
	{
		return await _context.Set<T>().ToListAsync();
	}

	public async Task<T> GetByIdAsync(int id)
	{
		return await _context.Set<T>().FindAsync(id);
	}

	public Task UpdateAsync(T entity)
	{
		T exist = _context.Set<T>().Find(entity.Id);
		_context.Entry(exist).CurrentValues.SetValues(entity);
		return Task.CompletedTask;
	}
}
