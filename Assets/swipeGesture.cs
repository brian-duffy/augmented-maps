using UnityEngine;
using System.Collections;

public class swipeGesture : MonoBehaviour {
	Vector3 startPosition;
	float startTime;
	public ChangeMap changemap;
	public LoadFlickrImages LatLong;

	private Touch initialTouch = new Touch();
	private float distance = 0;
	internal bool hasSwiped = false;
		
	void FixedUpdate()
	{
		foreach(Touch t in Input.touches)
		{
			if (t.phase == TouchPhase.Began)
			{
				initialTouch = t;
			}
			else if (t.phase == TouchPhase.Moved && !hasSwiped)
			{
				if (initialTouch.position.y > 400){
					//IF THE INITIAL TOUCH IS ABOVE 400 (FROM THE BOTTOM), DO THE FOLLOWING
					float deltaX = initialTouch.position.x - t.position.x;
					float deltaY = initialTouch.position.y - t.position.y;
					distance = Mathf.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
					bool swipedSideways = Mathf.Abs(deltaX) > Mathf.Abs(deltaY);

				if (distance > 600f)
				{
					if (swipedSideways && deltaX > 0) //swiped left
					{

							changemap.changeMapSequence(-1);


					}
					else if (swipedSideways && deltaX <= 0) //swiped right
					{
							changemap.changeMapSequence(+1);
					}
					else if (!swipedSideways && deltaY > 300) //swiped down
					{

					}
					else if (!swipedSideways && deltaY <= 0)  //swiped up
					{

					}

					hasSwiped = true;
				}
					
			}
			
				if (initialTouch.position.y < 400){
					//SWIPE WITHIN MENU BOX
					float deltaX = initialTouch.position.x - t.position.x;
					float deltaY = initialTouch.position.y - t.position.y;
					distance = Mathf.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
					bool swipedSideways = Mathf.Abs(deltaX) > Mathf.Abs(deltaY);
					if (swipedSideways && deltaX > 0) //swiped left
					{
						if (distance > 400f){
					LatLong.selected = LatLong.selected -1;
						}
					}
					else if (swipedSideways && deltaX <= 0) //swiped right
					{
						if (distance > 400f){

						LatLong.selected = LatLong.selected + 1;
					}
					}

					hasSwiped = true;

				}
			
			}
			else if (t.phase == TouchPhase.Ended)
			{
				initialTouch = new Touch();
				hasSwiped = false;
			}
	}
	}
}





















