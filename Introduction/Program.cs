using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Windows";
            ShowLargeFilesWithoutLinq(path);
            Console.WriteLine("**************");
            ShowLaregFilesWithLinq(path);
            Console.ReadKey();
        }

        private static void ShowLaregFilesWithLinq(string path)
        {
            var query = from file in new DirectoryInfo(path).GetFiles()
                        orderby file.Length descending      //Orders by Descending Lenth
                        select file;

            Console.WriteLine("///////////////////////////////");
            Console.WriteLine("Query Lambda Expressions :: ");
            foreach (var file in query.Take(5))
            {
                Console.WriteLine($"{file.Name,-20} : {file.Length,10:N0}");
            }

            var query2 = new DirectoryInfo(path).GetFiles()
                         .OrderByDescending(f => f.Length)  //Order by the File Length
                         .Take(5);

            Console.WriteLine("///////////////////////////////");
            Console.WriteLine("Shorthand Lambda Expressions :: ");
            foreach (var file in query2)
            {
                Console.WriteLine($"{file.Name,-20} : {file.Length,10:N0}");
            }
        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInfoComparer());
            for(int i = 0; i < 5; i++)
            {
                FileInfo file = files[i];
                Console.WriteLine($"{file.Name, -20} : {file.Length, 10:N0}");  //Name is Left Justified by 20 Places, while Lenght is right Justified by 10 Places in Number Formal, O after Decimal Places
            }            
        }
    }

    public class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare (FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);        //This Sorts in Dscending Order. If u return x.Length.ComparerTo -> this returns in ascending order.
        }
    }
}
