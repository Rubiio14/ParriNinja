using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este script es una Interfaz nos permitir� crear en otras clases un comportamiento diferenciado seg�n el objeto que se corte
/// Se utilizar� para simplificar el c�digo de Cuchillo.cs que tiene muchos if else y no es la mejor soluci�n posible.
/// Esto nos permitir� crear objetos cortables sin necesidad de modificar m�s el cuchillo.
/// Desde que un objeto que se corte contega el componente SlizableItem, se podr� cortar y llamar a 
/// GetComponent<SlizableItem>().Slice().

/// </summary>
public interface SlizableItem
{
    void Slice();
}

