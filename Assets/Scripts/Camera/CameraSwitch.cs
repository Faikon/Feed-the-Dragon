using Cinemachine;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private Vector3 _landscapeOffset = new Vector3(0, 10f, -5f);
    [SerializeField] private Vector3 _portraitOffset = new Vector3(0, 16f, -6f);

    private CinemachineTransposer _transposer;

    private void Awake()
    {
        _transposer = _virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
    }

    private void Update()
    {
        if (UnityEngine.Device.Application.isMobilePlatform)
        {
            if (UnityEngine.Device.Screen.orientation == ScreenOrientation.Portrait)
            {
                _transposer.m_FollowOffset = _portraitOffset;
            }
            else
            {
                _transposer.m_FollowOffset = _landscapeOffset;
            }
        }
    }
}
