using UnityEngine;

namespace StridersVR.Domain.SpeedPack
{
	public class OrientationPoint
	{
		private int id;

		private Vector3 attachedPosition;
		private Vector3 attachedRotation;

		private bool isActive;
		private bool isAvailable;
		private bool isHorizontal;

		public OrientationPoint (int id, Vector3 position, Vector3 rotation)
		{
			this.id = id;
			this.attachedPosition = position;
			this.attachedRotation = rotation;

			this.isActive = false;
			this.isAvailable = true;

			if (position.x != 0)
				this.isHorizontal = true;
			else
				this.isHorizontal = false;
		}

		public int getAnimHash(ref int _hashAnimName)
		{
			int _hashParam = 0;

			if (this.attachedPosition.x < 0) {
				_hashParam = Animator.StringToHash ("RotateLeft");
				_hashAnimName = Animator.StringToHash("AnimLeftPart");
			} else if (this.attachedPosition.x > 0) {
				_hashParam = Animator.StringToHash ("RotateRight");
				_hashAnimName = Animator.StringToHash("AnimRightPart");
			} else if (this.attachedPosition.y > 0) {
				_hashParam = Animator.StringToHash ("RotateBottom");
				_hashAnimName = Animator.StringToHash("AnimBottomPart");
			} else if (this.attachedPosition.y < 0) {
				_hashParam = Animator.StringToHash ("RotateTop");
				_hashAnimName = Animator.StringToHash("AnimTopPart");
			}

//			if (this.attachedPosition == new Vector3 (-1, 0, 0)) {
//				_hashParam = Animator.StringToHash ("RotateLeft");
//				_hashAnimName = Animator.StringToHash("AnimLeftPart");
//			} else if (this.attachedPosition == new Vector3 (1, 0, 0)) {
//				_hashParam = Animator.StringToHash ("RotateRight");
//				_hashAnimName = Animator.StringToHash("AnimRightPart");
//			} else if (this.attachedPosition == new Vector3 (0, 0.5f, 0)) {
//				_hashParam = Animator.StringToHash ("RotateBottom");
//				_hashAnimName = Animator.StringToHash("AnimBottomPart");
//			} else if (this.attachedPosition == new Vector3 (0, -0.5f, 0)) {
//				_hashParam = Animator.StringToHash ("RotateTop");
//				_hashAnimName = Animator.StringToHash("AnimTopPart");
//			}

			return _hashParam;
		}

		public void activePoint()
		{
			this.isActive = true;
		}

		public void changeAvailability()
		{
			this.isAvailable = false;
		}

		#region Properties
		public int Id
		{
			get { return this.id; }
		}

		public Vector3 AttachedRotation 
		{
			get { return attachedRotation; }
			set { attachedRotation = value; }
		}
		
		public Vector3 AttachedPosition 
		{
			get { return attachedPosition; }
			set { attachedPosition = value; }
		}

		public bool IsActive
		{
			get { return this.isActive; }
		}

		public bool IsAvailable
		{
			get { return this.isAvailable; }
		}

		public bool IsHorizontal
		{
			get { return this.isHorizontal; }
		}
		#endregion
	}
}

