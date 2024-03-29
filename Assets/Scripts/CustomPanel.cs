public class CustomPanel
{
    public void SetActive(bool val)
    {
        this.selectIcon.sprite = UIManager.GaragePage.carCustomize.sp[(!val) ? 0 : 1];
        base.gameObject.SetActive(val);
    }

    public Image selectIcon;
}