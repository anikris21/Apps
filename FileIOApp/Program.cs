namespace App
{
    using System.Collections.Specialized;
    using System.IO;

    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("----------------- FileIOApp ------------------");
            string[] drives = Environment.GetLogicalDrives();

            Dictionary<string, List<string>> list = new Dictionary<string, List<string>>();
            List<string> files = new List<string>();
            StringCollection log = new StringCollection();

            foreach (string drive in drives)
            {

                DriveInfo driveInfo = new DriveInfo(drive);

                Console.WriteLine($"drive = {drive} {driveInfo.Name} { driveInfo.TotalSize.ToString()}, { driveInfo.TotalFreeSpace}, { driveInfo.RootDirectory}");
                
                DirectoryInfo directoryInfo = new DirectoryInfo(drive);
                List<string> dirs = new List<string>();
                dirs.Add(driveInfo.RootDirectory.Name);

                while(dirs.Count > 0)
                {
                    var dirInf = new DirectoryInfo(dirs[0]);

                    try
                    {
                        var dirsInfo = dirInf.GetDirectories();

                        foreach (var dir in dirsInfo)
                        {
                            FileInfo[] fileinf = new FileInfo[100];
                            dirs.Add(dir.FullName);
                            try
                            {
                                fileinf = dir.GetFiles();
                            }
                            catch (UnauthorizedAccessException e)
                            {
                                log.Add(e.Message);
                            }

                            foreach (var file in fileinf)
                            {
                                files.Append(file?.FullName);
                            }

                        }
                    }
                    catch (UnauthorizedAccessException e) { 
                        log.Add(e.Message); 
                    }

                    //
                    dirs.RemoveAt(0);
                    
                }
            }

            foreach(var file in files)
            {
                Console.WriteLine(file);
            }

            Console.WriteLine("----------------------------------------------");
            Console.ReadKey();
        }
    }
}