using System;
using System.Collections.Generic;
using System.Linq;

namespace WayneMuirECE.FactoryMethod {
	/// <summary>
	/// Program startup class for Factory Method Design Pattern.
	/// </summary>
	class Program {												
		/// <summary>
		/// Entry point for the console application.
		/// </summary>
		static void Main(string[] args) {
			// A list of creators
			List<Company> creators = new List<Company>();
			creators.Add(new CompanyA());
			creators.Add(new CompanyB());

			// Iterate over creators and create products
			foreach (Company company in creators) {
				foreach (Employee employee in company.Employees) {
					// Data here can be pulled and placed into a
					//  new data stucture that matches new system requirements
					Console.WriteLine("Employee Name: {0}", employee.Name);
					Console.WriteLine("Employee ID: {0}", employee.EmployeeID);
					Console.WriteLine("Employee Note: {0}", employee.Note);
					Console.WriteLine("Employee Type: {0}", employee.GetType().Name);
					Console.WriteLine(" * * *");
				}
			}

			// Wait for user input
			Console.ReadKey();
		}

	}

	#region Product
	/// <summary>
	/// The 'Product' abstract class
	/// </summary>
	abstract class Employee {
		// Employee Name
		public string Name { get; set; }
		// Identification number for an employee
		public string EmployeeID { get; set; }
		// A note on the employee file
		public string Note { get; set; }
	}

	/// <summary>
	/// A 'ConcreteProduct' class
	/// </summary>
	class FullTimeEmployee : Employee {
		// A class specific variable for number of hours worked
		public readonly int Hours = 40;
	}
	#endregion Product

	#region Creator
	/// <summary>
	/// The 'Creator' abstract class
	/// </summary>
	abstract class Company {
		// A list of employees
		private List<Employee> _employees = new List<Employee>();
		/// <summary>
		/// Creator's constructor
		/// </summary>
		public Company() {
			this.ExtractEmployees();
		}
		// Property accessor for the list of employees
		public List<Employee> Employees {
			get {
				return _employees;
			}
		}
		// An abstract function made to be overwritten in a 'ConcreteCreator' class
		public abstract void ExtractEmployees();
	}

	/// <summary>
	/// A 'ConcreteCreator' class
	/// </summary>
	class CompanyA : Company {
		// An imported data structure for old data. To be used in the conversion of old data to new data.
		private DataSourceCompanyA CompanyAEmployees = new DataSourceCompanyA();
		/// <summary>
		/// The implementation of the abstract function for this class. Used to convert old data to new data.
		/// </summary>
		public override void ExtractEmployees() {
			FullTimeEmployee employeeNew;
			foreach (CompanyAEmployee employee in CompanyAEmployees.Employees) {
				employeeNew = new FullTimeEmployee();
				employeeNew.Name = employee.Name;
				employeeNew.EmployeeID = "a" + employee.ID;
				employeeNew.Note = employee.Notes;
				this.Employees.Add(employeeNew);
			}
		}
	}

	/// <summary>
	/// A 'ConcreteCreator' class
	/// </summary>
	class CompanyB : Company {
		// An imported data structure for old data. To be used in the convertion of old data to new data.
		private CompanyBEmployees CompanyBEmployees = new CompanyBEmployees();
		/// <summary>
		/// The implementation of the abstract function for this class. Used to convert old data to new data.
		/// </summary>
		public override void ExtractEmployees() {
			FullTimeEmployee employeeNew;
			foreach (CompEmployee employee in CompanyBEmployees.emp) {
				if (employee == null) {
					continue;
				}
				employeeNew = new FullTimeEmployee();
				// Convert data for new system requirements
				employeeNew.Name = employee.FirstName + " " + employee.LastName;
				employeeNew.EmployeeID = "b000" + employee.BadgeID;
				employeeNew.Note = "New employee";
				this.Employees.Add(employeeNew);
			}
		}
	}
	#endregion Creator

	/// <summary>
	/// Data source classes that could exist in any company.
	/// Data structures are different because every company will have
	///	 different set requirements on needed data.
	/// </summary>
	#region Data Sources
	/// <summary>
	/// Data source class for Company A
	/// </summary>
	public class DataSourceCompanyA {
		// A list for old data objects
		public List<CompanyAEmployee> Employees = new List<CompanyAEmployee>();
		// Old data objects
		CompanyAEmployee e18 = new CompanyAEmployee();
		CompanyAEmployee e543 = new CompanyAEmployee();
		CompanyAEmployee e1701 = new CompanyAEmployee();
		CompanyAEmployee e4242 = new CompanyAEmployee();
		CompanyAEmployee e12586 = new CompanyAEmployee();
		/// <summary>
		/// Constructor for old data source.
		/// </summary>
		public DataSourceCompanyA() {
			e18.Name = "Henry Lincoln";
			e18.ID = "000018";
			e18.Notes = "One of the founders";

			e543.Name = "Thomas Hero";
			e543.ID = "000543";
			e543.Notes = "CEO";

			e1701.Name = "Linus Torque";
			e1701.ID = "001701";
			e1701.Notes = "Head Engineer";

			e4242.Name = "John Smith";
			e4242.ID = "004242";
			e4242.Notes = "Dep. Head";

			e12586.Name = "Eric Tempson";
			e12586.ID = "012586";
			e12586.Notes = "Bottle washer";

			Employees.Add(e18);
			Employees.Add(e543);
			Employees.Add(e1701);
			Employees.Add(e4242);
			Employees.Add(e12586);
		}
	}
	/// <summary>
	/// Data source class for Company A Employee
	/// </summary>
	public class CompanyAEmployee {
		// Employee Name
		public string Name { get; set; }
		// Identification number for an employee
		public string ID { get; set; }
		// A note on the employee file
		public string Notes { get; set; }
	}

	/// <summary>
	/// Data source class for Company B
	/// </summary>
	public class CompanyBEmployees {
		// An array for old data objects
		public CompEmployee[] emp = new CompEmployee[5];
		/// <summary>
		/// Constructor for old data source.
		/// </summary>
		public CompanyBEmployees() {
			CompEmployee owner = new CompEmployee();
			owner.FirstName = "Tod";
			owner.LastName = "Mattson";
			owner.BadgeID = "001";

			CompEmployee emp1 = new CompEmployee();
			emp1.FirstName = "Mark";
			emp1.LastName = "Hatness";
			emp1.BadgeID = "003";

			CompEmployee emp2 = new CompEmployee();
			emp2.FirstName = "Brad";
			emp2.LastName = "Fittman";
			emp2.BadgeID = "018";

			emp[0] = owner;
			emp[1] = emp1;
			emp[2] = emp2;
		}
	}
	/// <summary>
	/// Data source class for Company B Employee
	/// </summary>
	public class CompEmployee {
		// Employee First Name
		public string FirstName;
		// Employee Last Name
		public string LastName;
		// Idenfification number for an employee
		public string BadgeID;
	}

	#endregion Data Sources

}

