using Microsoft.EntityFrameworkCore;
using SchoolCaseStudy.Data;

namespace SchoolCaseStudy.GanaricRepos
{
    public class GanaricRepo<T> : IGanaricRepo<T> where T : class
    {
        protected readonly AppDbContext appDbContext;

        public GanaricRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task Add(T entity)
        {
            await appDbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(int id)
        {
            var d = appDbContext.Set<T>().Find(id);
            if (d != null) { appDbContext.Set<T>().Remove(d); }
       
        }

        public async Task<List<T>> GetAll()
        {
            return await appDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await appDbContext.Set<T>().FindAsync(id);

        }

        public void Update(T entity)
        {
            appDbContext.Set<T>().Update(entity);
        }
    }
}
