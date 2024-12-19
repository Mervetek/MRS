using System;
using System.IO;
using Avalonia.Controls.Shapes;

namespace MRS.Services;

public class TextFileReaderWriter
{
    public void WriteFile(string filePath, int count)
    {
        if (filePath.Length == 0)
            return;
        var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        filePath = System.IO.Path.Combine(documentsPath, "counter.txt");
        if (!File.Exists(filePath))
            count = 0;
        File.WriteAllText(filePath, count.ToString());
    }

    public string ReadFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            WriteFile(filePath, 0);
            return "";
        }

        var content = File.ReadAllText(filePath);
        return content;
    }
}