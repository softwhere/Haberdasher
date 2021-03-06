﻿using System.Collections.Generic;

namespace Haberdasher.Tailors
{
	public interface ITailor
	{
		string SelectAll(IEnumerable<CachedProperty> properties);
		string Select(IEnumerable<CachedProperty> properties, CachedProperty key, string keyParam);
		string SelectMany(IEnumerable<CachedProperty> properties, CachedProperty key, string keysParam);

		string All(IEnumerable<CachedProperty> properties, CachedProperty key);

		string Find(IEnumerable<CachedProperty> properties, string whereClause);

		string Insert(IDictionary<string, CachedProperty> properties, CachedProperty key);

		string Update(IDictionary<string, CachedProperty> properties, CachedProperty key, string keyParam);
		string UpdateMany(IDictionary<string, CachedProperty> properties, CachedProperty key, string keysParam);

		string DeleteAll();
		string Delete(CachedProperty key, string keyParam);
		string DeleteMany(CachedProperty key, string keysParam);

        /// <summary>
        /// Formats the name of the SQL parameter such as including the @ before the param name.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <returns>System.String.</returns>
        string FormatSqlParamName(string paramName);
	}
}
