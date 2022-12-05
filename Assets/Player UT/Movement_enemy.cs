using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_enemy : MonoBehaviour
{
    //Definicion de objetos
    public Rigidbody Rbe;
    public GameObject target;

    //Definicion de variables
    public float vel = 30f;
    private float sal = 30;
    private float cronometro = 0;
    private int rutina;
    

    // Start is called before the first frame update
    void Start()
    {
        Rbe.AddForce(Vector3.up * sal);
        target = GameObject.Find("Player");
    }

    public void comportamiento()
    {
        float Mov_hor1 = 200;
        float Mov_vert1 = 200;
        float Mov_hor2 = -200;
        float Mov_vert2 = -200;
        float angulo = Random.Range(30, 50);
        Vector3 movimiento1 = new Vector3(Mov_hor1, 0.0f, Mov_vert1);
        Vector3 movimiento2 = new Vector3(Mov_hor2, 0.0f, Mov_vert2);
        //Rbe.AddForce(movimiento1 * vel);


        cronometro += 1 * Time.deltaTime;
        if (Vector3.Distance(transform.position, target.transform.position) > 10)
        {
            if (cronometro >= 5)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }

            switch (rutina)
            {
                case 0:
                    Rbe.AddForce(movimiento1 * vel * Time.deltaTime);
                    break;
                case 1:
                    Rbe.AddForce(movimiento2 * vel * Time.deltaTime);
                    break;
                case 2:
                    Rbe.AddForce(movimiento2 * vel * Time.deltaTime);
                    break;

            }
        }
        else
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
            transform.Translate(Vector3.forward * 8f * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        comportamiento();
    }
}
