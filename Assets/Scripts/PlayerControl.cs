using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D _rigidBody; //necesitamos esta variable para guardar el rigid body y usarlo
    private float _inputHorizontal; //variable donde miraremos el valor del input horizontal 
    public float playerSpeed = 4.5f; //variable que necesitamos para saber la velocidad del personaje
    public float jumpForce = 10;
    private GrowndSensor _growndSensor;

    void Awake() //en el awake llenamos la variable de rigidbody y la de Grownd sensor mediante get component in children
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _growndSensor = GetComponentInChildren<GrowndSensor>();
    }
    
    void Update() 
    {
        _inputHorizontal = Input.GetAxisRaw("Horizontal"); //en el update comprobamos con el Input.GetAxisRaw si se esta pulsando la tecla

        if(_inputHorizontal > 0) //este if comprueba si el input horizontal es mayor que 0 para saber si mira a la derecha
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); //esto fija la rotacion del personaje en 0,0,0, es decir mirando a la derecha (transforma los quaternions a angulos normales de unity)
        }
        else if(_inputHorizontal < 0) //este if comprueba si el input horizontal es menor que 0 para saber si mira a la izquierda
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); //esto fija la rotacion de el personaje cambiando la y a 180 para mirar a la izquierda (transforma los quaternions a angulos normales de unity)
        }

        if(Input.GetButtonDown("Jump") && _growndSensor._EstaEnElSuelo == true) //con este if controlamos si el boton de salto esta pulsado y si se puede saltar con el grownd sensor
        {
            Jump(); //llama la funcion de jump :33
        }
    }

    void FixedUpdate() //en el fixed update siempre se ponen fisicas
    {
        _rigidBody.velocity = new Vector2(_inputHorizontal * playerSpeed, _rigidBody.velocity.y); //esto añade velocidad mediante un vector 2 en el eje X
    }

    void Jump() //con esta funcion añadimos una fuerza hacia arriba y multiplicado con la fuerza de salto, seguidmaente pasamos el tipo de fuerza que queremos añadir
    {
        _rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
