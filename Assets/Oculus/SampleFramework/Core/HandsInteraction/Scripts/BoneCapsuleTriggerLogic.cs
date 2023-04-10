/*
 * Copyright (c) Meta Platforms, Inc. and affiliates.
 * All rights reserved.
 *
 * Licensed under the Oculus SDK License Agreement (the "License");
 * you may not use the Oculus SDK except in compliance with the License,
 * which is provided at the time of installation or download, or which
 * otherwise accompanies this software in either electronic or hard copy form.
 *
 * You may obtain a copy of the License at
 *
 * https://developer.oculus.com/licenses/oculussdk/
 *
 * Unless required by applicable law or agreed to in writing, the Oculus SDK
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */


using System.Collections.Generic;
using UnityEngine;
using Bhaptics.SDK2;

namespace OculusSampleFramework
{
	/// <summary>
	/// Allows a bone to keep track of interactables that it has touched. This information
	/// can be used by a tool.
	/// </summary>
	public class BoneCapsuleTriggerLogic : MonoBehaviour
	{
		public InteractableToolTags ToolTags;

		public HashSet<ColliderZone> CollidersTouchingUs = new HashSet<ColliderZone>();
		private List<ColliderZone> _elementsToCleanUp = new List<ColliderZone>();

		private string _name;

        private void Start()
        {

			_name = gameObject.name;
        }

        /// <summary>
        /// If we get disabled, clear our colliders. Otherwise, on trigger exit may not get called.
        /// </summary>
        private void OnDisable()
		{
			CollidersTouchingUs.Clear();
		}

		private void Update()
		{
			CleanUpDeadColliders();
		}

		private void AddHaptics()
        {
			BhapticsLibrary.PlayGlove(
		positionType: PositionType.GloveR,
		motorValues: new int[6] { 0, 80, 0, 0, 0, 0},
		playTimeValues: new GlovePlayTime[6] {
						  GlovePlayTime.None,
						  GlovePlayTime.TwentyMS,
						  GlovePlayTime.None, 
						  GlovePlayTime.None, 
			              GlovePlayTime.None, 
					      GlovePlayTime.None},
		shapeValues: new GloveShapeValue[6] { 0, GloveShapeValue.LinearIncrease, 0, 0, 0, 0});
		}

		private void OnTriggerEnter(Collider other)
		{
			var triggerZone = other.GetComponent<ButtonTriggerZone>();
			if (triggerZone != null && (triggerZone.ParentInteractable.ValidToolTagsMask & (int)ToolTags) != 0)
			{
				CollidersTouchingUs.Add(triggerZone);

				// triggers haptics
				switch (name)
				{
					case "Hand_Thumb3_CapsuleRigidbody":
						BhapticsLibrary.PlayGlove(
		positionType: PositionType.GloveR,
		motorValues: new int[6] { 80, 0, 0, 0, 0, 0 },
		playTimeValues: new GlovePlayTime[6] {
						  GlovePlayTime.TwentyMS,
						  GlovePlayTime.None,
						  GlovePlayTime.None,
						  GlovePlayTime.None,
						  GlovePlayTime.None,
						  GlovePlayTime.None},
		shapeValues: new GloveShapeValue[6] { GloveShapeValue.LinearIncrease, 0, 0, 0, 0, 0 });
						break;
					case "Hand_Index3_CapsuleRigidbody":
						BhapticsLibrary.PlayGlove(
		positionType: PositionType.GloveR,
		motorValues: new int[6] { 0, 80, 0, 0, 0, 0 },
		playTimeValues: new GlovePlayTime[6] {
						  GlovePlayTime.None,
						  GlovePlayTime.TwentyMS,
						  GlovePlayTime.None,
						  GlovePlayTime.None,
						  GlovePlayTime.None,
						  GlovePlayTime.None},
		shapeValues: new GloveShapeValue[6] { 0, GloveShapeValue.LinearIncrease, 0, 0, 0, 0 });
						break;
					case "Hand_Middle3_CapsuleRigidbody":
						BhapticsLibrary.PlayGlove(
		positionType: PositionType.GloveR,
		motorValues: new int[6] { 0, 0, 80, 0, 0, 0 },
		playTimeValues: new GlovePlayTime[6] {
						  GlovePlayTime.None,
						  0,
						  GlovePlayTime.TwentyMS,
						  0,
						  GlovePlayTime.None,
						  GlovePlayTime.None},
		shapeValues: new GloveShapeValue[6] { 0, 0, GloveShapeValue.LinearIncrease, 0, 0, 0 });
						break;
					case "Hand_Ring3_CapsuleRigidbody":
						BhapticsLibrary.PlayGlove(
		positionType: PositionType.GloveR,
		motorValues: new int[6] { 0, 0, 0, 80, 0, 0 },
		playTimeValues: new GlovePlayTime[6] {
						  GlovePlayTime.None,
						  0,
						  0,
						  GlovePlayTime.TwentyMS,
						  0,
						  GlovePlayTime.None},
		shapeValues: new GloveShapeValue[6] { 0, 0, 0, GloveShapeValue.LinearIncrease, 0, 0 });
						break;
					case "Hand_Pinky3_CapsuleRigidbody":
						BhapticsLibrary.PlayGlove(
		positionType: PositionType.GloveR,
		motorValues: new int[6] { 0, 0, 0, 0, 80, 0 },
		playTimeValues: new GlovePlayTime[6] {
						  GlovePlayTime.None,
						  0,
						  0,
						  0,
						  GlovePlayTime.TwentyMS,
						  GlovePlayTime.None},
		shapeValues: new GloveShapeValue[6] { 0, 0, 0, 0, GloveShapeValue.LinearIncrease, 0 });
						break;
					default:
						break;
				}
			}
		}

		private void OnTriggerExit(Collider other)
		{
			var triggerZone = other.GetComponent<ButtonTriggerZone>();
			if (triggerZone != null && (triggerZone.ParentInteractable.ValidToolTagsMask & (int)ToolTags) != 0)
			{
				CollidersTouchingUs.Remove(triggerZone);
			}
		}

		/// <summary>
		/// Sometimes colliders get disabled and trigger exit doesn't get called.
		/// Take care of that edge case.
		/// </summary>
		private void CleanUpDeadColliders()
		{
			_elementsToCleanUp.Clear();
			foreach (ColliderZone colliderTouching in CollidersTouchingUs)
			{
				if (!colliderTouching.Collider.gameObject.activeInHierarchy)
				{
					_elementsToCleanUp.Add(colliderTouching);
				}
			}

			foreach (ColliderZone colliderZone in _elementsToCleanUp)
			{
				CollidersTouchingUs.Remove(colliderZone);
			}
		}
	}
}
