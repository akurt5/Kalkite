using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class PrefabSpacingControl : MonoBehaviour
{
    [Range(0.5f, 5)]
    public float Spacing = 1.5f;
    public GameObject[,] Prefabs = new GameObject[7, 7];
    GameObject[] RootObjects = new GameObject[50];
    public int X, Z = 0;

    public bool Reset = false;
    void Update()
    {
        /*if (IsInvoking("Arrange"))
        {
            CancelInvoke("Arrange");
            Invoke("Arrange", 2f);
        }*/
    }

    void Awake()
    {
        if (Application.isPlaying)
        {
            if(RootObjects == null)
            {
                RootObjects = gameObject.scene.GetRootGameObjects();

            }
            foreach (GameObject g in RootObjects)
            {
                if ((g != null) && (g != gameObject) && (g != Camera.main.gameObject))
                {
                    
                    foreach (Component c in g.GetComponents(typeof(Component))as Component[])
                    {
                        //c. = false;
                    }
                }
            }
        }
    }

    void Arrange()
    {
        RootObjects = gameObject.scene.GetRootGameObjects();
        List<GameObject> AllObjects = new List<GameObject>(RootObjects);

        if (AllObjects.Count > 2)
        {
            foreach (GameObject g in AllObjects)
            {
                if ((g != gameObject) && (g != Camera.main.gameObject))
                {
                    for (int x = 0; x < 7; x++)
                    {
                        for (int y = 0; y < 7; y++)
                        {
                            if (Prefabs[x, y] == g)
                            {
                                break;
                            }
                        }
                    }
                    Prefabs[X, Z] = g;
                    g.transform.position = new Vector3(Spacing * X, 0, Spacing * Z);
                    if (X < 6)
                    {
                        X++;
                    }
                    else if ((Z > 5) && (X < 6))
                    {
                        Debug.Log("Too Many Prefabs");
                    }
                    else
                    {
                        X = 0;
                        Z++;

                    }
                }
            }
        }
    }

    void OnValidate()
    {
        if (Reset)
        {
            ResetValues();
            Reset = false;
        }
    }

    void ResetValues()
    {
        Prefabs = new GameObject[7, 7];
        RootObjects = new GameObject[50];
        X = Z = 0;
        Arrange();
    }
}
