using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    [Header("=== 추적 대상 ===")]
    [Tooltip("카메라가 따라갈 플레이어(타겟)")]
    [SerializeField] private Transform target;

    [Tooltip("타겟으로부터 카메라의 오프셋(상대 위치)")]
    [SerializeField] private Vector3 offset = new Vector3(0f, 5f, -8f);

    [Header("=== SmoothDamp 설정 ===")]
    [Tooltip("위치 보간 부드러움 정도 (초, 작을수록 빠름)")]
    [Range(0.01f, 1f)]
    [SerializeField] private float positionSmoothTime = 0.3f;

    [Tooltip("회전 보간 속도 (높을수록 빠르게 회전)")]
    [Range(1f, 20f)]
    [SerializeField] private float rotationSmoothSpeed = 5f;

    private Vector3 positionVelocity = Vector3.zero;

    // Update is called once per frame
    void LateUpdate()
    {
        var targetRotation = Quaternion.LookRotation((target.position - transform.position).normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothSpeed * Time.deltaTime);

        transform.position = Vector3.SmoothDamp(transform.position, target.position + target.rotation * offset, ref positionVelocity, positionSmoothTime);
    }
}
