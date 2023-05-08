namespace JacksonVeroneze.NET.AwsS3.Entities;

public class FileObject
{
    public string Name { get; }

    public string Url { get; }

    public FileObject(string name, string url)
    {
        Name = name;
        Url = url;
    }
}