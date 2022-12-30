namespace MovieManager.Infrastructure.FileStore;

public class FileStore : IFileStore
{
    private readonly IFileWrapper _fileWrapper;
    private readonly IDirectoryWrapper _directorWrapper;

    public FileStore(IFileWrapper fileWrapper, IDirectoryWrapper directorWrapper)
    {
        _fileWrapper = fileWrapper;
        _directorWrapper = directorWrapper;
    }

    public string SaveWriteFile(byte[] content, string sourceFileName, string path)
    {
        _directorWrapper.CreateDirectory(path);
        var outputFile = Path.Combine(path, sourceFileName);
        _fileWrapper.WriteAllBytes(outputFile, content);

        return outputFile;
    }
}