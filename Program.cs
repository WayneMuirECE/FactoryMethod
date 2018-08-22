using System;
using System.Collections.Generic;
using System.Linq;

namespace WayneMuirECE.FactoryMethod {
	/// <summary>
	/// Program startup class for Structural 
	/// Factory Method Design Pattern.
	/// </summary>
	class Program {
		/// <summary>
		/// Entry point into console application.
		/// </summary>
		static void Main(string[] args) {
			// An array of creators
			List<Creator> creators = new List<Creator>();
			creators.Add(new ConcreteCreatorA());
			creators.Add(new ConcreteCreatorB());

			// Iterate over creators and create products
			foreach (Creator creator in creators) {
				Product product = creator.FactoryMethodFunction();
				Console.WriteLine("Created product {0}", product.GetType().Name);
			}

			// Wait for user input
			Console.ReadKey();
		}

	}

	#region Product
	/// <summary>
	/// The 'Product' abstract class
	/// </summary>
	abstract class Product {
	}

	/// <summary>
	/// A 'ConcreteProduct' class
	/// </summary>
	class ConcreteProductA : Product {
	}

	/// <summary>
	/// A 'ConcreteProduct' class
	/// </summary>
	class ConcreteProductB : Product {
	}
	#endregion Product

	#region Creator
	/// <summary>
	/// The 'Creator' abstract class
	/// </summary>
	abstract class Creator {
		public abstract Product FactoryMethodFunction();
	}

	/// <summary>
	/// A 'ConcreteCreator' class
	/// </summary>
	class ConcreteCreatorA : Creator {
		public override Product FactoryMethodFunction() {
			return new ConcreteProductA();
		}
	}

	/// <summary>
	/// A 'ConcreteCreator' class
	/// </summary>
	class ConcreteCreatorB : Creator {
		public override Product FactoryMethodFunction() {
			return new ConcreteProductB();
		}
	}
	#endregion Creator
}

