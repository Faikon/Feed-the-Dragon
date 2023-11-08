using Cinemachine;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private float _landscapeFOV = 50;
    [SerializeField] private float _portraitFOV = 80;
        
    //[SerializeField] private Vector3 _landscapeOffset = new Vector3(0, 10f, -5f);
    //[SerializeField] private Vector3 _portraitOffset = new Vector3(0, 16f, -6f);

    private CinemachineTransposer _transposer;

    private void Awake()
    {
        //_transposer = _virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
    }

    private void Update()
    {
        if (UnityEngine.Device.Application.isMobilePlatform)
        {
            if (UnityEngine.Device.Screen.orientation == ScreenOrientation.Portrait)
            {
                _virtualCamera.m_Lens.FieldOfView = _portraitFOV;

                //_transposer.m_FollowOffset = _portraitOffset;
            }
            else
            {
                _virtualCamera.m_Lens.FieldOfView = _landscapeFOV;

                //_transposer.m_FollowOffset = _landscapeOffset;
            }
        }
    }
}
