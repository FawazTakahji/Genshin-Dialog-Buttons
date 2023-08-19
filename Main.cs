using UnityEngine;
using UnityEngine.UI;
using MelonLoader;

namespace Genshin_Dialog_Buttons
{
    public class Main : MelonMod
    {
        GameObject InLevelCutScenePage;
        GameObject GrpSelect;
        private float lastActionTime = 0f;
        public override void OnUpdate()
        {
            if (InLevelCutScenePage == null)
            {
                if (Time.time - lastActionTime > 2f)
                {
                    if (GameObject.Find("Canvas/Pages/InLevelCutScenePage"))
                        InLevelCutScenePage = GameObject.Find("Canvas/Pages/InLevelCutScenePage");
                    lastActionTime = Time.time;
                }
            }
            else
            {
                if (InLevelCutScenePage.active)
                {
                    if (GrpSelect == null)
                    {
                        if (GameObject.Find("Canvas/Dialogs/DialogLayer(Clone)/TalkDialog/GrpTalk/GrpSelect"))
                            GrpSelect = GameObject.Find("Canvas/Dialogs/DialogLayer(Clone)/TalkDialog/GrpTalk/GrpSelect");
                    }
                    else
                    {
                        if (GrpSelect.active)
                        {
                            Transform GrpSelectT = GrpSelect.transform;
                            int childCount = GrpSelectT.childCount;
                            for (int i = 0; i < childCount; i++)
                            {
                                Transform childTransform = GrpSelectT.GetChild(i);
                                GameObject childGameObject = childTransform.gameObject;
                                Transform childGameObjectT = childGameObject.transform;
                                Transform KeyIconTransform = childGameObjectT.Find("KeyIcon");
                                if (KeyIconTransform == null)
                                {
                                    GameObject KeyIcon = new GameObject("KeyIcon");
                                    KeyIcon.transform.SetParent(childGameObject.transform);
                                    char lastChar = childGameObject.name[childGameObject.name.Length - 1];
                                    int index = int.Parse(lastChar.ToString()) + 1;
                                    Text textComponent = KeyIcon.AddComponent<Text>();
                                    textComponent.text = index.ToString();
                                    textComponent.fontSize = 30;
                                    textComponent.color = Color.white;
                                    textComponent.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
                                    textComponent.alignment = TextAnchor.UpperLeft;
                                    textComponent.fontStyle = FontStyle.Bold;
                                    Outline outline = KeyIcon.AddComponent<Outline>();
                                    outline.effectColor = Color.black;
                                    outline.effectDistance = new Vector2(1f, -1f);
                                    RectTransform textRectTransform = textComponent.GetComponent<RectTransform>();
                                    textRectTransform.anchorMin = new Vector2(0f, 0f);
                                    textRectTransform.anchorMax = new Vector2(1f, 1f);
                                    textRectTransform.offsetMin = new Vector2(0f, 0f);
                                    textRectTransform.offsetMax = new Vector2(0f, 0f);
                                    textRectTransform.sizeDelta = childGameObject.GetComponent<RectTransform>().sizeDelta;
                                    KeyIcon.transform.localPosition = new Vector3(215f, -9.5f, 0f);
                                    KeyIcon.transform.localScale = Vector3.one;
                                }
                            }
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.Space))
                        InvokeButton(0);
                    if (Input.GetKeyDown(KeyCode.Alpha1))
                        InvokeButton(0);
                    if (Input.GetKeyDown(KeyCode.Alpha2))
                        InvokeButton(1);
                    if (Input.GetKeyDown(KeyCode.Alpha3))
                        InvokeButton(2);
                    if (Input.GetKeyDown(KeyCode.Alpha4))
                        InvokeButton(3);
                    if (Input.GetKeyDown(KeyCode.Alpha5))
                        InvokeButton(4);
                    if (Input.GetKeyDown(KeyCode.Alpha6))
                        InvokeButton(5);
                    if (Input.GetKeyDown(KeyCode.Alpha7))
                        InvokeButton(6);
                    if (Input.GetKeyDown(KeyCode.Alpha8))
                        InvokeButton(7);
                    if (Input.GetKeyDown(KeyCode.Alpha9))
                        InvokeButton(8);
                }
            }
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            InLevelCutScenePage = null;
            GrpSelect = null;
        }
        void InvokeButton(int index)
        {
            string ButtonName = "Canvas/Dialogs/DialogLayer(Clone)/TalkDialog/GrpTalk/GrpSelect/" + index.ToString();
            if (GrpSelect.active)
            {
                GameObject ButtonO = GameObject.Find(ButtonName);
                var ButtonC = ButtonO.GetComponent<MoleMole.MihoyoButton>();
                GameObject Convo = GameObject.Find("Canvas/Dialogs/DialogLayer(Clone)/TalkDialog/GrpTalk/GrpConversation/TalkGrpConversation_1(Clone)/Content/TxtDesc");
                var ConvoC = Convo.GetComponent<MoleMole.MonoTypewriter>();
                if (ButtonO.active && !ConvoC.JBLCLLOKBDC)
                    ButtonC.onClick.Invoke();
            }
        }
    }
}