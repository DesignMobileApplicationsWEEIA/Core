namespace Domain.Model.Database
{
    public class QueryResult<TValue> : IQueryResult<TValue> where TValue : class
    {
        public TValue Value { get; }
        public bool HasValue { get; }

        public QueryResult(TValue value)
        {
            Value = value;
            HasValue = value != null;
        }

        public QueryResult(TValue value, bool hasValue)
        {
            Value = value;
            HasValue = hasValue;
        }
    }
}