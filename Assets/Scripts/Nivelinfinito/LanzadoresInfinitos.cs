using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzadoresInfinitos : MonoBehaviour
{
    [Header("Carnes")]
    public GameObject m_Chicken;
    public GameObject m_Lamb;
    public GameObject m_Ribs;
    public GameObject m_Sausage;
    public GameObject m_Meatball;
    public GameObject m_Bone;
    public GameObject m_Lemon;
    [Header("Comprobaciones")]
    public GameObject m_ObjetoCreado;
    private Transform m_Spawn;
    public string SpawnSeleccionado;
    public float m_SpawnRotation;
    private int n_SpawnElegido;
    private int n_SpawnAnterior = -1; // Variable para almacenar el último spawn
    private int n_CarneElegida;

    public static LanzadoresInfinitos instance;
    public float TiempoEntreCarnes;
    public float minTime = 1f; // Tiempo mínimo entre lanzamientos
    public float maxTime = 3f; // Tiempo máximo entre lanzamientos

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void SpawnSelector()
    {
        int nuevoSpawn;

        // Generar un nuevo spawn que no sea igual al anterior
        do
        {
            nuevoSpawn = Random.Range(1, 5); // Ajustar el rango según la cantidad de spawns disponibles
        } while (nuevoSpawn == n_SpawnAnterior);

        n_SpawnElegido = nuevoSpawn;
        n_SpawnAnterior = n_SpawnElegido; // Actualizar el último spawn

        // Asignar la rotación según el spawn elegido
        if (n_SpawnElegido == 1)
        {
            m_SpawnRotation = Random.Range(1f, 2f);
        }
        else if (n_SpawnElegido == 2)
        {
            m_SpawnRotation = Random.Range(0.5f, 1f);
        }
        else if (n_SpawnElegido == 3)
        {
            m_SpawnRotation = Random.Range(0.1f, -0.1f);
        }
        else if (n_SpawnElegido == 4)
        {
            m_SpawnRotation = Random.Range(-0.5f, -1f);
        }
        else if (n_SpawnElegido == 5)
        {
            m_SpawnRotation = Random.Range(-1f, -2f);
        }

        // Obtener el Transform del spawn seleccionado
        SpawnSeleccionado = this.gameObject.transform.GetChild(n_SpawnElegido).ToString();
        m_Spawn = this.gameObject.transform.GetChild(n_SpawnElegido);
        Debug.Log(m_Spawn);

        // Seleccionar y lanzar carne
        MeatSelector(m_Spawn);
    }

    public void MeatSelector(Transform m_spawn)
    {
        n_CarneElegida = Random.Range(0, 7); // Ajustar el rango según la cantidad de carnes
        List<GameObject> Carnes = new List<GameObject> { m_Chicken, m_Lamb, m_Ribs, m_Sausage, m_Meatball, m_Bone, m_Lemon };

        GameObject m_meatClone = Instantiate(Carnes[n_CarneElegida]);
        m_ObjetoCreado = m_meatClone;
        m_meatClone.transform.position = m_spawn.position;
        m_meatClone.GetComponent<Rigidbody>().AddForce(new Vector3(m_SpawnRotation, Random.Range(5, 15), 0), ForceMode.Impulse);
        Debug.Log(Carnes[n_CarneElegida]);
    }

    public void Start()
    {
        // Iniciar la corutina que genera un spawn cada X tiempo
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            float timeBetweenSpawns = Random.Range(minTime, maxTime);// Tiempo aleatorio entre minTime y maxTime
            TiempoEntreCarnes = timeBetweenSpawns;
            yield return new WaitForSeconds(timeBetweenSpawns); // Espera hasta el siguiente spawn
            SpawnSelector(); // Ejecuta la función SpawnSelector
        }
    }
}