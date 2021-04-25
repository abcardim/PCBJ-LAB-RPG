using System.Collections;
using UnityEngine;

public class Player : Caractere
{
    public Inventario inventarioPrefab; // referência ao objeto prefab criado do Inventário
    Inventario inventario;

    public HealthBar healthBarPrefab; // referência ao objeto prefab criado da HealthBar
    HealthBar healthBar;

    public PontosDano pontosDano; // novo tipo que tem o valor da "saúde" do objeto script

    private void Start()
    {
        inventario = Instantiate(inventarioPrefab);

        pontosDano.valor = InicioPontosDano;
        healthBar = Instantiate(healthBarPrefab);
        healthBar.caractere = this;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coletavel"))
        {
            Item danoObjeto = collision.gameObject.GetComponent<Consumable>().item;
            if (danoObjeto != null)
            {
                bool deveDesaparecer = false;
                //print("Acertou: " + danoObjeto.nomeObjeto);

                switch (danoObjeto.tipoItem)
                {
                    case Item.TipoItem.MOEDA:
                        //deveDesaparecer = true;
                        deveDesaparecer = inventario.AddItem(danoObjeto);
                        break;
                    case Item.TipoItem.HEALTH:
                        deveDesaparecer = AjustarPontosDano(danoObjeto.quantidade);
                        break;
                    default:
                        break;
                }

                if (deveDesaparecer)
                {
                    collision.gameObject.SetActive(false);
                }
            }
        }
    }

    public override IEnumerator DanoCaractere(int dano, float intervalo)
    {
        while (true)
        {
            StartCoroutine(FlickerCaractere());

            pontosDano.valor -= dano;

            if (pontosDano.valor <= float.Epsilon)
            {
                KillCaractere();
                break;
            }

            if (intervalo > float.Epsilon)
            {
                yield return new WaitForSeconds(intervalo);
            }
            else
            {
                break;
            }
        }
    }

    public override void KillCaractere()
    {
        base.KillCaractere();
        Destroy(healthBar.gameObject);
        Destroy(inventario.gameObject);
    }

    public override void ResetCaractere()
    {
        inventario = Instantiate(inventarioPrefab);
        healthBar = Instantiate(healthBarPrefab);
        healthBar.caractere = this;
        pontosDano.valor = InicioPontosDano;
    }

    public bool AjustarPontosDano(int quantidade)
    {
        if (pontosDano.valor < MaxPontosDano)
        {
            pontosDano.valor += quantidade;
            print("Ajustando Pontos de Dano por: " + quantidade + ". Novo valor: " + pontosDano.valor);
            return true;
        }
        else
        {
            return false;
        }
    }
}
