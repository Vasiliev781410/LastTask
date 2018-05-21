using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace ScanFolder1
{
    public interface IFinderService
    {
        void FindFolder(object baseDirectory);
    }


    public class FinderService : IFinderService
    {
        List<string> Folders = new List<string>();
        public bool Stop = false;
        object locker = new object();

        public void FindFolder(object baseDirectory)
        {
            //ConsoleKeyInfo cki;
            try
            {
                Console.WriteLine(baseDirectory.ToString());

                Folders.AddRange(Directory.GetDirectories(baseDirectory.ToString()));
                var directories = Directory.GetDirectories(baseDirectory.ToString());

                foreach (var directory in directories)
                {                   
                    bool err = false;
                    try
                    {                       
                        var directs = Directory.GetDirectories(directory.ToString());                        
                    }
                    catch                                
                    {
                        Console.WriteLine("Error of acsess for folder - {0}", directory.ToString());
                        err = true;
                       
                    }
                    if (err == false)
                    {
                        Thread thread = new Thread(new ParameterizedThreadStart(FindFolder));
                        try
                        {
                            thread.Name = "thr" + Folders.LongCount().ToString();
                        }
                        catch
                        {
                        }
                        Thread.Sleep(1000);

                        thread.Start(directory);
                        Console.WriteLine(Thread.CurrentThread.Name);
                    }
                }               
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }                       
        }
    }
}
