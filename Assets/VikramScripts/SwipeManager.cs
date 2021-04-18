using System;
using UnityEngine;
using UnityEngine.UI;

namespace Tangiappps
{
	public class SwipeManager : MonoBehaviour
	{
		public static event Action<SwipeDirection> OnSwipe;
		
		private const float MAX_SWIPE_TIME = 0.5f;
		private const float MIN_SWIPE_DISTANCE = 0.17f;
		private Vector2 startPos;
		private float startTime;

		public void f_SwipeButtonClickDown()
        {
#if UNITY_EDITOR
			Vector3 touchPosition = Input.mousePosition;
#else
            Vector3 touchPosition = Input.GetTouch(0).position;
#endif

			startPos = new Vector2(touchPosition.x / (float)Screen.width, touchPosition.y / (float)Screen.width);
			startTime = Time.time;
		}

		public void f_SwipeButtonClickUp()
        {
#if UNITY_EDITOR
			Vector3 touchPosition = Input.mousePosition;
#else
            Vector3 touchPosition = Input.GetTouch(0).position;
#endif

			if (Time.time - startTime > MAX_SWIPE_TIME)
				return;

			Vector2 endPos = new Vector2(touchPosition.x / (float)Screen.width, touchPosition.y / (float)Screen.width);
			Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);

			if (swipe.magnitude < MIN_SWIPE_DISTANCE)
				return;

			if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
			{
				if (swipe.x > 0)
					TouchDetected(SwipeDirection.Right);
				else
					TouchDetected(SwipeDirection.Left);
			}
			else
			{
				if (swipe.y > 0)
					TouchDetected(SwipeDirection.Up);
				else
					TouchDetected(SwipeDirection.Down);
			}
		}

		private void TouchDetected(SwipeDirection direction)
        {
			OnSwipe?.Invoke(direction);
			Debug.Log("Direction: " + direction);
        }
	}
}