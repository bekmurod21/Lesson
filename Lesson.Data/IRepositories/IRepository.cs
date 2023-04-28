using Lesson.Domain.Commons;
using System.Linq.Expressions;

namespace Lesson.Data.IRepositories;

public interface IRepository<Entity> where Entity : Auditable
{
    ValueTask<Entity> InsertAsync(Entity entity);
    ValueTask<Entity> UpdateAsync(long id,Entity entity);
    ValueTask DeleteAsync(Expression<Func<Entity,bool>> expression = null);
    ValueTask<Entity> GetAsync(Expression<Func<Entity,bool>> expression);
    IQueryable<Entity> GetAllAsync(Expression<Func<Entity, bool>> expression = null);
}
