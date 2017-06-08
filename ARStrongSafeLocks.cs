/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Vuforia
{
	/// <summary>
	/// A custom handler that implements the ITrackableEventHandler interface.
	/// </summary>
	public class ARStrongSafeLocks : MonoBehaviour,
	ITrackableEventHandler
	{

		public GameObject StrongSafeLock;
		public bool StrongSafeLockOn;
		public int isStrongSafeLockOn;
		int APDamageCamera = 3;
		public string RobberStart;
		//	public string Upstairs;
		float DestroyTextOverTime = 5;
		public GameObject TextComponent;

		#region PRIVATE_MEMBER_VARIABLES

		private TrackableBehaviour mTrackableBehaviour;

		#endregion // PRIVATE_MEMBER_VARIABLES



		#region UNTIY_MONOBEHAVIOUR_METHODS

		void Start()
		{
			StrongSafeLock.SetActive (false);
			mTrackableBehaviour = GetComponent<TrackableBehaviour>();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
			}
			TextComponent.SetActive (false);
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

			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
			StrongSafeLockOn = true;
			DefenderAPpoints.DecreaseAPpoints (APDamageCamera);
			print ("Strong Locks Active");
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

		void Update () {


			if (StrongSafeLockOn == true) {
				isStrongSafeLockOn = 1;
				StrongSafeLock.SetActive (true);
				TextComponent.SetActive (true);
				Destroy (TextComponent, DestroyTextOverTime);
			}

			else {

				isStrongSafeLockOn = 0;
			}

			PlayerPrefs.GetInt ("pStrongSafeLock", isStrongSafeLockOn);
		}

		public void DefenderReadyButton() 
		{
			PlayerPrefs.SetInt("pStrongSafeLock", isStrongSafeLockOn);	
			SceneManager.LoadScene(RobberStart);
		}

	}

}
