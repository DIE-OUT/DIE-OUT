using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// helper class for useful enum functions
/// </summary>
public static class EnumHelper {
    
    /// <summary>
    /// returns all values of an enum
    /// </summary>
    /// <typeparam name="T">the enum type from which the values will be returned</typeparam>
    /// <returns>returns all values of the specified enum type T</returns>
    public static IEnumerable<T> GetAllEnumValuesOfType<T>() where T : Enum {
        return Enum.GetValues(typeof(T)).Cast<T>();
    }
    
}
