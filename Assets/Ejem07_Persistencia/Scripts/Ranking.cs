using UnityEngine;

// Clase estática: no se añade a ningún GameObject.
// Se usa desde cualquier script con Ranking.Metodo(...)
// IMPORTANTE: el fichero debe llamarse Ranking.cs (igual que la clase).
public static class Ranking
{
    public const int TAMANO = 5;

    // Carga el ranking guardado en dos arrays (nombres y puntos)
    public static void Cargar(string[] nombres, int[] puntos)
    {
        for (int i = 0; i < TAMANO; i++)
        {
            // El segundo parámetro es el valor por defecto si la clave no existe
            nombres[i] = PlayerPrefs.GetString("TopNombre" + i, "---");
            puntos[i] = PlayerPrefs.GetInt("TopPuntos" + i, 0);
        }
    }

    // Intenta meter una puntuación nueva en el top 5.
    // Devuelve la posición en la que ha quedado (0 a 4) o -1 si no entra.
    public static int GuardarPuntuacion(string nombre, int puntosNuevos)
    {
        string[] nombres = new string[TAMANO];
        int[] puntos = new int[TAMANO];
        Cargar(nombres, puntos);

        int posicion = -1;

        for (int i = 0; i < TAMANO; i++)
        {
            if (puntosNuevos > puntos[i])
            {
                // Bajamos una posición todo lo que hay por debajo (el último se pierde)
                for (int j = TAMANO - 1; j > i; j--)
                {
                    puntos[j] = puntos[j - 1];
                    nombres[j] = nombres[j - 1];
                }
                // Metemos la nueva puntuación en su hueco
                puntos[i] = puntosNuevos;
                nombres[i] = nombre;
                posicion = i;
                break;   // ya está colocada, salimos
            }
        }

        // Volvemos a guardar las 5 posiciones
        for (int i = 0; i < TAMANO; i++)
        {
            PlayerPrefs.SetString("TopNombre" + i, nombres[i]);
            PlayerPrefs.SetInt("TopPuntos" + i, puntos[i]);
        }

        // Guardamos también la última partida, para mostrarla en la pantalla de ranking
        PlayerPrefs.SetString("UltimoNombre", nombre);
        PlayerPrefs.SetInt("UltimosPuntos", puntosNuevos);
        PlayerPrefs.SetInt("UltimaPosicion", posicion);

        PlayerPrefs.Save();   // fuerza la escritura en disco
        return posicion;
    }

    // Útil para un botón "Borrar récords"
    public static void Borrar()
    {
        for (int i = 0; i < TAMANO; i++)
        {
            PlayerPrefs.DeleteKey("TopNombre" + i);
            PlayerPrefs.DeleteKey("TopPuntos" + i);
        }
        PlayerPrefs.DeleteKey("UltimoNombre");
        PlayerPrefs.DeleteKey("UltimosPuntos");
        PlayerPrefs.DeleteKey("UltimaPosicion");
        PlayerPrefs.Save();
    }
}