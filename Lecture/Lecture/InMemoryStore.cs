namespace Lecture
{
    public class InMemoryStore : IStore
    {
        public void Save(ISavable item)
        {
            Item = item??throw new ArgumentNullException(nameof(item));
        }

        public ISavable? Item { get; private set; }
    }
    public class DiskStore : IStore
    {
        public void Save(ISavable item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            // Save item to disk.
            // item.ToText() => disk;
        }
    }
}