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
        "Здравствуйте, здравствуйте. Приятно с вами познакомиться. Чтож, сейчас я выдам вам список заданий, вы должны выполнить его до конца рабочего дня, если возникнут какие-то вопросы, то вы можете задавать их куратору или другим работникам офиса, желаю удачи"
    };

    string[] KurD1 = new string[6]
     {
        "Доброго утра! Приятно познакомиться. Я ваш куратор, Адам. Добро пожаловать к нам на стажировку.",
        "Мы постараемся сделать ваше время здесь интересным и плодотворным.",
        "В нашей компании мы ценим развитие и саморазвитие своих сотрудников. У нас есть опытные специалисты, которые смогут поделиться своими знаниями и помочь вам в этом процессе.",
        "Сегодня мы познакомимся с некоторыми сотрудниками и выполним несколько заданий.",
        "Если у вас возникнут вопросы или потребуется помощь, не стесняйтесь обращаться ко мне или другим членам команды.",
        "Можешь пока осмотреться тут"
     };
    string[] MarkD1 = new string[1]
    {
        "Привет! Добро пожаловать в нашу команду! Мы рады видеть тебя здесь и готовы помочь во всем, что тебе понадобится."
    };
    string[] AmeliaD1 = new string[1]
    {
        "Начало работы всегда бывает сложным, но не переживай, мы все прошли через это. Задавай вопросы, не стесняйся — мы здесь, чтобы поддержать тебя."
    };
    string[] BossD2 = new string[1]
    {
        "Не сейчас"
    };
    string[] KurD2 = new string[9]
    {
        "Ну что, давай не будем медлить и приступим к первому заданию.Давай для начала возьмем этот роутер. Он находится у Марка",
        "Подключение роутера не такая уж сложная работа, но давай я тебе расскажу",
        "Для начала перезапусти роутер, сбоку есть кнопка «Reset», зажми ее на 10 секунд, тогда мы сбросим роутер до заводских настроек",
        "Потом надо подключиться к интернету с помощью aDSL технологии. Тут все просто, берешь телефонный кабель от сплиттера и втыкаешь в DSL порт.",
        "Далее подключаемся к Wi-Fi. Надо проверить, горит ли индикатор беспроводной сети зеленым.",
        "После нажми на Wi-Fi кнопку сбоку, и как только кнопка загорится мы подключимся к беспроводной сети",
        "Потом ещё пароль от вай-фая понадобится. Запиши - 123ASDq",
        "После со своего компьютера зайдёшь в браузер и вобьёшь в адресной строке IP-адрес: 192.168.1.1.",
        "Там введёшь пароль который записал"
    };
    string[] MarkD2 = new string[2]
    {
        "Я рад бы поболтать, но у меня скоро дедлайн, я очень занят. Вот роутер",
        "Только я уже пытался настроить его, но че то у меня совсем нет времени"
    };
    string[] AmeliaD2 = new string[1]
    {
        "Блин, когда закончится рабочий день?(( Сколько это может продожаться?"
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
