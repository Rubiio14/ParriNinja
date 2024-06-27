using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este script es una Interfaz nos permitirá crear en otras clases un comportamiento diferenciado según el objeto que se corte
/// Se utilizará para simplificar el código de Cuchillo.cs que tiene muchos if else y no es la mejor solución posible.
/// Esto nos permitirá crear objetos cortables sin necesidad de modificar más el cuchillo.
/// Desde que un objeto que se corte contega el componente SlizableItem, se podrá cortar y llamar a 
/// GetComponent<SlizableItem>().Slice().

/// </summary>
public interface SlizableItem
{
    void Slice();
}

