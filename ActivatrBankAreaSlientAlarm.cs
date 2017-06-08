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
	public class ActivatrBankAreaSlientAlarm : MonoBehaviour,
	ITrackableEventHandler
	{

		public GameObject SlientAlarm;
		public GameObject Text;
		public bool SlientAlarmOn;
		public int isSlientAlarmOn;
		int APDamageSlientAlarm = 5;
		public string RobberStart;
		float DestroyTextOverTime = 5;
		public GameObject TextComponent;

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

			SlientAlarm.SetActive (false);
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

			SlientAlarmOn = true; // decreses ap points from total 
			DefenderAPpoints.DecreaseAPpoints (APDamageSlientAlarm);
			print ("Slient Alarm Active");
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

		void Update(){

			if (SlientAlarmOn == true) {  // sets SlientAlarmOn to 1 so that is reconigse in robberstart scene
				isSlientAlarmOn = 1;
				SlientAlarm.SetActive (true);
				TextComponent.SetActive (true);
				Destroy (TextComponent, DestroyTextOverTime);
			}

			else {

				isSlientAlarmOn = 0;
			}

			PlayerPrefs.GetInt ("pBankAreaSlientAlarm", isSlientAlarmOn);

		}

		public void DefenderReadyButton() 
		{
			PlayerPrefs.SetInt("pBankAreaSlientAlarm", isSlientAlarmOn);	
			SceneManager.LoadScene(RobberStart);
		}


	}
}
