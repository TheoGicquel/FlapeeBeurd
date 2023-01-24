/**class TouchButtonPlay : MonoBehaviour {
    void  Start() {
        GameState.Instance.resetScorePlayer();

    }

    void update()
    {
        if(input.touchCount>0)
        {
            Touch p = Input.GetTouch(0);
            if(p.phase == TouchPhase.Ended)
            {
                
            }
        }
    }
}**/