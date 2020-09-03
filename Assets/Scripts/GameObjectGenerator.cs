using UnityEngine;

public class GameObjectGenerator : MonoBehaviour
{
	[SerializeField] private GameObject putObject = null;
	[SerializeField] private bool isPutInThisObject = true;

	[SerializeField] private bool isPlacement2D = false;

	[Header("Is not placement 2D")]
	[SerializeField, Min(1)] private int putAmount = 1;

	[Header("Is placement 2D")]
	[SerializeField] private float placementInterval = 1f;

	[SerializeField, Min(1)] private int putAmountX = 1;
	[SerializeField, Min(1)] private int putAmountZ = 1;

	private void PutGameObject(GameObject putObject, Vector3 position)
	{
		var gameObject = Instantiate(putObject);
		gameObject.transform.position = position;

		if (isPutInThisObject)
			gameObject.transform.parent = this.gameObject.transform;
	}

	private void Start()
	{
		if (isPlacement2D)
		{
			for (var x = 0; x < putAmountX; x++)
			{
				for (var z = 0; z < putAmountZ; z++)
				{
					var placePostion = transform.position + (new Vector3(x, 0, z) * placementInterval);
					PutGameObject(putObject, placePostion);
				}
			}
			return;
		}

		for (var i = 0; i < putAmount; i++)
		{
			PutGameObject(putObject, transform.position);
		}
	}
}