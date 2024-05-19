using BLINK;
using UnityEngine;

namespace PetVisionPro.Scripts
{
	public class PetBear : PetBase
	{
		private Animator _animator;
		private AnimationDemo _animationDemo; //quick copy from demo

		void Start()
		{
			_animationDemo = GetComponent<AnimationDemo>();
		}

		public Animator Animator
		{
			get
			{
				if (!_animator)
					_animator = GetComponentInChildren<Animator>();
				return _animator;
			}
			private set => _animator = value;
		}
		
		public override void Eating()
		{
			AnimationDemo.AnimationEntry entry = new AnimationDemo.AnimationEntry();
			entry.animationName = "Eat";
			entry.type = AnimationDemo.AnimationType.Bool;
			
			// _animationDemo.PlayAnimation(entry);

			_animationDemo.NextAnimation();
		}

		public override void Dancing()
		{
			AnimationDemo.AnimationEntry entry = new AnimationDemo.AnimationEntry();
			entry.animationName = "Jump";
			entry.type = AnimationDemo.AnimationType.Trigger;
			
			_animationDemo.PlayAnimation(entry);
		}

		public override void Playing()
		{
			AnimationDemo.AnimationEntry entry = new AnimationDemo.AnimationEntry();
			entry.animationName = "Sit";
			entry.type = AnimationDemo.AnimationType.Bool;
			
			_animationDemo.PlayAnimation(entry);
		}
	}
}