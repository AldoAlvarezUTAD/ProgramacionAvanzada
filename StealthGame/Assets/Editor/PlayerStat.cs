using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UTAD.PlayerData;
using UTAD.Enums;

namespace UTAD.CustomEditor
{
	[CustomPropertyDrawer(typeof(PlayerStats))]
	public class PlayerStat : PropertyDrawer
	{
		#region UNITY METHODS
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUIUtility.labelWidth = 80;
			EditorGUI.BeginProperty(position, label, property);

			InitializeVariables(property);

			position.height = baseHeaderSeparation;
			foldout.boolValue = EditorGUI.Foldout(position, foldout.boolValue, label, true, boldFoldout);

			if (foldout.boolValue)
			{
				DrawStats(position);
			}

			EditorGUI.EndProperty();
		}
		
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			if (!property.FindPropertyRelative("foldout").boolValue)
				return 22;
			return baseHeaderSeparation + ((elementsHeight + elementsSeparation) * ((int)PlayerStatsIDs.counter));
		}
		#endregion

		#region VARIABLES
		private SerializedProperty stats;
		private SerializedProperty upgradableStat;
		private SerializedProperty foldout;

		private GUIContent statLabel;
		private GUIStyle boldFoldout;

		private int baseHeaderSeparation = 26;
		private int elementsHeight = 20;
		private int elementsSeparation = 4;
		#endregion

		#region PRIVATE METHODS
		private void DrawStats(Rect position) 
		{
			position.y += baseHeaderSeparation;// + (stat * elementsSeparation);
			position.x += 20;
			position.width -= 20;
			position.height = elementsHeight;
			for (int stat = 0; stat < stats.arraySize; ++stat) 
			{
				DrawStat(stat, position);
				position.y += elementsHeight + elementsSeparation;
			}
		}

		private void DrawStat(int index, Rect position) 
		{
			upgradableStat = stats.GetArrayElementAtIndex(index).FindPropertyRelative("upgradableStat");
			statLabel.text = ((PlayerStatsIDs)index).ToString();
			EditorGUI.PropertyField(position, upgradableStat, statLabel);
		}

		private void InitializeVariables(SerializedProperty playerStats)
		{
			stats = playerStats.FindPropertyRelative("stats");
			foldout = playerStats.FindPropertyRelative("foldout");
			InitializeGUIStyles();
		}

		private void InitializeGUIStyles() 
		{
			boldFoldout = new GUIStyle(EditorStyles.foldout);
			boldFoldout.fontSize = 12;
			boldFoldout.fontStyle = FontStyle.Bold;

			statLabel = new GUIContent();
		}
		#endregion
	}
}