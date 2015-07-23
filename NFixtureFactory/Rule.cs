﻿using System;
using System.Collections;
using System.Collections.Generic;
using NFixtureFactory.Functions;

namespace NFixtureFactory
{
	public class Rule
	{
		private readonly ICollection<Property> _properties = new List<Property>();

		public ICollection<Property> Properties 
		{
			get
			{
				return new List<Property>(_properties);
			}

		}

		public Rule (){}

		public Rule Add(String property, Object value)
		{
			_properties.Add(new Property(property, value));
			return this;
		}

		public Rule Add(String property, IFunction function){
		
			_properties.Add(new Property(property, function ?? new IdentityFunction(null)));
			return this;
		}

		public static Object Cpf()
		{
			return new Cpf().GenerateValue<Double>();	
		}

		public static Object Cnpj()
		{
			return new Cnpj().GenerateValue<Double>();	
		}


		public static IAssociationFunction<T> One<T>(String label)
		{
			return new AssociationFunction<T>(label);
		}

		public static IAssociationFunction<IEnumerable<T>> Has<T>(Int32 quantity)
		{
			return new AssociationFunction<IEnumerable<T>>(quantity);
		}



	}
}

