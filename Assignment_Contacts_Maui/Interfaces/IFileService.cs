namespace Assignment_Contacts_Maui.Interfaces;

public interface IFileService
{
    Task SaveToFileAsync(string filePath, string content);
    string ReadFromFile(string filePath);
}
