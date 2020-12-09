namespace Birthday.Bot.Domain.Factories
{
    public interface IEntityFactory<in TData, out TEntity>
    {
        TEntity Make(TData data);
    }
}
