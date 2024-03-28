namespace SpaceInvaders.Core
{
    public class ClassifiedAction
    {
        public Dictionary<string, Delegate> events = [];

        public void Add<T>(Action<T> action)
        {
            var key = typeof(T).FullName;
            if (key != null)
            {
                if (events.TryGetValue(key, out var current))
                {
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
            var key = obj?.GetType().FullName;
            if (key != null && events.TryGetValue(key, out var value))
            {
                // var action = (Action<T>)value;
                // action?.Invoke(obj);
                value?.DynamicInvoke(obj);
            }
        }

        public void RemoveFor(string typeName)
        {
            events.Remove(typeName);
        }

        public List<string> TypesNames { get => events.Keys.ToList(); }
    }
}
