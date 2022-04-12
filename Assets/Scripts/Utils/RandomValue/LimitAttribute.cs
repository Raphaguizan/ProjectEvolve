using UnityEngine;

namespace Game.Util.RandomValue
{
	public class LimitAttribute : PropertyAttribute
	{
		public float min;
		public float max;

		public LimitAttribute(float min, float max)
		{
			this.min = min;
			this.max = max;
		}
	}
}