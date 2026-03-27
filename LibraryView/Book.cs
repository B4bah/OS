public struct Book
{
    public string author;
    public string title;
    public int dateOfRelease;

    public Book(string author, string title, int dateOfRelease)
    {
        this.author = author;
        this.title = title;
        this.dateOfRelease = dateOfRelease;
    }

    public override string ToString()
    {
        return $"{author} {title} {dateOfRelease}";
    }
}