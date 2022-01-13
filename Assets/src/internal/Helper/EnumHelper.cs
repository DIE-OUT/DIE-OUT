using System;
using System.Collections.Generic;
using System.Linq;

public static class EnumHelper {
    
    public static IEnumerable<T> GetAllEnumValuesOfType<T>() where T : Enum {
        return Enum.GetValues(typeof(T)).Cast<T>();
    }
    
}
