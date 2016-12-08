using ContactManager.Model;
using ContactManager.Views;

namespace ContactManager.Presenters
{
    public class EditContactPresenter : PresenterBase<EditContactView>
    {
        private readonly ApplicationPresenter _applicationPresenter;

        public EditContactPresenter(
            ApplicationPresenter applicationPresenter,
            EditContactView view,
            Contact contact)
            : base(view, "Contact.LookupName")
        {
            _applicationPresenter = applicationPresenter;
            Contact = contact;
        }

        public Contact Contact { get; }

        public void SelectImage()
        {
            var imagePath = View.AskUserForImagePath();
            if (!string.IsNullOrEmpty(imagePath))
                Contact.ImagePath = imagePath;
        }

        public void Save()
        {
            _applicationPresenter.SaveContact(Contact);
        }

        public void Delete()
        {
            _applicationPresenter.CloseTab(this);
            _applicationPresenter.DeleteContact(Contact);
        }

        public void Close()
        {
            _applicationPresenter.CloseTab(this);
        }

        public override bool Equals(object obj)
        {
            var presenter = obj as EditContactPresenter;
            return (presenter != null) && presenter.Contact.Equals(Contact);
        }
    }
}