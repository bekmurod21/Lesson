using Lesson.Data.Contexts;
using Lesson.Data.IRepositories;
using Lesson.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lesson.Data.Repositories
{
    public class Repository<Entity> : IRepository<Entity> where Entity : Auditable
    {
        private readonly AppDbContext dbContext;
        private readonly DbSet<Entity> dbSet;
        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<Entity>();
        }

        public async ValueTask DeleteAsync(Expression<Func<Entity,bool>> expression = null)
        {
            var entity = await dbSet.FirstOrDefaultAsync(expression);
            dbSet.Remove(entity);
        }

        public IQueryable<Entity> GetAllAsync(Expression<Func<Entity, bool>> expression = null)
        => dbSet;
            
        

        public async ValueTask<Entity> GetAsync(Expression<Func<Entity, bool>> expression)
        => await dbSet.FirstOrDefaultAsync(expression);
        

        public async ValueTask<Entity> InsertAsync(Entity entity)
        {
            var model = await dbSet.FirstOrDefaultAsync(x=> x.Id == entity.Id);
            if (model is null)
                return null;
            await dbSet.AddAsync(entity);
            return model;

        }

        public async ValueTask<Entity> UpdateAsync(long id, Entity entity)
        {
            entity.Id = id;
            var model = dbSet.Update(entity);
            return model.Entity;
        }
    }
}
