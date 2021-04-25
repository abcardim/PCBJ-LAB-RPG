using System.Collections;
using UnityEngine;

public abstract class Caractere : MonoBehaviour
{
    //public int PontosDano; // versão anterior do valor de "dano"
    //public PontosDano pontosDano; // novo tipo que tem o valor de "dano" do objeto script
    //public int MaxPontosDano; // versão anterior do valor máximo de "dano"
    public float InicioPontosDano; // valor mínimo inicial de "saúde" do Player
    public float MaxPontosDano; // valor máximo permitido de "saúde" do Player

    public abstract void ResetCaractere();

    public virtual IEnumerator FlickerCaractere()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public abstract IEnumerator DanoCaractere(int dano, float intervalo);

    public virtual void KillCaractere()
    {
        Destroy(gameObject);
    }
}
