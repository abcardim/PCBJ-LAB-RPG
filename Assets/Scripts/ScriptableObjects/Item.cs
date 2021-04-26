﻿using UnityEngine;

[CreateAssetMenu(menuName = "Item")]

public class Item : ScriptableObject
{
    public string nomeObjeto;
    public Sprite sprite;
    public int quantidade;
    public bool empilhavel;

    public enum TipoItem
    {
        MOEDA,
        HEALTH,
        CHAVE,
        DIAMANTE,
        COGUMELO,
        PAGINA
    }

    public TipoItem tipoItem;
}
