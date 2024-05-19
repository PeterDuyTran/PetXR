using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace PetVisionPro.Scripts
{
	[CustomEditor(typeof(PetSpawner))]
	public class PetBaseCustomInspector : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			PetSpawner pet = (PetSpawner) target;
			if (GUILayout.Button("Change pet"))
			{
				pet.ChangePet();
			}

			if (GUILayout.Button("Change Anim"))
			{
				pet.ChangeAnim();
			}
		}
	}
}