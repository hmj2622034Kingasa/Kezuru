using UnityEngine;
using UnityEngine.InputSystem;

public class Koritukuruyatu : MonoBehaviour
{
    public GameObject KoriPrefab;
    public Transform spawnPoint;

    public float KoriPerRoation = 20f;
    public float maxKoriPerSecond = 30f;

    private float previouAngle;
    private float KoriCounter;

    void Start()
    {
        previouAngle = GetMouseAngle();
    }

    void Update()
    {
        float currentAngle = GetMouseAngle();

        float angleDifference = 
            Mathf.DeltaAngle(previouAngle, currentAngle);

        previouAngle = currentAngle;

        float rotatationAmount = Mathf.Abs(angleDifference);

        float Koriamount =
            rotatationAmount / 360f * KoriPerRoation;

        Koriamount = Mathf.Min(
            Koriamount,
            maxKoriPerSecond * Time.deltaTime
        );

        KoriCounter += Koriamount;

        while ( KoriCounter >= 1f)
        {
            Instantiate(
                KoriPrefab,
                spawnPoint.position,
                Quaternion.identity
                );

            KoriCounter -= 1f;
        }
    }

    float GetMouseAngle()
    {
        Vector2 center = new Vector2(
            Screen.width / 2f,
            Screen.height / 2f
            );

        Vector2 direction = 
            Mouse.current.position.ReadValue() - center;

        return Mathf.Atan2(
            direction.y,
            direction.x
          ) * Mathf.Rad2Deg;
    }
}
