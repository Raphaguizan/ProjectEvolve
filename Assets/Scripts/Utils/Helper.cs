using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Util
{
    public static class Helper
    {
        public static object Find(this object[] list, Type t)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Type type = list[i].GetType();
                if (type.Equals(t))
                    return list[i];
            }
            return default;
        }

        /// <summary>
        /// remapea um valor de uma escala para outra exemplo:
        /// 5 entre 0 à 10 numa escala 0 à 1 é igual a 0.5
        /// </summary>
        /// <param name="s">valor a ser remapeado</param>
        /// <param name="a1">valor1 min</param>
        /// <param name="a2">valor1 max</param>
        /// <param name="b1">valor2 min</param>
        /// <param name="b2">valor2 max</param>
        /// <returns>float ajustado para a nova escala</returns>
        public static float Remap(this float s, float a1, float a2, float b1, float b2)
        {
            return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
        }
        public static Vector3 Randomize(this Vector3 v)
        {
            return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }
        public static Vector2 Randomize(this Vector2 v)
        {
            return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }
        public static Vector2 Rotate(this Vector2 v, float degrees)
        {
            float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
            float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

            float tx = v.x;
            float ty = v.y;
            v.x = (cos * tx) - (sin * ty);
            v.y = (sin * tx) + (cos * ty);
            return v;
        }
    }
}

