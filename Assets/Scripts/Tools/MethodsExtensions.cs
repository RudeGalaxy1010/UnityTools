using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RGLX_Extensions
{
    public static class MethodsExtensions
    {
        public static T ConvertToStruct<T>(object data)
            where T : struct
        {
            if (!(data is T))
            {
                throw new Exception("Wrong type of data");
            }

            return (T)Convert.ChangeType(data, typeof(T));
        }

        public static int GetRandomValueBetween(int min, int max)
        {
            return UnityEngine.Random.Range(min, max + 1);
        }

        public static float GetRandomValueBetween(float min, float max)
        {
            return UnityEngine.Random.Range(min, max);
        }
    }
}
