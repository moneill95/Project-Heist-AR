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
	public class ActivateOfficeAlarm : MonoBehaviour,
	ITrackableEventHandler
	{
		public string RobberStart;
		public GameObject Alarm;
		public GameObject Text;
		float DestroyTextOverTime = 5;

		//public GameObject TripAlarm;

		public bool AlarmOn;
		public int isAlarmOn;
		int APDamageAlarm = 2;
		public GameObject TextComponent;

		#region PRIVATE_MEMBER_VARIABLES

		private TrackableBehaviour mTrackableBehaviour;

		#endregion // PRIVATE_MEMBER_VARIABLES



		#region UNTIY_MONOBEHAVIOUR_METHODS

		void Start()
		{
			Alarm.SetActive (false);
			//TripAlarm.SetActive (false);
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
			AlarmOn = true;
			DefenderAPpoints.DecreaseAPpoints (APDamageAlarm);
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


			if (AlarmOn == true) {
				isAlarmOn = 1;
				Alarm.SetActive (true);
				TextComponent.SetActive (true);
				Destroy (TextComponent, DestroyTextOverTime);
			}
				else {
				
					isAlarmOn = 0;
				}
				//TripAlarm.SetActive (true);


			PlayerPrefs.GetInt ("pAlarm", isAlarmOn);
		}

		public void DefenderReadyButton() 
		{
			PlayerPrefs.SetInt("pAlarm", isAlarmOn);	
			SceneManager.LoadScene(RobberStart);

		}
	}
}
