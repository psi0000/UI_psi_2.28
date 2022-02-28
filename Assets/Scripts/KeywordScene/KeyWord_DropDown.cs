using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class KeyWord_DropDown : MonoBehaviour
{
   
    /*   public Text Text;
       public Text Text1;
       public Text Text2;
       public Text Text3;
       public Text Text4; */
    // Start is called before the first frame update
    void Start()
    {
        var dropdown = transform.GetComponent<TMP_Dropdown>();

        dropdown.options.Clear();

        List<string> items = new List<string>();
        items.Add("Music");
        items.Add("Picrue");
        items.Add("Movie");
        items.Add("Cap");
        items.Add("Happy");
        items.Add("Crossfit");

        foreach (var item in items)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData() { text = item });
        }



        // NextBtn(dropdown);


    }
}




 /*   public void NextBtn(Dropdown dropdown)
    {

        if (btnclick == 0)
        {
            Text.text = "주제를 선택해주세요^^";
            btnclick = 1;
        }
        else if (btnclick == 1)
        {
            int index = dropdown.value;
            Text1.text = dropdown.options[index].text;
            btnclick = 2;
            cancelnumber = 1;
        }
        else if (btnclick == 2)
        {
            int index = dropdown.value;
            Text2.text = dropdown.options[index].text;
            btnclick = 3;
            cancelnumber = 2;
        }
        else if (btnclick == 3)
        {
            int index = dropdown.value;
            Text3.text = dropdown.options[index].text;
            btnclick = 4;
            cancelnumber = 3;
        }
        else if (btnclick == 4)
        {
            int index = dropdown.value;
            Text4.text = dropdown.options[index].text;
            btnclick = 5;
            cancelnumber = 4;
        }
        else
        {
            Load3();
        }
    }

    public void CancelBtn()
    {

        if (cancelclick)
        {
            if (cancelnumber == 1)
            {
                Debug.Log("1번 주제 바껴야함");
                Text1.text = "1번 주제";
                cancelclick = false;
            }
            else if (cancelnumber == 2)
            {
                Debug.Log("2번 주제 바껴야함");
                Text2.text = "2번 주제";
                cancelclick = false;
            }
            else if (cancelnumber == 3)
            {

                Text3.text = "3번 주제";
                cancelclick = false;
            }
            else if (cancelnumber == 4)
            {
                Text4.text = "4번 주제";
                cancelclick = false;
            }
            else
            {
                Text.text = "초기화 할까요?^^";
                cancelclick = false;
            }

        }
        else
        {
            cancelclick = true;
            btnclick -= 1;
        }
    }

    private void Load3()
    {
        SceneManager.LoadScene(1);
    }
}
 */