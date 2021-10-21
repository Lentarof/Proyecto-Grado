using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class DataHandler : MonoBehaviour
{
    private GameObject plant;
    //public GameObject plant;

    //Tendra toda la informacion de cada uno de los botones
    [SerializeField] private ButtonManager buttonPrefab;
    //Contenedor  que tendra esos botones
    [SerializeField] private GameObject buttonContainer;
    //Almacena todos los Items
    [SerializeField] private List<Item> _items;
    //Este sera el nombre de los Items
    [SerializeField] private String label;


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

    private async void Start()
    {
        //Cuando el Juego inicie se llama a los items
        _items = new List<Item>();
        //Para cargar por resource
    //    LoadItems();
        //Esperar por todos los assets
        await Get(label);
        CreateButton();
    }

   /* void LoadItems()
    {
        var items_obj = Resources.LoadAll("Items", typeof(Item));
        foreach (var item in items_obj)
        {
                      //se hace un CAST al item
            _items.Add(item as Item);
        }
    }
    */
    //Crea los botones dinamicamente basado en los Items que tengamos
    void CreateButton()
    {
        //ScriptableObjects hace que la informacion sea persistente mantener toda la informacion de ese item
        //Para cada Item se crea un button
        foreach (Item i in _items)
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
        plant = _items[id].itemPrefab;
    }

    //por lo que es privado el plant
    public GameObject GetPlant()
    {
        return plant;
    }

    //Esta parte trabaja con Addresable
    //Obtener los Assets del cloud
    public async Task Get(String label)
    {
        //Donde queremos cargar los assets
        //los labels son las plantas    antes de que todo este en la lista se mantendra en espera
        var locations = await Addressables.LoadResourceLocationsAsync(label).Task;
        //
        foreach (var location in locations)
        {                                               //Item son los creados previamente en el ScriptableObject
            var obj = await Addressables.LoadAssetAsync<Item>(location).Task;
            _items.Add(obj);
        }
    }

}
