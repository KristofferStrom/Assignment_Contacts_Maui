using Assignment_Contacts_Maui.Interfaces;

namespace Assignment_Contacts_Maui.Services;

public class FileService : IFileService
{
    public string ReadFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                using StreamReader sr = new StreamReader(filePath);
                return sr.ReadToEnd();
            }
        }
        catch { }

        return null!;
    }

    public async Task SaveToFileAsync(string filePath, string content)
    {
        try
        {
            using StreamWriter sw = new StreamWriter(filePath);
            await sw.WriteLineAsync(content);
        }
        catch { }
    }
}
