using System.Collections;
using System.IO;

namespace Grades {
	internal interface IGradeTracker : IEnumerable {

		GradeStatistics ComputeStatistics();
		void WriteGrades(TextWriter destination);
		void AddGrade(float grade);

		string Name { get; set; }
		event NameChangedDelegate NameChanged;
	}
}