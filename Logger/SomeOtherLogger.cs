namespace Logger
{
    internal class SomeOtherLogger : BaseLogger
    {
        private string classNameInitializer;

        public SomeOtherLogger(string classNameInitializer)
        {
            this.classNameInitializer = classNameInitializer;
        }
    }
}