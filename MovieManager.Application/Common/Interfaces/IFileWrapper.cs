namespace MovieManager.Application.Common.Interfaces;

public interface IFileWrapper
{
    void WriteAllBytes(string outputFile, byte[] content);
}