﻿using System;

namespace Haberdasher.Support
{
	public static class Extensions
	{
		public static bool IsNumber(this Type type) {
			if (type.IsPrimitive) {
				return type != typeof(bool) &&
					type != typeof(char) &&
					type != typeof(IntPtr) &&
					type != typeof(UIntPtr);
			}

			if (type == typeof (decimal))
				return true;

			return false;
		}

		public static bool IsNumber(this object obj) {
			if (Equals(obj, null)) {
				return false;
			}

			var objType = obj.GetType();

			if (objType.IsPrimitive) {
				return objType != typeof(bool) &&
					objType != typeof(char) &&
					objType != typeof(IntPtr) &&
					objType != typeof(UIntPtr);
			}

			if (objType == typeof(decimal))
				return true;

			return false;
		}

		public static object GetDefaultValue(this Type t) {
			if (t.IsValueType && Nullable.GetUnderlyingType(t) == null)
				return Activator.CreateInstance(t);

			if (t == typeof (string))
				return String.Empty;

			return null;
		}

		public static bool IsNullable(this Type type) {
			if (type == null) return false;
			if (!type.IsValueType) return true; // ref-type
			if (Nullable.GetUnderlyingType(type) != null) return true; // Nullable<T>
			return false; // value-type
		}

        /// <summary>
        /// Removes the parameter identifier from the given param name. 
        /// In other words, given "@id", it returns "id"
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <returns>System.String.</returns>
        public static string RemoveParamIdentifier(this string paramName)
        {
            // the common identifiers used for to indicate a sql parameter name
            if (!string.IsNullOrEmpty(paramName))
            {
                switch (paramName[0])
                {
                    case '@':
                    case ':':
                    case '?':
                        return paramName.Substring(1);
                }
            }
            return paramName;
        }

	}
}
