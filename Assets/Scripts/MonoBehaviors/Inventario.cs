using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventario : MonoBehaviour
{
    public GameObject slotPrefab; // objeto que recebe o prefab Slot
    public const int numSlots = 5; // número fixo de slots
    Image[] itemImagens = new Image[numSlots]; // array de imagens
    Item[] items = new Item[numSlots]; // array de itens
    GameObject[] slots = new GameObject[numSlots]; // array de slots
    bool venceu = false; // testa a condicao de vitoria

    // Start is called before the first frame update
    void Start()
    {
        CriarSlot();
    }

    private void Update()
    {
        for (int i=0; i<items.Length; i++)
        {
            if (items[i].tipoItem == Item.TipoItem.MOEDA && items[i].quantidade == 3)
            {
                venceu = true;
            }
        }
        if(items.Length == 5 && venceu == true)
        {
            if(SceneManager.GetActiveScene().name == "Lab5_RPGSetup") SceneManager.LoadScene("Intermission");
            if(SceneManager.GetActiveScene().name == "Lab5_RPGSetup2") SceneManager.LoadScene("Win_Game");
        }
    }

    public void CriarSlot()
    {
        if (slotPrefab != null)
        {
            for (int i = 0; i < numSlots; i++)
            {
                GameObject novoSlot = Instantiate(slotPrefab);
                novoSlot.name = "ItemSlot_" + i;
                novoSlot.transform.SetParent(gameObject.transform.GetChild(0).transform);
                slots[i] = novoSlot;
                itemImagens[i] = novoSlot.transform.GetChild(1).GetComponent<Image>();
            }
        }
    }

    public bool AddItem(Item itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null && items[i].tipoItem == itemToAdd.tipoItem && itemToAdd.empilhavel)
            {
                items[i].quantidade++;
                Slot slotScript = slots[i].gameObject.GetComponent<Slot>();
                Text quantidadeTexto = slotScript.qtdTexto;
                quantidadeTexto.enabled = true;
                quantidadeTexto.text = items[i].quantidade.ToString();
                return true;
            }

            if (items[i] == null)
            {
                items[i] = Instantiate(itemToAdd);
                items[i].quantidade = 1;
                itemImagens[i].sprite = itemToAdd.sprite;
                itemImagens[i].enabled = true;
                return true;
            }
        }

        return false;
    }
}
