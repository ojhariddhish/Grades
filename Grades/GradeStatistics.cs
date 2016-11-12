using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades {
	public class GradeStatistics {

		public GradeStatistics() {
			HighestGrade = 0;
			LowestGrade = float.MaxValue;
		}

		public String LetterGrade {
			get {
				String result;
				if (Math.Round(AverageGrade) >= 90) {
					result = "A";
				}
				else if (Math.Round(AverageGrade) >= 80) {
					result = "B";
				}
				else if (Math.Round(AverageGrade) >= 70) {
					result = "C";
				}
				else if (Math.Round(AverageGrade) >= 60) {
					result = "D";
				}
				else {
					result = "F";
				}

				return result;
			}
		}

		public String Description {
			get {
				String result;
				switch (LetterGrade) {
					case "A":
						result = "Excellent";
						break;
					case "B":
						result = "Good";
						break;
					case "C":
						result = "Average";
						break;
					case "D":
						result = "Poor";
						break;
					default:
						result = "Failing";
						break;
				}
				return result;
			}
		}

		public float AverageGrade;
		public float LowestGrade;
		public float HighestGrade;
	}
}
