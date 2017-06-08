/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;

namespace Vuforia
{
	/// <summary>
	/// A custom handler that implements the ITrackableEventHandler interface.
	/// </summary>
	public class ARCashonDesk : MonoBehaviour,
	ITrackableEventHandler
	{

		public GameObject Player;
		//public GameObject CashonTable;
		private Vector3 playerTarget;
		private Vector3 playerPos;
		//public float mySpeed;
		//public Transform targetPos;
		public float speed;
		public int CashOnTable;
		public GameObject CashonDeskObject;
		//private Vector3 playerCashDeskTarget;
		public GameObject CashDeskTarget;
		private Vector3 CashDeskTargetPostion;

		#region PRIVATE_MEMBER_VARIABLES

		private TrackableBehaviour mTrackableBehaviour;

		#endregion // PRIVATE_MEMBER_VARIABLES



		#region UNTIY_MONOBEHAVIOUR_METHODS

		void Start()
		{
			mTrackableBehaviour = GetComponent<TrackableBehaviour>();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
			}
			//Player.SetActive (false);
//			playerTarget = CashonTable.transform.position;
			playerPos = Player.transform.position;
			CashDeskTargetPostion = CashDeskTarget.transform.position;

			//mySpeed = 20;
		}

		#endregion // UNTIY_MONOBEHAVIOUR_METHODS



		#region PUBLIC_METHODS

		/// <summary>
		/// Implementation of the ITrackableEventHandler function called when the
		/// tracking state changes.
		/// </summary>
		public void OnTrackableStateChanged(
			TrackableBehaviour.Status previousStatus,
			TrackableBehaviour.Status newStatus)
		{
			if (newStatus == TrackableBehaviour.Status.DETECTED ||
				newStatus == TrackableBehaviour.Status.TRACKED ||
				newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
			{
				OnTrackingFound();
			}
			else
			{
				OnTrackingLost();
			}
		}

		#endregion // PUBLIC_METHODS



		#region PRIVATE_METHODS


		private void OnTrackingFound()
		{
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

			// Enable rendering:
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = true;
			}

			// Enable colliders:
			foreach (Collider component in colliderComponents)
			{
				component.enabled = true;
			}
			CashonDesk ();
			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");

		}


		private void OnTrackingLost()
		{
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

			// Disable rendering:
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = false;
			}

			// Disable colliders:
			foreach (Collider component in colliderComponents)
			{
				component.enabled = false;
			}

			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
		}

		#endregion // PRIVATE_METHODS


		void CashonDesk()
		{
			//Player.SetActive (true);
			Player.transform.position = Vector3.MoveTowards (playerPos, CashDeskTargetPostion, speed * Time.deltaTime);
			if (CashonDeskObject == null)
				return;
			Destroy (CashonDeskObject);
			ScoreManager.AddCashtoTotal(CashOnTable);

		}


	}
}
