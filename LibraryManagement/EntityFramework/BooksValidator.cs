namespace LibraryManagement.EntityFramework;

public class BooksValidator
{
    public bool IsIdValid(string id)
    {
        Guid guid;
        return Guid.TryParse(id, out guid);
    }
    
    public bool IsTitleValid(string title)
    {
        return !string.IsNullOrEmpty(title);
    }

    public bool IsAuthorValid(string author)
    {
        return !string.IsNullOrEmpty(author);
    }

    public bool IsValidISBN(string ISBN)
    {
        return !string.IsNullOrEmpty(ISBN);
    }
}