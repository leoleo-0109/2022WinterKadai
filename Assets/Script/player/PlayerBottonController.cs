using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class PlayerBottonController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerShotController playerShotController;
    [SerializeField] private PlayerInputController playerInputController;

    [SerializeField] private Button buttonUp;
    [SerializeField] private Button buttonDown;
    [SerializeField] private Button buttonLeft;
    [SerializeField] private Button buttonRight;
    private CompositeDisposable Disposable = new CompositeDisposable();

    private void GetInputButton()
    {
        buttonUp.OnClickAsObservable()
            .Subscribe(_ =>
            {
                playerController.Move();
                Debug.Log("up");
                playerInputController.OnMove(new Vector2(0f, 1f));
                playerShotController.SetPlayerPos(transform.position);
                playerController.ScreenOut();
            }).AddTo(Disposable);
        buttonUp.OnPointerUpAsObservable()
            .Subscribe(_ =>
            {
                playerController.Move();
                playerInputController.OnMove(new Vector2(0f, 0f));
                playerShotController.SetPlayerPos(transform.position);
                playerController.ScreenOut();
            }).AddTo(Disposable);
        buttonDown.OnClickAsObservable()
            .Subscribe(_ =>
            {
                playerController.Move();
                Debug.Log("down");
                playerInputController.OnMove(new Vector2(0f, -1f));
                playerShotController.SetPlayerPos(transform.position);
                playerController.ScreenOut();
            }).AddTo(Disposable);
        buttonLeft.OnClickAsObservable()
            .Subscribe(_ =>
            {
                playerController.Move();
                Debug.Log("lift");
                playerInputController.OnMove(new Vector2(-1f, 0f));
                playerShotController.SetPlayerPos(transform.position);
                playerController.ScreenOut();
            }).AddTo(Disposable);
        buttonRight.OnClickAsObservable()
            .Subscribe(_ =>
            {
                playerController.Move();
                Debug.Log("right");
                playerInputController.OnMove(new Vector2(1f, 0f));
                playerShotController.SetPlayerPos(transform.position);
                playerController.ScreenOut();
            }).AddTo(Disposable);

    }

    private void Start()
    {
        GetInputButton();
    }
}