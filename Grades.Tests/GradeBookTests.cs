using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grades;

namespace Grades.Tests {

	[TestClass]
	public class GradeBookTests {

		[TestMethod]
		public void ComputesHighestGrade() {
			GradeBook grade = new GradeBook();
			grade.AddGrade(90);
			grade.AddGrade(10);

			GradeStatistics stats = grade.ComputeStatistics();
			Assert.AreEqual(90, stats.HighestGrade);

		}

		[TestMethod]
		public void ComputesLowestGrade() {
			GradeBook grade = new GradeBook();
			grade.AddGrade(90);
			grade.AddGrade(10);

			GradeStatistics stats = grade.ComputeStatistics();
			Assert.AreEqual(10, stats.LowestGrade);

		}

		[TestMethod]
		public void ComputesAverageGrade() {
			GradeBook grade = new GradeBook();
			grade.AddGrade(90);
			grade.AddGrade(10);
			grade.AddGrade(80);
			grade.AddGrade(71.5f);

			GradeStatistics stats = grade.ComputeStatistics();
			Assert.AreEqual(((90+10+80+71.5)/4), stats.AverageGrade, 0.01);

		}

	}
}
