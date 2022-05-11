using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class autoImport : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var CurrDir = System.IO.Directory.GetCurrentDirectory();
        DirectoryInfo d = new DirectoryInfo($@"{CurrDir}");

        FileInfo[] Files = d.GetFiles("*.ifc");

        foreach(FileInfo file in Files)
        {   
                string str = file.Name.Replace(".ifc", ".obj");
            if (File.Exists($@"{CurrDir}\Models\{str}") == false) {
                var process = System.Diagnostics.Process.Start("CMD.exe", $@"/C cd {CurrDir} & IfcConvert.exe -y -j 1 --use-element-guids {file.Name}");
                process.WaitForExit();
                File.Copy($@"{CurrDir}\{str}", $@"{CurrDir}\Models\{str}");
                File.Delete($@"{CurrDir}\{str}");
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
