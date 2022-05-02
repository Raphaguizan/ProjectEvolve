using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.DNAs.Genes
{
    [Serializable]
    public class GeneValue
    {
        private object value;
        private Type type;

        public GeneValue(object value, Type type)
        {
            this.value = value;
            this.type = type;
        }
        public Type GetValueType()
        {
            return type;
        }

        #region Set
        public void SetValue<T>(T t)
        {
            value = t;
            type = typeof(T);
        }
        #endregion

        #region Get
        public T GetValue<T>()
        {
            if(type.Equals(typeof(T)))
                return (T)value;
            return default;
        }
        #endregion
    }
}