using CWI.Watcher.Models;
using CWI.Watcher.Shared;
using System;
using System.IO;
using System.Linq;

namespace CWI.Watcher.Classes
{
    public static class FileManager
    {
        /// <summary>
        /// Run
        /// </summary>
        public static void Run()
        {
            try
            {
                Storage.Clear();
                Directory.CreateDirectory(Domain.PathTemp);
                Directory.CreateDirectory(Domain.PathOut);
                SearchFiles();
                new Report().Generate();
                Directory.Delete(Domain.PathTemp, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Scan files in a directory and move to tempary directory
        /// </summary>
        private static void SearchFiles()
        {
            try
            {
                if (!Directory.Exists(Domain.PathIn))
                    throw new Exception($"Input directory {Domain.PathIn} not found!");

                foreach (string pattern in Domain.AcceptedFileFormats)
                {
                    string[] files = Directory.GetFiles(Domain.PathIn, pattern, SearchOption.AllDirectories);

                    foreach (string file in files)
                    {
                        string destinationFile = Path.Combine(Domain.PathTemp, Path.GetFileName(file));
                        File.Move(file, destinationFile, true);
                    }
                }

                ProcessFiles();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Process files in temporary directory
        /// </summary>
        private static void ProcessFiles()
        {
            string[] files = Directory.GetFiles(Domain.PathTemp, "*", SearchOption.AllDirectories);

            foreach (string file in files)
                ReadFile(file);
        }

        /// <summary>
        /// Read lines from a file
        /// </summary>
        /// <param name="file">File name</param>
        private static void ReadFile(string file)
        {
            string line;

            StreamReader reader = new StreamReader(file);
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                try
                {
                    string[] fields = line.Split(Domain.Delimiter);
                    Storage.Add(fields);
                }
                catch (Exception)
                {
                    Console.WriteLine($"{file} file with errors.");
                    Directory.CreateDirectory(Domain.PathError);

                    reader.Close();
                    string destinationFile = Path.Combine(Domain.PathError, Path.GetFileName(file));
                    File.Move(file, destinationFile, true);
                    Storage.FileNamesErrors.Add(file);
                    return;
                }
            }

            reader.Close();
            string destionationFile = Path.Combine(Domain.PathOut, Path.GetFileName(file));
            File.Move(file, destionationFile, true);
            Storage.FileNamesRead.Add(file);
        }

    }
}
