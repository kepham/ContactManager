namespace ContactManager.Views
{
    public class PresenterBase<T> : Notifier
    {
        public PresenterBase(T view)
        {
            View = view;
        }

        public PresenterBase(T view, string tabHeaderPath)
        {
            View = view;
            TabHeaderPath = tabHeaderPath;
        }

        public T View { get; }

        public string TabHeaderPath { get; }
    }
}