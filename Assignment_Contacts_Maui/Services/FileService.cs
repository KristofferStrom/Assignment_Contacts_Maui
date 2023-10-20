using Assignment_Contacts_Maui.Interfaces;

namespace Assignment_Contacts_Maui.Services;

//Hämtar all text från en fil, om filen finns. 
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

    //Skriver över, eller skapar upp en fil med content.
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
