using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades {
	public abstract class GradeTracker : IGradeTracker {

		public event NameChangedDelegate NameChanged;
		protected String _name;
		public String Name {
			get {
				return _name;
			}
			set {
				if (!String.IsNullOrEmpty(value)) {
					if (_name != value) {
						NameChangedEventArgs args = new NameChangedEventArgs();
						args.ExistingName = _name;
						args.NewName = value;

						NameChanged(this, args);
					}

					_name = value;
				}
			}
		}

		public abstract GradeStatistics ComputeStatistics();
		public abstract void WriteGrades(TextWriter destination);
		public abstract void AddGrade(float grade);
		public abstract IEnumerator GetEnumerator();
	}
}
