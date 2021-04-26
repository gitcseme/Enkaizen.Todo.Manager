namespace Enkaizen.Todo.Dal
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
