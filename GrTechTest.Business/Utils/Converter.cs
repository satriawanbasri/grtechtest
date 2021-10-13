using System.Collections.Generic;
using System.Reflection;

namespace GrTechTest.Business.Utils
{
    public static class Converter
    {
        public static TD ConvertObject<TD>(this object obj) where TD : class, new()
        {
            if (obj == null)
            {
                return null;
            }

            TD result = new TD();
            PropertyInfo[] sourceProperties = obj.GetType().GetProperties();
            foreach (PropertyInfo property in sourceProperties)
            {
                try
                {
                    object sourceVal = property.GetValue(obj, null);
                    if (sourceVal != null)
                    {
                        PropertyInfo destProp = result.GetType().GetProperty(property.Name);
                        if (destProp != null)
                        {
                            if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                            {
                                MethodInfo mi = typeof(Converter).GetMethod("ConvertObject");
                                MethodInfo miConstructed = mi.MakeGenericMethod(destProp.PropertyType);

                                if (property.PropertyType.IsArray || property.PropertyType.Name.ToUpper().Contains("LIST"))
                                {
                                    mi = typeof(Converter).GetMethod("ConvertList");
                                    miConstructed = mi.MakeGenericMethod(property.PropertyType.GenericTypeArguments[0], destProp.PropertyType.GenericTypeArguments[0]);
                                }

                                object[] args = { sourceVal };
                                object target = miConstructed.Invoke(null, args);
                                sourceVal = target;
                            }

                            destProp.SetValue(result, sourceVal);
                        }
                    }

                }
                catch { }
            }
            return result;

        }

        public static IList<TD> ConvertList<TS, TD>(this IList<TS> listObj)
            where TD : class, new()
            where TS : class, new()
        {
            IList<TD> result = new List<TD>();
            if (listObj != null)
            {
                if (listObj.Count > 0)
                {
                    try
                    {
                        bool isClass = listObj[0].GetType().IsClass;
                        foreach (var item in listObj)
                        {
                            if (isClass)
                            {
                                MethodInfo mi = typeof(Converter).GetMethod("ConvertObject");
                                MethodInfo miConstructed = mi.MakeGenericMethod(typeof(TD));

                                object[] args = { item };
                                TD target = (TD)miConstructed.Invoke(null, args);

                                result.Add(target);
                            }
                            else
                            {
                                result.Add((TD)(object)item);
                            }
                        }
                    }
                    catch { }
                }
            }
            return result;
        }
    }
}