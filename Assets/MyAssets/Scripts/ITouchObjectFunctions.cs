using UnityEngine;

namespace PetVisionPro.Scripts
{
	public interface ITouchObjectFunctions
	{
		GameObject GetMainObject();
		void StartSelect();
		void Move();
		void EndSelect(bool WithCancel);
	}
}