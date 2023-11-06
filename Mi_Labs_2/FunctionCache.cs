namespace Mi_Labs_2
{
    public sealed class FunctionCache<TKey, TResult>
    {
        private readonly Dictionary<TKey, (TResult, DateTime)> cache = new Dictionary<TKey, (TResult, DateTime)>();
        private TimeSpan defaultDuration = TimeSpan.FromHours(1);

        public delegate TResult Func(TKey key);

        public TResult Get(TKey key, Func function)
        {
            if (cache.ContainsKey(key))
            {
                (TResult result, DateTime timestamp) = cache[key];
                if (DateTime.UtcNow - timestamp <= defaultDuration)
                {
                    return result;
                }
            }

            TResult newResult = function(key);
            cache[key] = (newResult, DateTime.UtcNow);
            return newResult;
        }

        public void SetDefaultDuration(TimeSpan duration) => defaultDuration = duration;
    }
}