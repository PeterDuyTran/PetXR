using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace PetVisionPro.Scripts
{
	public class PetSpawner : MonoBehaviour
	{
		[FormerlySerializedAs("_prefabModel")] [SerializeField]
		private List<GameObject> _prefabModels;
		private int _petIndex;
		private GameObject _currentModel;

		public int SelectedIndex = 0;
		public int PetIndex
		{
			get => _petIndex;
			set
			{
				if (value >= _prefabModels.Count - 1)
					_petIndex = 0;
				else if (value <= 0)
					_petIndex = _prefabModels.Count - 1;
				else
				{
					_petIndex = value;
				}
			}
		}

		private void Start()
		{
			ChangePet(SelectedIndex);
		}

		public void ChangePet(int Index = -1)
		{
			if (_currentModel)
				Destroy(_currentModel);
			int i = Index == -1 ? PetIndex++ : Index;
			_currentModel = Instantiate(_prefabModels[i]);
			_currentModel.transform.SetParent(transform);
			_currentModel.transform.SetLocalPositionAndRotation(Vector3.zero, quaternion.identity);
		}
		
		
		public void ChangeAnim()
		{
			
		}
	}
}