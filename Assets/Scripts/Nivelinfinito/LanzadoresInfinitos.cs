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

    [Header("Configuraciones")]
    [TooltipAttribute("Probabilidad de aparición del limón")] [Range(0f, 1f)] public float lemonSpawnChance = 0.1f;
    [TooltipAttribute("Tiempo mínimo entre carne y carne")] public float minTime = 1f;
    [TooltipAttribute("Tiempo máximo entre carne y carne")] public float maxTime = 3f; 

    [Header("Comprobaciones(No tocar)")]
    public GameObject m_ObjetoCreado;
    private Transform m_Spawn;
    public string SpawnSeleccionado;
    public float m_SpawnRotation;
    public float TiempoEntreCarnes;

    public static LanzadoresInfinitos instance;
    private int n_SpawnElegido;
    private int n_SpawnAnterior = -1;
    private int n_CarneElegida;
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
    public void Start()
    {
        //Inicia la corutina que genera un spawn cada X tiempo
        StartCoroutine(SpawnCoroutine());
    }

    public void SpawnSelector()
    {
        int nuevoSpawn;

        //Genera un nuevo spawn que no sea igual al anterior
        do
        {
            nuevoSpawn = Random.Range(1, transform.childCount); //Ajusta el rango según la cantidad de spawns disponibles(Son hijos de éste objeto)
        } while (nuevoSpawn == n_SpawnAnterior);

        n_SpawnElegido = nuevoSpawn;
        n_SpawnAnterior = n_SpawnElegido; //Actualiza el último spawn

        //Asigna la rotación según el spawn elegido
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

        //Obtiene el Transform del spawn seleccionado
        SpawnSeleccionado = this.gameObject.transform.GetChild(n_SpawnElegido).ToString();
        m_Spawn = this.gameObject.transform.GetChild(n_SpawnElegido);
        // Selecciona y lanza carne
        MeatSelector(m_Spawn);
    }

    public void MeatSelector(Transform m_spawn)
    {
        GameObject m_meatClone;

        List<GameObject> Carnes = new List<GameObject>
        {
            m_Chicken, m_Lamb, m_Ribs, m_Sausage, m_Meatball, m_Bone
        };

        //Agrega el limón dependiendo de su probabilidad, si no lanza una carne
        if (Random.value <= lemonSpawnChance)
        {
            m_meatClone = Instantiate(m_Lemon);
        }
        else
        { 
            n_CarneElegida = Random.Range(0, Carnes.Count);
            m_meatClone = Instantiate(Carnes[n_CarneElegida]);
        }


        m_ObjetoCreado = m_meatClone;
        m_meatClone.transform.position = m_spawn.position;
        m_meatClone.GetComponent<Rigidbody>().AddForce(new Vector3(m_SpawnRotation, Random.Range(8, 15), 0), ForceMode.Impulse);
        Debug.Log(Carnes[n_CarneElegida]);
    }


    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            float timeBetweenSpawns = Random.Range(minTime, maxTime); //Tiempo aleatorio entre minTime y maxTime
            TiempoEntreCarnes = timeBetweenSpawns;
            yield return new WaitForSeconds(timeBetweenSpawns); //Espera hasta el siguiente spawn
            SpawnSelector(); //Ejecuta la función SpawnSelector
        }
    }
}
