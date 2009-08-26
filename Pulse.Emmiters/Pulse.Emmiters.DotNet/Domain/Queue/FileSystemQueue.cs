using System;
using System.IO;
using System.Text;

namespace Pulse.Domain
{
    public class FileSystemQueue : ISimpleQueue
    {
        public string Path { get; set; }

        public FileSystemQueue(string path)
        {
            Path = path;
        }

        public void AddToQueue(string json)
        {
            Console.WriteLine(json);
            var bytes = Encoding.ASCII.GetBytes(json);
            using (var fw = File.Create(Path + @"\observation_" + DateTime.Now.Ticks))
            {
                fw.Write(Encoding.ASCII.GetBytes(json), 0, bytes.Length);
            }
            using (var fw = File.AppendText(Path + "rolling.txt"))
            {
                fw.Write(json + Environment.NewLine);
            }
        }
    }
}