using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;

public class dialg : MonoBehaviour
{

    string[] BossD1 = new string[1]
    {
        "������������, ������������. ������� � ���� �������������. ����, ������ � ����� ��� ������ �������, �� ������ ��������� ��� �� ����� �������� ���, ���� ��������� �����-�� �������, �� �� ������ �������� �� �������� ��� ������ ���������� �����, ����� �����"
    };

    string[] KurD1 = new string[6]
     {
        "������� ����! ������� �������������. � ��� �������, ����. ����� ���������� � ��� �� ����������.",
        "�� ����������� ������� ���� ����� ����� ���������� � ������������.",
        "� ����� �������� �� ����� �������� � ������������ ����� �����������. � ��� ���� ������� �����������, ������� ������ ���������� ������ �������� � ������ ��� � ���� ��������.",
        "������� �� ������������ � ���������� ������������ � �������� ��������� �������.",
        "���� � ��� ��������� ������� ��� ����������� ������, �� ����������� ���������� �� ��� ��� ������ ������ �������.",
        "������ ���� ����������� ���"
     };
    string[] MarkD1 = new string[1]
    {
        "������! ����� ���������� � ���� �������! �� ���� ������ ���� ����� � ������ ������ �� ����, ��� ���� �����������."
    };
    string[] AmeliaD1 = new string[1]
    {
        "������ ������ ������ ������ �������, �� �� ���������, �� ��� ������ ����� ���. ������� �������, �� ��������� � �� �����, ����� ���������� ����."
    };
    string[] BossD2 = new string[1]
    {
        "�� ������"
    };
    string[] KurD2 = new string[9]
    {
        "�� ���, ����� �� ����� ������� � ��������� � ������� �������.����� ��� ������ ������� ���� ������. �� ��������� � �����",
        "����������� ������� �� ����� �� ������� ������, �� ����� � ���� ��������",
        "��� ������ ����������� ������, ����� ���� ������ �Reset�, ����� �� �� 10 ������, ����� �� ������� ������ �� ��������� ��������",
        "����� ���� ������������ � ��������� � ������� aDSL ����������. ��� ��� ������, ������ ���������� ������ �� ��������� � �������� � DSL ����.",
        "����� ������������ � Wi-Fi. ���� ���������, ����� �� ��������� ������������ ���� �������.",
        "����� ����� �� Wi-Fi ������ �����, � ��� ������ ������ ��������� �� ����������� � ������������ ����",
        "����� ��� ������ �� ���-��� �����������. ������ - 123ASDq",
        "����� �� ������ ���������� ������ � ������� � ������� � �������� ������ IP-�����: 192.168.1.1.",
        "��� ������ ������ ������� �������"
    };
    string[] MarkD2 = new string[2]
    {
        "� ��� �� ���������, �� � ���� ����� �������, � ����� �����. ��� ������",
        "������ � ��� ������� ��������� ���, �� �� �� � ���� ������ ��� �������"
    };
    string[] AmeliaD2 = new string[1]
    {
        "����, ����� ���������� ������� ����?(( ������� ��� ����� �����������?"
    };
    [SerializeField]
    GameObject dial;
    [SerializeField]
    GameObject sce1;
    [SerializeField]
    GameObject sce2;
    [SerializeField]
    GameObject sce3;

    public TMP_Text Pod1;
    public TMP_Text Pod2;

    public TMP_Text Name;
    public TMP_Text text;
    public int level;

    private bool[] op= new bool[4];
    private string name;
    private bool _insideCollisionN;
    private bool _insideCollisionM;
    private bool _insideCollisionF;
    public List<string> dialog = new List<string>();
    public int score = 0;

    void Start()
    {
        Effects.FadeScreen(Color.black, 1, 0, 1);
        dial.SetActive(false);
        Pod1.gameObject.SetActive(false);
        Pod2.gameObject.SetActive(false);
        sce1.SetActive(false);
        sce2.SetActive(false);
        sce3.SetActive(false);      
        _insideCollisionN = false;
        _insideCollisionM = false;
        _insideCollisionN = false;
    }


    void Update()
    {
        Name.text = name;
        if (_insideCollisionN && Input.GetKeyDown(KeyCode.E) && dial.active == false)
        {

            DialOn();
            if(name == "Boss" && level == 1)
            {
                foreach(string s in BossD1) dialog.Add(s);
                op[0] = true;
            }
            if (name == "Adam" && level == 1)
            {
                foreach (string s in KurD1) dialog.Add(s);
                op[1] = true;
            }
            if (name == "Mark" && level == 1)
            {
                foreach (string s in MarkD1) dialog.Add(s);
                op[2] = true;
            }
            if (name == "Amelia" && level == 1)
            {
                foreach (string s in AmeliaD1) dialog.Add(s);
                op[3] = true;
            }
            if (name == "Boss" && level == 2)
            {
                foreach (string s in BossD2) dialog.Add(s);
            }
            if (name == "Adam" && level == 2)
            {
                foreach (string s in KurD2) dialog.Add(s);
                Pod1.gameObject.SetActive(true);
                Pod2.gameObject.SetActive(true);
            }
            if (name == "Mark" && level == 2)
            {
                foreach (string s in MarkD2) dialog.Add(s);
            }
            if (name == "Amelia" && level == 2)
            {
                foreach (string s in AmeliaD2) dialog.Add(s);
            }
        }
        if (dial.active == true)
        {
            if(Input.GetKeyDown(KeyCode.E) && dialog.Count>score)
            {
                text.text = dialog[score];
                score++;
            }
            else if(Input.GetKeyDown(KeyCode.E) && dialog.Count == score)
            {
                dialog.Clear();
                score = 0;
                DialOff();
            }
        }

        if (_insideCollisionM && name=="Router" && Input.GetKeyDown(KeyCode.E))
        {
            Effects.FadeScreen(Color.black, 0, 1, 1, () => SceneManager.LoadScene(3));
        }
        if (_insideCollisionM && name == "Comp" && Input.GetKeyDown(KeyCode.E))
        {
            sce1.SetActive(true);
            Time.timeScale = 0;
        }
        int i = 0;
        foreach (bool p in op)
        {        
            if (p) i++;
            if (i==4 && _insideCollisionF) Effects.FadeScreen(Color.black, 0, 1, 1, () => SceneManager.LoadScene(2)); ;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        name = other.gameObject.name;
        if (other.gameObject.tag == "NPS")
        {
            _insideCollisionN = true;
        }
        else if(other.gameObject.tag == "MINI")
        {
            _insideCollisionM = true;
        }
        else if (other.gameObject.tag == "Finish")
        {
            _insideCollisionF = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        name = "non";
        _insideCollisionN = false;
        _insideCollisionM = false;
        _insideCollisionF = false;
    }

    public void DialOn()
    {
        dial.SetActive(true);
        Time.timeScale = 0;
    }

    public void DialOff()
    {
        dial.SetActive(false);
        Time.timeScale = 1;
    }
}
