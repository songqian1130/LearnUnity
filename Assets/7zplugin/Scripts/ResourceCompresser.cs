using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

public class ResourceCompresser
{
    private string _srcPath;
    private string _dstPath;

    private const string _dstFileName = "resource.png";

    public ResourceCompresser(string srcPath,string dstPath)
    {
        _srcPath = srcPath;
        _dstPath = dstPath;
    }

    public void Compress()
    {
        var dstFilePath = Path.Combine(_dstPath, _dstFileName);
        if(File.Exists(dstFilePath))
        {
            File.Delete(dstFilePath);
        }
        if(!Directory.Exists(_dstPath))
        {
            Directory.CreateDirectory(_dstPath);
        }
        FileStream fs = new FileStream(dstFilePath, FileMode.Create);
    }
}
