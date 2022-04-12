using System;
using UnityEngine;

namespace Game.Util.RandomValue
{
	[Serializable]
	public class RandomFloat
	{
		[SerializeField]
		private float _min = 0;
		[SerializeField]
		private float _max = 0;

		public RandomFloat(float min = 0, float max = 0)
		{
			_min = min;
			_max = max;
		}

		public float Get()
		{
			if (!IsRandom())
				return _min;

			return UnityEngine.Random.Range(_min, _max);
		}

		public bool IsRandom() => _min != _max;

		public static implicit operator float(RandomFloat obj)
		{
			if (obj == null)
				return 0;

			return obj.Get();
		}
	}
}