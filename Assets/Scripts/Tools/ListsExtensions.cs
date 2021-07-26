using System;
using System.Collections.Generic;

namespace RGLX_Extensions
{
    public static class ListsExtensions
    {
        public static bool ContainsIndex<T>(this List<T> list, int index)
        {
            return list != null && index >= 0 && index < list.Count;
        }

        public static T TryGet<T>(this List<T> list, int index)
        {
            if (list.ContainsIndex(index))
            {
                return list[index];
            }

            return default;
        }

        public static T Get<T>(this List<T> list, int index)
        {
            if (list.ContainsIndex(index))
            {
                return list[index];
            }

            throw new Exception("List has no such index");
        }

        public static T TryGetRandomElement<T>(this List<T> list)
        {
            if (list != null && list.Count > 0)
            {
                return list[MethodsExtensions.GetRandomValueBetween(0, list.Count - 1)];
            }

            return default;
        }

        public static T GetRandomElement<T>(this List<T> list)
        {
            if (list != null && list.Count > 0)
            {
                return list[MethodsExtensions.GetRandomValueBetween(0, list.Count - 1)];
            }

            throw new Exception("List is empty");
        }
    }
}
