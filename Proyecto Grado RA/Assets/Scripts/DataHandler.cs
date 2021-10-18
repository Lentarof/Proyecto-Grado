using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    private GameObject plant;
    //public GameObject plant;

    //Tendra toda la informacion de cada uno de los botones
    [SerializeField] private ButtonManager buttonPrefab;
    //Contenedor  que tendra esos botones
    [SerializeField] private GameObject buttonContainer;
    //Almacena todos los Items
    [SerializeField] private List<Item> items;

    //ID del item 
    private int current_id = 0;

    private static DataHandler instance;

    //Se usa un singleton pattern code por el facil acceso al dato
    public static DataHandler Instance 
    {
        get 
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataHandler>();
            }
            return instance;
        } 
    }

    private void Start()
    {
        LoadItems();
        CreateButton();
    }

    void LoadItems()
    {
        var items_obj = Resources.LoadAll("Items", typeof(Item));
        foreach (var item in items_obj)
        {
                      //se hace un CAST al item
            items.Add(item as Item);
        }
    }

    //Crea los botones dinamicamente basado en los Items que tengamos
    void CreateButton()
    {
        //ScriptableObjects hace que la informacion sea persistente mantener toda la informacion de ese item
        //Para cada Item se crea un button
        foreach (Item i in items)
        {
            //button container tiene todos los botones Rectangle
            ButtonManager b = Instantiate(buttonPrefab, buttonContainer.transform);
            //Determinar el Id del objeto seleccionado
            b.ItemId = current_id;
            b.ButtonTexture = i.itemImage;
            current_id++;
        }
    }
    public void SetPlant (int id)
    {
        plant = items[id].itemPrefab;
    }

    //por lo que es privado el plant
    public GameObject GetPlant()
    {
        return plant;
    }

}
