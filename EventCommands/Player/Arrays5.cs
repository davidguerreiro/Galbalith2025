using System;
using UnityEngine;


public class Arrays5 : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int numX = 1;
        int numY = 5;

        // FuntionNoRetornaNada();

        // y = FunctionQueRetornaInt();

        int resultado = Sumar(numX, numY, 20);

        Debug.Log(resultado);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EjercicioArray()
    {
        float[] numeros = new float[10];
        float suma = 0f;
        float media = 0f;

        numeros = ConstruirListaNumeros(numeros.Length);

        suma = Suma(numeros);

        media = CalcularMedia(suma, numeros.Length);

        foreach (float numero in numeros)
        {
            if (numero > media)
            {
                Console.WriteLine(numero);
            }
        }
    }

    public float[] ConstruirListaNumeros(int length)
    {
        float[] numeros = new float[length];

        for (int i = 0; i < numeros.Length; i++)
        {
            Console.WriteLine("Escribe un numero");
            numeros[i] = float.Parse(Console.ReadLine());
        }

        return numeros;
    }

    public float Suma(float[] numeros)
    {
        float suma = 0;

        foreach (float numero in numeros)
        {
            suma += numero;
        }

        return suma;
    }

    public float CalcularMedia(float suma, int cantidadNumeros)
    {
        return suma / cantidadNumeros;
    }


    public void FuntionNoRetornaNada()
    {
        int x = 0;

        x = 2 + 2;
        Debug.Log(x);
    }

    public int FunctionQueRetornaInt()
    {
        int x = 0;

        x = 2 + 2 + 1;

        return x;
    }

    public int Sumar(int x, int y, int z = 0)
    {
        int resultado = x + y + z;

        return resultado;
    }
}
