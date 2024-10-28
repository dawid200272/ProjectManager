namespace ProjectManager.Application.Interfaces;
public interface IRepository<T> where T : IEntity<int>
{
	IQueryable<T> GetAll();
	T GetById(int id);
	int Add(T entity);
	bool Delete(T entity);
}
