using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private Menu[] Menus;

    private string currentMenu = "MainMenu";
    private void Start()
    {
        OpenMenu(Menus[0]);
    }

    public void OpenMenu(Menu menu)
    {
        for (int i = 0; i < Menus.Length; i++)
        {
            if (Menus[i].GetIsOpened == true)
            {
                CloseMenu(Menus[i]);
            }
        }
        menu.Open();
    }

    public void OpenMenu(string menuName)
    {
        //Debug.Log("Open menu: " + menuName);

        currentMenu = menuName;

        for (int i = 0; i < Menus.Length; i++)
        {
            if (Menus[i].GetMenuName == menuName)
            {
                Menus[i].Open();
            }
            else if (Menus[i].GetIsOpened == true)
            {
                CloseMenu(Menus[i]);
            }
        }
    }

    public void CloseMenu(Menu menu)
    {
        menu.Close();
    }

    public string GetCurrentMenu()
    {
        return currentMenu;
    }
}