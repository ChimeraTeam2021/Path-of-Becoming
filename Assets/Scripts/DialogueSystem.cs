using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] Text output;
    [SerializeField] Text nameOutput;
    [SerializeField] Text choice1Text;
    [SerializeField] Text choice2Text;
    [SerializeField] GameObject choiceNextTrigger;
    [SerializeField] GameObject controlButtons;
    [SerializeField] PlayerController PC;
    [SerializeField] Animator panelAnim;
    [SerializeField] Animator choosePanelAnim;

    public string[] file;
    private int whereIsEndChoose;
    private int choice1;
    private int choice2;
    private string subPlayer = "player";
    private string subFairy = "fairy";
    private string subImp = "imp";
    private string subCat = "cat";
    private string subAnonim = "anonym";
    private string subStranger = "stranger";
    private string subChoice = "choice";
    bool dialogueStarted;
    Queue<string> linesTriggered = new Queue<string>();
    private void Awake()
    {
        dialogueStarted = false;      
        TextAsset language = Resources.Load<TextAsset>("Russian2");
        file = language.text.Split('\n');     
    }
    private void Update()
    {
        if(dialogueStarted && Input.GetKeyDown(KeyCode.A))
        {
            DisplayNextLine();
        }
    }
    public void ChooseStart(int choose1, int choose2,int endOfChoices,GameObject nextTrigger)
    {
        controlButtons.SetActive(false);
        PC.OnButtonUp();
        choice1Text.text = file[choose1].Substring(file[choose1].IndexOf('=') + 1); ;
        choice2Text.text = file[choose2].Substring(file[choose2].IndexOf('=') + 1); ;
        choosePanelAnim.SetBool("PanelShow", true);
        whereIsEndChoose = endOfChoices;
        choice1 = choose1;
        choice2 = choose2;
        choiceNextTrigger = nextTrigger;
    }
    public void OnChoice1Click()
    {
        choosePanelAnim.SetBool("PanelShow", false);       
        StartDialogue(choice1, choice2, choiceNextTrigger);
    }
    public void OnChoice2Click()
    {
        choosePanelAnim.SetBool("PanelShow", false);
        StartDialogue(choice2, whereIsEndChoose, choiceNextTrigger);
    }
    public void StartDialogue(int startLine, int endLine, GameObject nextTrigger)
    {
        choiceNextTrigger = nextTrigger;
        panelAnim.SetBool("PanelShow", true);
        dialogueStarted = true;
        controlButtons.SetActive(false);
        PC.OnButtonUp();
        for (int i = startLine; i < endLine; i++)
        {
            linesTriggered.Enqueue(file[i]);
        }
        DisplayNextLine();
    }
    public void DisplayNextLine()
    {
        if(linesTriggered.Count == 0)
        {
            EndDialogue();
            return;
        }
        string line = linesTriggered.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeLine(line));
    }

    IEnumerator TypeLine(string sentence)
    {
        if(sentence.Contains(subPlayer))
        {
            nameOutput.text = "Генри";
            output.color = new Color(0, 0,255);
        }
        else if (sentence.Contains(subFairy))
        {
            nameOutput.text = "Лилия";
            output.color = new Color(250, 0, 250);
        }
        else if (sentence.Contains(subImp))
        {
            nameOutput.text = "Анчутка";
            output.color = new Color(255, 100, 0);
        }
        else if(sentence.Contains(subCat))
        {
            nameOutput.text = "Кот";
            output.color = new Color(0,0,0);
        }
        else if(sentence.Contains(subAnonim))
        {
            nameOutput.text = "???";
            output.color = new Color(60, 60, 60);
        }
        else if(sentence.Contains(subStranger))
        {
            nameOutput.text = "???";
            output.color = new Color(60, 60, 60);
        }

        string result = sentence.Substring(sentence.IndexOf('=') + 1);
        sentence = result.Trim();
        output.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            yield return new WaitForSecondsRealtime(0.06f);
            output.text += letter;
        }
    }   
    public void EndDialogue()
    {
        choiceNextTrigger.SetActive(true);
        panelAnim.SetBool("PanelShow", false) ;
        dialogueStarted = false;
        controlButtons.SetActive(true);
    }
}