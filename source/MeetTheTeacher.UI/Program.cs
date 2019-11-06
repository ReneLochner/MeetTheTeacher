using MeetTheTeacher.Logic;
using System;
using System.IO;
using System.Text;
using Utils;

namespace MeetTheTeacher.UI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string pathToInputFiles = MyFile.GetFullFolderNameInApplicationTree("Input");
            string pathToOutputFiles = MyFile.GetFullFolderNameInApplicationTree("Output");

            const string teachersFileName = "Teachers.csv";
            const string detailsFileName = "Details.csv";
            const string ignoredTeachersFileName = "IgnoredTeachers.csv";

            const string resultFileName = "Sprechstunden.html";

            Console.WriteLine("Meet the teacher");
            Console.WriteLine("================");
            string inputFileName = Path.Combine(pathToInputFiles, teachersFileName);
            string[] teacherLines = File.ReadAllLines(inputFileName, Encoding.UTF8);
            string[] detailLines = File.ReadAllLines(Path.Combine(pathToInputFiles, detailsFileName), Encoding.UTF8);
            string[] ignoredNames = File.ReadAllLines(Path.Combine(pathToInputFiles, ignoredTeachersFileName), Encoding.UTF8);

            Controller ctrl = new Controller(teacherLines, detailLines);
            ctrl.DeleteIgnoredTeachers (ignoredNames);

            //throw new NotImplementedException("Ausgabe lt. Angabe (siehe Screenshots) implementieren!");

            string html = ctrl.GetHtmlTable();
            File.WriteAllText(Path.Combine(pathToOutputFiles, resultFileName), html, Encoding.Default);
        }
    }
}
