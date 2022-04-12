using UnityEditor;
using UnityEngine;

namespace Game.Util.RandomValue.Editor
{
	[CustomPropertyDrawer(typeof(LimitAttribute))]
	public class LimitPropertyDrawer : PropertyDrawer
	{
		private const float LabelWidthRatio = .15f;
		private const string MaxPropertyPath = "_max";
		private const string MinPropertyPath = "_min";

		private readonly GUIContent[] subLabels = new GUIContent[]
		{
			new GUIContent("min", "Valor minimo."),
			new GUIContent("max", "Valor máximo.")
		};

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var valueProperties = new SerializedProperty[]
			{
				property.FindPropertyRelative(MinPropertyPath),
				property.FindPropertyRelative(MaxPropertyPath)
			};

			float[] values = new float[valueProperties.Length];

			bool isInt = valueProperties[0]?.propertyType == SerializedPropertyType.Integer;

			for (int i = 0; i < values.Length; i++)
			{
				values[i] = isInt ? valueProperties[i].intValue : valueProperties[i].floatValue;
			}

			LimitAttribute limit = attribute as LimitAttribute;
			var minLabel = new GUIContent(limit.min.ToString());
			var maxLabel = new GUIContent(limit.max.ToString());

			Rect line1 = EditorGUI.PrefixLabel(position, label);
			line1.height = EditorGUIUtility.singleLineHeight;
			Rect slider = new Rect(position)
			{
				height = line1.height,
				y = line1.yMax
			};
			Rect minLabelPosition = new Rect(slider)
			{
				width = slider.width * LabelWidthRatio
			};
			Rect maxLabelPosition = new Rect(minLabelPosition);
			slider.width -= minLabelPosition.width + maxLabelPosition.width;
			slider.x = minLabelPosition.xMax;
			maxLabelPosition.x = slider.xMax + 5;

			EditorGUI.BeginProperty(position, label, property);
			EditorGUI.BeginChangeCheck();
			EditorGUI.MultiFloatField(line1, subLabels, values);
			EditorGUI.LabelField(minLabelPosition, minLabel);
			EditorGUI.MinMaxSlider(slider, ref values[0], ref values[1], limit.min, limit.max);
			EditorGUI.LabelField(maxLabelPosition, maxLabel);

			if (EditorGUI.EndChangeCheck())
			{
				float last = limit.min;
				for (int i = 0; i < values.Length; i++)
				{
					var value = values[i];

					if (value < last)
						value = last;
					else if (value > limit.max)
						value = limit.max;

					if(isInt)
					{
						int converted;
						value = converted = Mathf.RoundToInt(value);
						valueProperties[i].intValue = converted;
					}
					else
						valueProperties[i].floatValue = value;

					last = value;
				}
			}
			EditorGUI.EndProperty();

		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return EditorGUIUtility.singleLineHeight * 2;
		}
	}
}