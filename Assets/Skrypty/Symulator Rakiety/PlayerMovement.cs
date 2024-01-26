using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 5f;

    float shipBoundaryX = 8.2f; // Ograniczenie na osi X

    void Start()
    {
        // Ustawienie gracza na dolnej części ekranu na starcie
        Vector3 initialPosition = new Vector3(0f, -Camera.main.orthographicSize + 0.5f, 0f);
        transform.position = initialPosition;
    }

    void Update()
    {
        // RUCH statku
        Vector3 pos = transform.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float newX = pos.x + horizontalInput * maxSpeed * Time.deltaTime;

        // Obliczenie nowej pozycji gracza tylko wzdłuż osi X z uwzględnieniem ograniczenia
        newX = Mathf.Clamp(newX, -shipBoundaryX, shipBoundaryX);

        // Aktualizacja pozycji gracza
        pos.x = newX;
        transform.position = pos;
    }
}
