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
	public class ActivateOfficeCamera : MonoBehaviour,
	ITrackableEventHandler
	{

		public GameObject Camera1;
		public GameObject Camera2;
		public GameObject Camera3;
		public bool CameraOn;
		public int isCameraOn;
		int APDamageCamera = 3;
		public string RobberStart;
		public string Upstairs;
		float DestroyTextOverTime = 5;
		public GameObject TextComponent;

		#region PRIVATE_MEMBER_VARIABLES

		private TrackableBehaviour mTrackableBehaviour;

		#endregion // PRIVATE_MEMBER_VARIABLES



		#region UNTIY_MONOBEHAVIOUR_METHODS

		void Start()
		{
			Camera1.SetActive (false);
			Camera2.SetActive (false);
			Camera3.SetActive (false);
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

			Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found"); // decreses ap points from total 
			CameraOn = true;
			DefenderAPpoints.DecreaseAPpoints (APDamageCamera);
			print ("Camera Active");
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


			if (CameraOn == true) { // sets isCameraOn to 1 so that is reconigse in robberstart scene
				isCameraOn = 1;
				Camera1.SetActive (true);
				Camera2.SetActive (true);
				Camera3.SetActive (true);
				TextComponent.SetActive (true);
				Destroy (TextComponent, DestroyTextOverTime);
			}

			else {

				isCameraOn = 0;
			}

			PlayerPrefs.GetInt ("pCamera", isCameraOn);
		}

		public void DefenderReadyButton() 
		{
			PlayerPrefs.SetInt("pCamera", isCameraOn);	
			SceneManager.LoadScene(RobberStart);
		}

		public void DefenderUpstairsButton() 
		{
			PlayerPrefs.SetInt("pCamera", isCameraOn);	
			SceneManager.LoadScene(Upstairs);
		}
	}

}
