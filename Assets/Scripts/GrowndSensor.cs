using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowndSensor : MonoBehaviour
{
    public bool _EstaEnElSuelo; //booleana de si esta en el suelo para saber si puede saltar o no

    void OnTriggerEnter2D(Collider2D collider) //en esta funcion necesitas un trigger(BoxCollider2D con el is tigger marcado) pq sino no funciona
    {
        if(collider.gameObject.layer == 3) //hace que detecte si el esta pisando suelo o otra cosa mediante un layer creado en unity
        {
            _EstaEnElSuelo = true; //pone la variable de EstaEnElSuelo a ture
        }
    }

    void OnTriggerStay2D(Collider2D collider)  //en esta funcion hacemos que cuando el trigger se quede colisionando siga siendo posible saltar
    {
        if(collider.gameObject.layer == 3) //hace que detecte si el esta pisando suelo o otra cosa mediante un layer creado en unity
        {
            _EstaEnElSuelo = true; //pone la variable de EstaEnElSuelo a ture
        }
    }

    void OnTriggerExit2D(Collider2D collider) //en esta funcion hacemos que cuando el trigger sale de la colision ya no se puede saltar
    {
        _EstaEnElSuelo = false; //pone la variable de EstaEnElSuelo a false
    }
}
