using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Cinemo.Service
{
  public class FileService
  {
    private string STORE_PATH = "wwwroot/uploads";
    public string PUBLIC_PATH = "/uploads";
    private IWebHostEnvironment _environment;
    public FileService(IWebHostEnvironment environment)
    {
      _environment = environment;
    }

    public string GetPath(string fileName) => PUBLIC_PATH + '/' + fileName;

    public string Save(IFormFile Upload)
    {
      try
      {
        var ext = Path.GetExtension(Upload.FileName);
        var fileName = Guid.NewGuid().ToString() + ext;

        var file = Path.Combine(STORE_PATH, fileName);
        using (var fileStream = new FileStream(file, FileMode.Create))
        {
          Upload.CopyTo(fileStream);
        }
        Console.WriteLine("File uploaded");
        return fileName;
      } catch(Exception error){
        Console.WriteLine(error.Message);
        return null;
      }
    }

    public void Remove(string fileName)
    {
      try
      {
        if (File.Exists(Path.Combine(STORE_PATH, fileName)))
        {
          File.Delete(Path.Combine(STORE_PATH, fileName));
          Console.WriteLine("File deleted.");
        }
        else Console.WriteLine("File not found");
      }
      catch (IOException ioExp)
      {
        Console.WriteLine(ioExp.Message);
      }
    }
  }
}