namespace SchoolCaseStudy.GanaricRepos
{
    public interface IGanaricRepo<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        void Update(T entity);
        Task Add(T entity);
        void Delete(int id);
    }
}
