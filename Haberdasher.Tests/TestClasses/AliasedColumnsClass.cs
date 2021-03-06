﻿using Haberdasher.Attributes;

namespace Haberdasher.Tests.TestClasses
{
	public class AliasedColumnsClass
	{
		[Key]
		public int Id { get; set; }

		[Alias("ADifferentName")]
		public string Name { get; set; }

		[Alias(null)]
		public string Description { get; set; }
	}
}
