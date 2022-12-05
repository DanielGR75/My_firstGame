using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Movement_Player : MonoBehaviour
{
    public Slider Fuel_bar;
    public Rigidbody Rb;

    //Basic Movement
    public float vel = 50;
    public float sal = 10;

    //Advance Movement
    public float maxgas = 2;
    public float boost = 10;
    public float recharge_rate = 1;
    private float gas1;
    
    //Validation
    public LayerMask ground;  
    private bool Check_isgrounded;
    private bool check_jump = false;


     // Start is called before the first frame update

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        gas1 = maxgas;
        Fuel_bar.value = gas1;
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject player = GameObject.Find("Player");
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Has muerto, vuelve a empezar");
            player.transform.position = new Vector3(-41.1f, 0f, -37.8f);
        }
        if (collision.gameObject.name == "Premio")
        {
            Debug.Log("HAS GANADO!!!");
            SceneManager.LoadScene("SampleScene");
        }
    }


    // Update is called once per frame
    void Update()
    {

        Check_isgrounded = Physics.CheckSphere(transform.position, 0.52f, ground);
        //Debug.Log(Time.deltaTime + " seg");
        float Mov_hor = Input.GetAxis("Horizontal");
        float Mov_vert = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(Mov_hor, 0.0f, Mov_vert);
        Rb.AddForce(movimiento * vel);

        //Salta si pulsa barra espaciadora
        if (Input.GetButtonDown("Jump") && check_jump == false)
        {
            check_jump = true;
            Rb.AddForce(Vector3.up * sal);
        }
            //Chequeo de un solo salto
            if (Check_isgrounded == true)
            {
                check_jump = false;
            }
            else
            {
                check_jump = true;
            }

        //Jetpack
        if ((Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.Keypad1)) && gas1 > 0)
        {
            Rb.AddForce(Vector3.up * boost, ForceMode.Impulse);
            gas1 -= Time.deltaTime;
            Debug.Log("Gas: " + gas1 + " un");
            Fuel_bar.value = gas1;
        }
        else if (Check_isgrounded == true && gas1 < maxgas)
        {
            gas1 += Time.deltaTime * recharge_rate;
            Debug.Log("Gas: " + gas1 + " un");
            Fuel_bar.value = gas1;
        }


        /* MOVIMIENTO POR TRASLACIONES
        //Cuando pulse w o flecha arriba mover verticalmente hacia adelante
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward*vel*Time.deltaTime);
        }
        //Cuando pulse w o flecha arriba mover verticalmente hacia atras
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back*vel*Time.deltaTime);
        }
            //Cuando pulse a o flecha arriba mover a la izquierda
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left*vel*Time.deltaTime);
        }
        //Cuando pulse d o flecha arriba mover verticalmente
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right*vel*Time.deltaTime);
        }*/
    }

}
