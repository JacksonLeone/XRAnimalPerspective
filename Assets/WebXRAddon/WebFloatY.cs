using Zinnia.Action;
using WebXR;
using Unity;

public class WebFloatY : FloatAction
{
    public WebXRController controller;
    private float yAxis;

    // Update is called once per frame
    void Update()
    {
        var vec2 = controller.GetAxis2D(WebXRController.Axis2DTypes.Thumbstick);
        yAxis = vec2.y;
        Receive(yAxis);
    }
}
