/******************************************************************************
 * Copyright (C) Leap Motion, Inc. 2011-2017.                                 *
 * Leap Motion proprietary and  confidential.                                 *
 *                                                                            *
 * Use subject to the terms of the Leap Motion SDK Agreement available at     *
 * https://developer.leapmotion.com/sdk_agreement, or another agreement       *
 * between Leap Motion and you, your company or other organization.           *
 ******************************************************************************/

using UnityEngine;
using System.Collections;

namespace Leap.Unity{
  
  /// <summary>
  /// Leap device info struct.
  /// </summary>
  /// <remarks>
  /// Default values are for Leap peripheral.
  /// </remarks>
  public struct LeapDeviceInfo {
    public bool isEmbedded;
    // TODO: Is head mounted
    public float baseline; //(meters) Distance between focal points of cameras
    public float focalPlaneOffset; //(meters) Distance from mount center to focal plane of cameras
    public float horizontalViewAngle; //(degrees) Field of view angle in parallel to baseline axis
    public float verticalViewAngle; //(degrees) Field of view angle perpendicular to baseline axis
    public float trackingRange; //(degrees) Maximum radius for reliable tracking
    public string serialID; //Device alphanumeric unique hardware ID
    
    public static LeapDeviceInfo GetLeapDeviceInfo() {
      LeapDeviceInfo deviceInfo;
      deviceInfo.isEmbedded = false;
      deviceInfo.baseline = 0.04f;
      deviceInfo.focalPlaneOffset = 0.10F;
      deviceInfo.horizontalViewAngle = 2.303835f * Mathf.Rad2Deg;
      deviceInfo.verticalViewAngle = 2.007129f * Mathf.Rad2Deg;
      deviceInfo.trackingRange = 470f / 1000f;
      deviceInfo.serialID = "";

      return deviceInfo;
    }
  }
}