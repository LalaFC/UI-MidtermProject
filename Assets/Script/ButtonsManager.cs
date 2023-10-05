using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class ButtonsManager : MonoBehaviour
{
    public Image imageToScale;
    private bool isZoomOut = false;
    private bool isFadeOut = false;
    private bool isFlipped = false;
    public void Zoom()
    {
        float zoomVal = 0;
        float targetScale = isZoomOut ? 1.0f : zoomVal;
        imageToScale.transform.DOScale(targetScale, 0.25f);
        isZoomOut = !isZoomOut;
    }

    public void Fade()
    {
        float fadeVal = 0;
        float targetScale = isFadeOut ? 1.0f : fadeVal;
        imageToScale.DOFade(targetScale, 1f);
        isFadeOut = !isFadeOut;
    }

    public void Flip()
    {
        float targetVal = isFlipped ? 1f : 0;
        float targetRot = isFlipped ? 0 : transform.rotation.y - 90;
        Sequence seq = DOTween.Sequence();
        seq.Append(imageToScale.transform.DORotate(new Vector3(0, targetRot, 0), 0.25f));
        seq.Join(imageToScale.DOFade(targetVal, 0.25f));
        isFlipped = !isFlipped;
    }

    public void Flash()
    {
        imageToScale.DOFade(0, 0.25f).SetLoops(4, LoopType.Yoyo);
    }

    public void Pulse()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(imageToScale.transform.DOScale(0.9f, 0.4f));
        seq.Join(imageToScale.DOFade(0.9f, 0.20f));
        seq.Append(imageToScale.DOFade(1f, 0.20f));
        seq.Join(imageToScale.transform.DOScale(1f, 0.3f));
    }

    public void Bounce()
    {
        imageToScale.transform.DOShakePosition(1.5f, strength: new Vector3(0, 20, 0), vibrato: 5, randomness: 5, snapping: true, fadeOut: true);
    }
     public void Shake ()
    {
        imageToScale.transform.DOShakePosition(1f, strength: new Vector3(20, 0, 0), 9, 3, false, false);
    }

}
