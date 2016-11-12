using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades {
	class Program {
		static void Main(string[] args) {

			SpeechSynthesizer synth = new SpeechSynthesizer();
			//synth.Speak("Hola, this is the Grade book program!");

			IGradeTracker book = CreateGradeBook();

			GetBookName(book);
			AddGrades(book);
			SaveGrades(book);
			WriteResults(book);

		}

		private static ThrowAwayGradeBook CreateGradeBook() {
			return new ThrowAwayGradeBook();
		}

		private static void WriteResults(IGradeTracker book) {
			GradeStatistics stats = book.ComputeStatistics();

			foreach (float grade in book) {
				Console.WriteLine(grade);
			}

			WriteResult("Average Grade ", stats.AverageGrade);
			WriteResult("Highest Grade ", (int)stats.HighestGrade);
			WriteResult("Lowest Grade ", stats.LowestGrade);
			WriteResult(stats.Description, stats.LetterGrade);
		}

		private static void SaveGrades(IGradeTracker book) {
			using (StreamWriter outputFile = File.CreateText("grades.txt")) {
				book.WriteGrades(outputFile);
				outputFile.Close();
			}
		}

		private static void AddGrades(IGradeTracker book) {
			book.AddGrade(90);
			book.AddGrade(80f);
			book.AddGrade(71.5f);
		}

		private static void GetBookName(IGradeTracker book) {
			// Delegates are multicast entities. They can refer to multiple methods.
			book.NameChanged += new NameChangedDelegate(OnNameChanged);
			book.NameChanged += OnNameChanged2;

			book.Name = "Riddh's Grade Book";
			book.Name = null;

			book.Name = "Just Another Grade Book";

			Console.WriteLine(book.Name);
		}

		static void OnNameChanged(Object sender, NameChangedEventArgs args) {
			Console.WriteLine($"Name is changing from {args.ExistingName} to {args.NewName}.");
		}

		static void OnNameChanged2(Object sender, NameChangedEventArgs args) {
			Console.WriteLine("***");
		}

		static void WriteResult(string description, int result) {
			Console.WriteLine(description + ": " + result);
		}

		static void WriteResult(string description, float result) {
			//Console.WriteLine("{0}: {1:F2}", description, result);
			Console.WriteLine($"{description}: {result:F2}");
		}

		static void WriteResult(string description, String result) {
			Console.WriteLine($"{description}: {result}");
		}
	}
}
