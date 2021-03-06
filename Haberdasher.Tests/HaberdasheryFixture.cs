﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Haberdasher.Tests.TestClasses;
using Xunit;

namespace Haberdasher.Tests
{
	public class HaberdasheryFixture
	{
		private readonly CachedType _simpleType;
		private readonly CachedType _aliasedType;

		private readonly SimpleClassHaberdashery _simpleHaberdashery;
		private readonly AliasedColumnsClassHaberdashery _aliasedHaberdashery;

		public HaberdasheryFixture() {
			_simpleType = new CachedType(typeof(SimpleClass));
			_aliasedType = new CachedType(typeof(AliasedColumnsClass));

			_simpleHaberdashery = new SimpleClassHaberdashery();
			_aliasedHaberdashery = new AliasedColumnsClassHaberdashery();
		}

		[Fact]
		public void BuildsSimpleParameterListCorrectly() {
			var simple = new SimpleClass {Id = 1, Name = "Simple Class"};

			var parameters = _simpleHaberdashery.BuildParameterList(_simpleType.SelectFields, simple);

			Assert.Equal(2, parameters.ParameterNames.Count());
			Assert.Equal(true, parameters.ParameterNames.Contains("Id"));
			Assert.Equal(true, parameters.ParameterNames.Contains("Name"));
		}

		[Fact]
		public void BuildsAliasedParameterListCorrectly() {
			var aliased = new AliasedColumnsClass() {Id = 1, Name = "Aliased Class", Description = "Aliased Description"};

			var parameters = _aliasedHaberdashery.BuildParameterList(_aliasedType.SelectFields, aliased);

			Assert.Equal(3, parameters.ParameterNames.Count());
			Assert.True(parameters.ParameterNames.Contains("Id"));
			Assert.True(parameters.ParameterNames.Contains("ADifferentName"));
			Assert.True(parameters.ParameterNames.Contains("Description"));
		}

		[Fact]
		public void BuildsSimplePropertyListCorrectly() {
			var properties = _simpleHaberdashery.BuildPropertyList(_simpleType.SelectFields);

			Assert.Equal(2, properties.Count());
			Assert.True(properties.ContainsKey("@Id"));
			Assert.True(properties.ContainsKey("@Name"));
		}

		[Fact]
		public void BuildsAliasedPropertyListCorrectly() {
			var properties = _aliasedHaberdashery.BuildPropertyList(_aliasedType.SelectFields);

			Assert.Equal(3, properties.Count());
			Assert.True(properties.ContainsKey("@Id"));
			Assert.True(properties.ContainsKey("@ADifferentName"));
			Assert.True(properties.ContainsKey("@Description"));
		}
	}
}
