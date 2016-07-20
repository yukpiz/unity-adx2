using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class EventController : MonoBehaviour {
    private string cueSheetName = "CueSheet_0";
    private string cueName = "tw012";
    private CriAtomSource bgm;

    public void Awake()
    {
        bgm = gameObject.AddComponent<CriAtomSource>();
        bgm.cueSheet = cueSheetName;

        Button startButton = transform.FindChild("StartButton").GetComponent<Button>();
        Button stopButton = transform.FindChild("StopButton").GetComponent<Button>();
        startButton.onClick.AsObservable()
            .Subscribe(_ =>
            {
                if (bgm.IsPaused())
                {
                    bgm.Pause(false);
                } else
                {
                    Debug.Log("play!!");
                    bgm.Play(cueName);
                }
            });
        stopButton.onClick.AsObservable()
            .Subscribe(_ =>
            {
                if (!bgm.IsPaused())
                {
                    bgm.Pause(true);
                }
            });
    }
}
