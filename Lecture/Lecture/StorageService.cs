namespace Lecture
{
    public class StorageService
    {
        public StorageService(IStore store)
        {
            Store=store;
        }

        public IStore Store { get; }

        // With Polymorphism.
        public void Save(ISavable item) =>
            Store.Save(item??throw new ArgumentNullException(nameof(item)));


        // Without Polymorphism.
        public void Save(object item)
        {
            switch(item)
            {
                case null:
                    throw new ArgumentNullException(nameof(item));
                case InMemoryStore:
                    // Do something
                    break;
                case DiskStore:
                    // Do something else
                    break;
                case ISavable:
                    Save((ISavable)item);
                    break;
                default:
                    throw new InvalidOperationException($"Code doesn't handle {item!.GetType()}");
            }


            // Using if/else
            #if UseIf
            if(item is InMemoryStore store)
            {

            }
            else if(item is DiskStore disk)
            {

            }
            else
            {
                throw new ArgumentException(nameof(item));
            }
            #endif
        }

    }
}