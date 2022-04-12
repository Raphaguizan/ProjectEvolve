using System;
using UnityEngine;

namespace Game.Util.RandomValue
{
	[Serializable]
	public struct RandomInt
	{
		[SerializeField]
		private int _min;
		[SerializeField]
		private int _max;

		public RandomInt(int min = 0, int max = 0)
		{
			_min = min;
			_max = max;
		}

		public int Get()
		{
			if (!IsRandom())
				return _min;

			return UnityEngine.Random.Range(_min, _max);
		}

		public readonly bool IsRandom() => _min != _max;

		public static implicit operator int(RandomInt obj)
		{
			return obj.Get();
		}
	}
}