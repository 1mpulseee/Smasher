using UnityEngine;
public class Test : MonoBehaviour
{
    bool isGyroEnabled;
    Gyroscope gyroscope;
    Quaternion rot;
    private void Awake()
    {
        isGyroEnabled = EnabledGyro();
    }
    private void Update()
    {
        if (isGyroEnabled)
        {
            transform.localRotation = gyroscope.attitude * rot;
        }
    }
    bool EnabledGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyroscope = Input.gyro;
            gyroscope.enabled = true;
            rot = new Quaternion(0, 0, 1, 0);
            return true;
        }
        else { return false; }
    }
}
