using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Photocom.Models.Entities.Database;

namespace Photocom.BusinessLogic.Utils
{
    public static class ReflectionHelper
    {
        public static TDest ConvertClassInstances<TDest>(string sourceTypeName, object sourceObject) where TDest : new()
        {
            Type sourceType = Type.GetType(sourceTypeName, true, true);
            TDest result = new TDest();

            var destTypeMembers = result.GetType().GetMembers().ToList();

            foreach (MemberInfo memberInfo in destTypeMembers)
            {
                string memberFullName = memberInfo.Name;
                if (memberFullName.Contains("get"))
                {
                    string propName = memberFullName.Replace("get_", "");
                    try
                    {
                        result.GetType().GetProperty(propName).SetValue(result, sourceType.GetProperty(propName).GetValue(sourceObject));
                    }
                    catch (NullReferenceException e)
                    {
                        throw;
                    }
                }
            }

            return result;
        }

        public static string GetFullTypeName(Type target)
        {
            return target.AssemblyQualifiedName;
        }
    }
}
