using UnityEngine;

public class LogicaPJ : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator anim;
    public float x, y;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>(); // Asigna el componente Animator si no está asignado
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener las entradas de movimiento del usuario (teclas WASD o las flechas)
        x = Input.GetAxis("Horizontal"); // Movimiento lateral (A/D o flechas izquierda/derecha)
        y = Input.GetAxis("Vertical");   // Movimiento hacia adelante/atrás (W/S o flechas arriba/abajo)

        // Movimiento del personaje en el espacio 3D
        Vector3 direccionMovimiento = new Vector3(x, 0, y); // Solo afectamos el movimiento en X y Z
        transform.Translate(direccionMovimiento * velocidadMovimiento * Time.deltaTime, Space.World);

        // Rotación del personaje en la dirección del movimiento
        if (direccionMovimiento.magnitude > 0)
        {
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccionMovimiento);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacionObjetivo, velocidadRotacion * Time.deltaTime);
        }

        // Opcional: Añadir animaciones si tienes un Animator configurado
        if (anim != null)
        {
            anim.SetFloat("VelX", x); // Asignar la velocidad en el eje X
            anim.SetFloat("VelY", y); // Asignar la velocidad en el eje Y
        }
    }
}
