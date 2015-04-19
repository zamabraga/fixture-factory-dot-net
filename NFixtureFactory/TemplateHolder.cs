﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace NFixtureFactory
{
	public class TemplateHolder
	{

		private readonly IDictionary<String,Rule> _rules = new Dictionary<String, Rule>();

		public Type Clazz{ get; private set;}

		public IDictionary<String,Rule> Rules
		{
			get{ return new Dictionary<String, Rule>(_rules); }
		}


		public TemplateHolder (Type clazz)
		{
			Clazz = clazz;
		}

		public TemplateHolder AddTemplate(String label, Rule rule) {
			_rules.Add(label, rule);
			return this;
		}

		public Rule GetRule(String label)
		{
			return _rules.ContainsKey(label) ? _rules [label] : null;
		}
	}
}
