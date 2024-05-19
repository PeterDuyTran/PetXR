using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace PetVisionPro.Scripts
{
	public class PetBase : MonoBehaviour, ITouchObjectFunctions, IPetActions
	{
		public GameObject GetMainObject()
		{
			return gameObject;
		}

		public virtual void StartSelect()
		{
			Eating();
		}

		public virtual void Move()
		{
			// throw new System.NotImplementedException();
			Playing();
		}

		public virtual void EndSelect(bool WithCancel)
		{
			throw new System.NotImplementedException();
		}

		public virtual void Eating()
		{
			throw new System.NotImplementedException();
		}

		public virtual void Dancing()
		{
			throw new System.NotImplementedException();
		}

		public virtual void Playing()
		{
			throw new System.NotImplementedException();
		}
	}
}