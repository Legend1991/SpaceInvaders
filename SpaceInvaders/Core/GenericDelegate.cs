namespace SpaceInvaders.Core
{
    public class GenericDelegate
    {
        public Dictionary<string, Delegate> events = new();

        public void Add<T>(Action<T> action)
        {
            var key = typeof(T).FullName;
            if (key != null)
            {
                if (events.ContainsKey(key))
                {
                    var current = events[key];
                    events[key] = Delegate.Combine(current, action);
                }
                else
                {
                    events.Add(key, action);
                }
            }
        }

        public void Invoke<T>(T obj)
        {
            var key = typeof(T).FullName;
            if (key != null && events.TryGetValue(key, out var value))
            {
                var action = (Action<T>)value;
                action?.Invoke(obj);
            }
        }
    }
}
