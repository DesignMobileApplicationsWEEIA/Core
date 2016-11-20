namespace Domain.Model.Database
{
    public interface IQueryResult<out TValue> where TValue : class
    {
        bool HasValue { get; }
        TValue Value { get; }
    }
}