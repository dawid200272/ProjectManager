namespace ProjectManager.Application.Interfaces;

public interface IEntity<T>
{
    T Id { get; set; }
}