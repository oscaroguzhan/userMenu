using System.Diagnostics;
using System.Text.Json;
using Domain.Models;

namespace Data.Services;

public class FileService(string fileName = "userList.json", string directoryPath = "Data")
{
    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };

    public void SaveListToFile(List<User> userList)
    {
        try
        {
            // check to directory path exist otherwise create a new
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            
            var json = JsonSerializer.Serialize(userList, _jsonSerializerOptions);
            File.WriteAllText(fileName, json);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
        }
    }

    public List<User> LoadListFromFile()
    {
        try
        {
            // check if the file exist to load
            if (!File.Exists(fileName))
            {
                return [];
            }
            var json = File.ReadAllText(fileName);
            var userList = JsonSerializer.Deserialize<List<User>>(json, _jsonSerializerOptions);
            return userList ?? [];
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return [];
        }
    }
    
}