using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public abstract class AnnimatedUI : MonoBehaviour, IBeginDragHandler, IDragHandler
{
  public bool show = false;
  public float transitionDuration = 0.2f;

  public void Show()
  {
    show = true;
    OnShow.Invoke();
  }

  public void Hide()
  {
    show = false;
    OnHide.Invoke();
  }

  public void Toogle()
  {
    if (IsShown())
      Hide();
    else
      Show();
  }

  public UnityEvent OnShow;
  public UnityEvent OnHide;

  public abstract bool IsShown();
  public abstract bool IsHidden();

  public void OnBeginDrag(PointerEventData eventData)
  {
    if (show)
    {
      transform.position = eventData.position;

      RectTransform rct = this.GetComponent<RectTransform>();
      float x = (rct.anchoredPosition.x) - eventData.position.x;
      float y =  (rct.anchoredPosition.y) - eventData.position.y;

      print(new Vector2(x,y));
    }

  }

  public void OnDrag(PointerEventData eventData)
  {
    if (show)
    {
      transform.position = eventData.position;
      print((Vector2)this.GetComponent<RectTransform>().anchoredPosition- eventData.position);
    }
  }


}