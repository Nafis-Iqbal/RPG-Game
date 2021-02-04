using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    void Awake()
    {
        instance = this;
    }
    
    
    
    
    [System.Serializable]
    public class Choice{
        public int next;
        [TextArea]
        public string dialogue;
    }
    
    [System.Serializable]
    public class Dialogue
    {
        [HideInInspector]
        public bool isDelevered = false;
        
        public int next;
        public string name;
        [TextArea]
        public string dialogue;
        public Choice[] choice;
    }
    
    [System.Serializable]
    public class Conversations
    {
        public Dialogue[] dialogue;
    }

    [System.Serializable]
    public class Character
    {
        public string name;
        public Sprite sprite;
    }
    
    public Conversations[] conversations;
    public Character[] characters;
    public Dictionary<string, Sprite> nameToImage = new Dictionary<string, Sprite>();
    public Sprite[] choiceImage = new Sprite[4];

    //UI Items
    public GameObject dialoguePanel;
    public Image speakerImage;
    public Text dialogueText;
    public GameObject choicePanel;


    //Prefabs
    public Button choiceButtonPrefab;
    public Button nextButtonPrefab;


    //Private Items
    private UnityAction[] onClickChoice = new UnityAction[4];
    private int i; //next Dialogue Index
    private Dialogue currentDialogue;
    private GridLayoutGroup choicePanelGridLayoutGroup;
    private Button nextButton;
    private Button[] choiceButton = new Button[4];
    
    //For Testing
    private bool buttonClicked = false;
    public Button button;
    

    
    void Start()
    {
        Initialize();
    }

    public void OnClickButton()
    {
        StartCoroutine(StartConversations(0));
    }

    public IEnumerator StartConversations(int conversationIndex)
    {
        dialoguePanel.SetActive(true);
        Conversations conversation = conversations[conversationIndex];
        Debug.Log("Conversation Started : " + Time.time);

        i=0;
        //yield return null;
        while(true)
        {
            if(i>=conversation.dialogue.Length) break;

            Debug.Log("Dialogue "+i.ToString()+" Started : " + Time.time);
            currentDialogue = conversation.dialogue[i];
            
            buttonClicked = false;
            speakerImage.sprite = nameToImage[currentDialogue.name];
            dialogueText.text = currentDialogue.dialogue;
            
            if(currentDialogue.choice.Length != 0)
            {
                choicePanelGridLayoutGroup.cellSize = new Vector2(1200.0f, 100.0f);
                choicePanelGridLayoutGroup.spacing = new Vector2(100.0f, 40.0f);
                choicePanelGridLayoutGroup.childAlignment = TextAnchor.MiddleLeft;
                
                for(int j=0; j<currentDialogue.choice.Length; j++)
                {
                    choiceButton[j] = Instantiate(choiceButtonPrefab, choicePanel.transform);
                    choiceButton[j].onClick.AddListener(onClickChoice[j]);
                    choiceButton[j].GetComponentInChildren<Text>().text = currentDialogue.choice[j].dialogue;
                    choiceButton[j].transform.GetChild(1).gameObject.GetComponent<Image>().sprite = choiceImage[j];
                    yield return null;
                }
            }
            else
            {
                choicePanelGridLayoutGroup.cellSize = new Vector2(290.0f, 100.0f);
                choicePanelGridLayoutGroup.spacing = new Vector2(100.0f, 40.0f);
                choicePanelGridLayoutGroup.childAlignment = TextAnchor.LowerRight;

                nextButton = Instantiate(nextButtonPrefab, choicePanel.transform);
                nextButton.onClick.AddListener(OnClickNextButton);
            }
            while(!buttonClicked)
            {
                yield return null;
            }

            Debug.Log("Dialogue "+i.ToString()+" Finished : " + Time.time);
            yield return null;
        }
        
        Debug.Log("Conversation Finished: " + Time.time);
        dialoguePanel.SetActive(false);
        yield return null;
    }
    
    public void OnClickNextButton()
    {
        Destroy(nextButton.gameObject);
        i = currentDialogue.next;
        buttonClicked = true;
    }
    public void OnClickChoiceAButton()
    {
        DestroyAllChoiceButton();
        i = currentDialogue.choice[0].next;
        buttonClicked = true;
    }
    public void OnClickChoiceBButton()
    {
        DestroyAllChoiceButton();
        i = currentDialogue.choice[1].next;
        buttonClicked = true;
    }
    public void OnClickChoiceCButton()
    {
        DestroyAllChoiceButton();
        i = currentDialogue.choice[2].next;
        buttonClicked = true;
    }
    public void OnClickChoiceDButton()
    {
        DestroyAllChoiceButton();
        i = currentDialogue.choice[3].next;
        buttonClicked = true;
    }

    private void DestroyAllChoiceButton()
    {
        for(int i=0; i<4; i++)
        {
            if(choiceButton[i] != null) Destroy(choiceButton[i].gameObject);
        }
    }

    private void Initialize()
    {
        for(int i=0; i<characters.Length; i++)
        {
            nameToImage.Add(characters[i].name, characters[i].sprite);
        }

        onClickChoice[0]+=OnClickChoiceAButton;
        onClickChoice[1]+=OnClickChoiceBButton;
        onClickChoice[2]+=OnClickChoiceCButton;
        onClickChoice[3]+=OnClickChoiceDButton;
        choicePanelGridLayoutGroup = choicePanel.GetComponent<GridLayoutGroup>();
    }
    
}
